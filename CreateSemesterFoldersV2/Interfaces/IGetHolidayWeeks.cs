namespace CreateSemesterFoldersV2.Interfaces
{
    public interface IGetHolidayWeeks
    {
        DateTime FindEasterSunday(int year);
        DateTime FirstSundayOfAdvent(int year);
        int WeekNumber(int year, int month, int day);
        List<int> HolidayWeeks(int easterWeekNumber, int firstAdventWeekNumber);
    }
}
