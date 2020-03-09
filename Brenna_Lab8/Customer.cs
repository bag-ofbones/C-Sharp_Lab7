using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Brenna_Lab5
{ // Create a new class called “Customer”, inherit PersonV2, and add the following properties: CustomerSince (DateTime)TotalPurchases (Double)DiscountMember (Bool)RewardsEarned (Int)Adjust the main program to use these new features properly.
    public class Customer : PersonV2
    {
        //Declare vars
        private String custsince;
        private String totalpurch;
        private String discountMbr;
        private String rewards;

        public string CustSince
        {
            get { return custsince; }
            set
            {
                if (ValidationLibrary.IsValidCustSince(value))
                { custsince = value; }
                else { custsince = "INVALID: Date/Time"; }
            }
        }
        public string TotalPurch
        {
            get { return totalpurch; }
            set
            {
                if (ValidationLibrary.IsValidTotalPurch(value))
                { totalpurch = value; }
                else { totalpurch = "INVALID: Total Purchases"; }
            }
        }
        public string DiscountMbr
        {
            get { return discountMbr; }
            set
            {
                if (ValidationLibrary.IsValidDiscountMbr(value))
                { discountMbr = value; }
                else { discountMbr = "INVALID: type 'Y' for Yes, 'N' for No"; }
            }
        }
        public string Rewards
        {
            get { return rewards; }
            set
            {
                if (ValidationLibrary.IsValidRewards(value))
                { rewards = value; }
                else { rewards = "INVALID: Rewards Amount"; }
            }
        }
        //Constructor for all added properties
        public Customer() : base()  //calls the parent constructor
        {
            CustSince = "";
            TotalPurch = "";
            DiscountMbr = "";
            Rewards = "";
        }
    }
}
