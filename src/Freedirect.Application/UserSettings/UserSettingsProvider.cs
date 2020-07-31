using System;
using System.IO;
using System.Text.Json;

namespace Freedirect.Application.UserSettings
{
    internal class UserSettingsProvider
    {
        private readonly string _settingsFilePath;

        internal UserSettingsProvider()
        {
            var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var settingsDirectoryPath = Path.Combine(localAppDataPath, "Freedirect");
            Directory.CreateDirectory(settingsDirectoryPath);

            _settingsFilePath = Path.Combine(settingsDirectoryPath, "Settings.json");

            if (File.Exists(_settingsFilePath))
            {
                var json = File.ReadAllText(_settingsFilePath);
                UserSettings = JsonSerializer.Deserialize<UserSettings>(json);
            }
        }

        internal UserSettings UserSettings { get; private set; }

        internal void UpdateUserSettings(UserSettings settings)
        {
            var json = JsonSerializer.Serialize(settings);
            File.WriteAllText(_settingsFilePath, json);

            UserSettings = settings;
        }
    }
}