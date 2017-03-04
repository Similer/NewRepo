using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace MetroUI.Control
{
    public static class Tsvn
    {
		static private void ExecuteProc(string command, string arg)
		{
			try
			{
				var str = string.Format("/command:{0} {1}", command, arg);

				// svn 경로 체크
				var pathString =
					str.Split(' ')
						.Where(e => e.Contains("/path:"))
						.Select(e => e.Substring(e.IndexOf(":") + 1))
						.First();

				if (Directory.Exists(pathString + "\\.svn"))
				{
					Process.Start("tortoiseproc.exe", str);
				}
				else
				{
					MessageBoxResult result = MessageBox.Show("SVN directory doesn't exist");
				}
			}
			catch(Exception e)
			{

			}
		}

        static public void Log(this string path)
		{
			ExecuteProc("log", string.Format("/path:{0}", path));
		}

		static public void Update(this string path)
		{
			ExecuteProc("update", string.Format("/path:{0}", path));
		}

		static public void Commit(this string path)
		{
			ExecuteProc("commit", string.Format("/path:{0}", path));
		}

		static public void CleanUp(this string path)
		{
			ExecuteProc("cleanup", string.Format("/path:{0}", path));
		}

		static public void Revert(this string path)
		{
			ExecuteProc("revert", string.Format("/path:{0}", path));
		}

		static public void Blame(this string path)
		{
			ExecuteProc("blame", string.Format("/path:{0}", path));
		}

		static public void Switch(this string path)
		{
			ExecuteProc("switch", string.Format("/path:{0}", path));
		}

		static public void RepoBrowser(this string path)
		{
			ExecuteProc("repobrowser", string.Format("/path:{0}", path));
		}
	}
}
