﻿namespace Noobow.Commons.Utils
{
    public static class StringUtil
    {
        private static readonly string[] metaCharacters = ["^", "$", ".", "*", "+", "?", "(", ")", "{", "}", "[", "]", "^"];

        public static bool ContainsAny(IEnumerable<string> ss, string s)
        {
            return ss.Any(c => s.Contains(c));
        }

        public static bool ContainsMetaCharacter(string s)
        {
            return ContainsAny(metaCharacters, s);
        }
    }
}
