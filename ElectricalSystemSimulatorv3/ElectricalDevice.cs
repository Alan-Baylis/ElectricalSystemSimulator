using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulatorv3
{
    public class ElectricalDevice
    {
        private List<ElectricalDevice> connectedDevices;
        private int powerConsumption;

        public int PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }
        public List<ElectricalDevice> ConnectedDevices
        {
            get { return connectedDevices; }
        }

        // Constructor
        public ElectricalDevice ()
        {
            connectedDevices = new List<ElectricalDevice>();
            powerConsumption = 0;
        }
    }
}
