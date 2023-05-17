using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string telephoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime membershipCreationDate { get; set; }
        public DateTime membershipExpirationDate { get; set; }
        public string fitnessGoals { get; set; }
        public string membershipStatus {
            get
            {
                var now = DateTime.Now.Date;
                var expiration = membershipExpirationDate.Date;

                if (now > expiration)
                {
                    return "Expired";
                }
                else if (expiration < now.AddDays(30))
                {
                    return "Soon to Expire";
                }
                else
                {
                    return "Valid";
                }
            }

            set { }


        }

        public Client()
        {
            
        }




    }


}
