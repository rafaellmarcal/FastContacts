using System;
using System.Collections.Generic;
using System.Linq;

namespace FastContacts.Domain.Common.Helper
{
    public class CPFValidation
    {
        public const int CPFLength = 11;

        public static bool Validate(string cpf)
        {
            var cpfNumbers = Utils.GetOnlyNumbers(cpf);

            if (!IsValidLength(cpfNumbers)) return false;
            return !HasRepeatedDigits(cpfNumbers) && HasValidDigits(cpfNumbers);
        }

        private static bool IsValidLength(string value)
        {
            return value.Length == CPFLength;
        }

        private static bool HasRepeatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidDigits(string value)
        {
            var number = value.Substring(0, CPFLength - 2);

            var verifierDigit = new VerifierDigit(number)
                .WithMultiplierFromTo(2, 11)
                .Replacing("0", 10, 11);

            var firstDigit = verifierDigit.CalculateDigit();
            verifierDigit.AddDigit(firstDigit);

            var secondDigit = verifierDigit.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(CPFLength - 2, 2);
        }
    }

    public class CNPJValidation
    {
        public const int CNPJLength = 14;

        public static bool Validate(string cpnj)
        {
            var cnpjNumbers = Utils.GetOnlyNumbers(cpnj);

            if (!IsValidLength(cnpjNumbers)) return false;
            return !HasRepeatedDigits(cnpjNumbers) && HasValidDigits(cnpjNumbers);
        }

        private static bool IsValidLength(string value)
        {
            return value.Length == CNPJLength;
        }

        private static bool HasRepeatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidDigits(string valor)
        {
            var number = valor.Substring(0, CNPJLength - 2);

            var verifierDigit = new VerifierDigit(number)
                .WithMultiplierFromTo(2, 9)
                .Replacing("0", 10, 11);

            var firstDigit = verifierDigit.CalculateDigit();
            verifierDigit.AddDigit(firstDigit);

            var secondDigit = verifierDigit.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == valor.Substring(CNPJLength - 2, 2);
        }
    }

    public class VerifierDigit
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _substitutions = new Dictionary<int, string>();
        private bool _moduleComplementary = true;

        public VerifierDigit(string number)
        {
            _number = number;
        }

        public VerifierDigit WithMultiplierFromTo(int firstMultiplier, int lastMultiplier)
        {
            _multipliers.Clear();
            for (var i = firstMultiplier; i <= lastMultiplier; i++)
                _multipliers.Add(i);

            return this;
        }

        public VerifierDigit Replacing(string substitute, params int[] digitos)
        {
            foreach (var i in digitos)
            {
                _substitutions[i] = substitute;
            }
            return this;
        }

        public void AddDigit(string digit)
        {
            _number = string.Concat(_number, digit);
        }

        public string CalculateDigit()
        {
            return !(_number.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var sum = 0;
            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var product = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                sum += product;

                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = (sum % Module);
            var result = _moduleComplementary ? Module - mod : mod;

            return _substitutions.ContainsKey(result) ? _substitutions[result] : result.ToString();
        }
    }

    public class Utils
    {
        public static string GetOnlyNumbers(string value)
        {
            var onlyNumber = "";
            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
