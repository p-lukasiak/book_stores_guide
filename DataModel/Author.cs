using System;
using System.Collections.Generic;
using System.Text;

namespace TeltIt.BSG.DataModel
{
    public class Author
    {
        public string FullName { get; set; }

        public Author(string fullName)
        {
            FullName = fullName;
        }
    }
}
