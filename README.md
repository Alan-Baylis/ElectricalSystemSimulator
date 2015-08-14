# ElectricalSystemSimulator

A project to simulate a simple electrical simulation based on power output of the connected devices.
Written in Visual C#.

# Try it out!

1. Open the solution in Visual Studio
2. Set "ElectricalSystemSimulatorv3_GUI" as your Startup Project.
2. Type any invalid gibberish in the command line and hit Enter, and console should display valid commands.
3. Use the included "test_script.txt" as an example script.

# Basic Concepts
<h3>Device:</h3> 
building block of the Electrical system. Each device has a power consumption value (power rating). Positive power ratings generate power (in Watts). Negative power ratings consume power. Devices can be physically connected together to form Electrical Networks. Zero power devices are there to conduct electricity (a wire is a device with 0 power).

<h3>Network: </h3> 
A network contains a series of devices that are physically connected together. One a network is determined, devices in it will contribute to its overall power rating. If a network's net power is positive (produces more power than it consumes), then all power-consuming devices in it will be active (lights will be on, furnaces will be lit, etc). If the net power is negative, power-consuming devices will not be active/will be semi-active while the generating devices will still be active (generators will still consume fuel even though lights are not on or are dim).

<h3>Switch:</h3> 
A switch contains two contacts (zero power devices), with will physically connect/disconnect them two if its "State" is on/off. The basic switch is a manually-actived entity.

<h3>Relay:</h3> 
A switch that has a coil device (with a negative power rating). If the relay's coil is connected to a positive power electrical network, the relay will have a switch state of ON, otherwise it is OFF. Because the coil uses the network from the previous iteration, relays will be updated one cycle late.

<img src="https://raw.githubusercontent.com/apklemon/ElectricalSystemSimulator/master/Concept1_mod.png"></img>
