using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace WebAddessbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("FirstName", "LastName");
            app.Contact.CreateContact(contact);
        }
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            app.Contact.CreateContact(contact);
        }
    }
}
