using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace pulire
{
	internal class Program
	{
		static void Main()
		{
			/*
			//Process.Start("C:\\Users\\ldamo\\OneDrive\\Desktop");
			Directory.SetCurrentDirectory("C:\\");
			try
			{
			string[] files = Directory.GetFiles(".", "*.*", SearchOption.AllDirectories);
			}
			catch(UnauthorizedAccessException e)
			{
				Console.WriteLine(e.Message);
				//continue;
			}
			*/
			Console.Write("admin rights + full screen? any key for yes..");
			Console.ReadKey(true);
			Console.WriteLine("  started");

			Directory.SetCurrentDirectory("C:\\");
			var files = GetAllAccessibleFiles("C:\\");
			//Console.WriteLine(string.Join(" | ", files));
			Console.WriteLine("\n\n"+files.Count+"\n");
			foreach(string path in files)
			{
				if(File.Exists(path))
				{
					string len = BytesToString(new FileInfo(path).Length);
					if(!len.EndsWith("By") && !len.EndsWith("KB"))
						if(len.EndsWith("MB"))
						{
							float syze = float.Parse(len.Substring(0, len.Length - 2));
							if(syze > 100)
							{
								Process.Start(Path.GetDirectoryName(path));
								Console.WriteLine(path + "\t\t" + syze + "MB");
							}
						}
						else
						{
							Process.Start(Path.GetDirectoryName(path));
							Console.WriteLine(path + "\t\t" + len);
						}
				}
			}

			Console.WriteLine("\n\n\nend");
			Console.ReadKey(true);
		}
		public static List<string> GetAllAccessibleFiles(string rootPath, List<string> alreadyFound = null)
		{
			if(alreadyFound == null)
				alreadyFound = new List<string>();
			//if(rootPath == "C:\\Windows\\System32\\LogFiles\\WMI\\RtBackup")
			//return alreadyFound;
			if(!CanRead(rootPath))
				return alreadyFound;
			DirectoryInfo di = new DirectoryInfo(rootPath);
			var dirs = di.EnumerateDirectories();
			foreach(DirectoryInfo dir in dirs)
			{
				if(!((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
				{
					alreadyFound = GetAllAccessibleFiles(dir.FullName, alreadyFound);
				}
			}

			var files = Directory.GetFiles(rootPath);
			foreach(string s in files)
			{
				alreadyFound.Add(s);
			}
			if(alreadyFound.Count%1000 == 0)
				Console.Write(alreadyFound.Count + " | ");
			return alreadyFound;
		}
		public static bool CanRead(string path)
		{
			try
			{
				bool readAllow = false;
				bool readDeny = false;
				DirectorySecurity accessControlList = Directory.GetAccessControl(path);
				if(accessControlList == null)
					return false;

				//get the access rules that pertain to a valid SID/NTAccount.
				AuthorizationRuleCollection accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
				if(accessRules ==null)
					return false;

				//we want to go over these rules to ensure a valid SID has access
				foreach(FileSystemAccessRule rule in accessRules)
				{
					if((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

					if(rule.AccessControlType == AccessControlType.Allow)
						readAllow = true;
					else if(rule.AccessControlType == AccessControlType.Deny)
						readDeny = true;
				}

				return readAllow && !readDeny;
			}
			catch(UnauthorizedAccessException)
			{
				return false;
			}
		}
		static String BytesToString(long byteCount)
		{
			string[] suf = { "By", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
			if(byteCount == 0)
				return "0" + suf[0];
			long bytes = Math.Abs(byteCount);
			int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
			double num = Math.Round(bytes / Math.Pow(1024, place), 1);
			return (Math.Sign(byteCount) * num).ToString() + suf[place];
		}
	}
}
