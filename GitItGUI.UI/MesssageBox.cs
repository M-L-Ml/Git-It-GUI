using Avalonia.Controls;
using GitItGUI.Core;
using GitItGUI.UI.Overlays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitItGUI.UI
{
	enum MessageBoxButton
	{
		OK
	}

	enum MessageBoxImage
	{
		Error
	}

	class MessageBox
	{
		public static void Show(string message)
		{
			Show(null, message);
		}

		public static void Show(Window window, string message)
		{
			Show(window, message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		public static void Show(Window window, string message, string title, MessageBoxButton button, MessageBoxImage image)
		{
			if (MainWindow.singleton != null)
			{
				MainWindow.singleton.ShowMessageOverlay(title, message);
			}
			else
			{
				DebugLog.LogError(title + ": " + message);
			}
		}
	}
}
