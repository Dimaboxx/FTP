using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Device_lib;
using FTP_client_lib;
using System.IO;
using System.Security.Cryptography;

namespace Device_Manager
{
    internal class Manager
    {
        internal iDevRep repository;
        public void Init() { }

        public Manager()
        { 
            //repository = new JSONRep();
            repository = new JSONRep();
            
        }


        public Manager(string path)
        {
            ;
            repository = new JSONRep(path);

        }    

        public void Print()
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };
            var tst = repository.GetDevices();
            string text = JsonSerializer.Serialize(tst, jsonSerializerOptions);
            Console.Write(text);
        }

        public void Save()
        {
            repository.SaveDevaices(repository.GetDevices());
        }

        public void UploadGroup(string groupName)
        {
            var devices = repository.GetDevices().Where(d => d.GroupCode.Equals(groupName));
            var r = devices.ToList();
            if (devices.Any())
            {
               foreach (var d in devices)
                {
                    FTP_Manager.UploadFile(d.toFTPTaskParam());
                }
            }
            else
            {
                Console.WriteLine("Group not found!");
                Console.ReadLine();
            }

        }



    }
}
