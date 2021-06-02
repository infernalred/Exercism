using System;

public class BankAccount
{
    private bool _isOpen;
    private decimal _balance;
    public void Open() => _isOpen = true;

    public void Close() => _isOpen = false;

    public decimal Balance => _isOpen == true ? _balance : throw new InvalidOperationException("Account is closed.");

    public void UpdateBalance(decimal change)
    {
        lock (this)
        {
            _balance += change;
        }
    }
}
