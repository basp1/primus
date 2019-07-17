using System;
using System.Collections.Generic;

using basp.primus.core;

namespace basp.primus.data
{
    public interface DataProvider<T> : IDisposable
    {
        TimeSeries<T> Request(DateTime from, DateTime to);
    }
}
