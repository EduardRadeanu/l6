namespace Tap.Solid.Ocp
{
    public interface AccountCommissionStrategy
    {
        decimal CalculateCommission(decimal value);
    }

    class RegularAccountCommissionStrategy : AccountCommissionStrategy
    {
        public decimal CalculateCommission(decimal value)
        {
            return value * 0.04m;
        }
    }

    class GoldAccountCommissionStrategy : AccountCommissionStrategy
    {
        public decimal CalculateCommission(decimal value)
        {
            return value * 0.02m;
        }
    }

    public class BankAccount
    {
        public decimal AccountBalance { get; private set; }
        public AccountType AccountType { get; private set; }
        private readonly AccountCommissionStrategy commissionStrategy;

        public BankAccount(decimal initialBalance, AccountType accountType)
        {
            AccountBalance = initialBalance;
            AccountType = accountType;

            
            if (accountType == AccountType.Regular)
            {
                commissionStrategy = new RegularAccountCommissionStrategy();
            }
            else if (accountType == AccountType.Gold)
            {
                commissionStrategy = new GoldAccountCommissionStrategy();
            }
        }

        public void ExtractMoney(decimal value)
        {
            var commision = 0m;
            AccountBalance = AccountBalance - (value + commision);
        }
    }
}

