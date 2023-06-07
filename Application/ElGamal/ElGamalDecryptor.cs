using System.Numerics;

namespace ElGamal;

public class ElGamalDecryptor
{
    private BigInteger _p; // Велике просте число
    private BigInteger _x; // Секретний ключ

    public ElGamalDecryptor(BigInteger p, BigInteger x)
    {
        _p = p;
        _x = x;
    }

    public BigInteger Decrypt(BigInteger[] encrypted)
    {
        BigInteger c1 = encrypted[0];
        BigInteger c2 = encrypted[1];

        BigInteger c1Inverse = BigInteger.ModPow(c1, _p - 1 - _x, _p);
        BigInteger decrypted = (c1Inverse * c2) % _p;

        return decrypted;
    }
}