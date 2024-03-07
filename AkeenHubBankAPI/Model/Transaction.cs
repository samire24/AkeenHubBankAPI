using Microsoft.AspNetCore.Http.Connections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace AkeenHubBankAPI.Model
{

    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public string Id { get; set; }

        public string TransactionUniqueReference { get; set; } //this will generate at every instance off this class
        public decimal TransactionAmount { get; set; }
        public TranStatus TransactionStatus { get; set; } //this is an enum, we create below
        public bool IsSuccesful => TransactionStatus.Equals(TranStatus.Success); //tis guy depends on the transaction status
        public string TransactionSourceAccount { get; set; }
        public string TransactionDestinationAccount { get; set; }
        public string TransactionParticulars { get; set; }
        public TranType TranspoType { get; set; } // this is another enum, lets create below too

        public Transaction()
        {
            TransactionUniqueReference = $"{Guid.NewGuid().ToString().Replace("-","").Substring(1,27)}"; //we will use guid to generate it

        }

    }
    public enum TranStatus
    {
        Failed,
        Success,
        Error
    }

    public enum TranType 
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}
