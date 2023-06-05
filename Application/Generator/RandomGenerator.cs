using System.Numerics;

namespace Generator;

public class RandomGenerator
{
    private static Random _random = new();

    public static BigInteger GenerateRandomNumber(BigInteger min, BigInteger max)
    {
        byte[] bytes = new byte[max.ToByteArray().LongLength];
        BigInteger randomNumber;
        do
        {
            _random.NextBytes(bytes);
            randomNumber = new BigInteger(bytes);
        } while (randomNumber < min || randomNumber >= max);

        return randomNumber;
    }
}