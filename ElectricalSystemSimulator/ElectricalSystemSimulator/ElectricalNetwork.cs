using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulator
{
    public class ElectricalNetwork
    {
        private List<ElectricalDevice> devices;

        public List<ElectricalDevice> Devices
        {
            get { return devices; }
        }

        public ElectricalNetwork()
        {
            devices = new List<ElectricalDevice>();
        }

        public int Power
        {
            get
            {
                int powerSum = 0;
                foreach (ElectricalDevice dev in Devices)
                {
                    powerSum += dev.Power;
                }
                return powerSum;
            }
        }
    }
}
