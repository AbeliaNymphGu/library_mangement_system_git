using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static System.Console;

namespace library_management_Lib
{
    public class Book : IBook
    {
        private string title;
        private string author;
        private string ISBN;
        private string publisher;
        private bool canBorrow;
        private int number;

        private Book()
        {
            throw new System.NotImplementedException();
        }

        public Book(string newTitle, string newISBN, string newPublisher)
        {
            ///throw new System.NotImplementedException();
            ///
            ContainTitle = newTitle;
            ContainISBN = newISBN;
            ContainPublisher = newPublisher;

        }

        public string ContainTitle
        {
            get => default(string);
            set
            {
            }
        }

        public string ContainAuthor
        {
            get => default(string);
            set
            {
            }
        }

        public string ContainISBN
        {
            get => default(string);
            set
            {
            }
        }

        public string ContainPublisher
        {
            get => default(string);
            set
            {
            }
        }

        public bool ContainCanBorrow
        {
            get => default(bool);
            set
            {
            }
        }

        public int ContainNumber
        {
            get => default(int);
            set
            {
            }
        }

        public bool SetTitle(string newTitle)
        {
            ///throw new System.NotImplementedException();
            ///
            ContainTitle = newTitle;
            return true;
        }

        public bool SetAuthor(string newAuthor)
        {
            ///throw new System.NotImplementedException();
            ///
            ContainAuthor = newAuthor;
            return true;
        }

        public bool SetISBN(string newISBN)
        {
            ///throw new System.NotImplementedException();
            ///
            ContainISBN = newISBN;
            return true;
        }

        public bool SetPublisher(string newPublisher)
        {
            ///throw new System.NotImplementedException();
            ///
            ContainPublisher = newPublisher;
            return true;
        }

        public bool SetCanBorrow(bool newCanBorrow)
        {
            ///throw new System.NotImplementedException();
            ///
            ContainCanBorrow = newCanBorrow;
            return true;
        }

        public string ShowInfo()
        {
            ///throw new System.NotImplementedException();
            ///

            return $"/t/t-------------------------------------------------------\n" +
                $"Title : {ContainTitle}\n" +
                $"Author : {ContainAuthor}\n" +
                $"Publisher : {ContainPublisher}\n" +
                $"ISBN : {ContainISBN}";

        }

        public bool SetNumber(int newNumber)
        {
            ///throw new System.NotImplementedException();
            ///

            ContainNumber = newNumber;
            return true;
        }

        void IBook.AddNewBook(Book newBook)
        {


            WriteLine("Please enter book's ISBN:");
            ContainISBN = ReadLine();

            WriteLine("Please enter book's title:");
            ContainTitle = ReadLine();

            WriteLine("Please enter book's author:");
            ContainAuthor = ReadLine();

            WriteLine("Please enter book's publisher:");
            ContainPublisher = ReadLine();

            WriteLine("Please enter book's number:");
            ContainNumber = Convert.ToInt32(ReadLine());

            WriteLine("Plesae select the status of these books:");
            ContainCanBorrow = Convert.ToBoolean(ReadLine()); 
            
        }

        void IBook.SaveBookInfoOfXml(Book writtenBook)
        {
            if (!Directory.Exists(@"info\book"))
            {
                Directory.CreateDirectory(@"info\book");

            }

            if (!File.Exists(@"info\book\" + $"{writtenBook.ContainISBN}.xml"))
            {
                XDocument tempNewBookXmlDocument = new XDocument(
                new XElement("books",
                    new XElement("book",
                        new XElement("ISBN", writtenBook.ContainISBN),
                        new XElement("title", writtenBook.ContainTitle),
                        new XElement("author", writtenBook.ContainAuthor),
                        new XElement("publisher", writtenBook.ContainPublisher)
                        
                    )));

                tempNewBookXmlDocument.Save(@"info\book\" + $"{writtenBook.ContainISBN}.xml");

            }
            else
            {
                throw new AccountRepeatException();
            }
        }
    }
}