using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSystemv2
{
    public class ElectricalEnvironment
    {
        //PRIVATE MEMBERS
        private List<Device> devices;
        private List<Relay> relays;
        private List<Network> networks;
        private int networkNameCounter;
        //PROPERTIES
        public List<Device> Devices
        {
            get { return devices; }
        }
        public List<Relay> Relays
        {
            get { return relays; }
        }
        public List<Network> Networks
        {
            get { return networks; }
        }
        
        //CONSTRUCTORS
        public ElectricalEnvironment()
        {
            devices = new List<Device>();
            relays = new List<Relay>();
            networks = new List<Network>();
            networkNameCounter = 0;
        }

        //METHODS
        public void update()
        {
            //Initialize
            clearNetworks();
            clearDeviceChecks();
            //printAll("Start of update");

            //Master For-Loop
            foreach (Switch sw in devices.OfType<Switch>())
            {
                sw.updateSwitch();
            }
            
            foreach(Device dev in devices)
            {
                //Device dev = devices[i];
                
                //Singletons
                if (dev.ConnectedDevices.Count == 0)
                {
                    Network net = newNetwork();
                    net.addDevice(dev);
                }
                // Connected Devices
                else
                {
                    List<Device> onlineDevs = new List<Device>();
                    foreach (Device connDev in dev.ConnectedDevices)
                    {
                        if (connDev.isOnline == true)
                        {
                            onlineDevs.Add(connDev);
                        }
                    }
                    if (onlineDevs.Count == 0)
                    {
                        Network net = newNetwork();
                        net.addDevice(dev);
                    }
                    else if (onlineDevs.Count == 1)
                    {
                        onlineDevs[0].Network.addDevice(dev);
                    }
                    else
                    {
                        //Make list of networks of online devices for merging
                        List<Network> onlineDevNets = new List<Network>();
                        foreach (Device onlineDev in onlineDevs)
                        {
                            onlineDevNets.Add(onlineDev.Network);
                        }
                        Network mergedNetwork = mergeNetworkList(onlineDevNets);
                        mergedNetwork.addDevice(dev);
                    }
                }
                //printAll("After connection of <" + dev.Name + ">");
                updateRelays();
            }
            
        }

        public void updateRelays()
        {
            foreach (Relay rel in Relays)
            {
                rel.updateRelay();
            }
        }

        public void addDevice(Device newDevice)
        {
            if (!devices.Contains(newDevice))
            {
                devices.Add(newDevice);
            }
            update();
        }
        public void addRelay(Relay newRelay)
        {
            relays.Add(newRelay);
            addDevice(newRelay.Coil);
            addDevice(newRelay.Switch);
        }
        public void connectTwoDevices(Device dev1, Device dev2)
        {
            dev1.connectTo(dev2);
            dev2.connectTo(dev1);
            update();
        }
        public void disconnectTwoDevices(Device dev1, Device dev2)
        {
            dev1.disconnectFrom(dev2);
            dev2.disconnectFrom(dev1);
            update();
        }
        private void addNetwork(Network newNetwork)
        {
            if (!networks.Contains(newNetwork))
            {
                networks.Add(newNetwork);
            }
        }
        private void removeNetwork(Network remNetwork)
        {
            if (networks.Contains(remNetwork))
            {
                networks.Remove(remNetwork);
            }
        }
        public void clearNetworks()
        {
            networks.Clear();
            networkNameCounter = 0;
        }
        public void clearDeviceChecks()
        {
            foreach (Device dev in devices)
            {
                dev.isOnline = false;
            }
        }
        public Network newNetwork()
        {
            int count = networkNameCounter++;
            string netName = "net" + count.ToString();
            Network newNetwork = new Network(netName);
            addNetwork(newNetwork);
            return newNetwork;
        }
        
        private Network mergeTwoNetworks(Network net1, Network net2)
        {
            Network mergedNetwork = newNetwork();
            //Check if networks are the same
            if (net1 == net2)
            {
                return net1;
            }
            //Add devices from both networks to new network
            foreach (var dev in net1.Devices)
            {
                mergedNetwork.addDevice(dev);
            }
            foreach (var dev in net2.Devices)
            {
                mergedNetwork.addDevice(dev);
            }
            //remove old networks from environment list
            removeNetwork(net1);
            removeNetwork(net2);

            return mergedNetwork;
        }
        public Network mergeNetworkList(List<Network> networkList)
        {
            //Initialize accumulator
            Network resultNetwork = new Network();
            //Accumulate
            foreach (Network net in networkList)
            {
                resultNetwork = mergeTwoNetworks(resultNetwork, net);
                removeNetwork(net);
            }
            return resultNetwork;
        }
        public void printAll(string message)
        {
            Console.Write("**** " + message + ":\n");
            Console.Write("MainEnvironment:\n");
            if (Networks.Count == 0)
            {
                Console.Write("EMPTY\n");
            }
            else foreach (var net in Networks)
                {
                    net.printDevices();
                }
            Console.Write("All devices:\n");
            if (Devices.Count == 0)
            {
                Console.WriteLine("NO DEVICES");
            }
            else foreach (Device dev in Devices)
                {
                    Console.Write(dev.Name + ", ");
                }
            Console.WriteLine("\n");
        }
        public Device getDeviceByName(string devName)
        {
            foreach (Device dev in this.Devices)
            {
                if (dev.Name == devName)
                {
                    return dev;
                }
            }
            return null;
        }
    }
}
