using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddessbookTests;

namespace WebAddessbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("qqq");
            newData.Header = "www";
            newData.Footer = "eee";

            app.Groups.Modify(1, newData);
        }
    }
}
