using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulator
{
    public class ElectricalDevice
    {
        private int deviceId;
        private double powerOutput;
        private bool isPowered;

        public double get_powerOutput()
        {
            return powerOutput;
        }
        public void set_powerOutput(double value)
        {
            powerOutput = value;
        }

        public ElectricalDevice(double powerOutput_c)
        {
            powerOutput = powerOutput_c;
            isPowered = false;
            Console.WriteLine("New electrical device #{1} created, with power output of {0}.", powerOutput, deviceId);
        }
        public ElectricalDevice(double powerOutput_c, int deviceId_c)
        {
            powerOutput = powerOutput_c;
            deviceId = deviceId_c;
            isPowered = false;
            Console.WriteLine("New electrical device #{1} created, with power output of {0}.", powerOutput, deviceId);
        }
        public int get_Id()
        {
            return deviceId;
        }
        public void set_isPowered(bool value)
        {
            isPowered = value;
            if (isPowered)
            {
                Console.WriteLine("Device #{0} is powered on.", deviceId);
            }
            else
            {
                Console.WriteLine("Device #{0} is powered off.", deviceId);
            }
        }
    }
}
