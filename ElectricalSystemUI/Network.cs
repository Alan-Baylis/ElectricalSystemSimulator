using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemUI
{
    public class Network
    {
        //PRIVATE MEMBERS
        private string name;
        private List<Device> devices;
        //PROPERTIES
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Power
        {
            get
            {
                int totalPower = 0;
                foreach (var dev in devices)
                {
                    totalPower += dev.Power;
                }
                return totalPower;
            }
        }
        public List<Device> Devices
        {
            get { return devices; }
        }
        //CONSTRUCTORS
        public Network()
        {
            devices = new List<Device>();
        }
        public Network(string name_c)
        {
            devices = new List<Device>();
            name = name_c;
        }
        //METHODS
        public void addDevice(Device newDevice)
        {
            if (!devices.Contains(newDevice))
            {
                devices.Add(newDevice);
                newDevice.Network = this;
                newDevice.isOnline = true;
            }
        }
    }
}
