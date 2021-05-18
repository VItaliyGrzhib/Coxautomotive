using System;
using System.Globalization;

namespace CoxAuto.Loader.Model
{
    public class SalesDataModel
    {
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }

        public SalesDataModel(string[] entity)
        {
            var culture = new CultureInfo("en-Ca");

            DealNumber = int.Parse(entity[0]);
            CustomerName = entity[1];
            DealershipName = entity[2];
            Vehicle = entity[3];
            Price = $"CAD{(decimal.Parse(entity[4])).ToString("C", culture)}";
            Date = DateTime.Parse(entity[5]).ToString("dd-MM-yyyy", culture);
        }

    }
}
