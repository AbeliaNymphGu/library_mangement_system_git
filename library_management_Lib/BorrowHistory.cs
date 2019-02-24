using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library_management_Lib
{
    public class BorrowHistory
    {
        private string borrowingNumber;
        private string bookTitle;
        private string bookISBN;
        private DateTime startTime;
        
        
        private DateTime endTime;
        private bool wetherToReturn;

        public BorrowHistory(Book borrowedBook, string endline)
        {
            //throw new System.NotImplementedException();

            ContainBorrowNumber = $"{DateTime.Now}" + $"{borrowedBook.ContainISBN}";
            ContainBookTitle = borrowedBook.ContainTitle;
            ContainBookISBN = borrowedBook.ContainISBN;
            ContainStartTime = DateTime.Now;
            ContainEndTime = DateTime.Parse(endline);
            ContainWetherToReturn = false;

            


        }

        public BorrowHistory()
        {
            //throw new System.NotImplementedException();
            ContainBorrowNumber =@"NaN." + $"{DateTime.Now}";
            ContainBookTitle = @"NaN.";
            ContainBookISBN = @"NaN.";
            ContainStartTime = DateTime.Now;
            ContainEndTime = DateTime.Parse("2018-11-11");
            ContainWetherToReturn = false;

        }

        public string ContainBookISBN
        {
            get => bookISBN;
            set
            {
                bookISBN = value;
            }
        }

        public string ContainBookTitle
        {
            get => bookTitle;
            set
            {
                bookTitle = value;
            }
        }

        public string ContainBorrowNumber
        {
            get => borrowingNumber;
            set
            {
                borrowingNumber = value;
            }
        }

        

        public DateTime ContainStartTime
        {
            get => startTime;
            set
            {
                startTime = value;
            }
        }


        public DateTime ContainEndTime
        {
            get => endTime;
            set
            {
                endTime = value;
            }
        }

        public bool ContainWetherToReturn
        {
            get => wetherToReturn;  
            set
            {
                wetherToReturn = value;
            }
        }

        public string ShowInfo()
        {
            //throw new System.NotImplementedException();

            return $"ID: {ContainBorrowNumber}\n" +
                $"BookTital:{ContainBookTitle}\n" +
                $"BookISBN:{ContainBookISBN}\n" +
                $"StartTime:{ContainStartTime}\n" +
                $"EndTime:{ContainEndTime}\n";
        }
    }
}