/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 16.11.2015.
 * Time: 21:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace aAITK
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.openFileDialog_Android_Image_Import = new System.Windows.Forms.OpenFileDialog();
			this.tabControl_AIJ = new System.Windows.Forms.TabControl();
			this.tabPage_SAI = new System.Windows.Forms.TabPage();
			this.listBox_AIBI = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.listBox_MDBI = new System.Windows.Forms.ListBox();
			this.button_Create_Import_Project = new System.Windows.Forms.Button();
			this.button_Split_And_Import = new System.Windows.Forms.Button();
			this.label_AIB_Info = new System.Windows.Forms.Label();
			this.button_Do_AI_Import = new System.Windows.Forms.Button();
			this.textBox_Project_Name = new System.Windows.Forms.TextBox();
			this.tabPage_JAI = new System.Windows.Forms.TabPage();
			this.groupBox_Projects = new System.Windows.Forms.GroupBox();
			this.button_Join_And_Export = new System.Windows.Forms.Button();
			this.comboBox_Use_This_Project = new System.Windows.Forms.ComboBox();
			this.saveFileDialog_Android_Image_Export = new System.Windows.Forms.SaveFileDialog();
			this.tabControl_AIJ.SuspendLayout();
			this.tabPage_SAI.SuspendLayout();
			this.tabPage_JAI.SuspendLayout();
			this.groupBox_Projects.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog_Android_Image_Import
			// 
			this.openFileDialog_Android_Image_Import.Filter = "All Boot.Img files (boot*.img)|boot*.img|All Recovery.Img files (recovery*.img)|r" +
			"ecovery*.img";
			this.openFileDialog_Android_Image_Import.Title = "Select Android Image to import...";
			// 
			// tabControl_AIJ
			// 
			this.tabControl_AIJ.Controls.Add(this.tabPage_SAI);
			this.tabControl_AIJ.Controls.Add(this.tabPage_JAI);
			this.tabControl_AIJ.Location = new System.Drawing.Point(12, 13);
			this.tabControl_AIJ.Name = "tabControl_AIJ";
			this.tabControl_AIJ.SelectedIndex = 0;
			this.tabControl_AIJ.Size = new System.Drawing.Size(444, 266);
			this.tabControl_AIJ.TabIndex = 0;
			this.tabControl_AIJ.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_AIJSelecting);
			// 
			// tabPage_SAI
			// 
			this.tabPage_SAI.Controls.Add(this.listBox_AIBI);
			this.tabPage_SAI.Controls.Add(this.label1);
			this.tabPage_SAI.Controls.Add(this.listBox_MDBI);
			this.tabPage_SAI.Controls.Add(this.button_Create_Import_Project);
			this.tabPage_SAI.Controls.Add(this.button_Split_And_Import);
			this.tabPage_SAI.Controls.Add(this.label_AIB_Info);
			this.tabPage_SAI.Controls.Add(this.button_Do_AI_Import);
			this.tabPage_SAI.Controls.Add(this.textBox_Project_Name);
			this.tabPage_SAI.Location = new System.Drawing.Point(4, 22);
			this.tabPage_SAI.Name = "tabPage_SAI";
			this.tabPage_SAI.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_SAI.Size = new System.Drawing.Size(436, 240);
			this.tabPage_SAI.TabIndex = 0;
			this.tabPage_SAI.Text = "Split Android Image";
			this.tabPage_SAI.UseVisualStyleBackColor = true;
			// 
			// listBox_AIBI
			// 
			this.listBox_AIBI.Location = new System.Drawing.Point(20, 77);
			this.listBox_AIBI.Name = "listBox_AIBI";
			this.listBox_AIBI.Size = new System.Drawing.Size(224, 121);
			this.listBox_AIBI.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(250, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "[ Manufacturer DTB Basic Info ]";
			// 
			// listBox_MDBI
			// 
			this.listBox_MDBI.FormattingEnabled = true;
			this.listBox_MDBI.HorizontalScrollbar = true;
			this.listBox_MDBI.Location = new System.Drawing.Point(250, 77);
			this.listBox_MDBI.Name = "listBox_MDBI";
			this.listBox_MDBI.Size = new System.Drawing.Size(162, 121);
			this.listBox_MDBI.TabIndex = 6;
			// 
			// button_Create_Import_Project
			// 
			this.button_Create_Import_Project.Location = new System.Drawing.Point(20, 22);
			this.button_Create_Import_Project.Name = "button_Create_Import_Project";
			this.button_Create_Import_Project.Size = new System.Drawing.Size(224, 21);
			this.button_Create_Import_Project.TabIndex = 5;
			this.button_Create_Import_Project.Text = "Create Android Image Import Project ...";
			this.button_Create_Import_Project.UseVisualStyleBackColor = true;
			this.button_Create_Import_Project.Click += new System.EventHandler(this.Button_Create_Import_ProjectClick);
			// 
			// button_Split_And_Import
			// 
			this.button_Split_And_Import.Location = new System.Drawing.Point(20, 204);
			this.button_Split_And_Import.Name = "button_Split_And_Import";
			this.button_Split_And_Import.Size = new System.Drawing.Size(198, 23);
			this.button_Split_And_Import.TabIndex = 4;
			this.button_Split_And_Import.Text = "Import && Split Android Image file ...";
			this.button_Split_And_Import.UseVisualStyleBackColor = true;
			this.button_Split_And_Import.Click += new System.EventHandler(this.Button_Import_And_SplitClick);
			// 
			// label_AIB_Info
			// 
			this.label_AIB_Info.Location = new System.Drawing.Point(20, 61);
			this.label_AIB_Info.Name = "label_AIB_Info";
			this.label_AIB_Info.Size = new System.Drawing.Size(137, 13);
			this.label_AIB_Info.TabIndex = 3;
			this.label_AIB_Info.Text = "[ Android Image Basic Info ]";
			// 
			// button_Do_AI_Import
			// 
			this.button_Do_AI_Import.Location = new System.Drawing.Point(381, 21);
			this.button_Do_AI_Import.Name = "button_Do_AI_Import";
			this.button_Do_AI_Import.Size = new System.Drawing.Size(31, 21);
			this.button_Do_AI_Import.TabIndex = 1;
			this.button_Do_AI_Import.Text = "...";
			this.button_Do_AI_Import.UseVisualStyleBackColor = true;
			this.button_Do_AI_Import.Visible = false;
			this.button_Do_AI_Import.Click += new System.EventHandler(this.Button_Do_AI_ImportClick);
			// 
			// textBox_Project_Name
			// 
			this.textBox_Project_Name.Location = new System.Drawing.Point(250, 22);
			this.textBox_Project_Name.Name = "textBox_Project_Name";
			this.textBox_Project_Name.Size = new System.Drawing.Size(125, 20);
			this.textBox_Project_Name.TabIndex = 0;
			this.textBox_Project_Name.Text = "Import project name?";
			this.textBox_Project_Name.Visible = false;
			this.textBox_Project_Name.Click += new System.EventHandler(this.TextBox_Project_NameClick);
			this.textBox_Project_Name.TextChanged += new System.EventHandler(this.TextBox_Project_NameTextChanged);
			// 
			// tabPage_JAI
			// 
			this.tabPage_JAI.Controls.Add(this.groupBox_Projects);
			this.tabPage_JAI.Location = new System.Drawing.Point(4, 22);
			this.tabPage_JAI.Name = "tabPage_JAI";
			this.tabPage_JAI.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_JAI.Size = new System.Drawing.Size(436, 240);
			this.tabPage_JAI.TabIndex = 1;
			this.tabPage_JAI.Text = "Join Android Image";
			this.tabPage_JAI.UseVisualStyleBackColor = true;
			// 
			// groupBox_Projects
			// 
			this.groupBox_Projects.Controls.Add(this.button_Join_And_Export);
			this.groupBox_Projects.Controls.Add(this.comboBox_Use_This_Project);
			this.groupBox_Projects.Location = new System.Drawing.Point(22, 26);
			this.groupBox_Projects.Name = "groupBox_Projects";
			this.groupBox_Projects.Size = new System.Drawing.Size(296, 125);
			this.groupBox_Projects.TabIndex = 3;
			this.groupBox_Projects.TabStop = false;
			// 
			// button_Join_And_Export
			// 
			this.button_Join_And_Export.Location = new System.Drawing.Point(18, 74);
			this.button_Join_And_Export.Name = "button_Join_And_Export";
			this.button_Join_And_Export.Size = new System.Drawing.Size(188, 23);
			this.button_Join_And_Export.TabIndex = 4;
			this.button_Join_And_Export.Text = "Join && Export Android Image ...";
			this.button_Join_And_Export.UseVisualStyleBackColor = true;
			this.button_Join_And_Export.Click += new System.EventHandler(this.Button_Join_And_ExportClick);
			// 
			// comboBox_Use_This_Project
			// 
			this.comboBox_Use_This_Project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Use_This_Project.FormattingEnabled = true;
			this.comboBox_Use_This_Project.Items.AddRange(new object[] {
									"Select Project to use ..."});
			this.comboBox_Use_This_Project.Location = new System.Drawing.Point(18, 26);
			this.comboBox_Use_This_Project.Name = "comboBox_Use_This_Project";
			this.comboBox_Use_This_Project.Size = new System.Drawing.Size(237, 21);
			this.comboBox_Use_This_Project.TabIndex = 3;
			// 
			// saveFileDialog_Android_Image_Export
			// 
			this.saveFileDialog_Android_Image_Export.Filter = "All Boot.Img files (boot*.img)|boot*.img|All Recovery.Img files (recovery*.img)|r" +
			"ecovery*.img";
			this.saveFileDialog_Android_Image_Export.Title = "Select where to save Android Image...";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 290);
			this.Controls.Add(this.tabControl_AIJ);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "aZuZu Android Boot & Recovery Image ToolKit, v2.0.0";
			this.tabControl_AIJ.ResumeLayout(false);
			this.tabPage_SAI.ResumeLayout(false);
			this.tabPage_SAI.PerformLayout();
			this.tabPage_JAI.ResumeLayout(false);
			this.groupBox_Projects.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox listBox_AIBI;
		private System.Windows.Forms.Button button_Do_AI_Import;
		private System.Windows.Forms.ListBox listBox_MDBI;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Android_Image_Export;
		private System.Windows.Forms.Button button_Join_And_Export;
		private System.Windows.Forms.GroupBox groupBox_Projects;
		private System.Windows.Forms.ComboBox comboBox_Use_This_Project;
		private System.Windows.Forms.Button button_Create_Import_Project;
		private System.Windows.Forms.Button button_Split_And_Import;
		private System.Windows.Forms.Label label_AIB_Info;
		private System.Windows.Forms.TabPage tabPage_JAI;
		private System.Windows.Forms.TextBox textBox_Project_Name;
		private System.Windows.Forms.TabPage tabPage_SAI;
		private System.Windows.Forms.TabControl tabControl_AIJ;
		private System.Windows.Forms.OpenFileDialog openFileDialog_Android_Image_Import;
	}
}
