/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 5/21/2011
 * Time: 7:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace aAITK
{

	public class Boot_Image
	{
		public static void Split_Android_Image(string Project_Name)
		 {
		 	Shared.Set_Files(Project_Name);
		 	BinaryReader a_image_file = new BinaryReader(File.OpenRead(Shared.Selected_File[0]));
			BinaryWriter kernel_file = new BinaryWriter(File.OpenWrite(Shared.Kernel_File));
			BinaryWriter ramdisk_file = new BinaryWriter(File.OpenWrite(Shared.RAMDisk_File));
			BinaryWriter second_file = new BinaryWriter(File.OpenWrite(Shared.Second_File));
			BinaryWriter dtb_file = new BinaryWriter(File.OpenWrite(Shared.DTB_File));
			TextWriter config_file = new StreamWriter(File.OpenWrite(Shared.Config_File));

		 	a_image_file.BaseStream.Position = 0;
		 	a_image_file.BaseStream.Seek((long)Shared.Kernel_Offset(), SeekOrigin.Begin);
		 	kernel_file.Write(a_image_file.ReadBytes((int)Shared.Boot_Image_Header.Kernel_Size));
		 	kernel_file.Close();
		 	a_image_file.BaseStream.Seek((long)Shared.RAMDisk_Offset(), SeekOrigin.Begin);
		 	ramdisk_file.Write(a_image_file.ReadBytes((int)Shared.Boot_Image_Header.RAMDisk_Size));
		 	ramdisk_file.Close();
		 	a_image_file.BaseStream.Seek(Shared.Second_Offset(), SeekOrigin.Begin);
		 	second_file.Write(a_image_file.ReadBytes((int)Shared.Boot_Image_Header.Second_Size));
		 	second_file.Close();
		 	if (Shared.Boot_Image_Header.DT_Size != 0 )
		 	{
		 		a_image_file.BaseStream.Seek(Shared.DTB_Offset(), SeekOrigin.Begin);
		 		dtb_file.Write(a_image_file.ReadBytes((int)Shared.Boot_Image_Header.DT_Size));
		 		dtb_file.Close();
		 	}
		 	config_file.WriteLine(Shared.Image_Type());
		 	config_file.WriteLine(Shared.Boot_Image_Header.Kernel_Address);
		 	config_file.WriteLine(Shared.Boot_Image_Header.RAMDisk_Address);
		 	config_file.WriteLine(Shared.Boot_Image_Header.Second_Address);
		 	config_file.WriteLine(Shared.Boot_Image_Header.Tags_Address);
		 	config_file.WriteLine(Shared.Boot_Image_Header.DT_Size.ToString() + "," + Shared.Boot_Image_Header.UnUsed_0.ToString());
		 	config_file.WriteLine(Shared.Boot_Image_Header.Page_Size);
		 	string Cmd_Line = new string(Shared.Boot_Image_Header.CmdLine);
		 	config_file.WriteLine(Cmd_Line.Trim());
		 	//string Extra_Cmd_Line = new string(Shared.Boot_Image_Header.Extra_CmdLine);
	 		//config_file.WriteLine(Extra_Cmd_Line);
	 		config_file.Close();
		 	a_image_file.Close();
		 }
		 public static void Join_Android_Image(string Project_Name)
		 {
		 	List<byte> New_Image_Signature = new List<byte>();
		 	Shared.Set_Files(Project_Name);
		 	MemoryStream a_image_file = new MemoryStream();
		 	BinaryReader a_img_r = new BinaryReader(a_image_file);
		 	BinaryWriter a_img_w = new BinaryWriter(a_image_file);
		 	BinaryWriter output_file = new BinaryWriter(File.OpenWrite(Shared.Selected_File[0]));
		 	BinaryReader kernel_file = new BinaryReader(File.OpenRead(Shared.Kernel_File));
		 	BinaryReader ramdisk_file = new BinaryReader(File.OpenRead(Shared.RAMDisk_File));
		 	BinaryReader second_file = new BinaryReader(File.OpenRead(Shared.Second_File));
		 	BinaryReader dtb_file = new BinaryReader(File.OpenRead(Shared.DTB_File));

		 	a_img_w.BaseStream.Position = 0;
		 	a_img_r.BaseStream.Position = 0;
		 	
		 	Shared.Boot_Image_Header.Kernel_Size = (uint)kernel_file.BaseStream.Length;
		 	Shared.Boot_Image_Header.RAMDisk_Size = (uint)ramdisk_file.BaseStream.Length;
	        string Magic = "ANDROID!";
	        Shared.Boot_Image_Header.Magic = Magic.ToCharArray();
	        if ( Shared.Config_Data.Length == 8 )
	        {
		        Shared.Boot_Image_Header.Kernel_Address = uint.Parse(Shared.Config_Data[1]);
		        Shared.Boot_Image_Header.RAMDisk_Address = uint.Parse(Shared.Config_Data[2]);
		        Shared.Boot_Image_Header.Second_Address = uint.Parse(Shared.Config_Data[3]);
		        Shared.Boot_Image_Header.Tags_Address = uint.Parse(Shared.Config_Data[4]);
		        Shared.Boot_Image_Header.DT_Size = Convert.ToUInt32(Shared.Config_Data[5].Split(',')[0]);
		        Shared.Boot_Image_Header.UnUsed_0 = Convert.ToUInt32(Shared.Config_Data[5].Split(',')[1]);
		        Shared.Boot_Image_Header.Page_Size = uint.Parse(Shared.Config_Data[6]);
		        Shared.Boot_Image_Header.CmdLine = Shared.Config_Data[7].ToCharArray();
			    Shared.Boot_Image_Header.ID = Shared.CheckSum();
		        //Shared.Boot_Image_Header.Extra_CmdLine = Config_File[7].ToCharArray();
	        }
	                                                        
	        a_img_w.Write(Shared.Boot_Image_Header.Magic);
	        a_img_w.Write(Shared.Boot_Image_Header.Kernel_Size);
	        a_img_w.Write(Shared.Boot_Image_Header.Kernel_Address);

	        a_img_w.Write(Shared.Boot_Image_Header.RAMDisk_Size);
	        a_img_w.Write(Shared.Boot_Image_Header.RAMDisk_Address);

	        a_img_w.Write(Shared.Boot_Image_Header.Second_Size);
	        a_img_w.Write(Shared.Boot_Image_Header.Second_Address);

	        a_img_w.Write(Shared.Boot_Image_Header.Tags_Address);
	        a_img_w.Write(Shared.Boot_Image_Header.Page_Size);
	        a_img_w.Write(Shared.Boot_Image_Header.DT_Size);
	        a_img_w.Write(Shared.Boot_Image_Header.UnUsed_0);
	        a_img_w.Write(Shared.Boot_Image_Header.Device_Name);
		    a_img_w.Write(Shared.Boot_Image_Header.CmdLine);
		    
		    //a_img_w.Write(Shared.Boot_Image_Header.Extra_CmdLine);
			
		    a_img_w.Write(Shared.Boot_Image_Header.ID);

		    char[] Padding_One = new char[Write_Padding((uint)a_img_r.BaseStream.Position)];
		    a_img_w.Write(Padding_One);		    
		    a_img_w.Write(kernel_file.ReadBytes((int)Shared.Boot_Image_Header.Kernel_Size));
		    
		    char[] Padding_Two = new char[Write_Padding((uint)a_img_r.BaseStream.Position)];
		    a_img_w.Write(Padding_Two);
		   	a_img_w.Write(ramdisk_file.ReadBytes((int)Shared.Boot_Image_Header.RAMDisk_Size));

		    char[] Padding_Three = new char[Write_Padding((uint)a_img_r.BaseStream.Position)];
		    a_img_w.Write(Padding_Three);
		   	a_img_w.Write(second_file.ReadBytes((int)(second_file.BaseStream.Length)));
		   	
		   	if ( Shared.Boot_Image_Header.DT_Size != 0 )
	   	    {
			    char[] Padding_Four = new char[Write_Padding((uint)a_img_r.BaseStream.Position)];
			    a_img_w.Write(Padding_Four);
			   	a_img_w.Write(dtb_file.ReadBytes((int)(dtb_file.BaseStream.Length)));
		   	}
		   	
		   	switch ( Shared.Selected_File[1] )
		   	{
		   		case "1":
		   			{
					   	for ( int bi = 0; bi < Shared.Signature_Byte_Offsets_Boot.Length; bi++ )
				    	{
		   					a_img_r.BaseStream.Seek(Shared.Signature_Byte_Offsets_Boot[bi], SeekOrigin.Begin);
		   					New_Image_Signature.AddRange(a_img_r.ReadBytes(2));
		   				}
					   	File.WriteAllBytes("S_Boot_S.Bin", New_Image_Signature.ToArray());					   	
		   				break;
		   			}
		   		case "2":
		   			{
					   	for ( int ri = 0; ri < Shared.Signature_Byte_Offsets_Recovery.Length; ri++ )
				    	{
		   					a_img_r.BaseStream.Seek(Shared.Signature_Byte_Offsets_Recovery[ri], SeekOrigin.Begin);
		   					New_Image_Signature.AddRange(a_img_r.ReadBytes(2));
			   			}
					   	File.WriteAllBytes("S_Recovery_S.Bin", New_Image_Signature.ToArray());
						break;		   				
		   			}
		   	}
			string SSAEF_Header = "SEANDROIDENFORCE";
		    a_img_w.BaseStream.Seek(a_image_file.Length, SeekOrigin.Begin);
		    a_img_w.Write(Encoding.ASCII.GetBytes(SSAEF_Header));
		    a_img_w.Write(New_Image_Signature.ToArray());
		 	a_img_r.Close();
		 	a_img_w.Close();
		 	output_file.Write(a_image_file.ToArray());
		 	output_file.Close();
		 	a_image_file.Close();
	 	 }

		 public static int Write_Padding(uint Item_Size)
	     {
	        int count;
	        if ((Item_Size & Shared.Page_Mask()) == 0)
	        {
	          	return 0;
	        }
	        count = (int)(Shared.Boot_Image_Header.Page_Size - (Item_Size & Shared.Page_Mask()));
	        return count;
		 }
	}
}
