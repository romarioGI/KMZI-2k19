using System;
using System.Numerics;

namespace KMZI_2k19
{
    public class RSA
    {
        public readonly BigInteger PublicKey;
        public readonly BigInteger PrivateKey;
        public readonly BigInteger Mod;
        public readonly BigInteger FirstModPart;
        public readonly BigInteger SecondModPart;

        public RSA(BigInteger publicKey, BigInteger firstModPart, BigInteger secondModPart)
        {
            PublicKey = publicKey;
            FirstModPart = firstModPart;
            SecondModPart = secondModPart;
            Mod = FirstModPart * SecondModPart;
            PrivateKey = CalcPrivateKey();
        }

        private BigInteger CheckPublicKey()
        {
            throw new NotImplementedException();
        }
        
        private BigInteger CalcPrivateKey ()
        {
            throw new NotImplementedException();
        }

        public BigInteger Encrypt(BigInteger openText)
        {
            return BinPow(openText, PublicKey, Mod);
        }

        public BigInteger Decrypt(BigInteger cipherText)
        {
            return BinPow(cipherText, PrivateKey, Mod);
        }

        private static BigInteger BinPow(BigInteger a, BigInteger x, BigInteger mod)
        {
            var res = new BigInteger(1);
            a %= mod;
            while (x != 0)
            {
                if ((x & 1) == 1)
                {
                    res *= a;
                    res %= mod;
                }

                x >>= 1;
                a = (a * a) % mod;
            }

            return res;
        }

        private static BigInteger Gcd(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                a %= b;
                var c = a;
                a = b;
                b = c;
            }

            return a;
        }
    }
}