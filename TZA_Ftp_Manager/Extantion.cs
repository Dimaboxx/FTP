using FTP_client_lib;
using Device_lib;
using FluentFTP;

namespace Device_Manager
{

    public static class FTPDeviceExtensions
    {
        public static FTP_Task_param toFTPTaskParam(this Device device)
        {
            return new FTP_Task_param()
            {
                node = new FTP_Node(device.Address, device.Port,  device.User, device.Password),
                local_path = $"Users_{device.GroupCode}.txt",
                ftp_path = $"/Users/Users_{device.SauID:D4}.txt",
            };
          
        }
    }
}