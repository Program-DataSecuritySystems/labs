using System.Text;

namespace DigitalSignature;

public class SymmetricEncryption
{
    private const int _blockSize = 8; // Розмір блоку (в байтах)

    // Метод для шифрування повідомлення з використанням симетричного шифру
    public static string Encrypt(string message, string key)
    {
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] encryptedBytes = new byte[messageBytes.Length];

        for (int i = 0; i < messageBytes.Length; i += _blockSize)
        {
            byte[] block = new byte[_blockSize];
            Array.Copy(messageBytes, i, block, 0, _blockSize);

            // Виконати шифрування блоку
            byte[] encryptedBlock = EncryptBlock(block, keyBytes);

            Array.Copy(encryptedBlock, 0, encryptedBytes, i, _blockSize);
        }

        return Convert.ToBase64String(encryptedBytes);
    }

    // Метод для шифрування одного блоку
    private static byte[] EncryptBlock(byte[] block, byte[] key)
    {
        byte[] encryptedBlock = new byte[block.Length];

        for (int i = 0; i < block.Length; i++)
        {
            encryptedBlock[i] = (byte)(block[i] ^ key[i % key.Length]);
        }

        return encryptedBlock;
    }

    // Метод для формування цифрового підпису повідомлення
    public static string GenerateSignature(string message, string key)
    {
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] signatureBytes = new byte[messageBytes.Length];

        for (int i = 0; i < messageBytes.Length; i += _blockSize)
        {
            byte[] block = new byte[_blockSize];
            Array.Copy(messageBytes, i, block, 0, _blockSize);

            byte[] encryptedBlock = EncryptBlock(block, keyBytes);

            for (int j = 0; j < _blockSize; j++)
            {
                signatureBytes[i + j] ^= encryptedBlock[j];
            }
        }

        return Convert.ToBase64String(signatureBytes);
    }
}