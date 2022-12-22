using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FTP_client_lib
{
    public class FTP_Task_param
    {

        public FTP_Node node { get; set; }

        public string ftp_path { get; set; }

        public string local_path { get; set; }

        public FtpProgress FtpProgress { get; set; }
    
    }
}
