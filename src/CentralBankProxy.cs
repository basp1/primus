﻿using System;
using System.Collections.Generic;
using System.Text;

using RestSharp;
using System.Xml;
using System.Globalization;

namespace basp.primus
{
    public class CentralBankProxy : IClientProxy
    {
        RestClient client;

        public CentralBankProxy()
        {
            client = new RestClient("http://www.cbr.ru");

        }

        public void Dispose()
        {
        }

        public ValuteSeries Request(Currency currency, DateTime from, DateTime to)
        {
            var request = new RestRequest("scripts/XML_dynamic.asp", Method.GET);

            request.AddParameter("date_req1",
                from.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                ParameterType.QueryString);

            request.AddParameter("date_req2",
                to.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                ParameterType.QueryString);

            request.AddParameter("VAL_NM_RQ",
                ToString(currency),
                ParameterType.QueryString);

            var response = client.Get(request);
            var content = response.Content;

            return ParseContent(content);
        }

        private ValuteSeries ParseContent(string content)
        {
            var series = new ValuteSeries();

            var reader = new XmlTextReader(new System.IO.StringReader(content));

            while (reader.Read())
            {
                Valute valute;
                if (XmlNodeType.Element == reader.NodeType && "Record" == reader.LocalName)
                {
                    valute.Date = DateTime.ParseExact(reader.GetAttribute("Date"), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    while (reader.Read() && "Value" != reader.LocalName) { }
                    reader.Read();
                    valute.Value = Double.Parse(reader.Value);

                    series.Add(valute);
                }
            }

            return series;
        }

        private static string ToString(Currency currency)
        {
            switch (currency)
            {
                case Currency.USDollar:
                    return "R01235";
                case Currency.BritishPoundSterling:
                    return "R01035";
                case Currency.ChinaYuan:
                    return "R01375";
                default:
                    throw new ArgumentException("unknown currency");
            }
        }
    }
}