namespace SchoolManagement.Data.AppMetaDate
{
    public class Router
    {
        public const string SymbolId = "/{Id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";



        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/login";
            public const string RefreshToken = Prefix + "/RefreshToken";
            public const string ValidateToken = Prefix + "/ValidateToken";




        }

        public static class Departmwent
        {
            public const string Prefix = Rule + "Admin" + "/Department";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/GetById";
            public const string Delete = Prefix + "/Delete" + SymbolId;
            public const string Update = Prefix + "/Update";
            public const string Add = Prefix + "/Add";




        }



        public static class User
        {
            public const string Prefix = Rule;
            public const string Add = Prefix + "Add";


        }




        public static class Course
        {
            public const string Prefix = Rule + "Admin" + "/Course";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/GetById";
            public const string Delete = Prefix + "/Delete" + SymbolId;
            public const string Update = Prefix + "/Update";
            public const string Add = Prefix + "/Add";




        }




        public static class Student
        {
            public const string Prefix = Rule + "Student";
            public const string GetClasses = Prefix + "/Classes";
            public const string GetGrade = Prefix + "/Grades";
            public const string SumbitAssigment = Prefix + "/Sumbit-Assigment";
            public const string VeiwAssigment = Prefix + "/AllAssigment";
            public const string Attendence = Prefix + "/All-Attendence";




        }





        public static class Teacher
        {
            public const string Prefix = Rule + "Teacher";
            public const string GetAssigmentById = Prefix + "/Assigment" + SymbolId;
            public const string GetAttendenceByClassId = Prefix + "/Get-Attendence - ByClassId" + SymbolId;
            public const string UpdateClass = Prefix + "/Update-Class";
            public const string AddClass = Prefix + "/Add-Class";
            public const string MarkAttendence = Prefix + "/Mark-Attendence";
            public const string AssignStudent = Prefix + "/Assign-Student-toClass";
            public const string AddAssigment = Prefix + "/Add-Assigment";
            public const string DeActiveClass = Prefix + "/DeActive-Class" + SymbolId;
            public const string PostGrade = Prefix + "/Add-Grade";








        }
    }
}
