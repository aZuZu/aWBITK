/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 16.11.2015.
 * Time: 21:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace aAITK
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{


		public static string Main_Path = Path.GetDirectoryName(Application.ExecutablePath);

		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Fill_Basic_Informations()
		{
			listBox_AIBI.Items.Clear();
			string Magic = new string(Shared.Boot_Image_Header.Magic);
			listBox_AIBI.Items.Add("Magic           : " + Magic + ", " + Shared.Image_Type());
			listBox_AIBI.Items.Add("Kernel size     : " + Shared.Boot_Image_Header.Kernel_Size);
			listBox_AIBI.Items.Add("Kernel address  : " + Shared.Boot_Image_Header.Kernel_Address.ToString("X"));
			listBox_AIBI.Items.Add("RAMDisk size    : " + Shared.Boot_Image_Header.RAMDisk_Size);
			listBox_AIBI.Items.Add("RAMDisk address : " + Shared.Boot_Image_Header.RAMDisk_Address.ToString("X"));
			listBox_AIBI.Items.Add("Second size     : " + Shared.Boot_Image_Header.Second_Size);
			listBox_AIBI.Items.Add("Second address  : " + Shared.Boot_Image_Header.Second_Address.ToString("X"));
			listBox_AIBI.Items.Add("Tags address    : " + Shared.Boot_Image_Header.Tags_Address.ToString("X"));
			listBox_AIBI.Items.Add("Page size       : " + Shared.Boot_Image_Header.Page_Size.ToString());
	 		//string Cmd_Line = new string(Shared.Boot_Image_Header.CmdLine);
	 		//listBox_AIBI.Items.Add(Cmd_Line);
	 		
	 		listBox_MDBI.Items.Clear();
	 		if ( Shared.Boot_Image_Header.DT_Size != 0 )
	 		{
	 			string DTB_Magic = new string(Shared.Manufacturer_DTB.DTB_Magic);
	 			listBox_MDBI.Items.Add("DTB Magic: " + DTB_Magic);
			 	listBox_MDBI.Items.Add("DTB Version: " + Shared.Manufacturer_DTB.DTB_Version);
			 	listBox_MDBI.Items.Add("DTB Entries Count: " + Shared.Manufacturer_DTB.DTB_Entries_Count);
			 	listBox_MDBI.Items.Add("DTB Platform ID: " + Shared.Manufacturer_DTB.DTB_Platform_ID);
			 	listBox_MDBI.Items.Add("DTB Variant: " + Shared.Manufacturer_DTB.DTB_Variant);
			 	listBox_MDBI.Items.Add("DTB SOC Revision: " + Shared.Manufacturer_DTB.DTB_SOC_Revision);
			 	listBox_MDBI.Items.Add("DTB Offset: " + Shared.Manufacturer_DTB.DTB_Offset);
			 	listBox_MDBI.Items.Add("DTB Data Size: " + Shared.Manufacturer_DTB.DTB_Data_Size);	 			
	 		}
		}
		void TextBox_Project_NameTextChanged(object sender, EventArgs e)
		{
			if ( textBox_Project_Name.Text.Length == 0 )
			{
				button_Do_AI_Import.Visible = false;
			} else {
				button_Do_AI_Import.Visible = true;
			}
		}
		void TextBox_Project_NameClick(object sender, EventArgs e)
		{
			textBox_Project_Name.Clear();
		}
		void Button_Do_AI_ImportClick(object sender, EventArgs e)
		{
			DialogResult Reply = openFileDialog_Android_Image_Import.ShowDialog();
			switch ( Reply )
			{
				case DialogResult.OK:
					{
						Shared.Selected_File[0] = openFileDialog_Android_Image_Import.FileName;
						Shared.Selected_File[1] = openFileDialog_Android_Image_Import.FilterIndex.ToString();
						Shared.Read_Out_AI_Info();
						Fill_Basic_Informations();
						break;
					}
				case DialogResult.Cancel:
					{
						
						break;
					}
			}
		}
		void Button_Import_And_SplitClick(object sender, EventArgs e)
		{
			Directory.CreateDirectory(Shared.Import_Projects + "\\" + textBox_Project_Name.Text);
			Boot_Image.Split_Android_Image(textBox_Project_Name.Text);			
		}
		void Button_Create_Import_ProjectClick(object sender, EventArgs e)
		{
			textBox_Project_Name.Visible = true;
		}
		void TabControl_AIJSelecting(object sender, TabControlCancelEventArgs e)
		{
			
			if ( tabControl_AIJ.SelectedIndex == 1 )
			{
				comboBox_Use_This_Project.SelectedIndex = 0;
				foreach ( string Project_Item in Directory.GetDirectories(Shared.Import_Projects))
				{
					string Project_Name = Path.GetFileName(Project_Item);
					if ( !comboBox_Use_This_Project.Items.Contains(Project_Name) )
					{
						comboBox_Use_This_Project.Items.Add(Project_Name);
					}
				}
			}
		}
		void Button_Join_And_ExportClick(object sender, EventArgs e)
		{
			DialogResult Reply = saveFileDialog_Android_Image_Export.ShowDialog();
			switch ( Reply )
			{
				case DialogResult.OK:
					{
						Shared.Selected_File[0] = saveFileDialog_Android_Image_Export.FileName;
						Shared.Selected_File[1] = saveFileDialog_Android_Image_Export.FilterIndex.ToString();
						Boot_Image.Join_Android_Image(comboBox_Use_This_Project.SelectedItem.ToString());
						break;
					}
				case DialogResult.Cancel:
					{
						
						break;
					}
			}
			
			

		}
	}
}
