using System;
using System.Collections.Generic;

namespace basp.primus
{
    public class TimeSeries<T>
    {
        IList<T> items;

        public TimeSeries()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }
    }
}
