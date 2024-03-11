using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace AntiGamesBuild
{
    class Program
    {
        static void Main(string[] args)
        {
			string ip = "http://localhost:8080//";
			WebClient webClient = new WebClient();
			while (true)
			{
				Thread.Sleep(500);
				Process[] processes = Process.GetProcesses();
				try
				{
					foreach (Process process in processes)
					{
						if (!string.IsNullOrEmpty(process.MainWindowTitle))
						{
							foreach (string text2 in process.MainWindowTitle.Split(new char[] { ' ' }))
							{
								if (webClient.DownloadString(ip) == "True" && webClient.DownloadString(ip + "check?word=" + text2.ToLower()) == "True")
								{
									process.Kill();
									
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					//MessageBox.Show(ex.ToString(), "Error");
				}
			}
		}
    }
}
