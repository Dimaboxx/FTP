using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;

namespace Examples
{

	internal static class UploadFileExample
	{
		/// <summary>
		/// https://github.com/robinrodricks/FluentFTP/blob/master/FluentFTP.CSharpExamples/UploadFile.cs
		/// https://github.com/robinrodricks/FluentFTP/blob/master/FluentFTP.CSharpExamples/UploadFileWithProgress.cs
		/// </summary>

		public static void UploadFile()
		{


			//			var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest");

			using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest") { DownloadDataType = FtpDataType.Binary })
			{
				ftp.Connect();

				// upload a file to an existing FTP directory
				ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md");

				// upload a file and ensure the FTP directory is created on the server
				ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true);

				// upload a file and ensure the FTP directory is created on the server, verify the file after upload
				ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, FtpVerify.Retry, progress: delegate (FtpProgress ftpProgress) { Console.WriteLine($"{DateTime.Now} {ftpProgress.Progress}"); });

			}
		}

		public static async Task UploadFileAsync()
		{
			var token = new CancellationToken();
			using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest"))
			{
				await ftp.ConnectAsync(token);

				// upload a file to an existing FTP directory
				await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", token: token);

				// upload a file and ensure the FTP directory is created on the server
				await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, token: token);

				// upload a file and ensure the FTP directory is created on the server, verify the file after upload
				await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, FtpVerify.Retry, token: token);

			}
		}
		internal static class UploadFileWithProgressExample
		{

			public static void UploadFile()
			{
				using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest"))
				{
					ftp.Connect();

					// define the progress tracking callback
					Action<FtpProgress> progress = delegate (FtpProgress p)
					{
						if (p.Progress == 1)
						{
							// all done!
						}
						else
						{
							// percent done = (p.Progress * 100)
						}
					};

					// upload a file with progress tracking
					ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, false, FtpVerify.None, progress);

				}
			}

			public static async Task UploadFileAsync()
			{
				var token = new CancellationToken();
				using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest"))
				{
					await ftp.ConnectAsync(token);

					// define the progress tracking callback
					Progress<FtpProgress> progress = new Progress<FtpProgress>(p =>
					{
						if (p.Progress == 1)
						{
							// all done!
						}
						else
						{
							// percent done = (p.Progress * 100)
						}
					});

					// upload a file with progress tracking
					await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, false, FtpVerify.None, progress, token);

				}
			}


		}
	}
}