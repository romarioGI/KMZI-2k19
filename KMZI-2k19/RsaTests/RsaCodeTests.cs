using System.Numerics;
using KMZI_2k19;
using Xunit;

namespace RsaTests
{
    public class RsaCodeTests
    {
        private static void EncryptDecrypt(Rsa rsa, BigInteger openText)
        {
            var cipherText = rsa.Encrypt(openText);
            Assert.Equal(openText, rsa.Decrypt(cipherText));
        }

        private static void DecryptEncrypt(Rsa rsa, BigInteger cipherText)
        {
            var openText = rsa.Decrypt(cipherText);
            Assert.Equal(cipherText, rsa.Encrypt(openText));
        }

        [Fact]
        public void EncryptDecrypt_Mod29x197_PublicKey13()
        {
            var rsa = new Rsa(29, 197) {PublicKey = 13};
            EncryptDecrypt(rsa, 112);
            EncryptDecrypt(rsa, 197);
            EncryptDecrypt(rsa, 512);
            EncryptDecrypt(rsa, 1);
            EncryptDecrypt(rsa, 5700);
        }

        [Fact]
        public void EncryptDecrypt_Mod199x197_PublicKey181()
        {
            var rsa = new Rsa(199, 197) { PublicKey = 181 };
            EncryptDecrypt(rsa, 112);
            EncryptDecrypt(rsa, 30000);
            EncryptDecrypt(rsa, 12345);
            EncryptDecrypt(rsa, 39123);
            EncryptDecrypt(rsa, 1);
        }

        [Fact]
        public void EncryptDecrypt_Mod1e9p7x1e9p9_PublicKey514229()
        {
            var rsa = new Rsa(1000000007, 1000000009) { PublicKey = 514229 };
            EncryptDecrypt(rsa, 112);
            EncryptDecrypt(rsa, 30000);
            EncryptDecrypt(rsa, 12345);
            EncryptDecrypt(rsa, 39123);
            EncryptDecrypt(rsa, 1);
        }

        [Fact]
        public void DecryptEncrypt_Mod29x197_PublicKey13()
        {
            var rsa = new Rsa(29, 197) { PublicKey = 13 };
            DecryptEncrypt(rsa, 112);
            DecryptEncrypt(rsa, 197);
            DecryptEncrypt(rsa, 512);
            DecryptEncrypt(rsa, 1);
            DecryptEncrypt(rsa, 5700);
        }

        [Fact]
        public void DecryptEncrypt_Mod199x197_PublicKey181()
        {
            var rsa = new Rsa(199, 197) { PublicKey = 181 };
            DecryptEncrypt(rsa, 112);
            DecryptEncrypt(rsa, 30000);
            DecryptEncrypt(rsa, 12345);
            DecryptEncrypt(rsa, 39123);
            DecryptEncrypt(rsa, 1);
        }

        [Fact]
        public void DecryptEncrypt_Mod1e9p7x1e9p9_PublicKey514229()
        {
            var rsa = new Rsa(1000000007, 1000000009) { PublicKey = 514229 };
            DecryptEncrypt(rsa, 112);
            DecryptEncrypt(rsa, 30000);
            DecryptEncrypt(rsa, 12345);
            DecryptEncrypt(rsa, 39123);
            DecryptEncrypt(rsa, 1);
        }
    }
}