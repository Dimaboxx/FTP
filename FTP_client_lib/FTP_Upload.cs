using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FTP_client_lib
{
    public static class FTP_Manager
    {
        public static void UploadFile(FTP_Task_param fTP_Task_Param)
        {
            using (var ftp = new FtpClient(fTP_Task_Param.node.Adress, fTP_Task_Param.node.User, fTP_Task_Param.node.Password))
            {
                ftp.UploadDataType = CovertIntToFTPDataType(fTP_Task_Param.node.TransferMode);
                ftp.ListingDataType = CovertIntToFTPDataType(fTP_Task_Param.node.ListingMode);
                ftp.DataConnectionType = FtpDataConnectionType.PORT;

                try
                {
                    ftp.Connect();
                }
               catch (TimeoutException )
                {
                    Console.WriteLine($"{fTP_Task_Param.node.Adress} соединение не установлено");
                    return;
               }
                catch (AuthenticationException )
                {
                    Console.WriteLine($"{fTP_Task_Param.node.Adress} не верные логин/пароль");
                }

                Action<FtpProgress> progress = delegate (FtpProgress p)
                {
                    Console.WriteLine($"current file progress : {p.Progress}%");
                };
                if (!ftp.IsConnected)
                {
                    Console.WriteLine("connection fail");
                    return;
                }
                if (!ftp.IsAuthenticated)
                {
                    Console.WriteLine("login fail");
                    return;
                }

               var s = ftp.UploadFile(fTP_Task_Param.local_path, fTP_Task_Param.ftp_path, FtpRemoteExists.Overwrite, false, FtpVerify.None, progress);
               Console.WriteLine(s.ToString());
            }
        }
        
        private static FtpDataType CovertIntToFTPDataType(uint mode)
        {
            return mode==0?FtpDataType.Binary:FtpDataType.ASCII;
        }
    }
}
