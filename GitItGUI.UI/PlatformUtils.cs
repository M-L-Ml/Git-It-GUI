using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace GitItGUI.UI.Utils
{
	static class PlatformUtils
	{
		public static bool SelectFolder(out string folderPath)
		{
			folderPath = SelectFolderAsync().GetAwaiter().GetResult();
			return !string.IsNullOrEmpty(folderPath);
		}

		public static async Task<string> SelectFolderAsync()
		{
			var topLevel = Avalonia.Controls.TopLevel.GetTopLevel(MainWindow.singleton);
			if (topLevel == null) return null;

			var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
			{
				Title = "Select Folder",
				AllowMultiple = false
			});

			var folder = folders?.FirstOrDefault();
			return folder?.TryGetLocalPath();
		}
	}
}
