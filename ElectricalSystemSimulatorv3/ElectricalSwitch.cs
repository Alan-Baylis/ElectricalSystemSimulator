using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulatorv3
{
    public class ElectricalSwitch
    {
        private string name;
        private ElectricalDevice firstContact;
        private ElectricalDevice secondContact;
        private bool switchState;

        // Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public ElectricalDevice FirstContact
        {
            get { return firstContact; }
            set { firstContact = value; }
        }
        public ElectricalDevice SecondContact
        {
            get { return secondContact; }
            set { secondContact = value; }
        }
        public bool SwitchState
        {
            get { return switchState; }
            set { switchState = value; }
        }

        // constructor
        public ElectricalSwitch (string name_c = "")
        {
            name = name_c;
            firstContact = new ElectricalDevice();
            secondContact = new ElectricalDevice();
            switchState = false;
        }
    }
}
