

using Microsoft.Extensions.Configuration;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using System.Net.NetworkInformation;

SqlCrud sql = new SqlCrud(GetConnectionString());
//ReadAllContacts(sql);

//ReadContact(sql, 1);

//CreateNewContact(sql);

//UpdateContact(sql);

RemovePhoneNumberFromContact(sql, 1, 1);

Console.ReadLine();

static void RemovePhoneNumberFromContact(SqlCrud sql, int contactId, int phoneNumberId)
{
    sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
}

static void UpdateContact(SqlCrud sql)
{
    BasicContactModel contact = new BasicContactModel
    {
        Id = 1,
        FirstName = "Test",
        LastName = "Test"
    };
    sql.UpdateContactName(contact);
}
static void CreateNewContact(SqlCrud sql)
{
    FullContactModel user = new FullContactModel
    {
        BasicInfo = new BasicContactModel
        {
            FirstName = "Test",
            LastName = "Test"
        }
    };

    user.EmailAddresses.Add(new EmailAdressModel { EmailAddress = "test@test.com" });

    user.PhoneNumber.Add(new PhoneNumberModel { PhoneNumber = "126789" });

    sql.CreateContact(user);
}

static void ReadAllContacts(SqlCrud sql)
{
    var rows = sql.GetAllContacts();

    foreach (var row in rows)
    {
        Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
    }
}

static void ReadContact(SqlCrud sql, int contactId)
{
    var contact = sql.GetFullContactById(contactId);

    
    Console.WriteLine($"{contact.BasicInfo.Id}: {contact.BasicInfo.FirstName} {contact.BasicInfo.LastName}");


}

static string GetConnectionString(string connectionStringName = "Default")
{
    string output = "";

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

    var config = builder.Build();

    output = config.GetConnectionString(connectionStringName);

    return output;
}