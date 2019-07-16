using System;
using System.Collections.Generic;

namespace basp.primus.core.providers
{
    public interface DataProvider<T> : IDisposable
    {
        TimeSeries<T> Request(DateTime from, DateTime to);
    }
}
