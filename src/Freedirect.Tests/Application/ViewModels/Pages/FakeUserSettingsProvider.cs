using Freedirect.Application.Settings;

namespace Freedirect.Tests.Application.ViewModels.Pages
{
    internal class FakeUserSettingsProvider : IUserSettingsProvider
    {
        internal FakeUserSettingsProvider(UserSettings userSettings)
        {
            UserSettings = userSettings;
        }

        public UserSettings UserSettings { get; private set; }

        public void UpdateUserSettings(UserSettings settings)
        {
            UserSettings = settings;
        }
    }
}