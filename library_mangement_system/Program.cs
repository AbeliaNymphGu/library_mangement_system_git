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
            /// 
            #region
            Dictionary<string, bool> loginOrRegisterSelectStatus = new Dictionary<string, bool>(2);
            Dictionary<string, bool> selectUserTypeStatus = new Dictionary<string, bool>(3);
            Dictionary<string, bool> studentMenuSelectStatus = new Dictionary<string, bool>(4);
            Dictionary<string, bool> loginOrRegisterSucceedStatus = new Dictionary<string, bool>(2);
             
            #endregion


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
            Book book = new Book();

            Menu.Display.NoLoginMainMenu();

            selectCode = Convert.ToInt32(Console.ReadLine());

            ///
            /// <summary>
            /// 主菜单，提示登录与注册
            /// </summary>
            ///
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

            ///<summary>
            ///登录模块
            /// </summary>
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


            ///<summary>
            ///注册模块
            /// </summary>
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
            
            ///<summary>
            ///学生登录成功菜单
            /// </summary>
            if (loginOrRegisterSucceedStatus[key: "studentLoginSucceed"])
            {
                Menu.Display.StudentMainMenu();

                selectCode = Convert.ToInt32(Console.ReadLine());

                switch (selectCode)
                {
                    case 1:
                        studentMenuSelectStatus[key: "bookSearchRequirement"] = true;
                        break;
                    case 2:
                        studentMenuSelectStatus[key: "bookLendingRequirement"] = true;
                        break;
                    case 3:
                        studentMenuSelectStatus[key: "bookReturnRequirement"] = true;
                        break;
                    case 4:
                        Console.WriteLine($"{ student.ShowInfo()}");

                        System.Threading.Thread.Sleep(5000);
                        break;
                    default:
                        break;
                }
            }

            ///<summary>
            ///书籍查询
            /// </summary>
            /// 
            if (studentMenuSelectStatus[key: "bookSearchRequirement"])
            {
                IBook newBook = book;
                Console.WriteLine(@"Please enter the ISBN:");
                string targetISBN = Console.ReadLine();
                bool searchSucceed = false;
                searchSucceed = newBook.Search(targetISBN, book);

                if (searchSucceed)
                {
                    Console.WriteLine($"{book.ShowInfo()}");
                    System.Threading.Thread.Sleep(10000);
                    
                }
            }


        }
    }
}
	

	