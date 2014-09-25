using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using ServiceStack.Text;

namespace Mockaroo
{
    public class MockarooFileGenerator
    {
        private static MockarooRow[] _data;

        public void GenerateMockarooFiles()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            GetDataFromJsonFile();

            CreateFile(x => x.BitcoinAddress, "BitcoinAddress", false);
            CreateFile(x => x.City, "City");
            CreateFile(x => x.Colour, "Colour");
            CreateFile(x => x.CompanyName, "CompanyName");
            CreateFile(x => x.Country, "Country");
            CreateFile(x => x.CountryCode, "CountryCode");
            CreateFile(x => x.CreditCardNumber, "CreditCardNumber", false);
            CreateFile(x => x.CreditCardType, "CreditCardType");
            CreateFile(x => x.Currency, "Currency");
            CreateFile(x => x.CurrencyCode, "CurrencyCode");
            CreateFile(x => x.DomainName, "DomainName", false);
            CreateFile(x => x.EmailAddress, "EmailAddress", false);
            CreateFile(x => x.FirstName, "FirstName");
            CreateFile(x => x.FirstNameFemale, "FirstNameFemale");
            CreateFile(x => x.FirstNameMale, "FirstNameMale");
            CreateFile(x => x.Frequency, "Frequency");
            CreateFile(x => x.FullName, "FullName", false);
            CreateFile(x => x.Gender, "Gender");
            CreateFile(x => x.HexColour, "HexColour", false);
            CreateFile(x => x.IBAN, "IBAN", false);
            CreateFile(x => x.IPAddressV4, "IPAddressV4", false);
            CreateFile(x => x.IPAddressV6, "IPAddressV6", false);
            CreateFile(x => x.ISBN, "ISBN", false);
            CreateFile(x => x.Language, "Language");
            CreateFile(x => x.LastName, "LastName");
            CreateFile(x => x.Latitude, "Latitude", false);
            CreateFile(x => x.Longitude, "Longitude", false);
            CreateFile(x => x.MacAddress, "MacAddress", false);
            CreateFile(x => x.Password, "Password", false);
            CreateFile(x => x.Race, "Race");
            CreateFile(x => x.SSN, "SSN", false);
            CreateFile(x => x.Title, "Title");
            CreateFile(x => x.URL, "URL", false);
            CreateFile(x => x.US_City, "US_City");
            CreateFile(x => x.US_Phone, "US_Phone", false);
            CreateFile(x => x.US_State, "US_State");
            CreateFile(x => x.US_StateAbbrev, "US_StateAbbrev");
            CreateFile(x => x.US_StreetAddress, "US_StreetAddress", false);
            CreateFile(x => x.US_ZipCode, "US_ZipCode", false);
            CreateFile(x => x.Username, "Username", false);

            sw.Stop();
            Console.WriteLine("Elapsed seconds: {0}", sw.Elapsed.Seconds);
            Console.ReadLine();
        }

        private void GetDataFromJsonFile()
        {
            var resourceName = "Mockaroo.Mockaroo_100000.json";
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            _data = JsonSerializer.DeserializeFromStream<MockarooRow[]>(stream);
        }

    private void CreateFile(Func<MockarooRow, string> selector, string dictionaryName, bool sort = true)
    {
        var fileName = string.Format("{0}.txt", dictionaryName);
        var query = _data.Select(selector).Distinct().Take(1000);
        if (sort)
        {
            query = query.OrderBy(x => x);
        }
        IList<string> words = query.ToList();
        File.WriteAllLines(fileName, words);

        Console.WriteLine("{0}. Record Count: {1}", dictionaryName, words.Count);
    }

    }
}
