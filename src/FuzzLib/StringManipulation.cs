using System;

namespace FuzzLib {
    public class StringManipulation {
        public string Reverse(string input) {
            if (string.IsNullOrEmpty(input)) {
                return input;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string ToUpperCase(string input) {
            return input.ToUpper();
        }

        public string Concatenate(string str1, string str2) {
            return str1 + str2;
        }

        public bool ContainsSubstring(string str, string substring) {
            return str.Contains(substring);
        }
    }
}