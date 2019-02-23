using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library_management_Lib
{
    public abstract class User
    {
        /// <summary>
        /// 姓名
        /// </summary>
        private string name;
        /// <summary>
        /// 性别（之后还能加个FUTA）
        /// </summary>
        private Gender gender;
        /// <summary>
        /// 标识号
        /// </summary>
        private string ID;
        /// <summary>
        /// 生日（虽然我并不知道有什么用）
        /// </summary>
        private DateTime birthday;
        /// <summary>
        /// 账号
        /// </summary>
        private string account;
        /// <summary>
        /// 密码
        /// </summary>
        private string password;
        /// <summary>
        /// 电子邮件（国内没人用，我也不知道为什么）
        /// </summary>
        private string email;
        /// <summary>
        /// 手机号
        /// </summary>
        private string phoneNumber;
        /// <summary>
        /// Name属性
        ///     <get>返回name:string</get>
        ///     <set>将值写入name</set>
        /// </summary>
        public string ContainName
        {
            get => name;
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// gender属性
        ///     <get>返回gender:Gender</get>
        ///     <set>将值写入gender</set>
        /// </summary>
        public Gender ContainGender
        {
            get => gender;
            set
            {
                gender = value;
            }
        }
        /// <summary>
        /// ID属性
        ///     <get>返回ID:string</get>
        ///     <set></set>
        /// </summary>
        public string ContainID
        {
            get => ID;
            set
            {
                ID = value;
            }
        }

        public DateTime ContainBirthday
        {
            get => birthday;
            set
            {
                birthday = value;
            }
        }

        public string ContainAccount
        {
            get => account;
            set
            {
                account = value;
            }
        }

        public string ContainPassword
        {
            get => password;
            set
            {
                password = value;
            }
        }

        public string ContainEmail
        {
            get => email;
            set
            {
                email = value;
            }
        }

        public string ContainPhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
            }
        }

        public virtual bool SetGender(Gender newGender)
        {
            ///throw new System.NotImplementedException();
            ///
            if (newGender == Gender.male || newGender == Gender.female )
            {
                ContainGender = newGender;

                return true;
            }
            else
            {
                throw (new ArgumentOutOfRangeException("Gender", newGender, "Please enter the correct gender(male or female)!"));
            }
        }

        public virtual bool SetName(string newName)
        {
            ///throw new System.NotImplementedException();
            ///

            ContainName = newName;

            return true;
        }

        public virtual bool SetID(string newID)
        {
            ///throw new System.NotImplementedException();
            ///

            ContainID = newID;

            return true;
        }

        public virtual string ShowInfo()
        {
            ///throw new System.NotImplementedException();
            ///

            return $"StudentID : {ContainID}\n" +
                $"Name : {ContainName}\n" +
                $"Gender : {ContainGender}\n" +
                $"Birthday : {ContainBirthday}\n"; 
        }

        public virtual bool SetBirthday(DateTime newBirthday)
        {
            ///throw new System.NotImplementedException();
            ///

            ContainBirthday = newBirthday;
            return true;
        }

        public void SetEmail(string newEmail)
        {
            throw new System.NotImplementedException();
        }

        public bool SetPhoneNumber(string newPhoneNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}