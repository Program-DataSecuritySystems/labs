using System.Numerics;
using Generator;

namespace RSA;

public class RsaKeyGenerator
{
    private BigInteger d; // Private exponent
    private BigInteger e; // Public exponent
    private BigInteger n; // Modulus
    private BigInteger p; // First prime number
    private BigInteger phi; // Euler's totient function
    private BigInteger q; // Second prime number

    public void GenerateKeys(int numberOfDigits)
    {
        PrimeGenerator primeGenerator = new PrimeGenerator();
        p = primeGenerator.GeneratePrime(numberOfDigits);
        q = primeGenerator.GeneratePrime(numberOfDigits);

        n = p * q;
        phi = (p - 1) * (q - 1);

        e = 65537;
        d = ModInverse(e, phi);
    }

    public RsaEncryptor GetEncryptor()
    {
        return new RsaEncryptor(n, e);
    }

    public RsaDecryptor GetDecryptor()
    {
        return new RsaDecryptor(n, d);
    }

    private BigInteger ModInverse(BigInteger a, BigInteger m)
    {
        BigInteger m0 = m;
        BigInteger y = 0;
        BigInteger x = 1;

        if (m == 1)
            return 0;

        while (a > 1)
        {
            BigInteger q = a / m;
            BigInteger t = m;

            m = a % m;
            a = t;
            t = y;

            y = x - q * y;
            x = t;
        }

        if (x < 0)
            x += m0;

        return x;
    }
}