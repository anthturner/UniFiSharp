# Command Line Tool

`unifi-cli` is a new tool to expose the functionality of UniFiSharp to the command line, so that other scripts can leverage the SDK for automation without needing to write C# code.

## Available Commands
The CLI tool attempts to expose all commands and information available through the UniFiSharp SDK as if you were using it in a C# application. You can find a full list of commands and some examples by typing:

`unifi-cli --help`

For commands which either run and create output, or simply provide information, you can pass the `--json` flag to output the information in JSON; otherwise, it will be formatted to be viewed by a human being through the use of tables.

## Explorer Mode
This tool allows you to interactively explore your network topology in a similar way to a file system. That is, you begin at the router (or outermost component of your perimeter) and can `cd` to network devices which are children of that component. You can do this for as many levels as is appropriate, and even `cd` into client devices.

All devices support the `info` command, which dumps all information which the system knows about the device.

You can also use commands such as `rssi` and `signal` to list the wirelessly connected client devices and their RSSI and signal strength to their access points.

For a full list of command functions, type `help`.

## Topology Mode
This mode outputs a visual formatted tree based on the converged topology from the Orchestrator component. It shows the relationship between network devices and their children, as well as where each client is connected on your network.

## Interactive Mode
Since the CLI tool exposes a significant number of commands, if you want to do maintenance, you can load the tool in interactive mode. Running it this way allows you to specify the controller URI, username, and password once, rather than needing to specify it on each run of the tool for a single operation. For example:

`unifi-cli interactive https://192.168.1.1 administrator myPassword123`

This session will run any commands against `192.168.1.1` with the credentials above.