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
		////////////////////////////////////////////////////////////////////////////
		// These calls are to be executed in the following order and
		// are not to be changed
		CBS_Main.Initialize ();
	
		this.textBox_Source_Destination.Text = CBS_Main.Get_Source_Dir();
		txt_Box_Destination.Text = CBS_Main.Get_Destination_Dir();
		///////////////////////////////////////////////////////////////////////////
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

	protected void OnBtnStartStopClicked (object sender, EventArgs e)
	{

	}

	protected void OnBtnDebugClicked (object sender, EventArgs e)
	{
		StreamReader MyStreamReader;

		MyStreamReader = System.IO.File.OpenText ("/home/bosnia/EFD/test.log");

		// Pass in stream reader and initialise new
		// EFD message. 
		EFD_Msg EDF_MESSAGE = new EFD_Msg (MyStreamReader);
	}


}
