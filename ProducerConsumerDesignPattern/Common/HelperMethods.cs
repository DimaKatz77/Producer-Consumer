﻿namespace ProducerConsumerDesignPattern.Common
{
    public static class HelperMethods
    {
        public static string RandomString(int length)
        {
            Random random = new Random();

            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789 ";

            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);

            return new string(chars.ToArray());
        }
    }
}
