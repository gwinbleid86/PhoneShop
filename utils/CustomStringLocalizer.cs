using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Localization;

namespace PhoneShop.utils
{
    public class CustomStringLocalizer : IStringLocalizer
    {
        Dictionary<string, Dictionary<string, string>> resources;

        const string HEADER = "Header";
        const string MESSAGE = "Message";

        public CustomStringLocalizer()
        {
            //en
            Dictionary<string, string> enDict = new Dictionary<string, string>
            {
                {HEADER, "Welcome" },
                {MESSAGE, "Hello world!" }
            };

            //ru
            Dictionary<string, string> ruDict = new Dictionary<string, string>
            {
                {HEADER, "Добро пожаловать" },
                {MESSAGE, "Привет мир!" }
            };

            //de
            Dictionary<string, string> deDict = new Dictionary<string, string>
            {
                {HEADER, "Willkommen" },
                {MESSAGE, "Hallo Welt!" }
            };

            resources = new Dictionary<string, Dictionary<string, string>>
            {
                {"en", enDict },
                {"ru", ruDict },
                {"de", deDict }
            };
        }

        public LocalizedString this[string name]
        {
            get
            {
                var currentCulture = CultureInfo.CurrentUICulture;
                string val = "";
                if (resources.ContainsKey(currentCulture.Name))
                {
                    if (resources[currentCulture.Name].ContainsKey(name))
                    {
                        val = resources[currentCulture.Name][name];
                    }
                }
                return new LocalizedString(name, val);
            }
        }

        public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return this;
        }
    }
}
