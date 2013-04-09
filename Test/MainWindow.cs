using System;
using Gtk;
using System.IO;
using System.Threading;
using System.Timers;

public partial class MainWindow: Gtk.Window
{	
	private static System.Timers.Timer MainTimer;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton3Clicked (object sender, EventArgs e)
	{
		MainTimer = new System.Timers.Timer (1000); // Set up the timer for 3 seconds
		//
		// Type "_timer.Elapsed += " and press tab twice.
		//
		MainTimer.Elapsed += new ElapsedEventHandler (_timer_Elapsed);
		MainTimer.Enabled = true; // Enable it

		MessageDialog MS = new MessageDialog(this,DialogFlags.DestroyWithParent,
		                                     MessageType.Other,
		                                     ButtonsType.Ok,
		                                     "Test");
		MS.Visible = true;
		int t = MS.Run();
		MS.Destroy();

	}

	void _timer_Elapsed (object sender, ElapsedEventArgs e)
	{
		this.label1.Text = DateTime.Now.ToLongTimeString();                              
	}
}
