//*****************************************************
// * Electrical System Simulator version 3
// * By BodyweightEnergy
// * Initial concept for Rust Experimental
// * **************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulatorv3
{
    public class ElectricalDevice
    {
        private string name;
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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Constructor
        public ElectricalDevice (string name_c = null)
        {
            if (!string.IsNullOrEmpty(name_c)) { name = name_c; }
            else { name = "D" + this.GetHashCode().ToString("00000000"); }
            connectedDevices = new List<ElectricalDevice>();
            powerConsumption = 0;
        }
    }
}
