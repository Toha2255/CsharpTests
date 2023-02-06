using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName 
                && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }
        public override string ToString()
        {
            return FirstName + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName != other.LastName)
            {
                return LastName.CompareTo(other.LastName);
            }
            else return FirstName.CompareTo(other.FirstName);
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
    }
}