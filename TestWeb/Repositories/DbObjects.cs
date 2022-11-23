using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public class DbObjects
    {
        public static void Initial(AppDbContext context)
        {

            if (context.Localizations.ToList().Count == 0)
            {
                context.Localizations.AddRange(Localizations.Select(x => x.Value));
                context.SaveChanges();
            }

            if (context.Symptoms.ToList().Count == 0)
            {
                context.AddRange(
                        new Symptom
                        {
                            Name = "Мигрень",
                            SymptomLocalization = Localizations["Голова"]
                        },

                        new Symptom
                        {
                            Name = "Боль в нижней части живота",
                            SymptomLocalization = Localizations["Живот"]
                        }
                    );
                context.SaveChanges();
            }
        }

        private static Dictionary<string, Localization> _Localization;

        public static Dictionary<string, Localization> Localizations
        {
            get
            {
                if (_Localization is null)
                {
                    var list = new Localization[] {
                        new Localization{Name = "Голова"},
                        new Localization{Name = "Живот"},
                        };
                    _Localization = new Dictionary<string, Localization>();

                    foreach(var item in list)
                    {
                        _Localization.Add(item.Name, item);
                    }
                }

                return _Localization;
            }

        }
    }
}
