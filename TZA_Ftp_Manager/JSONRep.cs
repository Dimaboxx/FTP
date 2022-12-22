using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Device_lib;


namespace Device_Manager
{
    public  class JSONRep: iDevRep

    {
        public JSONRep(string path = "FTPDev.json")
        {
           Path = path;
        }
        public string Path { get; set; }
 
        public List<Device> GetDevices( )
        {
            if (!File.Exists(Path))
            {
//// TODO 
                return null;
            }
            var res = JsonSerializer.Deserialize<List<Device>>(File.ReadAllText(Path));
            return res;
        }

        public  void SaveDevaices(List<Device> devices)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

            File.WriteAllText(Path, JsonSerializer.Serialize(devices, jsonSerializerOptions));

        }


    }
}
