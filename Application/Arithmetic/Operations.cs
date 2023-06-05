using System.Numerics;

namespace Arithmetic
{
    public class Operations
    {
        public string Multiply(string first, string second)
        {
            if (first.Length == 1 || second.Length == 1)
                return (int.Parse(first) * int.Parse(second)).ToString();

            var cutPos = GetCutPosition(first, second);
            var a = GetFirstPart(first, cutPos);
            var b = GetSecondPart(first, cutPos);
            var c = GetFirstPart(second, cutPos);
            var d = GetSecondPart(second, cutPos);
            var ac = Multiply(a, c);
            var bd = Multiply(b, d);
            var ab_cd = Multiply(StringAddtion(a, b), StringAddtion(c, d));

            return CalculateResult(ac, bd, ab_cd, b.Length + d.Length);
        }

        private string CalculateResult(string ac, string bd, string ab_cd, int padding)
        {
            var term0 = StringSubtraction(StringSubtraction(ab_cd, ac), bd);
            var term1 = term0.PadRight(term0.Length + padding / 2, '0');
            var term2 = ac.PadRight(ac.Length + padding, '0');
            return StringAddtion(StringAddtion(term1, term2), bd);
        }

        private string GetFirstPart(string str, int cutPos)
            => str.Remove(str.Length - cutPos);

        private string GetSecondPart(string str, int cutPos)
            => str.Substring(str.Length - cutPos);

        private int GetCutPosition(string first, string second)
        {
            var min = Math.Min(first.Length, second.Length);
            if (min == 1) return 1;
            if (min % 2 == 0) return min / 2;
            return min / 2 + 1;
        }

        public string StringAddtion(string a, string b)
        {
            var result = string.Empty;

            if (a.Length > b.Length)
                Swap(ref a, ref b);

            a = a.PadLeft(b.Length, '0');
            var length = a.Length;
            int carry = 0, res;

            for (var i = length - 1; i >= 0; i--)
            {
                var num1 = int.Parse(a.Substring(i, 1));
                var num2 = int.Parse(b.Substring(i, 1));
                res = (num1 + num2 + carry) % 10;
                carry = (num1 + num2 + carry) / 10;
                result = result.Insert(0, res.ToString());
            }

            if (carry != 0)
                result = result.Insert(0, carry.ToString());

            return SanitizeResult(result);
        }

        public string StringSubtraction(string a, string b)
        {
            var resultNegative = false;
            var result = string.Empty;

            if (StringIsSmaller(a, b))
            {
                Swap(ref a, ref b);
                resultNegative = true;
            }

            b = b.PadLeft(a.Length, '0');
            var length = a.Length;
            int carry = 0, res;

            for (var i = length - 1; i >= 0; i--)
            {
                var nextCarry = false;
                var num1 = int.Parse(a.Substring(i, 1));
                var num2 = int.Parse(b.Substring(i, 1));
                if (num1 - carry < num2)
                {
                    num1 = num1 + 10;
                    nextCarry = true;
                }

                res = (num1 - num2 - carry);
                result = result.Insert(0, res.ToString());
                if (nextCarry)
                    carry = 1;
                else
                    carry = 0;
            }

            result = SanitizeResult(result);

            if (resultNegative)
                return result.Insert(0, "-");

            return result;
        }

        private bool StringIsSmaller(string a, string b)
        {
            if (a.Length < b.Length)
                return true;

            if (a.Length > b.Length)
                return false;

            var arrayA = a.ToCharArray();
            var arrayB = b.ToCharArray();

            for (int i = 0; i < arrayA.Length; i++)
            {
                if (arrayA[i] < arrayB[i])
                    return true;
                if (arrayA[i] > arrayB[i])
                    return false;
            }

            return false;
        }

        private void Swap(ref string a, ref string b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        private string SanitizeResult(string result)
        {
            result = result.TrimStart(new char[] { '0' });
            if (result.Length == 0)
                result = "0";
            return result;
        }

        public string SquareElevation(string a)
        {
            return Multiply(a, a);
        }

        public string Modulo(string a, string m)
        {
            BigInteger res = 0;
            var mm = BigInteger.Parse(m);

            for (var i = 0; i < a.Length; i++)
                res = (res * 10 + a[i] - '0') % mm;

            return res.ToString();
        }

        private string ModPowerLL(BigInteger x, BigInteger n, BigInteger mod)
        {
            BigInteger result = 1;
            while (n > 0)
            {
                if (n % 2 == 1)
                    result = result * x % mod;
                n = n / 2;
                x = x * x % mod;
            }

            return result.ToString();
        }

        public string ModPowerStrings(string sa, string sb, string smod)
        {
            var mod = BigInteger.Parse(smod);

            var samod = Modulo(sa, smod);
            var a = BigInteger.Parse(samod);

            var b = BigInteger.Parse(sb);

            return ModPowerLL(a, b, mod);
        }
    }
}