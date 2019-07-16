﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using basp.primus;

namespace primus.test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test_1()
        {
            var proxy = new CentralBankProvider(Currency.USDollar);
            var result = proxy.Request(new DateTime(2001, 3, 2), new DateTime(2001, 3, 14));
        }
    }
}