using System.Text.RegularExpressions;
using CleanArchPOC.Domain.Contracts;

namespace CleanArchPOC.Domain.ValueObjects;

public class EmailAddress : IValueObject
{
    public string FullAddress;
    public string LocalPart;
    public string DomainPart;

    public EmailAddress(string emailAddress)
    {
        emailAddress = emailAddress.Trim();
        var regexValidEmail = new Regex(@"^([^.][!#$%&'*+\-/=?^_`{|}~.\w\d]+[^.])@([\-.\w]+)$");

        if (regexValidEmail.IsMatch(emailAddress))
            throw new Exception("E-mail address is not valid.");

        var matches = regexValidEmail.Matches(emailAddress);

        LocalPart = matches[1].Value;
        DomainPart = matches[2].Value;
        FullAddress = emailAddress;
    }

    public Dictionary<string, string> ToDictionary()
    {
        return new Dictionary<string, string>()
        {
            { "fullAddress", FullAddress },
            { "localPart", LocalPart },
            { "domainPart", DomainPart },
        };
    }
}
