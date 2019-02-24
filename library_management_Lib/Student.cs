using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Console;
using System.Xml.Linq;

namespace library_management_Lib
{
    public class Student : User, IStudent
    {
        public List<BorrowHistory> borrowedHistories = new List<BorrowHistory>();

        public Student(string newAccount, string newPassword, string newID)
        {
            base.ContainAccount = newAccount;
            base.ContainPassword = newPassword;
            base.ContainID = newID;

            borrowedHistories.Add(new BorrowHistory());
            
        }

        public Student(string newPassword, string newAccount, string newName, string newID, Gender newGender, string newBirthday, string newEmail, string newPhoneNumber)
        {
            ///throw new System.NotImplementedException();

            ContainName = newName;
            ContainID = newID;
            ContainGender = newGender;
            ContainBirthday = DateTime.Parse(newBirthday);
            ContainEmail = newEmail;
            ContainPhoneNumber = newPhoneNumber;
        }

        public Student()
        {
            borrowedHistories.Add(new BorrowHistory());
        }

        public new string ShowInfo()
        {
            ///throw new System.NotImplementedException();
            ///

            

            StringBuilder infoMessage = new StringBuilder();

            infoMessage.Append($"\nAccount : {ContainAccount}\n" +
                $"Password : {ContainPassword}\n" +
                $"Student ID : {ContainID}\n" +
                $"Name : {ContainName}\n" +
                $"Gender : {ContainGender}\n" +
                $"Birthday : {ContainBirthday}\n" +
                $"E-mail : {ContainEmail}\n" +
                $"Phone Number : {ContainPhoneNumber}\n");

            foreach (BorrowHistory item in borrowedHistories)
            {
                infoMessage.Append($"Borrow History:{item.ShowInfo()}");
            }

            return infoMessage.ToString();

            

        }
        bool IStudent.Register(Student newUser)
        {



            WriteLine("Please enter your account:");
            ContainAccount = ReadLine();

            WriteLine("Please enter your password:");
            ContainPassword = ReadLine();

            WriteLine("Please enter your student' ID:");
            ContainID = ReadLine();

            WriteLine("Please enter your name:");
            ContainName = ReadLine();

            WriteLine("Please select your gender(1.male 2.female):");
            ContainGender = (Gender)Convert.ToInt32(ReadLine());

            WriteLine("Plesae enter your birthday:");
            DateTime newStudentBirthday = new DateTime();
            DateTime.TryParse(ReadLine(), out newStudentBirthday);
            ContainBirthday = newStudentBirthday;

            WriteLine("Please enter your e_mail:");
            ContainEmail = ReadLine();

            WriteLine("Please enter your phone number:");
            ContainPhoneNumber = ReadLine();

            return true;


        }
        bool IStudent.SaveInfoXmlOfStudent(Student writtenStudent)
        {

            if (!Directory.Exists(@"info\user\student"))
            {
                Directory.CreateDirectory(@"info\user\student");

            }

            if (!File.Exists(@"info\user\student\" + $"{writtenStudent.ContainAccount}.xml"))
            {
                XDocument tempNewStudentXmlDocument = new XDocument(
                new XElement("students",
                    new XElement("student",
                        new XElement("account", writtenStudent.ContainAccount),
                        new XElement("password", writtenStudent.ContainPassword),
                        new XElement("ID", writtenStudent.ContainID),
                        new XElement("name", writtenStudent.ContainName),
                        new XElement("gender", writtenStudent.ContainGender),
                        new XElement("birthday", writtenStudent.ContainBirthday),
                        new XElement("phoneNumber", writtenStudent.ContainPhoneNumber)
                    )));

                tempNewStudentXmlDocument.Save(@"info\user\student\" + $"{writtenStudent.ContainAccount}.xml");

                return true;

            }
            else
            {
                throw new AccountRepeatException();
            }



        }

        bool IStudent.Login(Student loginStudent)
        {
            string loginOldStudentAccount, loginOldStudentPassword;

            Console.WriteLine("Please enter your account:");
            loginOldStudentAccount = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            loginOldStudentPassword = Console.ReadLine();


            if (Directory.Exists(@"info\user\student"))
            {
                if (File.Exists(@"info\user\student\" + $"{loginOldStudentAccount}.xml"))
                {
                    XDocument tempLoginStudentsXml = XDocument.Load(@"info\user\student\" + $"{loginOldStudentAccount}.xml");
                    XElement tempLoginStudentsRoot = tempLoginStudentsXml.Root;
                    XElement tempLoginStudentElement = tempLoginStudentsRoot.Element("student");
                    XElement tempLoginPasswordElement = tempLoginStudentElement.Element("password");

                    if (loginOldStudentPassword.Equals(tempLoginPasswordElement.Value))
                    {
                        loginStudent.ContainAccount = tempLoginStudentElement.Element("account").Value;
                        loginStudent.ContainPassword = tempLoginStudentElement.Element("password").Value;
                        loginStudent.ContainID = tempLoginStudentElement.Element("ID").Value;
                        loginStudent.ContainName = tempLoginStudentElement.Element("name").Value;

                        if (tempLoginStudentElement.Element("gender").Value.Equals("male"))
                        {
                            loginStudent.ContainGender = (Gender)1;
                        }
                        else
                        {
                            loginStudent.ContainGender = (Gender)2;
                        }

                        loginStudent.ContainBirthday = DateTime.Parse(tempLoginStudentElement.Element("birthday").Value);
                        loginStudent.ContainPhoneNumber = tempLoginStudentElement.Element("phoneNumber").Value;





                        return true;
                    }


                }



            }

            return false;
        }

       
    }
}