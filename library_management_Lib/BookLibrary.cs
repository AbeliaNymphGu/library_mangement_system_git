using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using library_management_Lib;


namespace library_management_Lib
{
    public class BookLibrary
    {
        private DateTime createdDay = DateTime.Today;

        private int amountOfBooks;
        private Form formOfBooks;
        private Dictionary<string, Book> bookLib;

        public BookLibrary()
        {
            //throw new System.NotImplementedException();

            
        }

        public int ContainAmountOfBook
        {
            get => default(int);
            set
            {

            }
        }

        public DateTime ContainCeratedTime
        {
            get => default(DateTime);
            set
            {
            }
        }

        public Form ContainFormOfBooks
        {
            get => default(Form);
            set
            {
            }
        }

        public Book ContainBookLib
        {
            get => default(Book);
            set
            {
            }
        }

        public bool AddBook(Book newBook)
        {
            throw new System.NotImplementedException();
        }

        public bool DelteBook(Book oldBook)
        {
            throw new System.NotImplementedException();
        }

        public bool SearchForBook(Book needBook)
        {
            throw new System.NotImplementedException();
        }

        public string ShowInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}