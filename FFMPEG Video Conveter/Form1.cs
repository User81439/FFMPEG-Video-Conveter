﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Dialogs;


/// TODO:
///   organise and clean up code | -> convert to OO
///  
/// delete dragged in files
/// 
/// WORKING FUNCTIONALLY, UX KIND OF SHITTY
/// added ffmpeg.exe to debug > bin should work for testing, not sure if that will work on proper build...
/// 
/// this.Script_Select_Box.SelectedIndex = 0;
/// 
/// install ffmpeg to C and set up envirnoment variable? C:\ffmpeg\bin
/// END TODO

namespace FFMPEG_Video_Conveter
{
    public partial class Form1 : Form
    {
        private string Input_File;
        private string Output_File;

        private string FFMPEG_String; //= " -map_metadata -1 -c:v hevc_nvenc -preset slow -x265-params pass=2 -crf 17 ";
        //C:\\Users\\Hamish\\source\\repos\\FFMPEG Video Conveter\\FFMPEG Video Conveter\\FFMPEG\\bin\\ffmpeg.exe
        private string FFMPEG_i = "/C ffmpeg -i ";
        private string FULL_CMD;

        private string[] FileNames;

        List<string> FFMPEG_CMD = new List<string>();

        private string FileExtension;
        private string FileNameRAW;
        private string FileDirectory;
        private string FileConvertedSuffix = " HEVC";
        private string FileConvertedPrefix = "example ";

        //FolderBrowserDialog outputBrowser = new FolderBrowserDialog();
        CommonOpenFileDialog outputBrowser = new CommonOpenFileDialog();


        public Form1()
        {
            InitializeComponent();
            Script_Select_Box.SelectedIndex = 0;
            Select_Extension.SelectedIndex = 0;

        }

        public void Main()
        {

        }

        private void listBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Select_Extension.SelectedIndex = 0; //sets default container, if not set crashes
            File_Input.Items.Clear();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;

            //add set FileDirectory here to browse in file location before hitting generate
        }

        private void listBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            FileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;

            for (i = 0; i < FileNames.Length; i++)
            {
                File_Input.Items.Add(FileNames[i]);
            }
        }

        private string GenerateOutput(string Input_File)
        {
            FileExtension = Path.GetExtension(Input_File);
            FileNameRAW = Path.GetFileNameWithoutExtension(Input_File);
            FileDirectory = Path.GetDirectoryName(Input_File);

            SetFileVariables();

            string New_File = FileDirectory + "\\" + FileConvertedPrefix + FileNameRAW + FileConvertedSuffix + FileExtension;
            
            return New_File;
        }

        private void generateCMD()
        {
            if (FileNames == null)
            {
                string message = "Please Add Some Video Files";
                string title = "Error";
                MessageBox.Show(message, title);
            }

            else
            {
                FFMPEG_CMD.Clear();
                for (int i = 0; i < FileNames.Length; i++)
                {
                    Input_File = FileNames[i];

                    Output_File = GenerateOutput(Input_File);

                    FULL_CMD = FFMPEG_i + "\"" + Input_File + "\"" + FFMPEG_String + "\"" + Output_File + "\""; //+ Environment.NewLine
                        /*might need to remove for cmd; seems to be fine...*/

                    FFMPEG_CMD.Add(FULL_CMD);

                    CMD_Output_Box.Text += FFMPEG_CMD[i].ToString();

                }

                Convert_Button.Visible = true;
            }

        }
        #region set variables
        private void SetFileVariables()
        {
            FileExtension = Select_Extension.SelectedItem.ToString();

            if (Script_Select_Box.Visible == true) { FFMPEG_String = Script_Select_Box.SelectedItem.ToString(); } //gets default string from dropdown
            else if (FFMPEG_Script_Box.Visible == true) { FFMPEG_String = FFMPEG_Script_Box.Text; } //gets custom script from text box

            if (Output_Directory_Box.Text != "") { FileDirectory = outputBrowser.FileName; } //get different output directory

            if (Prefix_CheckBox.Checked) { Suffix_TextBox.Visible = true;  FileConvertedPrefix = Prefix_TextBox.Text; } else { FileConvertedPrefix = ""; } //get file prefix

            if (Suffix_CheckBox.Checked) { FileConvertedSuffix = Suffix_TextBox.Text; } else { FileConvertedSuffix = ""; } //get file suffix
        }
        #endregion

        private void ConvertFiles(string FFMPEG_Script)
        {
            Process StartCMD = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal/*Normal or Hidden*/;
            startInfo.FileName = "cmd.exe";

            //startInfo.WorkingDirectory = @"C:\"; //how to

            StartCMD.StartInfo = startInfo;

            startInfo.Arguments = FFMPEG_Script;
            StartCMD.Start();
            StartCMD.WaitForExit();
        }

        private void Generate_Button_Click(object sender, EventArgs e)
        {
            CMD_Output_Box.Clear();
            
            generateCMD();

        }

        private void Convert_Button_Click(object sender, EventArgs e)
        {
            if (Input_File == Output_File)
            {
                string message = "Please change file name or path";
                string title = "Error";
                MessageBox.Show(message, title);


                //DialogResult dialogResult = MessageBox.Show("Do you want to overwrite the current file?", "Error", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    ConvertSetup();
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    generateCMD();
                //}

            }

            else { ConvertSetup(); }

        }

        private void ConvertSetup() //used to initiallise progress bar
        {
            int i = 0;
            int CalcPer = 0;
            Conversion_Progress.Value = 0;

            foreach (string element in FFMPEG_CMD)
            {
                ConvertFiles(element); //converts files
                ++i;

                CalcPer = (int)(0.5f + ((100f * i) / FFMPEG_CMD.Count()));

                Conversion_Progress.Maximum = 100;
                Conversion_Progress.Value = CalcPer;
            }
        }

        #region select output folder
        private void Browse_Output_Button_Click(object sender, EventArgs e)
        {
            outputBrowser.InitialDirectory = FileDirectory;
            outputBrowser.IsFolderPicker = true;
            outputBrowser.Title = "Select Output Folder";

            if (outputBrowser.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Output_Directory_Box.Text = outputBrowser.FileName;
            }

        }
        #endregion

        /// sets and gets suffix | not OO
        #region suffix
        private void Suffix_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Suffix_CheckBox.Checked == true)
            {
                Suffix_TextBox.Visible = true;
                Suffix_TextBox.Text = FileConvertedSuffix;
            }

            if (Suffix_CheckBox.Checked == false)
            {
                Suffix_TextBox.Visible = false;
                FileConvertedSuffix = "";
            }

        }
        #endregion

        /// sets and gets prefix | not OO
        #region prefix
        private void Prefix_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Prefix_CheckBox.Checked == true)
            {
                Prefix_TextBox.Visible = true;
                Prefix_TextBox.Text = FileConvertedPrefix;
            }

            if (Prefix_CheckBox.Checked == false)
            {
                Prefix_TextBox.Visible = false;
                FileConvertedPrefix = "";
            }

        }
        #endregion 

        /// gets script and/or sets custom script | not OO
        #region custom script check
        private void Script_Custom_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Script_Custom_Check.Checked == true)
            {
                FFMPEG_Script_Box.Visible = true;
                Script_Select_Box.Visible = false;

                FFMPEG_Script_Box.Text = Script_Select_Box.SelectedItem.ToString();

            }

            if (Script_Custom_Check.Checked == false)
            {
                FFMPEG_Script_Box.Visible = false;
                Script_Select_Box.Visible = true;

                FFMPEG_String = Script_Select_Box.SelectedItem.ToString();
            }
        }
        #endregion
    }
}
