using System;
using Gtk;
using WebKit;

using Key = Gdk.Key;
using State = Gdk.ModifierType;

public static class Program 
{
	private static void Main() 
	{
		Application.Init();

		Window window = new("Microsoft Whiteboard");
		WebView webview = new();

		webview.LoadUri(@"https://app.whiteboard.microsoft.com/");

		window.KeyPressEvent += (s, e) => 
		{
			var key = e.Event.Key;
			var state = e.Event.State;

			if (key == Key.F5 || ((key == Key.r || key == Key.R) && (state & State.ControlMask) != 0)) 
			{
				if ((state & State.ShiftMask) != 0)
					webview.ReloadBypassCache();
				else
					webview.Reload();
			}
		};

		window.Destroyed += (s, e) => Application.Quit();

		window.Resizable = true;
		window.SetDefaultSize(1280, 720);
		window.Add(webview);
		window.ShowAll();

		Application.Run();
	}
}
