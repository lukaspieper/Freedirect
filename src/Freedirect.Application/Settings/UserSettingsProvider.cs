using System;
using System.IO;
using System.Text.Json;

namespace Freedirect.Application.Settings
{
    internal class UserSettingsProvider : IUserSettingsProvider
    {
        private readonly string _settingsFilePath;

        internal UserSettingsProvider()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var settingsDirectoryPath = Path.Combine(appDataPath, "Freedirect");
            Directory.CreateDirectory(settingsDirectoryPath);

            _settingsFilePath = Path.Combine(settingsDirectoryPath, "Settings.json");

            if (File.Exists(_settingsFilePath))
            {
                var json = File.ReadAllText(_settingsFilePath);
                UserSettings = JsonSerializer.Deserialize<UserSettings>(json);
            }
        }

        public UserSettings UserSettings { get; private set; } = new UserSettings();

        public void UpdateUserSettings(UserSettings settings)
        {
            var json = JsonSerializer.Serialize(settings);
            File.WriteAllText(_settingsFilePath, json);

            UserSettings = settings;
        }
    }
}