| Classes			| Methods/Properties                                | Scenario							| Outputs          |
|-------------------|---------------------------------------------------|-----------------------------------|------------------
|Account.cs			|Deposit(Payment payment) | Let user deposit money into account | bool
|Account.cs			|Withdraw(Payment payment) | Let user withdraw money from account | bool
|Account.cs			|PrintBankStatement() | User wants to see a transaction history | string
|Account.cs			|CalculateBalance()
|Account.cs			|ApproveOrRejectOverdraft(bool approve)	|Let bank managers approve or reject an overdraft request | bool
|Account.cs			|SendBankStatement()
|Account.cs			|Guid Id	| Unique identifier for object instance | Guid
|Account.cs			|Guid AccountNumber	| Unique identifier for an account | Guid
|Account.cs			|Branch BranchName | Associate an account to a branch using enums | Branch
|Account.cs			|decimal Balance
|Payment.cs			|Guid Id | Unique identifier for payment | Guid
|Payment.cs			|Guid Account | Unique identifier for account for the payment | Guid
|Payment.cs			|DateTime Date | Date and time of the payment | DateTime
|Payment.cs			|decimal Amount | Amount we want to withdraw/deposit | decimal
|SavingAccount.cs   | |Inherits the Account class
|CurrentAccount.cs  | | Inherits the Account class
|CurrentAccount.cs	|RequestOverdraft(int overdraftAmount) | Request overdraft on account | bool
