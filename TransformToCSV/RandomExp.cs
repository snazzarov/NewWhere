using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransformToCSV
{
    static class RandomExp
    {
        public static Random random = new Random();
        public static string StringByLength(int length)
        {
            var capChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lowChars = "abcdefghijklmnopqrstuvwxyz0123456789_";
            var stringChars = new char[length];
            // var random = new Random();
            // string will be like "Nhdhd0_rr1"
            stringChars[0] = capChars[random.Next(capChars.Length)];
            for (int i = 1; i < stringChars.Length; i++)
                stringChars[i] = lowChars[random.Next(lowChars.Length)];
            return new String(stringChars);
        }
        public static int IntStringLength(int maxLength)
        {
            return random.Next(1, maxLength + 1);
        }
        public static int IntRange(int minInt, int maxInt)
        {
            return random.Next(minInt, maxInt);
        }
        public static double DoubleRange(double minDouble, double maxDouble)
        {
            return (random.NextDouble() * (maxDouble - minDouble)) + minDouble;
        }
    }
}