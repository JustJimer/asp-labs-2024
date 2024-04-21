namespace LR3_Chupyna_ASP_402
{
    public class TimeOfDayService
    {
        public string GetTimeOfDayMessage()
        {
            var currentHour = DateTime.Now.Hour;
            if (currentHour >= 6 && currentHour < 12)
            {
                return "good morning";
            }
            else if (currentHour >= 12 && currentHour < 18)
            {
                return "good day";
            }
            else if (currentHour >= 18 && currentHour < 24)
            {
                return "good evening";
            }
            else
            {
                return "good night";
            }
        }
    }
}
