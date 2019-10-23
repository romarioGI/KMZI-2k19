using KMZI_2k19;
using Xunit;

namespace RotorMachineTests
{
    public class NsuCryptoExamples
    {
        [Fact]
        public void Encrypt_StartPosition0EncryptOOT_TRS()
        {
            var machine = new RotorMachine(0);
            const string text = "OOT";

            const string expected = "TRS";

            var actual = machine.Encrypt(text);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Encrypt_StartPosition4EncryptPOSTTOTOPOOPSSORRYSTOPROTOR_TRRYSSPRYRYROYTOPTOPTSPSPRS()
        {
            var machine = new RotorMachine(4);
            const string text = "POSTTOTOPOOPSSORRYSTOPROTOR";

            const string expected = "TRRYSSPRYRYROYTOPTOPTSPSPRS";

            var actual = machine.Encrypt(text);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Decrypt_StartPosition0DecryptTRS_OOT()
        {
            var machine = new RotorMachine(0);
            const string text = "TRS";

            const string expected = "OOT";

            var actual = machine.Decrypt(text);

            Assert.Equal(expected, actual);
            Assert.Equal(0, machine.CurrentPosition);
        }

        [Fact]
        public void Decrypt_StartPosition4DecryptTRRYSSPRYRYROYTOPTOPTSPSPRS_POSTTOTOPOOPSSORRYSTOPROTOR()
        {
            var machine = new RotorMachine(4);
            const string text = "TRRYSSPRYRYROYTOPTOPTSPSPRS";

            const string expected = "POSTTOTOPOOPSSORRYSTOPROTOR";

            var actual = machine.Decrypt(text);

            Assert.Equal(expected, actual);
            Assert.Equal(4, machine.CurrentPosition);
        }
    }
}
