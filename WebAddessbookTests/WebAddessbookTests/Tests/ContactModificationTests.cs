using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.CheckAvailabilityContactElement();
            if (!app.Contact.IsContactExist())
            {
                ContactData contact = new ContactData("Ягон", "Дон");
                app.Contact.CreateContact(contact);
            }

            ContactData newData = new ContactData("Salam", "Alekum");
            app.Contact.Modify(1, newData);

            
        }
    }
}
