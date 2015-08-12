using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemv2
{
    public class Device
    {
        //PRIVATE MEMBERS
        private bool bOnline;
        private string name;
        private int power;
        private Network network;
        private List<Device> connectedDevices;

        //PROPERTIES
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public bool isOnline
        {
            get { return bOnline; }
            set { bOnline = value; }
        }
        public Network Network
        {
            get { return network; }
            set { network = value; }
        }

        public List<Device> ConnectedDevices
        {
            get { return connectedDevices; }
        }
                   
        //CONSTRUCTORS
        public Device()
        {
            Power = 0;
            connectedDevices = new List<Device>();
            bOnline = false;
        }
        public Device(string name_c, int power_c)
        {
            name = name_c;
            Power = power_c;
            connectedDevices = new List<Device>();
            bOnline = false;
        }

        //METHODS
        public void connectTo(Device newDevice)
        {
            if (!connectedDevices.Contains(newDevice))
            {
                connectedDevices.Add(newDevice);
            }
        }
        public void disconnectFrom(Device oldDevice)
        {
            if (connectedDevices.Contains(oldDevice))
            {
                connectedDevices.Remove(oldDevice);
            }
        }
        public bool isConnectedTo(Device dev)
        {
            bool isConnected = false;
            if (connectedDevices.Contains(dev))
            {
                isConnected = true;
            }
            return isConnected;
        }
    }
}
