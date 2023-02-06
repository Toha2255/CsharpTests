using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("пјр", "Ыртр");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
