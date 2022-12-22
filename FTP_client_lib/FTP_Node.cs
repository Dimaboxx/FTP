namespace FTP_client_lib
{
    public class FTP_Node
    {
        /// <summary>
        /// adress (ip/name)
        /// </summary>
        public string Adress { get; set; }
 
        /// <summary>
        /// port number for connection
        /// </summary>
        public uint Port{ get; set; }

        /// <summary>
        /// 0-Binary / 1-ASCII
        /// </summary>
        public uint TransferMode { get; set; }
 
        /// <summary>
        /// 0-Binary / 1-ASCII
        /// </summary>
        public uint ListingMode { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Password of ftp server
        /// </summary>
        public string Password { get; set; }
        public FTP_Node(string address, uint port,  string user, string password, uint transferMode = 0, uint listingMode = 1)
        {
            Adress = address;
            Port = port;
            TransferMode = transferMode;
            ListingMode = listingMode;
            User = user;
            Password = password;

        }
    }
}