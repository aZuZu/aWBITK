/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 16.11.2015.
 * Time: 22:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace aAITK
{
	/// <summary>
	/// Description of Shared.
	/// </summary>
	public class Shared
	{
		static public string Import_Projects = MainForm.Main_Path + "\\Import_Projects";
		static public string Export_Projects = MainForm.Main_Path + "\\Export_Projects";
		static public string[] Selected_File = new string[2];

		static public string Kernel_File = string.Empty;		
		static public string RAMDisk_File = string.Empty;
		static public string Second_File = string.Empty;
		static public string Tags_File = string.Empty;
		static public string DTB_File = string.Empty;
		static public string Config_File;
		static public string[] Config_Data = new string[6];
	
		
		[StructLayout(LayoutKind.Sequential, Pack=1, Size=4)]
		public struct Boot_Image_Header
		{
		    public static char[] Magic = new char[8];
		    public static uint Kernel_Size;
		    public static uint Kernel_Address;
		    public static uint RAMDisk_Size;
		    public static uint RAMDisk_Address;
		    public static uint Second_Size;
		    public static uint Second_Address;
		    public static uint Tags_Address;
		    public static uint Page_Size;
		    public static uint DT_Size;
		    public static uint UnUsed_0;
		    public static char[] Device_Name = new char[16];
		    public static char[] CmdLine = new char[512];
		    public static byte[] ID = new byte[8];
		    //public static char[] Extra_CmdLine = new char[1024];
		}
		
		[StructLayout(LayoutKind.Sequential, Pack=1, Size=4)]
		public struct Boot_Image_DTB_Data
		{
			private static char[] Magic = new char[4];
			private uint Version;
			private uint Entries;
			private uint Platform_ID;
			private uint Variant;
			private uint SOC_Revision;
		    private uint Offset;
		    private uint Data_Size;

		    public char[] DTB_Magic
		    {
		    	get
		    	{
		    		return Magic;
		    	}
		    	set
		    	{
		    		Magic = value;
		    	}
		    	
		    	
		    }
			public uint DTB_Version
			{
				get
				{
					return Version;
				}
				set
				{
					Version = value;
				}
			}
			public uint DTB_Entries_Count
			{
				get
				{
					return Entries;
				}
				set
				{
					Entries = value;
				}
			}
			public uint DTB_Platform_ID
			{
				get
				{
					return Platform_ID;
				}
				set
				{
					Platform_ID = value;
				}
			}
			public uint DTB_Variant
			{
				get
				{
					return Variant;
				}
				set
				{
					Variant = value;
				}
			}
			public uint DTB_SOC_Revision
			{
				get
				{
					return SOC_Revision;
				}
				set
				{
					SOC_Revision = value;
				}
			}		    
			public uint DTB_Offset
			{
				get
				{
					return Offset;
				}
				set
				{
					Offset = value;
				}
			}
			public uint DTB_Data_Size
			{
				get
				{
					return Data_Size;
				}
				set
				{
					Data_Size = value;
				}
			}
		}
		
		public static Boot_Image_DTB_Data Manufacturer_DTB = new Boot_Image_DTB_Data();

		public static long[] Signature_Byte_Offsets_Boot = new long[] { 116584,271891,139126,1085303,488854,28624,632837,38539,29400,40402,1938534,58490,768647,16292,55288,25814,447600,148937,44081,66554,196804,24763,234225,196541,1982786,26168,63424,22006,79537,316621,154106,102754,495437,4243015,100034,266179,141799,1138495,165867,217469,184496,151935,301381,13979,578379,96885,6099,529044,123922,60547,473711,1586609,283337,25055,69769,32408,88343,113530,34081,532743,863326,13034,5497113,1365638,114176,27106,3063078,1576926,22963,196254,134,422165,629450,32704,721233,451953,532638,2206196,232445,87765,15777,1190766,2652,142280,1254677,1830898,2463979,1370042,42019,330481,182565,4085034,27436,2166878,5221,122808,114989,12408,592096,606153,28837,1508268,2084530,213660,37193,525152,673872,262603,628207,54946,230134,19725,213215,24079,28173,60772,2219860,127234,1822238,1220984,54927,18046,136528,252606,134039,24908,57682,140347 };
		public static long[] Signature_Byte_Offsets_Recovery = new long[] { 990956,201565,20389,808684,57562,177963,787104,176443,582077,505882,72451,273417,175885,107126,144372,17757,47169,227981,938274,425865,1302071,13424,3212,112635,73357,158461,3774426,43381,170546,4131869,2988985,440052,23575,827865,51111,1456607,359743,623342,2685591,446470,3630401,429981,166426,32788,71663,4799,81694,4538722,50185,51188,75673,1090617,3939,340611,514238,1651593,87671,688162,42375,54462,731914,111058,302367,44053,420884,1372492,2937982,1648202,18765,424138,373263,313261,135702,150479,127036,43398,81186,19638,372402,709555,52876,523020,158776,139347,5690,65129,83382,1446726,68702,170765,162921,2406746,29735,2301905,142807,181543,36890,1344078,16365,17568,212011,160266,2496170,107901,213215,124724,600520,387122,82258,300610,722553,33513,1628992,183436,13861,26088,255808,3329852,129582,480232,52588,131932,799597,36027,191591,386365,123662,46990 };
		
		public static int Read_Out_AI_Info()
		{
			if ( Shared.Selected_File[0] != string.Empty )
			{
				BinaryReader a_image_file = new BinaryReader(File.OpenRead(Shared.Selected_File[0]));
			 	a_image_file.BaseStream.Position = 0;
			 	Boot_Image_Header.Magic = a_image_file.ReadChars(8);
			 	string Image_Magic = new string(Boot_Image_Header.Magic);
			 	if (Image_Magic != "ANDROID!")
			 	{
			 		a_image_file.Close();
			 		return -1;
			 	}
			 	Boot_Image_Header.Kernel_Size = a_image_file.ReadUInt32();
			 	Boot_Image_Header.Kernel_Address = a_image_file.ReadUInt32();
			 	Boot_Image_Header.RAMDisk_Size = a_image_file.ReadUInt32();
			 	Boot_Image_Header.RAMDisk_Address = a_image_file.ReadUInt32();
			 	Boot_Image_Header.Second_Size = a_image_file.ReadUInt32();
			 	Boot_Image_Header.Second_Address = a_image_file.ReadUInt32();
			 	Boot_Image_Header.Tags_Address = a_image_file.ReadUInt32();
			 	Boot_Image_Header.Page_Size = a_image_file.ReadUInt32();
			 	Boot_Image_Header.DT_Size = a_image_file.ReadUInt32();
			 	Boot_Image_Header.UnUsed_0 = a_image_file.ReadUInt32();
			 	Boot_Image_Header.Device_Name = a_image_file.ReadChars(16);
			 	Boot_Image_Header.CmdLine = a_image_file.ReadChars(512);
			 	Boot_Image_Header.ID = a_image_file.ReadBytes(8);
			 	//Boot_Image_Header.Extra_CmdLine = a_image_file.ReadChars(1024);			 	
			 	if ( Boot_Image_Header.DT_Size != 0 )
			 	{
			 		a_image_file.BaseStream.Seek(Shared.DTB_Offset(), SeekOrigin.Begin);
			 		Manufacturer_DTB.DTB_Magic = a_image_file.ReadChars(4);
			 		Manufacturer_DTB.DTB_Version = a_image_file.ReadUInt32();
			 		Manufacturer_DTB.DTB_Entries_Count = a_image_file.ReadUInt32();
			 		Manufacturer_DTB.DTB_Platform_ID = a_image_file.ReadUInt32();
			 		Manufacturer_DTB.DTB_Variant = a_image_file.ReadUInt16();
			 		Manufacturer_DTB.DTB_SOC_Revision = a_image_file.ReadUInt32();
			 		Manufacturer_DTB.DTB_Offset = a_image_file.ReadUInt32();
			 		Manufacturer_DTB.DTB_Data_Size = a_image_file.ReadUInt32();
			 	}
		 		return 0;
			} else {
				return -1;
			}
		}
		public static string Image_Type()
		{
			List<byte> A = new List<byte>();
			List<byte> B = new List<byte>();
			string Result = string.Empty;
			byte[] File_Signature = new byte[256];
			BinaryReader a_image_file = new BinaryReader(File.OpenRead(Shared.Selected_File[0]));
			a_image_file.BaseStream.Seek((int)a_image_file.BaseStream.Length - 256, SeekOrigin.Begin);
			File_Signature =  a_image_file.ReadBytes(256);
			a_image_file.BaseStream.Position = 0;
			for ( int a = 0; a < 128; a ++ )
			{
				a_image_file.BaseStream.Seek(Signature_Byte_Offsets_Boot[a], SeekOrigin.Begin);
				if ( a_image_file.ReadBytes(2) != File_Signature.Skip(a).Take(2) )
				{
					Result = "Recovery";
					break;
				}
				a_image_file.BaseStream.Seek(Signature_Byte_Offsets_Recovery[a], SeekOrigin.Begin);
				if ( a_image_file.ReadBytes(2) != File_Signature.Skip(a).Take(2) )
				{
					Result = "Boot";
					break;
				}
			}
			a_image_file.Close();
			return Result;
		}
		public static void Set_Files(string Project_Name)
		{
			string AImage_Type = string.Empty;
			switch (Selected_File[1])
			{
				case "1":
				{
					AImage_Type = "boot";
					break;
				}
				case "2":
				{
					AImage_Type = "recovery";
					break;
				}
			}
			
			Kernel_File = Import_Projects + "\\" + Project_Name + "\\" + AImage_Type + ".img-kernel";
			RAMDisk_File = Import_Projects + "\\" + Project_Name + "\\" + AImage_Type + ".img-ramdisk";
			Second_File = Import_Projects + "\\" + Project_Name + "\\" + AImage_Type + ".img-second";
			Tags_File = Import_Projects + "\\" + Project_Name + "\\" + AImage_Type + ".img-tags";
			DTB_File = Import_Projects + "\\" + Project_Name + "\\" + AImage_Type + ".img-dtb";
			Config_File = Import_Projects + "\\" + Project_Name + "\\" + Project_Name + ".img-config";
			if ( File.Exists ( Config_File ) )
			{
				Config_Data = File.ReadAllLines(Config_File);
			}
			
		}
		public static byte[] CheckSum()
		{
			List<byte> Data_To_Hash = new List<byte>();
			SHA1 SHA = SHA1Managed.Create();

			byte[] K_File = File.ReadAllBytes(Shared.Kernel_File);
			byte[] R_File = File.ReadAllBytes(Shared.RAMDisk_File);
			byte[] S_File = File.ReadAllBytes(Shared.Second_File);
			byte[] D_File = File.ReadAllBytes(Shared.DTB_File);
			Data_To_Hash.AddRange(K_File);
			Data_To_Hash.AddRange(BitConverter.GetBytes(K_File.Length));
			Data_To_Hash.AddRange(R_File);
			Data_To_Hash.AddRange(BitConverter.GetBytes(R_File.Length));
			Data_To_Hash.AddRange(S_File);
			Data_To_Hash.AddRange(BitConverter.GetBytes(S_File.Length));
			Data_To_Hash.AddRange(D_File);
			Data_To_Hash.AddRange(BitConverter.GetBytes(D_File.Length));
			return SHA.ComputeHash(Data_To_Hash.ToArray());
		}

		public static uint Page_Mask()
		{
			return Boot_Image_Header.Page_Size - 1;
		}
		public static uint Kernel_I()
        {
			return  (Boot_Image_Header.Kernel_Size + Page_Mask()) / Boot_Image_Header.Page_Size;
        }
		public static uint RAMDisk_I()
        {
			return  (Boot_Image_Header.RAMDisk_Size + Page_Mask()) / Boot_Image_Header.Page_Size;
        }
		public static uint Second_I()
        {
			return (Boot_Image_Header.Second_Size + Page_Mask()) / Boot_Image_Header.Page_Size;
        }
		public static uint DTB_I()
        {
			return (Boot_Image_Header.DT_Size + Page_Mask()) / Boot_Image_Header.Page_Size;
        }

		public static uint Total_Size()
        {
			return (1 + Kernel_I() + RAMDisk_I() + Second_I() + DTB_I()) * Boot_Image_Header.Page_Size;
        }
		public static uint Kernel_Offset()
        {
       		return Boot_Image_Header.Page_Size;
        }
		public static uint RAMDisk_Offset()
        {
			return (1 + Kernel_I()) * Boot_Image_Header.Page_Size;
        }
		public static uint Second_Offset()
        {
			return (1 + Kernel_I() + RAMDisk_I()) * Boot_Image_Header.Page_Size;
        }
		public static uint DTB_Offset()
        {
			return (1 + Kernel_I() + RAMDisk_I() + Second_I()) * Boot_Image_Header.Page_Size;
        }		
	}
}
