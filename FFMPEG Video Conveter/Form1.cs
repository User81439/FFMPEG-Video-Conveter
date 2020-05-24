using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// TODO:
///   need progress displayed somewhere?
///   organise and clean up code
///   
///     
/// find out why Select_Extension (Form1.Designer) keeps removing index..;
///     this.Select_Extension.SelectedIndex = 0;
///     
/// find out why FFMPEG_String sometimes isnt set
///     
/// delete dragged in files
/// 
/// END TODO

namespace FFMPEG_Video_Conveter
{
    public partial class Form1 : Form
    {

        private string Input_File;
        private string Output_File;

        private string FFMPEG_String = " -c:v hevc_nvenc -preset slow -x265-params pass=2 -crf 17 ";
        private string FFMPEG_i = "/C ffmpeg -i ";
        private string FULL_CMD;

        private string[] FileNames;
        //private string[] ;

        List<string> FFMPEG_CMD = new List<string>();

        private string FileExtension;
        private string FileNameRAW;
        private string FileDirectory;
        private string FileConvertedID;

        FolderBrowserDialog outputBrowser = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
        }

        public void Main()
        {

        }

        private void listBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            FileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;

            for (i = 0; i < FileNames.Length; i++)
            {
                File_Input.Items.Add(FileNames[i]);
                //Console.WriteLine(FileNames[i]); //testing
            }
        }

        private string GenerateOutput(string Input_File)
        {
            FileExtension = Path.GetExtension(Input_File);
            FileNameRAW = Path.GetFileNameWithoutExtension(Input_File);
            FileDirectory = Path.GetDirectoryName(Input_File);
            FileConvertedID = " HEVC";

            FileExtension = Select_Extension.SelectedItem.ToString();

            if (Output_Directory_Box.Text != "") { FileDirectory = outputBrowser.SelectedPath; }

            string New_File = FileDirectory + "\\" + FileNameRAW + FileConvertedID + FileExtension;
            
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

                for (int i = 0; i < FileNames.Length; i++)
                {
                    Input_File = FileNames[i];

                    Output_File = GenerateOutput(Input_File);

                    FULL_CMD = FFMPEG_i + "\"" + Input_File + "\"" + FFMPEG_String + "\"" + Output_File + "\"" + Environment.NewLine
                        /*might need to remove for cmd; seems to be fine...*/;

                    FFMPEG_CMD.Add(FULL_CMD);

                    CMD_Output_Box.Text += FFMPEG_CMD[i].ToString();

                }
            }

        }

        private void ConvertFiles(string FFMPEG_Script)
        {
            System.Diagnostics.Process StartCMD = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal/*Normal or Hidden*/;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = FFMPEG_Script;
            StartCMD.StartInfo = startInfo;
            StartCMD.Start();
            StartCMD.WaitForExit();

        }

        private void Generate_Button_Click(object sender, EventArgs e)
        {
            CMD_Output_Box.Clear();
            FFMPEG_String = FFMPEG_Script_Box.Text;
            generateCMD();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CMD_Output_Box.Clear();
            int i = 0;
            int CalcPer = 0;
            Conversion_Progress.Value = 0;


            foreach (string element in FFMPEG_CMD)
            {
                ConvertFiles(element);
                ++i;

                CalcPer = (int)(0.5f + ((100f * i) / FFMPEG_CMD.Count()));

                Conversion_Progress.Maximum = 100;
                Conversion_Progress.Value = CalcPer;

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileExtension = Select_Extension.SelectedItem.ToString();
            CMD_Output_Box.Text += FileExtension + Environment.NewLine;
        }

        private void Browse_Output_Button_Click(object sender, EventArgs e)
        {
            if (FileDirectory != null) { outputBrowser.SelectedPath = FileDirectory; }

            if (outputBrowser.ShowDialog() == DialogResult.OK)
            {
                Output_Directory_Box.Text = outputBrowser.SelectedPath;
            }
        }

        private void Load_FFMPEG_Button_Click(object sender, EventArgs e)
        {
            FFMPEG_Script_Box.Text = FFMPEG_String;
        }
    }
}
