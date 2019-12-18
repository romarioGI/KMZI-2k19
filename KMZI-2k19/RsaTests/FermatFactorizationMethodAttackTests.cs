using System.Numerics;
using KMZI_2k19;
using Xunit;

namespace RsaTests
{
    public class FermatFactorizationMethodAttackTests
    {
        private static void FermatFactorizationMethodAttackTest(Rsa rsa, BigInteger openText)
        {
            var cipherText = rsa.Encrypt(openText);

            Assert.Equal(openText, Rsa.FermatFactorizationMethodAttack(cipherText, rsa.PublicKey, rsa.Mod));
        }

        [Fact]
        public void FermatFactorizationMethodAttack_Mod29x197_PublicKey13()
        {
            var rsa = new Rsa(29, 197) { PublicKey = 13 };
            FermatFactorizationMethodAttackTest(rsa, 112);
            FermatFactorizationMethodAttackTest(rsa, 197);
            FermatFactorizationMethodAttackTest(rsa, 512);
            FermatFactorizationMethodAttackTest(rsa, 1);
            FermatFactorizationMethodAttackTest(rsa, 5700);
        }

        [Fact]
        public void FermatFactorizationMethodAttack_Mod199x197_PublicKey181()
        {
            var rsa = new Rsa(199, 197) { PublicKey = 181 };
            FermatFactorizationMethodAttackTest(rsa, 112);
            FermatFactorizationMethodAttackTest(rsa, 30000);
            FermatFactorizationMethodAttackTest(rsa, 12345);
            FermatFactorizationMethodAttackTest(rsa, 39123);
            FermatFactorizationMethodAttackTest(rsa, 1);
        }

        [Fact]
        public void FermatFactorizationMethodAttack_Mod1e9p7x1e9p9_PublicKey514229()
        {
            var rsa = new Rsa(1000000007, 1000000009) { PublicKey = 514229 };
            FermatFactorizationMethodAttackTest(rsa, 112);
            FermatFactorizationMethodAttackTest(rsa, 30000);
            FermatFactorizationMethodAttackTest(rsa, 12345);
            FermatFactorizationMethodAttackTest(rsa, 39123);
            FermatFactorizationMethodAttackTest(rsa, 1);
        }

        [Fact]
        public void FermatFactorizationMethodAttack_Mod59x160001_PublicKey514229()
        {
            var rsa = new Rsa(59, 160001) { PublicKey = 514229 };
            FermatFactorizationMethodAttackTest(rsa, 112);
            FermatFactorizationMethodAttackTest(rsa, 30000);
            FermatFactorizationMethodAttackTest(rsa, 12345);
            FermatFactorizationMethodAttackTest(rsa, 39123);
            FermatFactorizationMethodAttackTest(rsa, 1);
        }
    }
}