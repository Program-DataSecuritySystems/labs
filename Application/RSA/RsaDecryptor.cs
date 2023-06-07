using System.Numerics;
using RSA.Interfaces;

namespace RSA;

public class RsaDecryptor : IDecryptor
{
    private BigInteger n; // Modulus
    private BigInteger d; // Private exponent

    public RsaDecryptor(BigInteger modulus, BigInteger exponent)
    {
        n = modulus;
        d = exponent;
    }

    public BigInteger Decrypt(BigInteger encryptedMessage)
    {
        // Decryption using the private exponent and modulus
        return BigInteger.ModPow(encryptedMessage, d, n);
    }

    public static BigInteger Decrypt(BigInteger[] encrypted, BigInteger x, BigInteger p)
    {
        BigInteger c1 = encrypted[0];
        BigInteger c2 = encrypted[1];

        BigInteger c1Inverse = BigInteger.ModPow(c1, p - 1 - x, p); // Calculate c1^(-x) mod p
        BigInteger decrypted = (c1Inverse * c2) % p;

        return decrypted;
    }
}