using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulatorv3
{
    public class ElectricalRelaySPST : ElectricalSwitch
    {
        private ElectricalDevice relayCoil;
        private bool normallyClosed;
        public ElectricalDevice Coil
        {
            get { return relayCoil; }
            set { relayCoil = value; }
        }
        public bool NormallyClosed
        {
            get { return normallyClosed; }
            set { normallyClosed = value; }
        }

        // Constructor
        public ElectricalRelaySPST(string name_c = null)
            : base(name_c)
        {
            relayCoil = new ElectricalDevice();
            normallyClosed = false;
        }
    }
}
