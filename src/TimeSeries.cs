using System;
using System.Linq;
using System.Collections.Generic;

namespace basp.primus
{
    public class TimeSeries<T>
    {
        IList<DateTime> dates;
        IList<T> items;

        public TimeSeries()
        {
            dates = new List<DateTime>();
            items = new List<T>();
        }

        public KeyValuePair<DateTime, T> First
        {
            get
            {
                return new KeyValuePair<DateTime, T>(dates.First(), items.First());
            }
        }

        public KeyValuePair<DateTime, T> Last
        {
            get
            {
                return new KeyValuePair<DateTime, T>(dates.Last(), items.Last());
            }
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public void Add(DateTime date, T item)
        {
            if (Count > 0 && date < dates.Last())
            {
                throw new ArgumentOutOfRangeException("'date' should be < " + dates.Last().ToString());
            }

            dates.Add(date);
            items.Add(item);
        }

        public void Insert(DateTime date, T item)
        {
            int index = LowerBound(dates, date);

            if (index >= 0 && index < Count && date == dates[index])
            {
                dates[index] = date;
                items[index] = item;
            }
            else
            {
                dates.Insert(index, date);
                items.Insert(index, item);
            }
        }

        static int LowerBound(IList<DateTime> array, DateTime date)
        {
            int n = array.Count - 1;
            int l = 0;
            int r = n;

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (date == array[m])
                {
                    return m;
                }
                if (date < array[m])
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            return l;
        }
    }
}
