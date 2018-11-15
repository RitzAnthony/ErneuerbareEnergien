using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CimArkUnitTests
{
    [TestClass]
    public class PowerStatisticTest
    {
        //This command is a jenkins test
        private readonly CimArkDevEntities _ctx = new CimArkDevEntities();

        //Method GetAllPowerProductionByYear
        [TestMethod]
        public void GetAllPowerProductionByYearTest_2Years()
        {
            var testResult = PowerStatistic.GetAllPowerProductionByYear(2017, 2018);
            Assert.AreEqual(testResult.Count, _ctx.PowerTypes.Count() * 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "beginYear must be smaller or equal to endYear")]
        public void GetAllPowerProductionByYearTest_EndBeforeBeginYear()
        {
            PowerStatistic.GetAllPowerProductionByYear(2013, 2012);
        }

        [TestMethod]
        public void GetAllPowerProductionByYearTest_3Years()
        {
            var testResult = PowerStatistic.GetAllPowerProductionByYear(2011, 2013);
            Assert.AreEqual(testResult.Count, _ctx.PowerTypes.Count() * 3);
        }

        [TestMethod]
        public void GetAllPowerProductionByYearTest_1Year()
        {
            var testResult = PowerStatistic.GetAllPowerProductionByYear(2000, 2000);
            Assert.AreEqual(testResult.Count, _ctx.PowerTypes.Count());
        }
    }
}
