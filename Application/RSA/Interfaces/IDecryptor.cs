using System.Numerics;

namespace RSA.Interfaces;

public interface IDecryptor
{
    public BigInteger Decrypt(BigInteger encryptedMessage);
}