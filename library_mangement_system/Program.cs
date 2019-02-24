using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using library_management_Lib;

namespace Main_Program
{
    class Program
    {
        static void Main(string[] args)
        {


            
            ///<summary>
            ///程序初始化
            /// </summary>
            ///<summary>
            ///菜单选项
            /// </summary>

            int selectCode = default;
            ///<summary>
            ///菜单状态初始化
            /// </summary>
            Dictionary<string, bool> loginOrRegisterSelectStatus = new Dictionary<string, bool>(2);
            Dictionary<string, bool> selectUserTypeStatus = new Dictionary<string, bool>(3);
            Dictionary<string, bool> studentMenuSelectStatus = new Dictionary<string, bool>(4);
            Dictionary<string, bool> loginOrRegisterSucceedStatus = new Dictionary<string, bool>(2);
            ///<summary>
            ///
            /// </summary>
            /// 
            

            loginOrRegisterSelectStatus.Add("loginRequirement", false);
            loginOrRegisterSelectStatus.Add("registerRequirement", false);

            selectUserTypeStatus.Add("studentRequirement", false);
            selectUserTypeStatus.Add("librarianRequirement", false);
            selectUserTypeStatus.Add("systemManagerRequirement", false);
            
            studentMenuSelectStatus.Add("bookSearchRequirement", false);
            studentMenuSelectStatus.Add("bookLendingRequirement", false);
            studentMenuSelectStatus.Add("bookReturnRequirement", false);
            studentMenuSelectStatus.Add("viewPersonalInfoRequirement", false);

            loginOrRegisterSucceedStatus.Add("studentLoginSucceed", false);
            
            

            Student student = new Student();
            Librarian librarian = new Librarian();

            Menu.Display.NoLoginMainMenu();

            selectCode = Convert.ToInt32(Console.ReadLine());

            switch (selectCode)
            {
                case 1:
                    loginOrRegisterSelectStatus["loginRequirement"] = true;
                    break;

                case 2:
                    loginOrRegisterSelectStatus["registerRequirement"] = true;
                    break;   
                    
                default:
                    break;
            }

            if (loginOrRegisterSelectStatus[key: "loginRequirement"])
            {
                

                Menu.Display.SelectUserTypeMenu();

                selectCode = Convert.ToInt32(Console.ReadLine());

                switch (selectCode)
                {
                    case 1:
                        IStudent newStudent = student;

                        loginOrRegisterSucceedStatus["studentLoginSucceed"] = newStudent.Login(student);
                        break;

                    case 2:
                        ILibrarian newLibrarian = librarian;

                        newLibrarian.Login(librarian);
                        break;

                    case 3:


                        break;
                    default:
                        break;
                }
            }

            if (loginOrRegisterSelectStatus[key: "registerRequirement"])
            {
                

                Menu.Display.SelectUserTypeMenu();

                selectCode = Convert.ToInt32(Console.ReadLine());

                switch (selectCode)
                {
                    case 1:
                        IStudent newStudent = student;

                        newStudent.Register(student);
                        newStudent.SaveInfoXmlOfStudent(student);
                        break;

                    case 2:
                        ILibrarian newLibrarian = librarian;

                        newLibrarian.Register(librarian);
                        newLibrarian.SaveInfoXmlOfLibrarian(librarian);
                        break;

                    case 3:


                        break;
                    default:
                        break;
                }

            }

            if (loginOrRegisterSucceedStatus[key: "studentLoginSucceed"])
            {
                Menu.Display.StudentMainMenu();

                selectCode = Convert.ToInt32(Console.ReadLine());

                switch (selectCode)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine($"{ student.ShowInfo()}");

                        System.Threading.Thread.Sleep(5000);
                        break;
                    default:
                        break;
                }
            }




        }
    }
}
	

	