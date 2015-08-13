using ElectricalSystemSimulatorv3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricalSystemSimulatorv3_GUI
{
    public partial class ElectricalSimulatorForm : Form
    {
        private ElectricalEnvironment env;
        public ElectricalSimulatorForm()
        {
            InitializeComponent();
            env = new ElectricalEnvironment();
            textBoxCommandLine.KeyUp += CommandLineKeyUp;
        }

        private void CommandLineKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CommandLineExecute();
                e.Handled = true;
            }
        }

        #region Command Line Parser
        private void CommandLineExecute()
        {
            ConsoleClear();
            var sb = new StringBuilder();
            var commandString = textBoxCommandLine.Text;
            textBoxCommandLine.Text = "";
            var commandArgs = commandString.Split(' ','\t').ToList<string>();
            var command = commandArgs[0];
            var cmdCnt = commandArgs.Count;
            switch(command)
            {
                case "device":
                    #region ElectricalDevice case
                    if (cmdCnt == 1)
                    {
                        sb.Append("Invalid command.");
                    }
                    else
                    {
                        
                        var arg1 = commandArgs[1];
                        switch(arg1)
                        {
                            case "add":
                                if (cmdCnt != 3) sb.Append("Invalid amount of arguments.");
                                else
                                {
                                    var deviceName = commandArgs[2];
                                    var newDevice = env.CreateDevice(deviceName);
                                    if (newDevice == null)
                                    {
                                        sb.Append("A device with this name already exists.");
                                    }
                                    else 
                                    {
                                        sb.Append("New Device \"" + newDevice.Name + "\" successfully created."); 
                                    }
                                }
                                break;
                            case "remove":
                                if (cmdCnt != 3) sb.Append("Invalid amount of arguments.");
                                else
                                {
                                    var deviceName = commandArgs[2];
                                    if (env.FindDeviceByName(deviceName) == null)
                                    {
                                        sb.Append("No such device exists.");
                                    }
                                    else
                                    {
                                        env.RemoveDevice(env.FindDeviceByName(deviceName));
                                        sb.Append("Device \"" + deviceName + "\" has been deleted.");
                                    }
                                }
                                break;
                            case "connect":
                                if (cmdCnt != 4) sb.Append("Invalid amount of arguments.");
                                else
                                {
                                    var dev1Name = commandArgs[2];
                                    var dev2Name = commandArgs[3];
                                    if (env.FindDeviceByName(dev1Name) == null || env.FindDeviceByName(dev1Name) == null)
                                    {
                                        sb.Append("One or both of the devices doesn't exist.");
                                    }
                                    else
                                    {
                                        var dev1 = env.FindDeviceByName(dev1Name);
                                        var dev2 = env.FindDeviceByName(dev2Name);
                                        if (dev1 == null)
                                        {
                                            sb.Append("First device does not exist.");
                                        }
                                        else if (dev2 == null)
                                        {
                                            sb.Append("Second device does not exist.");
                                        }
                                        else
                                        {
                                            env.ConnectDevices(dev1, dev2);
                                            sb.Append("Devices \"" + dev1Name + "\" and \"" + dev2Name + "\" are now connected.");
                                            sb.Append("dev1.ConnectDevices[0]=" + dev1.ConnectedDevices[0].Name + ", dev2.ConnectedDevices[0]=" + dev2.ConnectedDevices[0].Name);
                                        }
                                    }
                                }
                                break;
                            case "disconnect":
                                if (cmdCnt != 4) sb.Append("Invalid amount of arguments.");
                                else
                                {
                                    var dev1Name = commandArgs[2];
                                    var dev2Name = commandArgs[3];
                                    if (env.FindDeviceByName(dev1Name) == null || env.FindDeviceByName(dev2Name) == null)
                                    {
                                        sb.Append("One or both of the devices doesn't exist.");
                                    }
                                    else
                                    {
                                        env.DisconnectDevices(env.FindDeviceByName(dev1Name), env.FindDeviceByName(dev2Name));
                                        sb.Append("Devices \"" + dev1Name + "\" and \"" + dev2Name + "\" are now disconnected.");
                                    }
                                }
                                break;
                            default:
                                sb.Append("Invalid command.");
                                break;
                        }
                    }
                    #endregion
                    break;
                case "switch":
                    #region ElectricalSwitch case

                    if (cmdCnt == 1)
                    {
                        sb.Append("Invalid command.");
                    }
                    else
                    {
                        var arg1 = commandArgs[1];
                        switch(arg1)
                        {
                            case "add":
                                if (cmdCnt != 3) sb.Append("Invalid amount of arguments.");
                                else
                                {
                                    var switchName = commandArgs[2];
                                    var newSwitch = env.CreateSwitch(switchName);
                                    if (newSwitch == null)
                                    {
                                        sb.Append("A switch with this name already exists.");
                                    }
                                    else
                                    {
                                        sb.Append("New Device \"" + newSwitch.Name + "\" successfully created.");
                                    }
                                }
                                break;
                            case "remove":
                                if (cmdCnt != 3) sb.Append("Invalid amount of arguments.");
                                else
                                {
                                    var switchName = commandArgs[2];
                                    if (env.FindSwitchByName(switchName) == null)
                                    {
                                        sb.Append("No such device exists.");
                                    }
                                    else
                                    {
                                        var sw = env.FindSwitchByName(switchName);
                                        env.RemoveSwitch(sw);
                                        sb.Append("Device \"" + sw.Name + "\" has been deleted.");
                                    }
                                }
                                break;
                            case "connect":
                                if (cmdCnt != 5) sb.Append("Invalid arguments.");
                                else
                                {
                                    var sw = env.FindSwitchByName(commandArgs[2]);
                                    var dev1 = env.FindDeviceByName(commandArgs[3]);
                                    var dev2 = env.FindDeviceByName(commandArgs[4]);
                                    if (sw == null) sb.Append("Switch does not exist.");
                                    else if (dev1 == null) sb.Append("First device does not exist.");
                                    else if (dev2 == null) sb.Append("Second device does not exist.");
                                    else
                                    {
                                        env.ConnectDevices(sw.FirstContact, dev1);
                                        env.ConnectDevices(sw.SecondContact, dev2);
                                        sb.Append("Switch " + sw.Name + " is now connected to " + dev1.Name + " and " + dev2.Name + ".");
                                    }
                                }
                                break;
                            case "disconnect":
                                break;
                            case "state":
                                break;
                            default:
                                sb.Append("Invalid command.");
                                break;
                        }
                    }

                    #endregion
                    break;
                default:
                    break;
            }
            ConsoleWrite(sb.ToString() + Environment.NewLine);
            print_update();
            
        }
        #endregion

        private void ConsoleWrite(string text)
        {
            textBoxConsoleOutput.Text += text;
        }
        private void ConsoleWriteLine(string text)
        {
            textBoxConsoleOutput.Text += text + Environment.NewLine;
        }
        private void ConsoleClear()
        {
            textBoxConsoleOutput.Text = "";
        }

        private string PrintDevices()
        {
            var sb = new StringBuilder();
            sb.Append("Devices = [ ");
            foreach (var dev in env.Devices)
            {
                sb.Append(getDeviceName(dev) + ", ");
            }
            sb.Append("]");
            return sb.ToString();
        }
        private string PrintNetworks()
        {
            var netList = env.UpdateNetworks();
            var sb = new StringBuilder();
            sb.Append("Networks = {" + Environment.NewLine);
            foreach (var net in netList)
            {
                sb.Append("N" + net.GetHashCode().ToString() + " = [ ");
                foreach (var dev in net.Devices)
                {
                    sb.Append(getDeviceName(dev) + ", ");
                }
                sb.Append("]" + Environment.NewLine);
            }
            sb.Append("}");
            return sb.ToString();

        }
        private string PrintSwitches()
        {
            var swList = env.Switches;
            var sb = new StringBuilder();
            sb.Append("Switches = {" + Environment.NewLine);
            foreach (var sw in swList)
            {
                sb.Append(getSwitchName(sw) + ", ");
                sb.Append(" = { " + getDeviceName(sw.FirstContact) + ", " + getDeviceName(sw.SecondContact) + " }" + Environment.NewLine);
            }
            sb.Append("}");
            return sb.ToString();

        }
        private string PrintLookup()
        {
            var sb = new StringBuilder();
            var lookup = env.DeviceLookup;
            sb.Append("Lookup:" + Environment.NewLine);
            foreach(var pair in lookup)
            {
                sb.Append(getDeviceName(pair.Key) + ":\tN" + pair.Value.GetHashCode() + Environment.NewLine);
            }
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
        private void print_update()
        {
            ConsoleWriteLine("******************************************************" + Environment.NewLine);
            ConsoleWriteLine(PrintDevices() + Environment.NewLine);
            ConsoleWriteLine(PrintSwitches() + Environment.NewLine);
            ConsoleWriteLine(PrintNetworks() + Environment.NewLine);
            ConsoleWriteLine(PrintLookup() + Environment.NewLine);
        }

        private string getDeviceName(ElectricalDevice dev)
        {
            return dev.Name;
        }
        private string getSwitchName(ElectricalSwitch sw)
        {
            return sw.Name;
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            CommandLineExecute();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            print_update();
        }
    }
}
