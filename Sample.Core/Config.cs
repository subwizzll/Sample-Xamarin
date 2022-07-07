using System;

namespace Sample.Core
{
    public class TaxRateConfig
    {
        public static Uri BaseAddress => new Uri("https://api.taxjar.com/");
        public static string PublicKey => "5da2f821eee4035db4771edab942a4cc";
    }
}