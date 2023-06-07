using System.Numerics;
using RSA.Interfaces;

namespace RSA;

public class RsaEncryptor : IEncryptor
{
    private BigInteger _n; // Modulus
    private BigInteger _e; // Public exponent

    public RsaEncryptor(BigInteger modulus, BigInteger exponent)
    {
        _n = modulus;
        _e = exponent;
    }

    public BigInteger Encrypt(int message)
    {

        return BigInteger.ModPow(message, _e, _n);
    }
}