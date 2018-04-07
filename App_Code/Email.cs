using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    protected SmtpClient client;

    public Email()
    {
        EmailFrom = "postmaster@sandbox619e95ee455844d5841175a8d4d14b19.mailgun.org";
        SetClient();
    }
    public Email(string from)
    {
        EmailFrom = from;
        SetClient();
    }
    protected void SetClient()
    {
        client = new SmtpClient("smtp.mailgun.org")
        {
            Credentials = new NetworkCredential(
            "postmaster@sandbox619e95ee455844d5841175a8d4d14b19.mailgun.org",
            "ff3fc388cd16108ef14b7f9716bcfc0f-db1f97ba-57e9c9bb"
            )
        };
    }
    public string Subject { set; get; }

    public string Body { set; get; }

    public string EmailFrom { set; get; }

    //public static void SendSimpleMessage()
    //{
    //    RestClient client = new RestClient();
    //    client.BaseUrl = "https://api.mailgun.net/v3";
    //    client.Authenticator =
    //    new HttpBasicAuthenticator("api",
    //                              "key-64ba373c08997e028b2cd5b872ebefcb");
    //    RestRequest request = new RestRequest();
    //    request.AddParameter("domain", "sandbox619e95ee455844d5841175a8d4d14b19.mailgun.org", ParameterType.UrlSegment);
    //    request.Resource = "{domain}/messages";
    //    request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox619e95ee455844d5841175a8d4d14b19.mailgun.org>");
    //    request.AddParameter("to", "Ben Doe <benjamin.doe@outlook.com>");
    //    request.AddParameter("subject", "Hello Ben Doe");
    //    request.AddParameter("text", "Congratulations Ben Doe, you just sent an email with Mailgun!  You are truly awesome!");
    //    request.Method = Method.POST;
    //    return client.Execute(request);
    //}

    public void Send(string to)
    {
        MailAddress mailTo = new MailAddress(to);
        MailAddress mailFrom = new MailAddress(EmailFrom);
        MailMessage message = new MailMessage(mailFrom, mailTo)
        {
            Subject = Subject,
            Body = Body
        };
        message.IsBodyHtml = true;
        // Use the application or machine configuration to get the 
        // host, port, and credentials.
        System.Diagnostics.Debug.WriteLine("Sending an e-mail message to {0} at {1} by using the SMTP host={2}.",
            mailTo.User, mailTo.Host, client.Host);
        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Exception caught in Send(): " + ex.ToString());
        }
    }
}