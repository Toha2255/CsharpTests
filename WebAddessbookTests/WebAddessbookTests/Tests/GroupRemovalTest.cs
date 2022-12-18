using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using WebAddessbookTests;

namespace WebAddessbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
            app.Groups
                .SelectGroup(1)
                .RemoveGroup()
                .ReturnToGroupsPage();
        }
    }
}
