using System;
using System.Collections.Generic;
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
            if (!app.Contact.IsContactExist())
            {
                ContactData contact = new ContactData("Йасо", "Сал");
                app.Contact.CreateContact(contact);
            }

            app.Contact.CheckAvailabilityContactElement();
            app.Navigator.GoToHomePage();
            app.Contact.RemoveContact(1);
        }
    }
}
