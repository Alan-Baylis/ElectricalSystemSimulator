using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulator
{
    public class ElectricalNetwork
    {
        private int networkId;
        private List<ElectricalDevice> connectedDevices;

        public ElectricalNetwork()
        {
            connectedDevices = new List<ElectricalDevice>();
            networkId = -1;
            Console.WriteLine("New electrical network #{0} created.", networkId);
        }
        public ElectricalNetwork(int networkId_c)
        {
            connectedDevices = new List<ElectricalDevice>();
            networkId = networkId_c;
            Console.WriteLine("New electrical network #{0} created.", networkId);
        }

        public List<ElectricalDevice> get_connectedDevices()
        {
            return connectedDevices;
        }
        public void add_connectedDevice(ElectricalDevice newDevice)
        {
            //if (!connectedDevices.Contains(newDevice) )
            //{
                connectedDevices.Add(newDevice);
            //}
        }
        public bool remove_connectedDevice(ElectricalDevice oldDevice )
        {
            if( connectedDevices.Contains(oldDevice) )
            {
                connectedDevices.Remove(oldDevice);
            }
            if( connectedDevices.Contains(oldDevice) )
            {
                return false;
            }
            else return true;
        }
        public void print_connectedDevices()
        {
            Console.WriteLine("List of connected device on network #{0}:", networkId);
            foreach (ElectricalDevice dev in connectedDevices)
            {
                Console.WriteLine("Connected device: #{0} P={1}", dev.get_Id(), dev.get_powerOutput());
            }
        }
        public double get_powerSum()
        {
            double powerSum = 0;
            foreach (ElectricalDevice dev in connectedDevices)
            {
                powerSum += dev.get_powerOutput();
            }
            return powerSum;
        }
    }
}
