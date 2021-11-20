using System;
using System.Globalization;

namespace Conversion_Calculator
{
    class CurrencyConverter
    {
        public static string[] GetCurrencyTags()
        {
         return new string[] {"EUR", "USD", "JPY", "RUB", "TRY", "INR", "NZD", "PHP"};
        }

        public static float GetCurrencyRateInEuro(string currency)
        {
            if (currency.ToLower() == "")
                throw new ArgumentException("Invalid Argument! currency parameter cannot be empty!");
            if (currency.ToLower() == "eur")
                throw new ArgumentException("Invalid Argument! Cannot get exchange rate from EURO to EURO");

            try
            {
                string rssUrl = string.Concat("http://www.ecb.int/rss/fxref-", currency.ToLower() + ".html");

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(rssUrl);

                System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("rdf", "http://purl.org/rss/1.0/");
                nsmgr.AddNamespace("cb", "http://www.cbwiki.net/wiki/index.php/Specification_1.1");

                System.Xml.XmlNodeList nodeList = doc.SelectNodes("//rdf:item", nsmgr);

                foreach (System.Xml.XmlNode node in nodeList)
                {
                    CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    ci.NumberFormat.CurrencyDecimalSeparator = ".";

                    try
                    {
                        float exchangeRate = float.Parse(
                            node.SelectSingleNode("//cb:statistics//cb:exchangeRate//cb:value", nsmgr).InnerText,
                            NumberStyles.Any,
                            ci);

                        return exchangeRate;
                    }
                    catch { }
                }

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public static float GetExchangeRate(string from, string to, float amount = 1)
        {
     
            if (from == null || to == null)
                return 0;

       
            if (from.ToLower() == "eur" && to.ToLower() == "eur")
                return amount;

            try
            {
                                float toRate = 1; 
                float fromRate;
                if (to.ToLower() != "eur")
                {
                    toRate = GetCurrencyRateInEuro(to);
                }
               
                if (from.ToLower()!="eur")
                {
                    fromRate = GetCurrencyRateInEuro(from);
                }
                 else 
                {
                    fromRate = 1;
                    return (amount * toRate) / fromRate;
                }

                if (from.ToLower() == "eur")
                {
                    return (amount * toRate);
                }
                else if (to.ToLower() == "eur")
                {
                    return (amount / fromRate);
                }
                else
                {
                   return (amount * toRate) / fromRate;
                }
            }
            catch { return -1; }
        }
    }
}
    
