using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ElectricalSystemUI
{
    public partial class Form1 : Form
    {
        static ElectricalEnvironment mainEnv;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainEnv = new ElectricalEnvironment();
        }
        public void processCommand(string input)
        {
            string[] script = { };
            bool isScriptActive = false;
            int scriptCommandCounter = 0;

            char[] whitespace = new char[] { ' ', '\t' };
            List<string> command = input.Split(whitespace).ToList<string>();
            do
            {
                switch (command[0])
                {
                    case "devadd":
                        if (command.Count == 3)
                        {
                            string deviceName = command[1];
                            int devicePower = int.Parse(command[2]);
                            mainEnv.addDevice(new Device(deviceName, devicePower));
                            printAll("After addition of " + deviceName);
                        }
                        else
                        {
                            printInvalidCommand(command.Count);
                        }
                        break;

                    case "devconn":
                        if (command.Count == 3)
                        {
                            string firstDeviceName = command[1];
                            string secondDeviceName = command[2];

                            Device firstDevice = mainEnv.getDeviceByName(firstDeviceName);
                            Device secondDevice = mainEnv.getDeviceByName(secondDeviceName);

                            if (firstDevice != null && secondDevice != null)
                            {
                                mainEnv.connectTwoDevices(firstDevice, secondDevice);
                                printAll("After connection of " + firstDevice.Name);
                            }
                            else
                            {
                                consoleWriteLine("One of the devices is null, cannot connect.");
                            }
                        }
                        else
                        {
                            printInvalidCommand(command.Count);
                        }
                        break;

                    case "devdisc":
                        if (command.Count == 3)
                        {
                            string firstDeviceName = command[1];
                            string secondDeviceName = command[2];

                            Device firstDevice = mainEnv.getDeviceByName(firstDeviceName);
                            Device secondDevice = mainEnv.getDeviceByName(secondDeviceName);

                            if (firstDevice != null && secondDevice != null)
                            {
                                mainEnv.disconnectTwoDevices(firstDevice, secondDevice);
                                printAll("After disconnection of " + firstDevice.Name + " and " + secondDevice.Name);
                            }
                            else
                            {
                                consoleWriteLine("One of the devices is null, cannot connect.");
                            }
                        }
                        else
                        {
                            printInvalidCommand(command.Count);
                        }
                        break;
                    case "swadd":
                        if (command.Count == 4)
                        {
                            string deviceName = command[1];
                            string firstDeviceName = command[2];
                            string secondDeviceName = command[3];

                            Device firstDevice = mainEnv.getDeviceByName(firstDeviceName);
                            Device secondDevice = mainEnv.getDeviceByName(secondDeviceName);
                            if (firstDevice != null && secondDevice != null)
                            {
                                mainEnv.addDevice(new Switch(deviceName, firstDevice, secondDevice));
                                printAll("After connection of switch " + deviceName + " from " + firstDevice.Name + " to " + secondDevice.Name);
                            }
                            else
                            {
                                consoleWriteLine("One of the devices is null, cannot connect.");
                            }
                        }
                        else
                        {
                            printInvalidCommand(command.Count);
                        }
                        break;
                    case "swtoggle":
                        if (command.Count == 2)
                        {
                            string switchName = command[1];
                            Switch connSwitch = (Switch)mainEnv.getDeviceByName(switchName);

                            if (connSwitch != null)
                            {
                                connSwitch.toggleSwitch();
                                mainEnv.update();
                                mainEnv.update();
                                printAll("After toggling of switch " + switchName + ", new state is " + connSwitch.IsSwitchClosed.ToString());
                            }
                            else
                            {
                                consoleWriteLine("Switch is null, cannot toggle.");
                            }
                        }
                        else
                        {
                            printInvalidCommand(command.Count);
                        }
                        break;

                    case "swset":
                        if (command.Count == 3)
                        {
                            string switchName = command[1];
                            string switchState = command[2];
                            Switch connSwitch = (Switch)mainEnv.getDeviceByName(switchName);
                            if (switchState != "1" && switchState != "0")
                            {
                                consoleWriteLine("Bad parameter " + switchState.ToString() + ", try again ('0' or '1' only).");
                                break;
                            }
                            if (connSwitch != null)
                            {
                                connSwitch.IsSwitchClosed = (switchState == "1" ? true : false);
                                mainEnv.update();
                                mainEnv.update();
                                printAll("After setting of switch " + switchName + ", new state is " + connSwitch.IsSwitchClosed.ToString());
                            }
                            else
                            {
                                consoleWriteLine("Switch is null, cannot toggle.");
                            }
                        }
                        else
                        {
                            printInvalidCommand(command.Count);
                        }
                        break;
                    case "reladd":
                        // reladd <relayName> <coilPower> <driveDeviceName> <FirstDeviceName> <SecondDeviceName>
                        if (command.Count == 7)
                        {
                            string relayName = command[1];
                            int coilPower = int.Parse(command[2]);
                            bool isNC = (int.Parse(command[3]) == 1 ? true : false);
                            Device driverDevice = mainEnv.getDeviceByName(command[4]);
                            Device firstDevice = mainEnv.getDeviceByName(command[5]);
                            Device secondDevice = mainEnv.getDeviceByName(command[6]);
                            Relay newRelay = new Relay(relayName, coilPower, isNC, driverDevice, firstDevice, secondDevice);

                            if (driverDevice != null && (firstDevice != null && secondDevice != null))
                            {
                                mainEnv.addRelay(newRelay);
                                mainEnv.update();
                                printAll("After adding relay " + relayName + ", coil connected to " + driverDevice.Name + ", switch connecting " + firstDevice.Name + " to " + secondDevice.Name);
                            }
                            else
                            {
                                consoleWriteLine("Switch is null, cannot toggle.");
                            }
                        }
                        else
                        {
                            printInvalidCommand(command.Count);
                        }
                        break;
                    //update manually
                    case "update":
                        mainEnv.update();
                        printAll("MANUAL UPDATE");
                        break;
                    //script file read
                    case "fo":
                        if (command.Count == 2)
                        {
                            if (!isScriptActive)
                            {
                                isScriptActive = true;
                                string fileName = command[1];
                                string[] scriptFile = { };
                                try
                                {
                                    scriptFile = File.ReadAllLines(fileName);
                                }
                                catch (FileNotFoundException)
                                {
                                    consoleWriteLine("Invalid file.");
                                }
                                List<string> commandList = new List<string>(scriptFile);
                                int commandCount = commandList.Count;
                                while (scriptCommandCounter < commandCount)
                                {
                                    processCommand(commandList[scriptCommandCounter]);
                                    scriptCommandCounter++;
                                }
                                isScriptActive = false;
                            }
                            else
                            {
                                consoleWriteLine("Already executing script, cannot recursively execute scripts.");
                            }
                        }
                        else
                        {
                            printInvalidCommand(command.Count);
                        }
                        break;
                    default:
                        printInvalidCommand(command.Count);
                        break;
                }
            }
            while (isScriptActive);
        }
        public void consoleWriteLine(string text)
        {
            consoleTextBox.AppendText(text + Environment.NewLine);
        }
        public void consoleWrite(string text)
        {
            consoleTextBox.Text += text;
        }
        private void printInvalidCommand(int commandCount)
        {
            consoleWriteLine("Bad command, try again. (size=" + commandCount.ToString() + ")");
        }
        public void printAll(string message)
        {
            consoleWriteLine("**** " + message + ":\n");
            
            consoleWrite("MainEnvironment:\n");
            if (mainEnv.Networks.Count == 0)
            {
                consoleWriteLine("EMPTY\n");
            }
            else foreach (var net in mainEnv.Networks)
                {
                    consoleWrite(net.Name + "(" + net.Power + ")=[");
                    foreach (var dev in net.Devices)
                    {
                        consoleWrite(dev.Name + "(" + dev.Power + "), ");
                    }
                    consoleWriteLine("]");
                }
            consoleWrite("All devices:\n");
            if (mainEnv.Devices.Count == 0)
            {
                consoleWriteLine("NO DEVICES");
            }
            else foreach (Device dev in mainEnv.Devices)
                {
                    consoleWrite(dev.Name + ", ");
                }
            consoleWriteLine("\n");
        
        }

        private void commandTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitButton_Click(this, new EventArgs());
            }
        }

        private void updateEnvironmentTreeView()
        {
            // Start with clean slate
            environmentTreeView.Nodes.Clear();

            // Add Environment node
            TreeNode envNode = environmentTreeView.Nodes.Add("Environment");

            // Add all devices and networks as children
            //TreeNode envDevs = envNode.Nodes.Add("Devices");
            TreeNode envNets = envNode.Nodes.Add("Networks");

            //foreach(Device dev in mainEnv.Devices)
            //{
            //    TreeNode devNode = envDevs.Nodes.Add(dev.Name);
            //    devNode.Nodes.Add("Power").Nodes.Add(dev.Power.ToString());
            //    devNode.Nodes.Add("Network").Nodes.Add(dev.Network.Name);
            //    TreeNode connDevs = devNode.Nodes.Add("Connected Devices");
            //    foreach (Device connDev in dev.ConnectedDevices)
            //    {
            //        connDevs.Nodes.Add(connDev.Name);
            //    }
            //}

            foreach (Network net in mainEnv.Networks)
            {
                TreeNode netNode = envNets.Nodes.Add(net.Name);
                netNode.Nodes.Add("Power").Nodes.Add(net.Power.ToString());
                TreeNode devs = netNode.Nodes.Add("Devices");
                foreach (Device dev in net.Devices)
                {
                    devs.Nodes.Add(dev.Name).Nodes.Add("Power").Nodes.Add(dev.Power.ToString());
                }
            }
            envNode.ExpandAll();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string input = commandTextBox.Text;
            commandTextBox.Text = "";
            processCommand(input);
            //updateEnvironmentTreeView();
        }
    }
}
