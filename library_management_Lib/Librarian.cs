using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.IO;
using System.Xml.Linq;

namespace library_management_Lib
{
    public class Librarian : User, ILibrarian
    {

        public override string ShowInfo()
        {
            ///throw new System.NotImplementedException();
            ///

            return $"/t/t-----------------------------------------------------\n" +
                $"Librarian Inforamtion\n" +
                $"Account : {ContainAccount}\n" +
                $"Password : {ContainPassword}\n" +
                $"ID : {ContainID}\n" +
                $"Name : {ContainName}\n" +
                $"Gender : {ContainGender}\n" +
                $"Birthday : {ContainBirthday}\n" +
                $"Phone Number : {ContainPhoneNumber}";


        }

        void ILibrarian.Register(Librarian newLibrarian)
        {
            WriteLine("Please enter your account:");
            ContainAccount = ReadLine();

            WriteLine("Please enter your password:");
            ContainPassword = ReadLine();

            WriteLine("Please enter your library' ID:");
            ContainID = ReadLine();

            WriteLine("Please enter your name:");
            ContainName = ReadLine();

            WriteLine("Please select your gender(1.male 2.female):");
            ContainGender = (Gender)Convert.ToInt32(ReadLine());

            WriteLine("Plesae enter your birthday:");
            DateTime newStudentBirthday = new DateTime();
            DateTime.TryParse(ReadLine(), out newStudentBirthday);
            ContainBirthday = newStudentBirthday;

            WriteLine("Please enter your phone number:");
            ContainPhoneNumber = ReadLine();
        }

        void ILibrarian.SaveInfoXmlOfLibrarian(Librarian savedLibrarian)
        {
            if (!Directory.Exists(@"info\user\librarian"))
            {
                Directory.CreateDirectory(@"info\user\librarian");

            }

            if (!File.Exists(@"info\user\librarian\" + $"{savedLibrarian.ContainAccount}.xml"))
            {
                XDocument tempNewStudentXmlDocument = new XDocument(
                new XElement("librarians",
                    new XElement("librarian",
                        new XElement("account", savedLibrarian.ContainAccount),
                        new XElement("password", savedLibrarian.ContainPassword),
                        new XElement("ID", savedLibrarian.ContainID),
                        new XElement("name", savedLibrarian.ContainName),
                        new XElement("gender", savedLibrarian.ContainGender),
                        new XElement("birthday", savedLibrarian.ContainBirthday),
                        new XElement("phoneNumber", savedLibrarian.ContainPhoneNumber)
                    )));

                tempNewStudentXmlDocument.Save(@"info\user\librarian\" + $"{savedLibrarian.ContainAccount}.xml");

            }
            else
            {
                throw new AccountRepeatException();
            }
        }

        bool ILibrarian.Login(Librarian loginLibrarian)
        {
            string loginAccount, loginPassword;

            Console.WriteLine("Please enter your account:");
            loginAccount = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            loginPassword = Console.ReadLine();


            if (Directory.Exists(@"info\user\librarian"))
            {
                if (File.Exists(@"info\user\librarian\" + $"{loginAccount}.xml"))
                {
                    XDocument tempLoginStudentsXml = XDocument.Load(@"info\user\librarian\" + $"{loginAccount}.xml");
                    XElement tempLoginStudentsRoot = tempLoginStudentsXml.Root;
                    XElement tempLoginStudentElement = tempLoginStudentsRoot.Element("librarian");
                    XElement tempLoginPasswordElement = tempLoginStudentElement.Element("password");

                    if (loginPassword.Equals(tempLoginPasswordElement.Value))
                    {
                        loginLibrarian.ContainAccount = tempLoginStudentElement.Element("account").Value;
                        loginLibrarian.ContainPassword = tempLoginStudentElement.Element("password").Value;
                        loginLibrarian.ContainID = tempLoginStudentElement.Element("ID").Value;
                        loginLibrarian.ContainName = tempLoginStudentElement.Element("name").Value;

                        if (tempLoginStudentElement.Element("gender").Value.Equals("male"))
                        {
                            loginLibrarian.ContainGender = (Gender)1;
                        }
                        else
                        {
                            loginLibrarian.ContainGender = (Gender)2;
                        }

                        loginLibrarian.ContainBirthday = DateTime.Parse(tempLoginStudentElement.Element("birthday").Value);
                        loginLibrarian.ContainPhoneNumber = tempLoginStudentElement.Element("phoneNumber").Value;





                        return true;
                    }


                }



            }

            return false;
        }
    }
}