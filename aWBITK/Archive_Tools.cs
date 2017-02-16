/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 23.11.2015.
 * Time: 15:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.IO.Compression;

namespace aWBITK
{
	/// <summary>
	/// Description of Archive_Tools.
	/// </summary>
	public class Archive_Tools
	{
		void GZ_Compress(string infile, string outputFile)
		{
			FileStream in_fs = File.OpenRead(infile);
			FileStream out_fs = File.Create(outputFile);
			 
			GZipStream gz_fs = new GZipStream(out_fs, CompressionMode.Compress);
			 
			byte[] bytes = new byte[2048];
			int bytesRead;
			
			while ((bytesRead = in_fs.Read(bytes, 0, bytes.Length)) != 0 )
			{
		    	gz_fs.Write(bytes, 0, bytesRead);
			}

			in_fs.Close();
			gz_fs.Close();
			out_fs.Close();
		}
		void GZ_DeCompress(string infile, string outputFile)
		{
			FileStream in_fs = File.OpenRead(infile);
			FileStream out_fs= File.Create(outputFile);
			 
			GZipStream gz_fs = new GZipStream(in_fs, CompressionMode.Decompress);
			byte[] bytes = new byte[2048];
			int bytesRead;
			
			while ((bytesRead = gz_fs.Read(bytes, 0, bytes.Length)) != 0 )
			{
		    	out_fs.Write(bytes,0, bytesRead);
			}
		    
			gz_fs.Close();
			in_fs.Close();
			out_fs.Close();
		}	

	}
}
