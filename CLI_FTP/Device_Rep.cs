using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device_lib

{
    public class Rep 
    {
        public List<Device> Devices { get; set; }

        public Rep()
        {
            Devices = new List<Device>();  
        }
        public Rep(List<Device> devices)
        {
            Devices = devices;
        }

        public void AddDevice (Device device)
        {
           Devices?.Add(device);
       }

        public List<Device> GetDevices()
        {
            return Devices;
        }

 
    }
}
