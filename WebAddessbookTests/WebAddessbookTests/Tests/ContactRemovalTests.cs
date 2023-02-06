using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int p = 0;
            app.Contact.CheckAvailabilityContactElement();

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.RemoveContact(p);

            //Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(p);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
