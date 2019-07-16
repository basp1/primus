using System;
using System.Collections.Generic;

namespace basp.primus
{
    public interface DataProvider<T> : IDisposable
    {
        TimeSeries<T> Request(DateTime from, DateTime to);
    }
}
