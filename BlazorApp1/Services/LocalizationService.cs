using Microsoft.Extensions.Localization;

namespace BlazorApp1.Services
{
    public class LocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Resources", typeof(LocalizationService).Assembly.FullName);
        }

        public string GetLocalizedString(string key)
        {
            return _localizer[key];
        }

        public void SetCurrentLanguage(string languageCode)
        {
            // Optionally, you can add logic here to switch between different localizations
        }
    }
}
