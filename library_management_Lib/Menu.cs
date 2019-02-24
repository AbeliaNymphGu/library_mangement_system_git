using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace library_management_Lib
{
    public static class Menu
    {

        public static class Display
        {
            public static void LoginSucceedWelcome(Student newStudent)
            {
                WriteLine("Login Succeed!!!");

                System.Threading.Thread.Sleep(1500);

                Clear();

                WriteLine($"Welcome!{newStudent.ContainName}");
            }

            public static void NoLoginMainMenu()
            {
                WriteLine(@"Menu:");
                WriteLine(@"1)Login");
                WriteLine(@"2)Register");
            }

            public static void SelectUserTypeMenu()
            {
                WriteLine(@"Menu:");
                WriteLine(@"1)Student");
                WriteLine(@"2)Librarian");
                WriteLine(@"3)System Manager");

            }

            public static void StudentMainMenu()
            {
                WriteLine(@"Menu:");
                WriteLine(@"1)Book Search");
                WriteLine(@"2)Book Lending");
                WriteLine(@"3)Book Return");
                WriteLine(@"4)View Personal Information");

            }

            public static void PersonalInformationMenu()
            {
                WriteLine(@"Menu:");
                WriteLine(@"1)Modify personal information");
            }

            public static void ModifyPersonalInformationMenu()
            {
                WriteLine(@"Menu: ");
                WriteLine(@"Please specify the item you wish to modify:");
            }
        }

        public static class Initialization
        {
            public static void LoginOrRegisterDictionary(Dictionary<string, bool> keyValuePairs)
            {

            }
        }

        public class Judge
        {
            public void NoLoginMainMenu(int selectCode, Student newStudent, bool studentStatus)
            {
                switch (selectCode)
                {
                    case 1:


                        

                        IStudent loginStudent = newStudent;
                        bool loginSucceed = loginStudent.Login(newStudent);

                        if (loginSucceed)
                        {

                            Menu.Display.LoginSucceedWelcome(newStudent);

                            System.Threading.Thread.Sleep(1500);



                            //Console.WriteLine($"{newStudent.ShowInfo()}");

                        }

                        break;
                    case 2:

                        

                        try
                        {
                            IStudent InewStudent = newStudent;

                            InewStudent.Register(newStudent);

                            InewStudent.SaveInfoXmlOfStudent(newStudent);
                        }
                        catch (AccountRepeatException newAccountRepeatException)
                        {

                            Console.WriteLine(newAccountRepeatException.Message);
                            Console.WriteLine("Register Failed!!! Please try again!!!");
                        }

                        break;

                    default:
                        Console.WriteLine("Exit Succeed!!");
                        break;

                }

            }
        }



        
    }
}