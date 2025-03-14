#include <iostream>
#include <string>

// The BankAccount class encapsulates its data (account number and balance)
// by making them private. External code can interact with these fields only
// through public methods, which enforce rules for updating the internal state.
class BankAccount {
private:
    std::string accountNumber; // Private field: cannot be accessed directly from outside
    double balance;            // Private field: holds the current balance

public:
    // Constructor: Initializes the account with an account number and an initial balance.
    BankAccount(const std::string& acctNum, double initBalance)
        : accountNumber(acctNum), balance(initBalance) {}

    // Public method to deposit money into the account.
    // It ensures that only valid (positive) amounts are added.
    void deposit(double amount) {
        if (amount > 0) {
            balance += amount;
            std::cout << "Deposited $" << amount << ". New balance: $" << balance << "\n";
        } else {
            std::cout << "Invalid deposit amount!\n";
        }
    }

    // Public method to withdraw money from the account.
    // It checks that the withdrawal amount is positive and that there are sufficient funds.
    void withdraw(double amount) {
        if (amount > 0 && amount <= balance) {
            balance -= amount;
            std::cout << "Withdrew $" << amount << ". New balance: $" << balance << "\n";
        } else {
            std::cout << "Insufficient funds or invalid withdrawal amount!\n";
        }
    }

    // Public accessor method to get the current balance.
    // This method provides read-only access to the private balance field.
    double getBalance() const {
        return balance;
    }

    // Public method to display account information.
    void displayAccountInfo() const {
        std::cout << "Account Number: " << accountNumber << "\n";
        std::cout << "Balance: $" << balance << "\n";
    }
};

int main() {
    // Create a new bank account with a specific account number and initial balance.
    BankAccount account("ABC123", 500.0);

    // Display initial account information.
    account.displayAccountInfo();

    // Deposit and withdraw money using public methods.
    account.deposit(150.0);
    account.withdraw(200.0);
    account.withdraw(1000.0);  // This should trigger an error due to insufficient funds
    account.withdraw(1000000);

    // Final balance output using the accessor method.
    std::cout << "Final Balance: $" << account.getBalance() << "\n";

    return 0;
}
