using System.Numerics;

namespace RSA.Interfaces;

public interface IEncryptor
{
    public BigInteger Encrypt(int message);
}