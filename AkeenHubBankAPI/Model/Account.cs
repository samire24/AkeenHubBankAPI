using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace AkeenHubBankAPI.Model
{
    [Table("Accounts")]

    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public decimal CurrentAccountBalance { get; set; }

        public AccountType AccountType { get; set; } // This will be an enum to show the if the accout to be created is "savings" or "current"

        public string AccountNumberGenerated { get; set; } //this is where we generate account number

        //we will show the hash and salt of the Account Transaction pin here
        public byte[] PinHash { get; set; }
        public byte[] PinSalt { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public DateTime DateCreated { get; set; }

        //to generate account number, lets do that in the constructor

        // but first we generate a random number

        Random rand = new Random();

        public Account()
        {
            AccountNumberGenerated = Convert.ToString((long)rand.NextDouble() * 9_000_000_000L + 1_000_000_000L);
            //we did 9_000_000_000L  so we could get a 10 digit random numbers

            //also w need the accountName property = FirstName+LastName
            AccountName = $"{FirstName} {LastName}"; //e.g Fisayo Ireti

        }
    }

    public enum AccountType
    {
        Savings,
        Current,
        Corporate,
        Government
    }
}
