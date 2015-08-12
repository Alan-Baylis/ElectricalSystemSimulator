using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemv2
{
    public class Relay
    {
        //PRIVATE MEMBERS
        private string name;
        private Device coil;
        private Switch inSwitch;
        private bool isNormallyClosed;

        //PROPERTIES
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Device Coil
        {
            get { return coil; }
            set { coil = value; }
        }
        public Switch Switch
        {
            get { return inSwitch; }
            set { inSwitch = value; }
        }
        public bool State
        {
            get { return Switch.IsSwitchClosed; }
        }
        public bool IsNormallyClosed
        {
            get { return isNormallyClosed; }
            set { isNormallyClosed = value; }
        }

        //CONSTRUCTOR
        public Relay (string name_c, int power_c, bool isNC, Device driverDevice, Device firstDevice, Device secondDevice)
        {
            name = name_c;
            isNormallyClosed = isNC;
            coil = new Device("coil[" + name_c + "]", power_c);
            inSwitch = new Switch("switch[" + name_c + "]", firstDevice, secondDevice);
            coil.connectTo(driverDevice);
            driverDevice.connectTo(coil);
            updateRelay();
        }

        //METHODS
        public void updateRelay()
        {
            if (Coil.Network == null)
            {
                this.Switch.IsSwitchClosed = isNormallyClosed;
            }
            else
            {
                if (Coil.Network.Power < 0)
                {
                    this.Switch.IsSwitchClosed = isNormallyClosed;
                }
                else
                {
                    this.Switch.IsSwitchClosed = !isNormallyClosed;
                }
            }
        }
    }
}
