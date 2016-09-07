using System;
using System.Globalization;
using System.Threading;

namespace Mediware.Utils.Globalization
{
    public class LanguageSwitchContext : IDisposable
    {
        public const string DefaultcultureName = "en-US";

        public CultureInfo PreviousLanguage { get; private set; }
        
        public LanguageSwitchContext(CultureInfo culture)
        {
            PreviousLanguage = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        public LanguageSwitchContext(string cultureName) : this(new CultureInfo(cultureName))
        {
        }

        public LanguageSwitchContext() : this(DefaultcultureName)
        {
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = PreviousLanguage; 
        }
    }
}