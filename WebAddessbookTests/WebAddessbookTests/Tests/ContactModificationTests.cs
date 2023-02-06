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
            int p = 2;
            app.Contact.CheckAvailabilityContactElement();

            ContactData newData = new ContactData("Salam", "Alekum");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(p, newData);

            //Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts[p].FirstName = newData.FirstName;
            oldContacts[p].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
