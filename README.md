#Player Tracker
This program is to be written in C# (because our school's security software wasn't allowing it to connect to the Internet in Java). It is my capstone project for my senior year at Cuyahoga Valley Career Center (2013-2014).

The application will include both a client- and server-side. The idea of the program is to help game and forum administrators keep track of players, their actions, wrongdoings, and the like. For data storage, a MySQL database will be used. Visual Studio's built-in unit testing framework will also be used for unit testing.

#Usage
###Server
#####Required Software
- [.NET Framework 4 (Client)](http://download.microsoft.com/download/1/B/E/1BE39E79-7E39-46A3-96FF-047F95396215/dotNetFx40_Full_setup.exe) or [above](http://download.microsoft.com/download/B/A/4/BA4A7E71-2906-4B2D-A0E1-80CF16844F5F/dotNetFx45_Full_setup.exe)
- [MySQL Server](http://dev.mysql.com/get/Downloads/MySQL-5.6/mysql-5.6.17-winx64.zip)
- [MySQL Connector/NET library](http://dev.mysql.com/get/Downloads/Connector-Net/mysql-connector-net-1.0.10.1.exe) (MySQL.Data.dll) -- Included in binary folder.
- PlayerTracker Common library (Player Tracker Common.dll) -- Included in binary folder.

#####Recommended Software
- [MySQL Workbench](http://dev.mysql.com/get/Downloads/MySQLGUITools/mysql-workbench-community-6.1.4-win32.msi)
OR
[Navicat for MySQL](http://download3.navicat.com/download/navicat110_mysql_en_x64.exe) -- used for executing SQL queries on the server, if needed. The former is installed on my computer if you use it.

#####Instructions
1. Open the program.
2. Run the SQL script found in the server binary folder.
3. Insert any users you want to use to the DB (this will be fixed to be a config form in the server GUI if I get to it).
4. Insert any servers you wish to use to the DB (as above, this will be a GUI if I have time).
5. Leave the server to run and accept any client connections.

###Client
Required Software
- [.NET Framework 4 (Client)](http://download.microsoft.com/download/1/B/E/1BE39E79-7E39-46A3-96FF-047F95396215/dotNetFx40_Full_setup.exe) or [above](http://download.microsoft.com/download/B/A/4/BA4A7E71-2906-4B2D-A0E1-80CF16844F5F/dotNetFx45_Full_setup.exe)
- PlayerTracker Common Library (Player Tracker Common.dll) -- Included in binary folder.

#####Instructions
1. Run the program.
2. Type in your username and password, set up from the server-side above.
3. Log in.
4. Search for a player on a server (type the player's name into the box, and select a server in the listbox).
5. Click Search.
6. Edit the player's information, then click Save & Close or Cancel.
7. Click Search again if you'd like to confirm that the information was saved (or not).

#####Pre-defined test data
######Players
- asdf
- 123
- gooby
- frogs
- toadular
- stuff
- joefabeetz
- You can also type in a name that isn't here and it will be added to the database.

######Users
- frogs (password: 1234)
- You can add more by executing the following statement (replacing appropriate constants in all caps): ```INSERT INTO `users` (`firstName`, `lastName`, `user`, `pass`, `serverAccess`) VALUES("FIRST_NAME", "LAST_NAME", "USERNAME", "PASSWORD", "SERVER_IDS_ACCESSIBLE_DELIMITED_BY_COMMAS");```

######Servers
- stuff
- You can add more by executing the following statement (replacing ```SERVER_NAME_HERE``` with the actual name) on the SQL server: ```INSERT INTO `servers` (serverName) VALUES("SERVER_NAME_HERE");```

#Known Bugs
###Client
- Configuration form does not display entirely correctly: if a user adds a server, deletes it, saves the configuration, then opens the configuration form again, the active server will not show anything.
- Although it isn't really a bug -- just a code shortcoming (which I know how to fix) -- client forms and the server form may freeze at times when reading or sending data betwixt each other. This is caused by the overhead of sockets and their synchronous reading and sending (even though they have asynchronous methods to do so, too).
- Downloading player attachments does not work correctly (sometimes?).

###Server
- Connections might not drop properly if not closed manually, i.e. might not be removed from connection list if network adapter is disabled.
- Does not use a UUID (didn't have time to implement); multiple connections on a computer or network with the same external IP will use the last connected user's permissions.

#Project Evaluation
###Objectives
As a reminder, my objectives were to learn:
- Use JUnit to learn unit testing and how it works.
- Use server sockets and learn their capabilities.
- Learn how to use a MySQL server (I'd only used MSSQL before)
- Learn Maven and set up all projects' builds with it.
- Learn more about VCS (Version Control Systems)

###Accomplishments
######I did accomplish the following:
- Learned use of JUnit and learned how to set up unit tests using it.
- Learned how to use server sockets and their limitations and capabilities.
- Learned how to use MySQL.
- Learned how to use Maven and set up multiple project builds.
- Learned how to use VCS.
- I learned Serialization and Non-serializability -- an excellent and vital tool for programming.

######In addition, I also accomplished:
- Learned how Sockets work in C#.
- Completed about half of the project in Java -- then had to switch to C#. The [old repository](https://github.com/14jesenskyd/PlayerTracker-Java/) is still available.
- Learned Visual Studio's unit testing framework.
- Learned Visual Studio's batch build and dependency compilation features.

###Shortcomings
######There were some things I couldn't accomplish during the 75 hours (more or less, missing days for BPA and the like):
- I couldn't complete the project in Java as planned. Obviously, as Java and C# are so similar, I probably could finish it in Java if I tried to at home. My struggle is not unknown with the school's security software, so C# was settled upon instead -- C++ had too long of a development overhead.
- I wasn't able to use Jenkins. The school's security software did not allow the build slaves to run. It also barely allowed me to run the .WAR (java executable, alternative to .JAR) file. I have significant belief that the continuous integration would fail in other ways, too.
- Maven was used for the Java portion of the project, but that portion was basically discarded after porting it to C#. Maven doesn't exist for C#, as Visual Studio does everything that Maven does.

###Compromises
######There were some things that I compromised on in the switch between Java and C#.
- JUnit is java-only. Visual Studio has an equivalent built-in, and that was used instead. Unfortunately, however, not many unit tests were constructed -- I didn't have enough time to make many of them. I did, however, still learn what they are, what they do, and how they work -- for two languages. I figured that sufficed.
- Rather than using Maven (since it only exists for Java), I used Visual Studio's built-in batch-build and dependency-compile system.


###Expected Outcome Versus Actual Outcome
######Expected
This is the purpose:
>This project is intended to keep track of players on a minecraft server and such, but could be used for other purposes as well. The application will consist of two parts: a client and a server. The server will handle all database connections and sending retrieved data to the client, as well as storing information sent to it by the client. The client then will be responsible for sending data requests at the user's command, as well as updating it at the same. This project is to fulfil a request from a friend (whose name is Elijah) and help him out as he runs game servers (not just minecraft) and cannot possibly keep track of all of his players' offenses and such by himself.

This is the expected outcome:
>The expected outcome is an application which can sustain a good deal of utility for both Elijah and his volunteer staff and help them keep track of players on game servers which they host and what those players do, be it positive or negative. I expect to learn working knowledge of server-side sockets and more about Maven, continuous integration (CI) systems (assuming the school security allows it), and learn about MySQL (I've only ever used MSSQL).

######Actual
Purpose:
>I feel that the purpose is satisfied, per the original write-up.

Outcome:
>I feel that, while it falls short by my standards, time constraints did not allow for full completion. With more time, I probably would've been able to complete more, better. Unfortunately, due to time, the forms in the client which send packets (which is all of them except for the configuration ones) do not use asynchronous calls for sending and receiving data to and from the server. This, by my standards, would fail -- but the program still functions to its specified parameters. The server, while "working" in most aspects, does not allow listening on a different port or address. There is no form to manage existing users, and there is no permission level for anything. This falls short of what I wanted to (and will, after the project is graded -- this isn't just for a grade) do with the project. There's no registration-via-key system that I wanted to implement, but that also falls in line with the aforementioned. There's also no commenting, which is unfortunate (or, that which exists is in Java format, not C#'s XML format), but was necessary for the sake of time -- I barely finished what I did, so if I spent time commenting, I'd probably have nothing to show for all of this time.
