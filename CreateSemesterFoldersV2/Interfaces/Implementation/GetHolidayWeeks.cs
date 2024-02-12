namespace CreateSemesterFoldersV2.Interfaces.Implementation
{
    public class GetHolidayWeeks : IGetHolidayWeeks
    {
        public List<int> HolidayWeeks(int easterWeekNumber, int firstAdventWeekNumber)
        {
            ICheckIfInt validate = new CheckIfInt();

            int[] ferieUger = [27, 28, 29, 30, 42];
            List<int> ferie = [.. ferieUger, easterWeekNumber];

            Console.Write("Har du vinterferie? (J/N): ");
            string vFerie = Console.ReadLine().ToUpper();
            if (vFerie == "J")
            {
                Console.WriteLine("");
                Console.Write("Hvilket ugenummer har du vinterferie i?: ");
                string vUge = Console.ReadLine();
                int input = validate.Validate(vUge);
                ferie.Add(input);
            }

            int christmasWeek = firstAdventWeekNumber + 4;
            if (christmasWeek > 52)
            {
                christmasWeek = 52;
                ferie.Add(christmasWeek);
                ferie.Add(1);
            }
            else if (christmasWeek == 52)
            {
                ferie.Add(christmasWeek);
                ferie.Add(1);
            }
            else
            {
                ferie.Add(christmasWeek);
                ferie.Add(christmasWeek + 1);
            }

            return ferie;
        }

        public DateTime FindEasterSunday(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = (h + l - 7 * m + 114) % 31 + 1;
            return new DateTime(year, month, day).Date;
        }

        public DateTime FirstSundayOfAdvent(int year)
        {
            int weeks = 4;
            int correction = 0;
            DateTime christmas = new DateTime(year, 12, 24);

            if (christmas.DayOfWeek != DayOfWeek.Sunday)
            {
                weeks--;
                correction = (int)christmas.DayOfWeek - (int)DayOfWeek.Sunday;
            }
            return christmas.AddDays(-1 * (weeks * 7 + correction));
        }

        public int WeekNumber(int year, int month, int day)
        {
            int a = (14 - month) / 12;
            int y = year + 4800 - a;
            int m = month + 12 * a - 3;
            int JD = day + (153 * m + 2) / 5 + 365 * y + y / 4 - y / 100 + y / 400 - 32045;
            int d4 = (JD + 31741 - JD % 7) % 146097 % 36524 % 1461;
            int L = d4 / 1460;
            int d1 = (d4 - L) % 365 + L;
            return d1 / 7 + 1;
        }
    }
}
