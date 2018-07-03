
Read me...

To get started with the SophiaTX Blockchain Library...

1. Add Alexandria.net.dll file to the project as an Assembly Reference.
2. Depending on the Environment you are running add one of the "libalexandria" library to the project as an existing element > all files.

				Linux------> libalexandria.so
				MacOS------> libalexandria.dylib
				Windows----> libalexandria.dll
3. Use below mentioned the connection address and port to connect to a SophiaClient. Now you are all set to use the SophiaTX Blockchain Wallet.

				new SophiaClient("195.48.9.208", 8095, 8096);