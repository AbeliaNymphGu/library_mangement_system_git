using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library_management_Lib
{
    public interface ILibrarian
    {
        void Register(Librarian newLibrarian);
        void SaveInfoXmlOfLibrarian(Librarian savedLibrarian);
        bool Login(Librarian loginStudent);

    }
}