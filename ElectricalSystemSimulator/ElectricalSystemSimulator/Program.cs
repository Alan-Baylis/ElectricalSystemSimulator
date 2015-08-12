using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulator
{
    enum Status
    {
        e_NO_ACTION = 0,
        e_SUCCESS,
        e_FAILURE
    }

    class Program
    {
        private static List<ElectricalDevice> allDevs;
        static void Main(string[] args)
        {
            allDevs = new List<ElectricalDevice>();
            ElectricalDevice dev0 = new ElectricalDevice(1000); allDevs.Add(dev0);
            ElectricalDevice dev1 = new ElectricalDevice(-650); allDevs.Add(dev1);
            ElectricalDevice dev2 = new ElectricalDevice(-50); allDevs.Add(dev2);
            ElectricalDevice dev3 = new ElectricalDevice(-100); allDevs.Add(dev3);
            ElectricalDevice dev4 = new ElectricalDevice(-150); allDevs.Add(dev4);
            ElectricalDevice dev5 = new ElectricalDevice(-200); allDevs.Add(dev5);
            print_DeviceInfo();
            connect_Devices(dev0, dev1);
            print_DeviceInfo();
            connect_Devices(dev1, dev2);
            print_DeviceInfo();
            disconnect_Devices(dev0, dev1);
            print_DeviceInfo();
            connect_Devices(dev2, dev3);
            print_DeviceInfo();
            connect_Devices(dev0, dev1);
            print_DeviceInfo();
            connect_Devices(dev3, dev4);
            print_DeviceInfo();
            connect_Devices(dev4, dev5);
            print_DeviceInfo();

        }

        public static void connect_Devices(ElectricalDevice target, ElectricalDevice device)
        {
            target.ConnectedDevices.Add(device);
            device.ConnectedDevices.Add(target);
            target.seek_network();
            device.seek_network();
        }
        public static void disconnect_Devices(ElectricalDevice target, ElectricalDevice device)
        {
            if (!target.ConnectedDevices.Contains(device))
            {
                return;
            }
            else
            {
                target.ConnectedDevices.Remove(device);
                device.ConnectedDevices.Remove(target);
                target.seek_network();
                device.seek_network();
            }
        }
        public static void print_DeviceInfo()
        {
            Console.Write("[DP,NP]= {\t");
            foreach (ElectricalDevice dev in allDevs)
            {
                Console.Write("[{0},{1}]\t", dev.Power, dev.Network.Power);
            }
            Console.WriteLine("} ");
        }
    }
}
