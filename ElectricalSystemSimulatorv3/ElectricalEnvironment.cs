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
    public class ElectricalEnvironment
    {
        // Private Members
        private Dictionary<ElectricalDevice, ElectricalNetwork> N;
        private List<ElectricalDevice> devices;
        private List<ElectricalSwitch> switches;

        // Getter Properties
        public Dictionary<ElectricalDevice, ElectricalNetwork> DeviceLookup
        {
            get { return N;}
        }
        public List<ElectricalDevice> Devices
        {
            get { return devices; }
        }
        public List<ElectricalSwitch> Switches
        {
            get { return switches; }
        }

        // Constructor
        public ElectricalEnvironment()
        {
            N = new Dictionary<ElectricalDevice, ElectricalNetwork>();
            devices = new List<ElectricalDevice>();
            switches = new List<ElectricalSwitch>();
        }

        // Device Management Methods
        public ElectricalDevice CreateDevice(string deviceName = null)
        {
            if(FindDeviceByName(deviceName) != null)
            {
                return null;
            }
            var newDevice = new ElectricalDevice(deviceName);
            devices.Add(newDevice);
            return newDevice;
        }
        public void RemoveDevice(ElectricalDevice device)
        {
            if(devices.Contains(device))
            {
                devices.Remove(device);
                foreach (var dev in device.ConnectedDevices)
                {
                    if(dev.ConnectedDevices.Contains(device))
                    {
                        dev.ConnectedDevices.Remove(device);
                    }
                }
            }
        }
        public void DisconnectDevices(ElectricalDevice first, ElectricalDevice second)
        {
            if (devices.Contains(first) && devices.Contains(second))
            {
                if(first.ConnectedDevices.Contains(second))
                {
                    first.ConnectedDevices.Remove(second);
                }
                if (second.ConnectedDevices.Contains(first))
                {
                    second.ConnectedDevices.Remove(first);
                }
            }
        }
        public void ConnectDevices(ElectricalDevice first, ElectricalDevice second)
        {
            if (devices.Contains(first) && devices.Contains(second))
            {
                if (!first.ConnectedDevices.Contains(second))
                {
                    first.ConnectedDevices.Add(second);
                }
                if (!second.ConnectedDevices.Contains(first))
                {
                    second.ConnectedDevices.Add(first);
                }
            }
        }
        public ElectricalDevice FindDeviceByName (string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            ElectricalDevice device = null;
            name = name.ToLower();
            var allDevices = devices;
            // Try to find an exact match first
            foreach (var d in allDevices)
            {
                if (d.Name == name)
                {
                    if (device != null)
                        return null; // Not unique
                    device = d;
                }
            }
            if (device != null)
                return device;
            // Otherwise try to find a partial match
            foreach (var d in allDevices)
            {
                if (d.Name.ToLower().IndexOf(name) >= 0)
                {
                    if (device != null)
                        return null; // Not unique
                    device = d;
                }
            }
            return device;
        
        }

        // Switch Management Methods
        public ElectricalSwitch CreateSwitch(string swName = null)
        {
            if (FindSwitchByName(swName) != null)
            {
                return null;
            }
            var newSwitch = new ElectricalSwitch(swName);
            switches.Add(newSwitch);
            newSwitch.FirstContact = CreateDevice(swName+"(c1)");
            newSwitch.SecondContact = CreateDevice(swName+"(c2)");
            return newSwitch;
        }
        public void RemoveSwitch (ElectricalSwitch sw)
        {
            if(switches.Contains(sw))
            {
                switches.Remove(sw);
            }
            RemoveDevice(sw.FirstContact);
            RemoveDevice(sw.SecondContact);
        }
        public ElectricalSwitch FindSwitchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            ElectricalSwitch mswitch = null;
            name = name.ToLower();
            var allSwitches = switches;
            // Try to find an exact match first
            foreach (var sw in allSwitches)
            {
                if (sw.Name == name)
                {
                    if (mswitch != null)
                        return null; // Not unique
                    mswitch = sw;
                }
            }
            if (mswitch != null)
                return mswitch;
            // Otherwise try to find a partial match
            foreach (var sw in allSwitches)
            {
                if (sw.Name.ToLower().IndexOf(name) >= 0)
                {
                    if (mswitch != null)
                        return null; // Not unique
                    mswitch = sw;
                }
            }
            return mswitch;

        }

        // Relay Management Methods
        public ElectricalRelay CreateRelay(string swName = null)
        {
            if (FindSwitchByName(swName) != null)
            {
                return null;
            }
            var newSwitch = new ElectricalRelay(swName);
            switches.Add(newSwitch);
            newSwitch.FirstContact = CreateDevice(swName + "(1)");
            newSwitch.SecondContact = CreateDevice(swName + "(2)");
            newSwitch.Coil = CreateDevice(swName + "(c)");
            return newSwitch;
        }
        public void RemoveRelay(ElectricalRelay sw)
        {
            if (switches.Contains(sw))
            {
                switches.Remove(sw);
            }
            RemoveDevice(sw.FirstContact);
            RemoveDevice(sw.SecondContact);
            RemoveDevice(sw.Coil);
        }

        // Network Management Methods
        public List<ElectricalNetwork> UpdateNetworks ()
        {
            // Update Switches
            UpdateSwitchContacts();

            var netList = new List<ElectricalNetwork>();
            Dictionary<ElectricalDevice, bool> P = new Dictionary<ElectricalDevice, bool>();
            N.Clear();

            // Initialize Processed and Lookup Tables
            foreach(var i in devices)
            {
                P[i] = false;
                var newNetwork = new ElectricalNetwork();
                N[i] = newNetwork;
                newNetwork.Devices.Add(i);
            }

            // Master Loop
            foreach (var i in devices)
            {
                foreach(var j in i.ConnectedDevices)
                {
                    if(P[j]==true)
                    {
                        var newNet = N[j];
                        var oldNet = N[i];
                        var oldNetDevices = oldNet.Devices;
                        foreach (var d in oldNetDevices)
                        {
                            newNet.Devices.Add(d);
                            N[d] = newNet;
                        }
                    }
                }
                P[i] = true;
            }

            // Add all non-empty networks to returned List
            foreach(var pair in N)
            {
                if(!netList.Contains(pair.Value))
                {
                    netList.Add(pair.Value);
                }
            }
            return netList;
        }
        public void UpdateSwitchContacts ()
        {
            UpdateRelayContacts();
            if(switches.Count != 0)
            {
                foreach(var sw in switches)
                {
                    if (sw.SwitchState) { ConnectDevices(sw.FirstContact, sw.SecondContact); }
                    else { DisconnectDevices(sw.FirstContact, sw.SecondContact); }
                }
            }
        }
        public void UpdateRelayContacts ()
        {
            if (switches.Count != 0)
            {
                foreach (ElectricalSwitch sw in switches)
                {
                    if (sw is ElectricalRelay)
                    {
                        var r = (ElectricalRelay) sw;
                        if (N.ContainsKey(r.Coil))
                        {
                            var coilNet = N[r.Coil];
                            if (coilNet.NetPower > 0)
                            {
                                sw.SwitchState = true;
                            }
                            else
                            {
                                sw.SwitchState = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
