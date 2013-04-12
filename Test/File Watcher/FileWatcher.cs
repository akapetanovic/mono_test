using System;
using System.IO;
using System.Collections.Generic;

namespace CBS
{
	public static class FileWatcher
	{
		//Create a new FileSystemWatcher.
		private static FileSystemWatcher watcher = new FileSystemWatcher ();

		// Creates and starts FileWatcher with the given
		// directory
		public static void CreateWatcher (string path)
		{

			//Set the filter to only catch TXT files.
			//watcher.Filter = "*.txt";

			//Subscribe to the Created event.
			watcher.Created += new FileSystemEventHandler (watcher_FileCreated);

			//Set the path to C:\Temp\
			watcher.Path = path;

			//Enable the FileSystemWatcher events.
			watcher.EnableRaisingEvents = true;
		}

		public static void StopWatcher ()
		{
			watcher.EnableRaisingEvents = false;
			watcher.Dispose();
		}

		private static void watcher_FileCreated (object sender, FileSystemEventArgs e)
		{
			EFD_File_Handler.Handle_New_File(e.FullPath);
		} 
	}
}

