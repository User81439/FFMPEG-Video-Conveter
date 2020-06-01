using System.Windows.Forms;

namespace FFMPEG_Video_Conveter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.File_Input = new System.Windows.Forms.ListBox();
            this.CMD_Output_Box = new System.Windows.Forms.TextBox();
            this.Generate_Button = new System.Windows.Forms.Button();
            this.Convert_Button = new System.Windows.Forms.Button();
            this.Select_Extension = new System.Windows.Forms.ComboBox();
            this.Drag_Files_Label = new System.Windows.Forms.Label();
            this.Extension_Label = new System.Windows.Forms.Label();
            this.CMD_Label = new System.Windows.Forms.Label();
            this.Output_Directory_Label = new System.Windows.Forms.Label();
            this.Output_Directory_Box = new System.Windows.Forms.TextBox();
            this.Browse_Output_Button = new System.Windows.Forms.Button();
            this.Load_FFMPEG_Label = new System.Windows.Forms.Label();
            this.FFMPEG_Script_Box = new System.Windows.Forms.TextBox();
            this.Conversion_Progress = new System.Windows.Forms.ProgressBar();
            this.Suffix_CheckBox = new System.Windows.Forms.CheckBox();
            this.Prefix_CheckBox = new System.Windows.Forms.CheckBox();
            this.Suffix_TextBox = new System.Windows.Forms.TextBox();
            this.Prefix_TextBox = new System.Windows.Forms.TextBox();
            this.Script_Custom_Check = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Script_Select_Box = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // File_Input
            // 
            this.File_Input.AllowDrop = true;
            this.File_Input.FormattingEnabled = true;
            this.File_Input.Location = new System.Drawing.Point(12, 29);
            this.File_Input.Name = "File_Input";
            this.File_Input.Size = new System.Drawing.Size(716, 108);
            this.File_Input.TabIndex = 0;
            this.File_Input.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.File_Input.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // CMD_Output_Box
            // 
            this.CMD_Output_Box.Location = new System.Drawing.Point(12, 167);
            this.CMD_Output_Box.Multiline = true;
            this.CMD_Output_Box.Name = "CMD_Output_Box";
            this.CMD_Output_Box.Size = new System.Drawing.Size(716, 112);
            this.CMD_Output_Box.TabIndex = 2;
            // 
            // Generate_Button
            // 
            this.Generate_Button.Location = new System.Drawing.Point(12, 499);
            this.Generate_Button.Name = "Generate_Button";
            this.Generate_Button.Size = new System.Drawing.Size(75, 23);
            this.Generate_Button.TabIndex = 3;
            this.Generate_Button.Text = "Generate";
            this.Generate_Button.UseVisualStyleBackColor = true;
            this.Generate_Button.Click += new System.EventHandler(this.Generate_Button_Click);
            // 
            // Convert_Button
            // 
            this.Convert_Button.Location = new System.Drawing.Point(138, 499);
            this.Convert_Button.Name = "Convert_Button";
            this.Convert_Button.Size = new System.Drawing.Size(75, 23);
            this.Convert_Button.TabIndex = 4;
            this.Convert_Button.Text = "Convert";
            this.Convert_Button.UseVisualStyleBackColor = true;
            this.Convert_Button.Visible = false;
            this.Convert_Button.Click += new System.EventHandler(this.Convert_Button_Click);
            // 
            // Select_Extension
            // 
            this.Select_Extension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Select_Extension.FormattingEnabled = true;
            this.Select_Extension.Items.AddRange(new object[] {
            ".mkv",
            ".mp4",
            ".mov",
            ".m4v"});
            this.Select_Extension.Location = new System.Drawing.Point(139, 351);
            this.Select_Extension.Name = "Select_Extension";
            this.Select_Extension.Size = new System.Drawing.Size(75, 21);
            this.Select_Extension.TabIndex = 5;
            // 
            // Drag_Files_Label
            // 
            this.Drag_Files_Label.AutoSize = true;
            this.Drag_Files_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Drag_Files_Label.Location = new System.Drawing.Point(9, 9);
            this.Drag_Files_Label.Name = "Drag_Files_Label";
            this.Drag_Files_Label.Size = new System.Drawing.Size(122, 17);
            this.Drag_Files_Label.TabIndex = 6;
            this.Drag_Files_Label.Text = "Drag Files Here";
            // 
            // Extension_Label
            // 
            this.Extension_Label.AutoSize = true;
            this.Extension_Label.Location = new System.Drawing.Point(12, 354);
            this.Extension_Label.Name = "Extension_Label";
            this.Extension_Label.Size = new System.Drawing.Size(121, 13);
            this.Extension_Label.TabIndex = 7;
            this.Extension_Label.Text = "Select File Output Type:";
            // 
            // CMD_Label
            // 
            this.CMD_Label.AutoSize = true;
            this.CMD_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMD_Label.Location = new System.Drawing.Point(12, 151);
            this.CMD_Label.Name = "CMD_Label";
            this.CMD_Label.Size = new System.Drawing.Size(123, 13);
            this.CMD_Label.TabIndex = 8;
            this.CMD_Label.Text = "FFMPEG RAW OUT:";
            // 
            // Output_Directory_Label
            // 
            this.Output_Directory_Label.AutoSize = true;
            this.Output_Directory_Label.Location = new System.Drawing.Point(12, 389);
            this.Output_Directory_Label.Name = "Output_Directory_Label";
            this.Output_Directory_Label.Size = new System.Drawing.Size(87, 13);
            this.Output_Directory_Label.TabIndex = 9;
            this.Output_Directory_Label.Text = "Output Directory:";
            // 
            // Output_Directory_Box
            // 
            this.Output_Directory_Box.Location = new System.Drawing.Point(228, 386);
            this.Output_Directory_Box.Name = "Output_Directory_Box";
            this.Output_Directory_Box.ReadOnly = true;
            this.Output_Directory_Box.Size = new System.Drawing.Size(500, 20);
            this.Output_Directory_Box.TabIndex = 10;
            // 
            // Browse_Output_Button
            // 
            this.Browse_Output_Button.Location = new System.Drawing.Point(138, 384);
            this.Browse_Output_Button.Name = "Browse_Output_Button";
            this.Browse_Output_Button.Size = new System.Drawing.Size(75, 23);
            this.Browse_Output_Button.TabIndex = 11;
            this.Browse_Output_Button.Text = "Browse...";
            this.Browse_Output_Button.UseVisualStyleBackColor = true;
            this.Browse_Output_Button.Click += new System.EventHandler(this.Browse_Output_Button_Click);
            // 
            // Load_FFMPEG_Label
            // 
            this.Load_FFMPEG_Label.AutoSize = true;
            this.Load_FFMPEG_Label.Location = new System.Drawing.Point(9, 424);
            this.Load_FFMPEG_Label.Name = "Load_FFMPEG_Label";
            this.Load_FFMPEG_Label.Size = new System.Drawing.Size(114, 13);
            this.Load_FFMPEG_Label.TabIndex = 13;
            this.Load_FFMPEG_Label.Text = "Modify FFMPEG Script";
            // 
            // FFMPEG_Script_Box
            // 
            this.FFMPEG_Script_Box.Location = new System.Drawing.Point(228, 420);
            this.FFMPEG_Script_Box.Name = "FFMPEG_Script_Box";
            this.FFMPEG_Script_Box.Size = new System.Drawing.Size(500, 20);
            this.FFMPEG_Script_Box.TabIndex = 14;
            this.FFMPEG_Script_Box.Visible = false;
            // 
            // Conversion_Progress
            // 
            this.Conversion_Progress.Location = new System.Drawing.Point(225, 499);
            this.Conversion_Progress.Name = "Conversion_Progress";
            this.Conversion_Progress.Size = new System.Drawing.Size(500, 23);
            this.Conversion_Progress.TabIndex = 15;
            // 
            // Suffix_CheckBox
            // 
            this.Suffix_CheckBox.AutoSize = true;
            this.Suffix_CheckBox.Location = new System.Drawing.Point(138, 447);
            this.Suffix_CheckBox.Name = "Suffix_CheckBox";
            this.Suffix_CheckBox.Size = new System.Drawing.Size(52, 17);
            this.Suffix_CheckBox.TabIndex = 16;
            this.Suffix_CheckBox.Text = "Suffix";
            this.Suffix_CheckBox.UseVisualStyleBackColor = true;
            this.Suffix_CheckBox.CheckedChanged += new System.EventHandler(this.Suffix_CheckBox_CheckedChanged);
            // 
            // Prefix_CheckBox
            // 
            this.Prefix_CheckBox.AutoSize = true;
            this.Prefix_CheckBox.Location = new System.Drawing.Point(138, 470);
            this.Prefix_CheckBox.Name = "Prefix_CheckBox";
            this.Prefix_CheckBox.Size = new System.Drawing.Size(52, 17);
            this.Prefix_CheckBox.TabIndex = 17;
            this.Prefix_CheckBox.Text = "Prefix";
            this.Prefix_CheckBox.UseVisualStyleBackColor = true;
            this.Prefix_CheckBox.CheckedChanged += new System.EventHandler(this.Prefix_CheckBox_CheckedChanged);
            // 
            // Suffix_TextBox
            // 
            this.Suffix_TextBox.Location = new System.Drawing.Point(225, 447);
            this.Suffix_TextBox.Name = "Suffix_TextBox";
            this.Suffix_TextBox.Size = new System.Drawing.Size(500, 20);
            this.Suffix_TextBox.TabIndex = 18;
            this.Suffix_TextBox.Visible = false;
            // 
            // Prefix_TextBox
            // 
            this.Prefix_TextBox.Location = new System.Drawing.Point(225, 473);
            this.Prefix_TextBox.Name = "Prefix_TextBox";
            this.Prefix_TextBox.Size = new System.Drawing.Size(500, 20);
            this.Prefix_TextBox.TabIndex = 19;
            this.Prefix_TextBox.Visible = false;
            // 
            // Script_Custom_Check
            // 
            this.Script_Custom_Check.AutoSize = true;
            this.Script_Custom_Check.Location = new System.Drawing.Point(138, 424);
            this.Script_Custom_Check.Name = "Script_Custom_Check";
            this.Script_Custom_Check.Size = new System.Drawing.Size(61, 17);
            this.Script_Custom_Check.TabIndex = 20;
            this.Script_Custom_Check.Text = "Custom";
            this.Script_Custom_Check.UseVisualStyleBackColor = true;
            this.Script_Custom_Check.CheckedChanged += new System.EventHandler(this.Script_Custom_Check_CheckedChanged);
            // 
            // Script_Select_Box
            // 
            this.Script_Select_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Script_Select_Box.FormattingEnabled = true;
            this.Script_Select_Box.Items.AddRange(new object[] {
            " -map_metadata -1 -c:v hevc_nvenc ",
            " -map_metadata -1 -c:v hevc_nvenc -preset slow -x265-params pass=2 -crf 17 ",
            " -map_metadata -1 "});
            this.Script_Select_Box.Location = new System.Drawing.Point(228, 420);
            this.Script_Select_Box.Name = "Script_Select_Box";
            this.Script_Select_Box.Size = new System.Drawing.Size(500, 21);
            this.Script_Select_Box.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 536);
            this.Controls.Add(this.Script_Select_Box);
            this.Controls.Add(this.Script_Custom_Check);
            this.Controls.Add(this.Prefix_TextBox);
            this.Controls.Add(this.Suffix_TextBox);
            this.Controls.Add(this.Prefix_CheckBox);
            this.Controls.Add(this.Suffix_CheckBox);
            this.Controls.Add(this.Conversion_Progress);
            this.Controls.Add(this.FFMPEG_Script_Box);
            this.Controls.Add(this.Load_FFMPEG_Label);
            this.Controls.Add(this.Browse_Output_Button);
            this.Controls.Add(this.Output_Directory_Box);
            this.Controls.Add(this.Output_Directory_Label);
            this.Controls.Add(this.CMD_Label);
            this.Controls.Add(this.Extension_Label);
            this.Controls.Add(this.Drag_Files_Label);
            this.Controls.Add(this.Select_Extension);
            this.Controls.Add(this.Convert_Button);
            this.Controls.Add(this.Generate_Button);
            this.Controls.Add(this.CMD_Output_Box);
            this.Controls.Add(this.File_Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox File_Input;
        private System.Windows.Forms.TextBox CMD_Output_Box;
        private System.Windows.Forms.Button Generate_Button;
        private System.Windows.Forms.Button Convert_Button;
        private System.Windows.Forms.ComboBox Select_Extension;
        private System.Windows.Forms.Label Drag_Files_Label;
        private System.Windows.Forms.Label Extension_Label;
        private System.Windows.Forms.Label CMD_Label;
        private System.Windows.Forms.Label Output_Directory_Label;
        private System.Windows.Forms.TextBox Output_Directory_Box;
        private System.Windows.Forms.Button Browse_Output_Button;
        private Label Load_FFMPEG_Label;
        private TextBox FFMPEG_Script_Box;
        private ProgressBar Conversion_Progress;
        private CheckBox Suffix_CheckBox;
        private CheckBox Prefix_CheckBox;
        private TextBox Suffix_TextBox;
        private TextBox Prefix_TextBox;
        private CheckBox Script_Custom_Check;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox Script_Select_Box;
    }
}

