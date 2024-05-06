using System;

namespace Datens
{
    public class Date
    {
        private int day;
        public int Day
        {
            get => day;
            set => day = value;

        }
        private int month;
        public int Month
        {
            get => month;
            set => month = value;
        }
        private int year;
        public int Year
        {
            get => year;
            set => year = value;
        }
    }
}