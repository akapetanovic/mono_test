using System;
using System.IO;

namespace CBS
{
	public static class Generate_Output
	{
		public static void Generate(EFD_Msg Message_Data)
		{
            // First check if directory already exists
            string IFPLID_DIR_NAME = Message_Data.ACID + "_" + Message_Data.IFPLID + "_*";
            string[] DestDirectory = Directory.GetDirectories(CBS_Common.Destination_Path, IFPLID_DIR_NAME);
            if (DestDirectory.Length == 0)
            {
                // This must be a new flight, so lets create applicable directory
                IFPLID_DIR_NAME = Message_Data.ACID + "_" + Message_Data.IFPLID + "_";
                IFPLID_DIR_NAME = IFPLID_DIR_NAME + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                Directory.CreateDirectory(CBS_Common.Destination_Path + IFPLID_DIR_NAME);
                // Now when it is created, lets get it again so it can be used
                DestDirectory = Directory.GetDirectories(CBS_Common.Destination_Path, IFPLID_DIR_NAME);

                // Now create subdirectories within new directory
                Directory.CreateDirectory(Path.Combine(DestDirectory[0], "Common"));
                Directory.CreateDirectory(Path.Combine(DestDirectory[0], "EFD"));
                Directory.CreateDirectory(Path.Combine(DestDirectory[0], "Status"));
            }

            Common.Generate_Output(Message_Data);
            EFD.Generate_Output(Message_Data);
            Status.Generate_Output(Message_Data);
		}
	}
}
