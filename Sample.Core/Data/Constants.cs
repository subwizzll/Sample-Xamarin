using System;

namespace Sample.Core.Data
{
    public static class Constants
    {
        public static class TaxRateApi
        {
            public static Uri BaseAddress => new("https://api.taxjar.com/");
            public static string PublicKey => "5da2f821eee4035db4771edab942a4cc";
        }   
    }
}