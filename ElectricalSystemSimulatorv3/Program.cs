using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemSimulatorv3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example script
            ElectricalEnvironment env = new ElectricalEnvironment();
            var dev1 = env.CreateDevice("dev1");
            var dev2 = env.CreateDevice("dev2");
            env.ConnectDevices(dev1, dev2);
            var dev3 = env.CreateDevice();
            var dev4 = env.CreateDevice();
            env.ConnectDevices(dev3, dev4);
            print_update(env);
            var sw1 = env.CreateSwitch("sw1");
            print_update(env);
            env.ConnectDevices(sw1.FirstContact, dev2);
            env.ConnectDevices(sw1.SecondContact, dev3);
            print_update(env);
            sw1.SwitchState = true;
            print_update(env);
            sw1.SwitchState = false;
            print_update(env);
        }

        static string PrintDevices(ElectricalEnvironment env)
        {
            var sb = new StringBuilder();
            sb.Append("Devices = [ ");
            foreach(var dev in env.Devices)
            {
                sb.Append(getDeviceName(dev) + ", ");
            }
            sb.Append("]");
            return sb.ToString();
        }
        static string PrintNetworks(ElectricalEnvironment env)
        {
            var netList = env.UpdateNetworks();
            var sb = new StringBuilder();
            sb.Append("Networks = {\n");
            foreach (var net in netList)
            {
                sb.Append("N" + net.GetHashCode().ToString() + " = [ ");
                foreach(var dev in net.Devices)
                {
                    sb.Append(getDeviceName(dev) + ", ");
                }
                sb.Append("]\n");
            }
            sb.Append("}");
            return sb.ToString();

        }
        static string PrintSwitches(ElectricalEnvironment env)
        {
            var swList = env.Switches;
            var sb = new StringBuilder();
            sb.Append("Switches = {\n");
            foreach (var sw in swList)
            {
                sb.Append(getSwitchName(sw) + ", ");
                sb.Append(" = { " + getDeviceName(sw.FirstContact) + ", " + getDeviceName(sw.SecondContact) + " }\n");
            }
            sb.Append("}");
            return sb.ToString();

        }
        static void print_update(ElectricalEnvironment env)
        {
            Console.WriteLine("******************************************************");
            Console.WriteLine(PrintDevices(env) + "\n");
            Console.WriteLine(PrintSwitches(env) + "\n");
            Console.WriteLine(PrintNetworks(env) + "\n");
        }

        static string getDeviceName (ElectricalDevice dev)
        {
            if (dev.Name != "") return dev.Name;
            return "D" + dev.GetHashCode().ToString();
        }
        static string getSwitchName(ElectricalSwitch sw)
        {
            if (sw.Name != "") return sw.Name;
            return "S" + sw.GetHashCode().ToString();
        }
    }
}
