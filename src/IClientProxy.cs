using System;
using System.Collections.Generic;
using System.Text;

namespace basp.primus
{
    public interface IClientProxy : IDisposable
    {
        ValuteSeries Request(Currency currency, DateTime from, DateTime to);
    }
}
