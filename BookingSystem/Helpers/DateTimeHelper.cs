namespace BookingSystem.Helpers
{
    public class DateTimeHelper
    {
        public bool AreDateTimeRangesOverlap(DateTime firstDateFrom, DateTime firstDateTo, DateTime secondDateFrom, DateTime secondDateTo)
        {
            if (firstDateFrom <= secondDateTo && secondDateFrom <= firstDateTo)
            {
                return true;
            }
            return false;
        }
    }
}
