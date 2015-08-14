using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulatorv3
{
    public class ElectricalRelay : ElectricalSwitch
    {
        private ElectricalDevice relayCoil;

        public ElectricalDevice Coil
        {
            get { return relayCoil; }
            set { relayCoil = value; }
        }

        // Constructor
        public ElectricalRelay(string name_c = null)
            : base(name_c)
        {
            relayCoil = new ElectricalDevice();
        }
    }
}
