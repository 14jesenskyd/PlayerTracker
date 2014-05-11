#Player Tracker
This program is to be written in C# (because our school's security software wasn't allowing it to connect to the Internet in Java). It is my capstone project for my senior year at Cuyahoga Valley Career Center (2013-2014).

The application will include both a client- and server-side. The idea of the program is to help game and forum administrators keep track of players, their actions, wrongdoings, and the like. For data storage, a MySQL database will be used. Visual Studio's built-in unit testing framework will also be used for unit testing.

#Usage
###Server
#####Required Software
- .NET Framework 4 (Client) or above
- MySQL Server
- MySQL Connector/NET library (MySQL.Data.dll) -- Included in binary folder.
- PlayerTracker Common library (Player Tracker Common.dll) -- Included in binary folder.

#####Instructions
1. Open the program.
2. Run the SQL script found in the server binary folder.
3. Insert any users you want to use to the DB (this will be fixed to be a config form in the server GUI if I get to it).
4. Insert any servers you wish to use to the DB (as above, this will be a GUI if I have time).
5. Leave the server to run and accept any client connections.

###Client
Required Software
- .NET Framework 4 (Client) or above
- PlayerTracker Common Library (Player Tracker Common.dll) -- Included in binary folder.

#####Instructions
1. Run the program.
2. Type in your username and password, set up from the server-side above.
3. Log in.
4. Search for a player on a server (type the player's name into the box, and select a server in the listbox).
5. Click Search.
6. Edit the player's information, then click Save & Close or Cancel.
7. Click Search again if you'd like to confirm that the information was saved (or not).

#Known Bugs
###Client
- Configuration form does not display entirely correctly: if a user adds a server, deletes it, saves the configuration, then opens the configuration form again, the active server will not show anything.

###Server
- Does not close correctly; will hang. Process must be stopped manually from the task manager.
