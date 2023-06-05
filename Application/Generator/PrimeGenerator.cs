using System.Numerics;

namespace Generator;

public class PrimeGenerator
{
    private static readonly Random Random = new();

    public BigInteger GeneratePrime(int numberOfDigits)
    {
        while (true)
        {
            var candidate = GenerateRandomNumber(numberOfDigits);
            if (IsPrime(candidate)) return candidate;
        }
    }

    private BigInteger GenerateRandomNumber(int numberOfDigits)
    {
        var min = BigInteger.Pow(10, numberOfDigits - 1);
        var max = BigInteger.Pow(10, numberOfDigits);

        var randomBytes = new byte[numberOfDigits];
        Random.NextBytes(randomBytes);

        var randomNumber = new BigInteger(randomBytes);
        if (randomNumber < 0) randomNumber = -randomNumber;

        return BigInteger.Remainder(randomNumber, max - min) + min;
    }

    private bool IsPrime(BigInteger number)
    {
        if (number == 2 || number == 3)
            return true;

        if (number < 2 || number % 2 == 0)
            return false;

        var d = number - 1;
        var s = 0;

        while (d % 2 == 0)
        {
            d /= 2;
            s++;
        }

        for (var i = 0; i < 10; i++) // Тест Міллера-Рабіна
        {
            var a = GenerateRandomBigInteger(number.ToByteArray().Length - 1);
            var x = BigInteger.ModPow(a, d, number);

            if (x == 1 || x == number - 1)
                continue;

            for (var r = 1; r < s; r++)
            {
                x = BigInteger.ModPow(x, 2, number);

                if (x == 1)
                    return false;

                if (x == number - 1)
                    break;
            }

            if (x != number - 1)
                return false;
        }

        return true;
    }

    private BigInteger GenerateRandomBigInteger(int numberOfDigits)
    {
        var min = BigInteger.Pow(10, numberOfDigits - 1);
        var max = BigInteger.Pow(10, numberOfDigits);

        var bytes = new byte[numberOfDigits];
        var random = new Random();
        random.NextBytes(bytes);

        var result = new BigInteger(bytes);
        result = BigInteger.Abs(result);

        if (result < min)
            result += min;

        if (result >= max)
            result %= max - min;

        return result;
    }

    private BigInteger Sqrt(BigInteger number)
    {
        var x = number;
        var y = (x + 1) / 2;
        while (y < x)
        {
            x = y;
            y = (x + number / x) / 2;
        }

        return x;
    }
}