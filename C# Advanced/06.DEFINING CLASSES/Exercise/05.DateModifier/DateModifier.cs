using System;

namespace _05.DateModifier
{
    public class DateModifier
    {
        private DateTime startDate;
        private DateTime endDate;

        public DateModifier(DateTime start, DateTime end)
        {
            this.StartDate = start;
            this.EndDate = end;
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }


        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public double GetDaysDifference()
        {
            return Math.Abs((EndDate - startDate).TotalDays);
        }
    }
}
