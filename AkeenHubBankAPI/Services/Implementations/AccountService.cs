using AkeenHubBankAPI.DAL;
using AkeenHubBankAPI.Model;
using AkeenHubBankAPI.Services.Interfaces;
using System.Text;

namespace AkeenHubBankAPI.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private AkeenBankingDBContext _dbContext;
        public AccountService(AkeenBankingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account Authenticate(string AccountNumber, string Pin)
        {
            //lets authenticate, see if account exist for that number

        }

        public Account Create(Account account, string Pin, string confirmPin)
        {
            //this is to create new account
            if (_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("An Account " +
                "already exist with this email");
            //validating the pin
            if (!Pin.Equals(confirmPin)) throw new ArgumentException("Pins do no match", "Pin");
            //now all validation passes, lets create account
            //we are hashing/ encrypting the pin first
            byte[] pinHash, pinSalt;
            CreatePinHash(Pin, out pinHash, out pinSalt); //let us create this crypto metthod

            account.PinHash = pinHash;
            account.PinSalt = pinSalt;

            //all good, lets add account to db
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();


        }

        private static void CreatePinHash(string pin, out byte[] pinHash, out byte[] pinSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pinSalt = hmac.Key;
                pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
            }
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public Account GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account, string Pin = null)
        {
            throw new NotImplementedException();
        }
    }
}
