using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library_management_Lib
{
    public interface IStudent
    {
        bool Register(Student newStudent);
        bool SaveInfoXmlOfStudent(Student savedStudent);
        bool Login(Student loginStudent);
        //Student XmlToStudent();
    }
}