using System;
using System.Collections.Generic;
using System.Linq;
using Mediware.Util.Validation.Utils.Enumerations;

namespace Mediware.Util.Validation.Utils
{
    public static class Holidays
    {
        public static readonly IDictionary<Country, IList<Holiday>> FixedNationalDays = new Dictionary
            <Country, IList<Holiday>>
            {
                {
                    Country.Cz, new List<Holiday>
                        {
                            new Holiday(null, 1, 1, "Den obnovy samostatného českého státu"),
                            new Holiday(null, 5, 1, "Svátek práce"),
                            new Holiday(null, 5, 8, "Den vítězství"),
                            new Holiday(null, 7, 5, "Den slovanských věrozvěstů Cyrila a Metoděje"),
                            new Holiday(null, 7, 6, "Den upálení mistra Jana Husa"),
                            new Holiday(null, 9, 28, "Den české státnosti"),
                            new Holiday(null, 10, 28, "Den vzniku samostatného československého státu"),
                            new Holiday(null, 11, 17, "Den boje za svobodu a demokracii"),
                            new Holiday(null, 12, 24, "Štědrý den"),
                            new Holiday(null, 12, 25, "1. svátek vánoční"),
                            new Holiday(null, 12, 26, "1. svátek vánoční"),
                        }
                },
                {
                    Country.Sk, new List<Holiday>
                        {
                            new Holiday(null, 1, 1, "Deň vzniku Slovenskej republiky"),
                            new Holiday(null, 1, 6, "Zjavenie Pána (Traja králi a vianočný sviatok pravoslávnych kresťanov)"),
                            new Holiday(null, 5, 1, "Sviatok práce"),
                            new Holiday(null, 5, 8, "Deň víťazstva nad fašizmom"),
                            new Holiday(null, 7, 5, "Sviatok svätého Cyrila a svätého Metoda"),
                            new Holiday(null, 8, 29, "Výročie Slovenského národného povstania"),
                            new Holiday(null, 9, 1, "Deň Ústavy Slovenskej republiky"),
                            new Holiday(null, 9, 15, "Sedembolestná Panna Mária"),
                            new Holiday(null, 11, 1, "Sviatok všetkých svätých"),
                            new Holiday(null, 11, 17, "Deň boja za slobodu a demokraciu"),
                            new Holiday(null, 12, 24, "Štedrý deň"),
                            new Holiday(null, 12, 25, "Prvý sviatok vianočný"),
                            new Holiday(null, 12, 26, "Druhý sviatok vianočný"),
                        }
                }
            };

        private static IEnumerable<Holiday> GetMoveableNationalDays(Country country, int year)
        {
            var moveableNationalDays = new List<Holiday>();
            var eDate = EasterDate(year);
            switch (country)
            {
                case Country.Cz:
                    moveableNationalDays.Add(new Holiday(year, eDate.Month, eDate.Day, "Velikonoční pondělí"));
                    break;
                case Country.Sk:
                    moveableNationalDays.Add(new Holiday(year, eDate.Month, eDate.Day, "Veľkonočný pondelok"));
                    var eFriday = eDate.AddDays(-3);
                    moveableNationalDays.Add(new Holiday(year, eFriday.Month, eFriday.Day, "Veľký piatok"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(country), country, null);
            }
            return moveableNationalDays;
        }

        public static List<Holiday> GetHolidayDaysByCountry(Country country, int year)
        {
            if (year > DateTime.MaxValue.Year || year < DateTime.MinValue.Year)
                return null;
            var holidays = new List<Holiday>();

            var fixedNationalDays = FixedNationalDays.ContainsKey(country) ? FixedNationalDays[country] : null;
            if (fixedNationalDays != null)
                holidays.AddRange(fixedNationalDays.ToList());

            var moveableHolidays = GetMoveableNationalDays(country, year);
            if (moveableHolidays != null)
                holidays.AddRange(moveableHolidays);

            return holidays;
        }

        public static List<Holiday> GetHolidayDaysByCountry(Country country, int yearFrom, int yearTo)
        {
            if ((yearFrom > yearTo) || (yearTo > DateTime.MaxValue.Year) || (yearFrom < DateTime.MinValue.Year))
                return null;
            var holidays = new List<Holiday>();

            var fixedNationalDays = FixedNationalDays.ContainsKey(country) ? FixedNationalDays[country] : null;
            if (fixedNationalDays != null)
                holidays.AddRange(fixedNationalDays.ToList());

            for (var year = yearFrom; year <= yearTo; year++)
            {
                var moveableHolidays = GetMoveableNationalDays(country, year);
                if (moveableHolidays != null)
                    holidays.AddRange(moveableHolidays);
            }
            return holidays;
        }

        public struct Holiday
        {
            public Holiday(int? year, int month, int day, string name) : this()
            {
                Year = year;
                Month = month;
                Day = day;
                Name = name;
            }

            public int? Year { get; set; }

            public int Month { get; set; }

            public int Day { get; set; }

            public string Name { get; set; }
        }

        /// <summary>
        /// Method compute Easter Monaday for given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static DateTime EasterDate(int year)
        {
            int month = 3, golden = year % 19 + 1, century = year / 100 + 1, x = (3 * century) / 4 - 12, y = (8 * century + 5) / 25 - 5, sunday = (5 * year) / 4 - x - 10, epact = (11 * golden + 20 + y - x) % 30;

            if (epact == 24)
            {
                epact++;
            }
            if ((epact == 25) && (golden > 11))
            {
                epact++;
            }
            var n = 44 - epact;
            if (n < 21)
            {
                n = n + 30;
            }
            var sun = (n + 7) - ((sunday + n) % 7);
            if (sun > 31)
            {
                sun -= 31;
                month = 4;
            }
            return new DateTime(year, month, sun).AddDays(1);
        }
    }
}
