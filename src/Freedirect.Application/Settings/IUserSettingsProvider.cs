namespace Freedirect.Application.Settings
{
    internal interface IUserSettingsProvider
    {
        UserSettings UserSettings { get; }

        void UpdateUserSettings(UserSettings settings);
    }
}