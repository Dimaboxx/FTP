using Device_lib;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;


namespace Device_Manager
{
 
    public class FakeRep : iDevRep

    {
        public FakeRep(string path = "FTPDev.json")
        {
            Path = path;
        }
        public string Path { get; set; }
        public List<Device> GetDevices()
        {
            return new List<Device>()
                {
                    new Device(name: "TST_81" ,sauid: 0081u, groupCode: "TST", address: "10.50.21.8", user: "SYSTEM", password: "666666"),

                    new Device(name: "SVO_PN1",sauid: 0001u, groupCode: "SVO", address: "172.18.01.151", user: "SYSTEM", password: "66666"),
                    new Device(name: "SVO_PN2",sauid: 0002u, groupCode: "SVO", address: "172.18.02.151", user: "SYSTEM", password: "66666"),
                    new Device(name: "SVO_PN3",sauid: 0508u, groupCode: "SVO", address: "172.18.08.151", user: "SYSTEM", password: "66666"),
                    new Device(name: "SVO_PN4",sauid: 0192u, groupCode: "SVO", address: "172.18.04.151", user: "SYSTEM", password: "66666"),
                    new Device(name: "SVO_PS1",sauid: 0099u, groupCode: "SVO", address: "172.18.03.151", user: "SYSTEM", password: "66666"),

                    new Device(name: "OVB_PN1",sauid: 0509u, groupCode: "OVB", address: "172.18.09.151", user: "SYSTEM", password: "66666"),
                    new Device(name: "OVB_PN2",sauid: 0510u, groupCode: "OVB", address: "172.18.10.151", user: "SYSTEM", password: "66666"),
                    new Device(name: "OVB_PN3",sauid: 0513u, groupCode: "OVB", address: "172.18.05.151", user: "SYSTEM", password: "66666"),
                    new Device(name: "OVB_PS1",sauid: 0514u, groupCode: "OVB", address: "172.18.06.151", user: "SYSTEM", password: "66666"),
                };
        }

        public void SaveDevaices(List<Device> devices)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

            File.WriteAllText(Path, JsonSerializer.Serialize(devices, jsonSerializerOptions));

        }


    }
}

