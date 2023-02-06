using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper RemoveContact(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            DeletContact();
            CloseAlert();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            //SelectContact(p);
            InitContactModification(p);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCash = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private ContactHelper DeletContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCash = null;
            return this;
        }

        private ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCash = null;
            return this;
        }

        public ContactHelper InitContactModification(int p)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (p + 1) + "]")).Click();
            return this;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public ContactHelper CheckAvailabilityContactElement()
        {
            manager.Navigator.GoToHomePage();
            if (! IsContactExist())
            {
                ContactData contact = new ContactData("", "");
                CreateContact(contact);
            }
            return this;
        }

        public List<ContactData> contactCash = null;

        public List<ContactData> GetContactList()
        {
            if (contactCash == null)
            {
                contactCash = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    string fname = element.FindElements(By.TagName("td"))[2].Text;
                    string lname = element.FindElements(By.TagName("td"))[1].Text;
                    contactCash.Add(new ContactData(fname, lname));
                }
            }
            return new List<ContactData>(contactCash);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }
    }
}
