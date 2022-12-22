namespace Device_lib
{
    public class Device
    {   
        /// <summary>
        /// Name / Description
        /// </summary>
        public string Name { get; set; }
 
        /// <summary>
        /// sau id
        /// </summary>
        public uint SauID { get; set; }
 
        /// <summary>
        /// adress (ip/name)
        /// </summary>
        public string Address { get; set; }

        public uint Port{ get; set; }
 
        /// <summary>
        /// 0-Binary / 1-ASCII
        /// </summary>
        public uint Mode { get; set; }
        /// <summary>
        /// FTP user
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// FTP password
        /// </summary>
        public string Password { get; set; }

        public string GroupCode { get; set; }

        public Device(string name,uint sauid, string groupCode, string address, string user, string password, uint port = 22, uint mode = 0  )
        {
            Name = name;
            SauID = sauid;
            GroupCode = groupCode;
            Address = address;
            Port = port;
            Mode = mode; 
            User = user;
            Password = password;
        }
    }
}