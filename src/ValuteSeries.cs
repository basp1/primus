using System;
using System.Collections.Generic;
using System.Text;

namespace basp.primus
{
    public class ValuteSeries
    {
        IList<Valute> valutes;

        public ValuteSeries()
        {
            valutes = new List<Valute>();
        }

        public void Add(Valute valute)
        {
            valutes.Add(valute);
        }
    }
}
