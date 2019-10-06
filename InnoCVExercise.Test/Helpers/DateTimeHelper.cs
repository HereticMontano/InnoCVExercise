using System;

namespace InnoCVExercise.Test.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime RandomDay()
        {
            var gen = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
