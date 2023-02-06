using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }


        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }

        public GroupHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
      
        public GroupHelper CheckAvailabilityGroupElement()
        {
            manager.Navigator.GoToGroupsPage();
            if (! IsGroupExist())
            {
                GroupData group = new GroupData("");
                Create(group);
            }
            return this;
        }

        public bool IsGroupExist()
        {
            return IsElementPresent(By.ClassName("group"));
        }

        private List<GroupData> groupCash = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCash == null)
            {
                groupCash = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCash.Add(new GroupData(element.Text));
                }
            }
            return new List<GroupData>(groupCash);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
