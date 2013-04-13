using System;
using Gtk;
using System.IO;
using System.Threading;
using System.Timers;
using Google.KML;
using CBS;

public partial class MainWindow: Gtk.Window
{	
	private static System.Timers.Timer MainTimer;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		MainTimer = new System.Timers.Timer (1000); // Set up the timer for 3 seconds
		MainTimer.Elapsed += new ElapsedEventHandler (_timer_Elapsed);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton3Clicked (object sender, EventArgs e)
	{


	}

	private void DisplayMessage (string Msg_In)
	{
		MessageDialog MS = new MessageDialog (this, DialogFlags.DestroyWithParent,
		                                     MessageType.Other,
		                                     ButtonsType.Ok,
		                                     Msg_In);
		MS.Visible = true;
		MS.Run ();
		MS.Destroy ();
	}

	////////////////////////////////////////////////////////////////
	// This is the main timer that gets enabled once the user
	// starts proccesing. It will handle all periodical events
	//
	void _timer_Elapsed (object sender, ElapsedEventArgs e)
	{
		                           
	}

	protected void OnBtnStartStopClicked (object sender, EventArgs e)
	{
		if (this.btn_Start_Stop.Label == "Start") {

			this.btn_Start_Stop.Label = "Stop";
			MainTimer.Enabled = true; 
			CBS.FileWatcher.CreateWatcher(this.textBox_Source_Destination.Text);

		} else {

			this.btn_Start_Stop.Label = "Start";
			MainTimer.Enabled = false;
			CBS.FileWatcher.StopWatcher();
		}

	}

	protected void OnBtnDebugClicked (object sender, EventArgs e)
	{
		StreamReader MyStreamReader;

		MyStreamReader = System.IO.File.OpenText ("/home/bosnia/EFD/test.log");

			// Pass in stream reader and initialise new
			// EFD message. 
			EFD_Msg EDF_MESSAGE = new EFD_Msg(MyStreamReader);
	}


}
