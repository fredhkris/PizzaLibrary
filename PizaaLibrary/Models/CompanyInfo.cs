using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class CompanyInfo
    {
        private static CompanyInfo instance;

        public double Vat
        {
            get; set;
        }
        public string CVR
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public double ClubDiscount
        {
            get; set;
        }

        private CompanyInfo()
        {
        }

        public static CompanyInfo GetInstance()
        {
            if (instance == null)
            {
                instance = new CompanyInfo();
            }
            return instance;
        }
    }
}
