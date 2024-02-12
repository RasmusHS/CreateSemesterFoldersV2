namespace CreateSemesterFoldersV2.Interfaces.Implementation
{
    public class CreateFolders : ICreateFolders
    {
        public void Create(int startUge, int slutUge, string sti)
        {
            IGetHolidayWeeks getHolidayWeeks = new GetHolidayWeeks();

            DateTime easterSunday = getHolidayWeeks.FindEasterSunday(DateTime.Today.Year);
            int easterWeekNumber = getHolidayWeeks.WeekNumber(easterSunday.Year, easterSunday.Month, easterSunday.Day);
            int firstAdventWeekNumber = getHolidayWeeks.WeekNumber(
                getHolidayWeeks.FirstSundayOfAdvent(DateTime.Today.Year).Year,
                getHolidayWeeks.FirstSundayOfAdvent(DateTime.Today.Year).Month,
                getHolidayWeeks.FirstSundayOfAdvent(DateTime.Today.Year).Day);

            List<int> ferie = getHolidayWeeks.HolidayWeeks(easterWeekNumber, firstAdventWeekNumber);

            for (int uge = startUge; uge <= slutUge; uge++)
            {
                string mappeSti = @$"";

                try
                {
                    if (ferie.Contains(uge))
                        continue;
                    else
                    {
                        mappeSti = @$"{sti}{"\\Uge " + uge}";
                    }

                    if (Directory.Exists(mappeSti))
                    {
                        Console.WriteLine($"Programmet stødte på en mappe med ugenummeret {uge}, som allerede eksistere");
                        return;
                    }
                    else
                    {
                        //Forsøger at lave mapperne
                        DirectoryInfo di = Directory.CreateDirectory(mappeSti);
                        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(mappeSti));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }

            }
        }
    }
}
