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

namespace FFMPEG_Video_Conveter
{
    public partial class Form1 : Form
    {

        private string Input_File;
        private string Output_File;

        private string FFMPEG_String;
        private string FFMPEG_i;
        private string FULL_CMD;

        private string[] FileNames;

        private string FileExtension;
        private string FileNameRAW;
        private string FileDirectory;

        FolderBrowserDialog outputBrowser = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
        }

        public void Main()
        {
            //setStrs();
            //getFileName();

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

        private void setStrs()
        {
            FFMPEG_i = "/C ffmpeg -i ";
            FFMPEG_String = " -c:v hevc_nvenc -preset slow -x265-params pass=2 -crf 17 ";
        }

        private string GenerateOutput(string Input_File)
        {
            FileExtension = Path.GetExtension(Input_File);
            FileNameRAW = Path.GetFileNameWithoutExtension(Input_File);
            FileDirectory = Path.GetDirectoryName(Input_File);

            FileExtension = Select_Extension.SelectedItem.ToString();

            if (Output_Directory_Box.Text != "") { FileDirectory = outputBrowser.SelectedPath; }

            string New_File = FileDirectory + "\\" + FileNameRAW + " HEVC" + FileExtension;
            
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

                    CMD_Output_Box.Text += FULL_CMD;
                }
            }

        }

        private void ConvertFiles()
        {

            System.Diagnostics.Process StartCMD = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal/*Normal or Hidden*/;
            //startInfo.RedirectStandardInput = true;
            //startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = FULL_CMD;
            //startInfo.Arguments = "/C ipconfig";
            StartCMD.StartInfo = startInfo;
            StartCMD.Start();
            //StartCMD.StandardInput.Flush();
            //StartCMD.StandardInput.Close();
            //StartCMD.WaitForExit();


            //System.Diagnostics.Process StartCMD = new System.Diagnostics.Process();
            //StartCMD.StartInfo.FileName = "cmd.exe";
            //StartCMD.StartInfo.CreateNoWindow = true;
            //StartCMD.Start();
            //StartCMD.StandardInput.WriteLine("ipconfig");
            //StartCMD.StandardInput.Flush();
            //StartCMD.StandardInput.Close();
            //StartCMD.WaitForExit();

        }

        private void Generate_Button_Click(object sender, EventArgs e)
        {
            setStrs();
            generateCMD();
            //CMD_Output_Box.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConvertFiles();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileExtension = Select_Extension.SelectedItem.ToString();
            CMD_Output_Box.Text += FileExtension + Environment.NewLine;
        }

        private void CMD_Output_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Browse_Output_Button_Click(object sender, EventArgs e)
        {

            if (FileDirectory != null) { outputBrowser.SelectedPath = FileDirectory; }

            //InitialDirectory
            //FolderBrowserDialog


            if (outputBrowser.ShowDialog() == DialogResult.OK)
            {
                Output_Directory_Box.Text = outputBrowser.SelectedPath;

                //outputBrowser.SelectedPath = FileDirectory;
                //FileDirectory = outputBrowser.SelectedPath;
            }
        }
    }
}
