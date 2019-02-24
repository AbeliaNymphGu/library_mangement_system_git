using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library_management_Lib
{
    public interface IBook
    {
        void AddNewBook(Book newBook);
        void SaveBookInfoOfXml(Book writtenBook);
        bool Search(string targetBookISBN, Book targetBook);

    }
}