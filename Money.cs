using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp16
{
    public class BankruptException : Exception
    {
        public BankruptException(string message) : base(message) { }
    }

    public class Money
    {
        private int hryvnias;
        private int kopecks;

        public Money(int hryvnias, int kopecks)
        {
            if (hryvnias < 0 || kopecks < 0)
                throw new ArgumentException("Сумма не может быть отрицательной.");

            this.hryvnias = hryvnias + kopecks / 100;
            this.kopecks = kopecks % 100;
        }

        public override string ToString()
        {
            return $"{hryvnias} грн {kopecks} коп.";
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.hryvnias + b.hryvnias, a.kopecks + b.kopecks);
        }

        public static Money operator -(Money a, Money b)
        {
            int totalKopecksA = a.hryvnias * 100 + a.kopecks;
            int totalKopecksB = b.hryvnias * 100 + b.kopecks;

            if (totalKopecksA < totalKopecksB)
                throw new BankruptException("Недостаточно средств.");

            return new Money(0, totalKopecksA - totalKopecksB);
        }

        public static Money operator /(Money a, int divisor)
        {
            if (divisor <= 0)
                throw new ArgumentException("Делитель должен быть положительным.");

            int totalKopecks = a.hryvnias * 100 + a.kopecks;
            return new Money(0, totalKopecks / divisor);
        }

        public static Money operator *(Money a, int multiplier)
        {
            if (multiplier < 0)
                throw new ArgumentException("Множитель не может быть отрицательным.");

            int totalKopecks = a.hryvnias * 100 + a.kopecks;
            return new Money(0, totalKopecks * multiplier);
        }

        public static Money operator ++(Money a)
        {
            return new Money(a.hryvnias, a.kopecks + 1);
        }

        public static Money operator --(Money a)
        {
            int totalKopecks = a.hryvnias * 100 + a.kopecks;

            if (totalKopecks <= 0)
                throw new BankruptException("Недостаточно средств для уменьшения.");

            return new Money(0, totalKopecks - 1);
        }

        public static bool operator <(Money a, Money b)
        {
            return (a.hryvnias * 100 + a.kopecks) < (b.hryvnias * 100 + b.kopecks);
        }

        public static bool operator >(Money a, Money b)
        {
            return (a.hryvnias * 100 + a.kopecks) > (b.hryvnias * 100 + b.kopecks);
        }

        public static bool operator ==(Money a, Money b)
        {
            return (a.hryvnias == b.hryvnias) && (a.kopecks == b.kopecks);
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Money)
            {
                Money other = (Money)obj;
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (hryvnias, kopecks).GetHashCode();
        }
    }
}