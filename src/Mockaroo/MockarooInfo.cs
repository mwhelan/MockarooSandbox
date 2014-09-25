using System.Text;

namespace Mockaroo
{
    public class MockarooInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Id: {0}  Full Name: {1}  Email Address: {2}", Id, FullName, EmailAddress));
            sb.AppendLine(string.Format("    Email Address: {0}  Password: {1}", EmailAddress, Password));
            sb.AppendLine(string.Format("    City: {0}  Company: {1}  Url: {2}", City, CompanyName, Url));
            return sb.ToString();
        }
    }
}
