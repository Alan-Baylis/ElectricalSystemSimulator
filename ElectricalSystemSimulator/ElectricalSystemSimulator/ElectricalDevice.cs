using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulator
{
    public class ElectricalDevice
    {
        private int power;
        private ElectricalNetwork network;
        private List<ElectricalDevice> connectedDevices;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public ElectricalNetwork Network
        {
            get { return network; }
            set 
            { 
                network = value;
                network.Devices.Add(this);
            }
        }
        public List<ElectricalDevice> ConnectedDevices
        {
            get { return connectedDevices; }
        }

        public ElectricalDevice ()
        {
            Power = 0;
            Network = new ElectricalNetwork();
            connectedDevices = new List<ElectricalDevice>();
        }
        public ElectricalDevice(int powerOutput)
        {
            Network = new ElectricalNetwork();
            Power = powerOutput;
            connectedDevices = new List<ElectricalDevice>();
        }
        public void seek_network()
        {
            Console.WriteLine("BEGIN seek_network()");
            Network.Devices.Remove(this);
            if (ConnectedDevices.Count == 0)
            {
                Network = new ElectricalNetwork();
            }
            else
            {
                if (Network != ConnectedDevices[0].Network)
                {
                    Network = ConnectedDevices[0].Network;
                }
            }
        }
    }
}
