using ConsoleApp16;
using System;

class Program
{
    static void Main()
    {
        try
        {
            Money money1 = new Money(10, 50);
            Money money2 = new Money(5, 75);

            Console.WriteLine($"Сумма 1: {money1}");
            Console.WriteLine($"Сумма 2: {money2}");

            Money sum = money1 + money2;
            Console.WriteLine($"Сумма: {sum}");

            Money difference = money1 - money2;
            Console.WriteLine($"Разность: {difference}");

            Money multiplied = money1 * 2;
            Console.WriteLine($"Умножение на 2: {multiplied}");

            Money divided = money1 / 2;
            Console.WriteLine($"Деление на 2: {divided}");

            money1++;
            Console.WriteLine($"После увеличения на 1 копейку: {money1}");

            money1--;
            Console.WriteLine($"После уменьшения на 1 копейку: {money1}");

            Console.WriteLine($"money1 > money2: {money1 > money2}");
            Console.WriteLine($"money1 < money2: {money1 < money2}");
            Console.WriteLine($"money1 == money2: {money1 == money2}");
        }
        catch (BankruptException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}