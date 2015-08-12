using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            ElectricalNetwork net0 = new ElectricalNetwork(1);
            net0.add_connectedDevice(new ElectricalDevice(100, 1));
            net0.add_connectedDevice(new ElectricalDevice(-30, 2));
            net0.print_connectedDevices();
            Console.WriteLine("Total power on network = {0}", net0.get_powerSum());

        }
    }
}
