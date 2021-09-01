using System.Collections.Generic;
namespace Packt.Shared
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            //compare name lengths
            int result = x.Name.Length.CompareTo(y.Name.Length);

            //if the are equal
            if (result == 0)
            {
                //then compare bu the names
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                //otherwise compare by the length
                return result;
            }
        }
    }
}