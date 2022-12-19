using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsGroupExist())
            {
                GroupData group = new GroupData("");
                app.Groups.Create(group);
            }

            app.Groups.CheckAvailabilityGroupElement();
            GroupData newData = new GroupData("qqq");
            newData.Header = "www";
            newData.Footer = "eee";
            app.Groups.Modify(1, newData);
        }
    }
}
