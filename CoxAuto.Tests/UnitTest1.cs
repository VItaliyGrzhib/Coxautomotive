using CoxAuto.Loader.Model;
using CoxAuto.Loader.Service;
using CoxAuto.Service.Service;
using NUnit.Framework;
using System.Linq;

namespace CoxAuto.Tests
{

    public class Tests
    {
        const string path = "C:\\Users\\ID\\source\\repos\\VItaliyGrzhib\\Coxautomotive\\docs\\Dealertrack-CSV-Example.csv";

        private ILoader<SalesDataModel> _fileloader { get; set; }

        [Test]
        public void Test()
        {
            _fileloader = new csvFileLoader();
            var model = _fileloader.GetData(path);
            Assert.IsTrue(model.All(x=>x!=null));
            
        }


    }
}