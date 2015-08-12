using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemv2
{
    class Program
    {
        static ElectricalEnvironment mainEnv;
        static void Main(string[] args)
        {
        
            mainEnv = new ElectricalEnvironment();
            
            string input = "";
            while (input != "QUIT")
            {
                input = Console.ReadLine();
                processCommand(input);
                
            }
            
        }
        static void processCommand(string input)
        {
            string[] script = { };
            bool isScriptActive = false;
            int scriptCommandCounter = 0;

            char[] whitespace = new char[] { ' ','\t' };
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
                            mainEnv.printAll("After addition of " + deviceName);
                        }
                        else
                        {
                            Console.WriteLine("Bad command, try again. (size={0})", command.Count);
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
                                mainEnv.printAll("After connection of " + firstDevice.Name);
                            }
                            else
                            {
                                Console.WriteLine("One of the devices is null, cannot connect.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad command, try again. (size={0})", command.Count);
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
                                mainEnv.printAll("After disconnection of " + firstDevice.Name + " and " + secondDevice.Name);
                            }
                            else
                            {
                                Console.WriteLine("One of the devices is null, cannot connect.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad command, try again. (size={0})", command.Count);
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
                                mainEnv.printAll("After connection of switch " + deviceName + " from " + firstDevice.Name + " to " + secondDevice.Name);
                            }
                            else
                            {
                                Console.WriteLine("One of the devices is null, cannot connect.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad command, try again. (size={0})", command.Count);
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
                                mainEnv.printAll("After toggling of switch " + switchName + ", new state is " + connSwitch.IsSwitchClosed.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Switch is null, cannot toggle.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad command, try again. (size={0})", command.Count);
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
                                Console.WriteLine("Bad parameter \"{0}\", try again ('0' or '1' only).", switchState);
                                break;
                            }
                            if (connSwitch != null)
                            {
                                connSwitch.IsSwitchClosed = (switchState=="1" ? true : false);
                                mainEnv.update();
                                mainEnv.update();
                                mainEnv.printAll("After setting of switch " + switchName + ", new state is " + connSwitch.IsSwitchClosed.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Switch is null, cannot toggle.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad command, try again. (size={0})", command.Count);
                        }
                        break;
                    case "reladd":
                        // reladd <relayName> <coilPower> <driveDeviceName> <FirstDeviceName> <SecondDeviceName>
                        if (command.Count == 7)
                        {
                            string relayName = command[1];
                            int coilPower = int.Parse(command[2]);
                            bool isNC = (int.Parse(command[3])==1 ? true : false);
                            Device driverDevice = mainEnv.getDeviceByName(command[4]);
                            Device firstDevice = mainEnv.getDeviceByName(command[5]);
                            Device secondDevice = mainEnv.getDeviceByName(command[6]);
                            Relay newRelay = new Relay(relayName, coilPower, isNC , driverDevice, firstDevice, secondDevice);

                            if (driverDevice != null && (firstDevice != null && secondDevice != null))
                            {
                                mainEnv.addRelay(newRelay);
                                mainEnv.update();
                                mainEnv.printAll("After adding relay " + relayName + ", coil connected to " + driverDevice.Name + ", switch connecting " + firstDevice.Name + " to " + secondDevice.Name);
                            }
                            else
                            {
                                Console.WriteLine("Switch is null, cannot toggle.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad command, try again. (size={0})", command.Count);
                        }
                        break;
                        //update manually
                    case "update":
                        mainEnv.update();
                        mainEnv.printAll("MANUAL UPDATE");
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
                                    Console.WriteLine("Invalid file.");
                                }
                                List<string> commandList = new List<string>(scriptFile);
                                int commandCount = commandList.Count;
                                while(scriptCommandCounter < commandCount)
                                {
                                    processCommand(commandList[scriptCommandCounter]);
                                    scriptCommandCounter++;
                                }
                                    isScriptActive = false;
                            }
                            else
                            {
                                Console.WriteLine("Already executing script, cannot recursively execute scripts.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad command, try again. (size={0})", command.Count);
                        }
                        break;
                    default:
                        Console.WriteLine("Bad command, try again. (size={0})", command.Count);
                        break;
                }
            }
            while (isScriptActive);
        }
        

    }
}
