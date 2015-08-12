using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulatorv3
{
    public class ElectricalNetwork
    {
        private List<ElectricalDevice> devices;

        public List<ElectricalDevice> Devices
        {
            get { return devices; }
        }

        public ElectricalNetwork ()
        {
            devices = new List<ElectricalDevice>();
        }

        public int NetPower
        {
            get
            {
                int netpower = 0;
                foreach(var device in Devices)
                {
                    netpower += device.PowerConsumption;
                }
                return netpower;
            }
        }
        public int NetGenerativePower
        {
            get
            {
                int netgenpower = 0;
                foreach (var device in Devices)
                {
                    if (device.PowerConsumption > 0) { netgenpower += device.PowerConsumption; }
                }
                return netgenpower;
            }
        }
        public int NetConsumingPower
        {
            get
            {
                int netconpower = 0;
                foreach (var device in Devices)
                {
                    if (device.PowerConsumption < 0) { netconpower += device.PowerConsumption; }
                }
                return netconpower;
            }
        }
        public int DeviceCount
        {
            get { return Devices.Count; }
        }
        public int GenerativeDeviceCount
        {
            get 
            {
                var count = 0;
                foreach (var device in Devices)
                {
                    if (device.PowerConsumption < 0) { count++; }
                }
                return count;
            }
        }
        public int ConsumingDeviceCount
        {
            get
            {
                var count = 0;
                foreach (var device in Devices)
                {
                    if (device.PowerConsumption > 0) { count++; }
                }
                return count;
            }
        }
    }
}
