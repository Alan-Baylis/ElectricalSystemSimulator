using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemv2
{
    public class Switch : Device
    {
        //PRIVATE MEMBERS
        private Device firstDevice;
        private Device secondDevice;
        private bool isSwitchClosed;

        //PROPERTIES
        public Device FirstDevice
        {
            get { return firstDevice; }
            set { firstDevice = value; }
        }
        public Device SecondDevice
        {
            get { return secondDevice; }
            set { secondDevice = value; }
        }
        public bool IsSwitchClosed
        {
            get { return isSwitchClosed; }
            set { isSwitchClosed = value; }
        }
    
        //CONSTRUCTORS
        public Switch(string name_c, Device firstDevice_c, Device secondDevice_c) : base ( name_c, 0 )
        {
            firstDevice = firstDevice_c;
            secondDevice = secondDevice_c;
            isSwitchClosed = false;
            this.connectTo(firstDevice);
            firstDevice.connectTo(this);
            updateSwitch();
        }

        //METHODS
        public void updateSwitch()
        {
            if (this.isSwitchClosed == true)
            {
                this.connectTo(secondDevice);
                secondDevice.connectTo(this);
            }
            else
            {
                this.disconnectFrom(secondDevice);
                secondDevice.disconnectFrom(this);
            }
        }
        public void toggleSwitch()
        {
            IsSwitchClosed = !IsSwitchClosed;
        }
    }
}
