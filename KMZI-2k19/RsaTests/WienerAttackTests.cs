using System.Numerics;
using KMZI_2k19;
using Xunit;

namespace RsaTests
{
    public class WienerAttackTests
    {
        private static void WienerAttackTest(Rsa rsa, BigInteger openText)
        {
            var cipherText = rsa.Encrypt(openText);

            Assert.Equal(openText, Rsa.WienerAttack(cipherText, rsa.PublicKey, rsa.Mod));
        }

        [Fact]
        public void WienerAttack_Mod1277x1279_PublicKey5()
        {
            var rsa = new Rsa(1277, 1279) { PublicKey = 5 };
            WienerAttackTest(rsa, 112);
            WienerAttackTest(rsa, 197);
            WienerAttackTest(rsa, 512);
            WienerAttackTest(rsa, 1);
            WienerAttackTest(rsa, 5700);
        }

        [Fact]
        public void WienerAttack_Mod199x197_PublicKey5()
        {
            var rsa = new Rsa(199, 197) { PublicKey = 5 };
            WienerAttackTest(rsa, 112);
            WienerAttackTest(rsa, 30000);
            WienerAttackTest(rsa, 12345);
            WienerAttackTest(rsa, 39123);
            WienerAttackTest(rsa, 1);
        }

        [Fact]
        public void WienerAttack_Mod1e9p7x1e9p9_PublicKey133()
        {
            var rsa = new Rsa(1000000007, 1000000009) { PublicKey = 29 };
            WienerAttackTest(rsa, 112);
            WienerAttackTest(rsa, 30000);
            WienerAttackTest(rsa, 12345);
            WienerAttackTest(rsa, 39123);
            WienerAttackTest(rsa, 1);
        }

        [Fact]
        public void WienerAttack_Mod59x1297_PublicKey7()
        {
            var rsa = new Rsa(59, 160001) { PublicKey = 7 };
            WienerAttackTest(rsa, 112);
            WienerAttackTest(rsa, 30000);
            WienerAttackTest(rsa, 12345);
            WienerAttackTest(rsa, 39123);
            WienerAttackTest(rsa, 1);
        }
    }
}
