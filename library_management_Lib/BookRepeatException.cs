using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library_management_Lib
{
    public class BookRepeatException : Exception
    {
        public BookRepeatException() : base("The book has been added,please try again.\n")
        {

        }
    }
}