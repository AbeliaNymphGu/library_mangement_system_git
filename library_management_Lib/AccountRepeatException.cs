using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library_management_Lib
{
    public class AccountRepeatException:Exception
    {
        public AccountRepeatException() : base("The current account has been registered,please replace it with another one.\n")
        {

        }
    }
}