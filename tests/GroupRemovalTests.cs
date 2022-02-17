using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count() == 1)
            {
                GroupData group = new GroupData()
                {
                    Name = "New"
                };

                app.Groups.Add(group);

                oldGroups = app.Groups.GetGroupList();
            }

            int index = oldGroups.Count - 1;
            GroupData groupToRemove = oldGroups[index];
            app.Groups.Delete(index);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Remove(groupToRemove);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}