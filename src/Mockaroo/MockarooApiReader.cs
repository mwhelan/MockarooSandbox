using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ServiceStack.Text;

namespace Mockaroo
{
    public class MockarooApiReader
    {
        private const string API_KEY = "**** PLACE YOUR API KEY HERE ****";

    public MockarooInfo[] GetData()
    {
        var request = CreateRequest();

        MockarooInfo[] data;
        using (var client = new HttpClient())
        {
            var response = client.SendAsync(request).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            data = JsonSerializer.DeserializeFromString<MockarooInfo[]>(json);
        }

        return data;
    }

        private static HttpRequestMessage CreateRequest()
        {
            var json = CreateSchema();
            //json = WebUtility.HtmlEncode(json);
            string url = string.Format(@"http://www.mockaroo.com/api/generate.json?key={0}&count=10&fields={1}", API_KEY, json);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return request;
        }

    private static string CreateSchema()
    {
        var fields = new List<MockarooParameter>
        {
            new MockarooParameter{ Name = "Id", Type = "Row Number" },
            new MockarooParameter{ Name = "FullName", Type = "Full Name" },
            new MockarooParameter{ Name = "EmailAddress", Type = "Email Address" },
            new MockarooParameter{ Name = "Password", Type = "Password" },
            new MockarooParameter{ Name = "City", Type = "City" },
            new MockarooParameter{ Name = "CompanyName", Type = "Company Name" },
            new MockarooParameter{ Name = "Url", Type = "URL", IncludeQueryString = false }
        };

        JsConfig.EmitCamelCaseNames = true;
        return JsonSerializer.SerializeToString(fields);
    }
    }

    public class MockarooParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IncludeQueryString { get; set; }
    }
}