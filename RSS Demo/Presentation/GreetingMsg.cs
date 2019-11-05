using System;

namespace RSS_Demo
{
    public class GreetingMsg
    {
        public virtual string Greet()
        {
            return "Nu är det inte jul";
        }
    }

    public class HolidayGreeting : GreetingMsg
    {
        public override string Greet()
        {
            var dateNow = DateTime.Now;
            if (dateNow.Month == 10 && dateNow.Day == 31)
            {
                return "Nu är det Halloween";
            }
            else if (dateNow.Month == 12 && dateNow.Day == 24)
            {
                return "Nu är det Jul";
            }
            else
            {
                return base.Greet();
            }
        }
    }
}