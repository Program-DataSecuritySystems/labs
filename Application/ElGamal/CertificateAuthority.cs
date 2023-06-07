using System.Numerics;
using Generator;

namespace ElGamal;

public class CertificateAuthority
{
    private BigInteger _g; // Примітивний корінь по модулю p
    private BigInteger _p; // Велике просте число
    private BigInteger _privateKey; // Закритий ключ сертифікаційного органу

    public CertificateAuthority(BigInteger p, BigInteger g)
    {
        _p = p;
        _g = g;
        GeneratePrivateKey();
    }

    private void GeneratePrivateKey()
    {
        _privateKey = RandomGenerator.GenerateRandomNumber(2, _p - 1);
    }

    public BigInteger GenerateCertificate(BigInteger y)
    {
        var r = RandomGenerator.GenerateRandomNumber(2, _p - 1);
        BigInteger s = BigInteger.ModPow(y, r, _p);

        BigInteger signature = BigInteger.ModPow(s, _privateKey, _p);
        return ((s << 16) + signature);
    }

    public bool VerifyCertificate(BigInteger certificate, BigInteger y)
    {
        BigInteger shiftAmount = BigInteger.Pow(2, 16);
        BigInteger s = certificate >> (int)shiftAmount;
        BigInteger mask = BigInteger.Parse("FFFF", System.Globalization.NumberStyles.HexNumber);
        BigInteger signature = certificate & mask;

        BigInteger pMinusOne = _p - 1;
        BigInteger sInverse = BigInteger.ModPow(s, pMinusOne - _privateKey, _p);

        BigInteger leftSide = BigInteger.ModPow(_g, signature, _p);
        BigInteger rightSide = (sInverse * BigInteger.ModPow(y, signature, _p)) % _p;

        return leftSide == rightSide;
    }
}