using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device_lib
{
    public interface iDevRep
    {
        public List<Device> GetDevices();

        public void SaveDevaices(List<Device> devices);

    }
}
