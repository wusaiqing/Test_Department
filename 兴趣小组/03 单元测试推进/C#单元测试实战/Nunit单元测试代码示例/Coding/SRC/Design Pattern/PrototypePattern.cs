using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit.SRC.Design_Pattern
{
    //浅克隆
    //Abstract Prototype class
    public abstract class Prototype
    {
        public abstract Prototype clone();
    }
    public class Professor
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    public class Student : Prototype
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        Professor p;
        public Professor P
        {
            get { return p; }
            set { p = value; }
        }
        public override Prototype clone()
        {
            Student st = new Student();
            st.Name = name;
            st.Age = age;
            return st;
        }
    }
    public class client
    {
        public void show(Student s)
        {
            Console.WriteLine("This student's name is: " + s.Name + " age is: " + s.Age + " and his professor is :" + s.P.Name);
        }
        public Student stu(string name, int age, string proname, int proage)
        {
            Student student = new Student();
            student.Name = name;
            student.Age = age;
            Professor p = new Professor();
            p.Name = proname;
            p.Age = age;
            student.P = p;
            return student;
        }
        public static void Main(string[] args)
        {
            Student s = new Student();
            Student s1 = (Student)s.clone();
            client c1 = new client();
            s1 = c1.stu("zhangshan", 20, "liming", 35);
            c1.show(s1);
            Student s2 = (Student)s1.clone();
            s2 = c1.stu("lishi", 25, "zhanghua", 40);
            c1.show(s2);
            c1.show(s1);
            Console.Read();
        }
    }
}


//namespace CSharpUnit.SRC.Design_Pattern
//{
//    //浅克隆
//    //Abstract Prototype class
//    public abstract class Prototype
//    {
//        public abstract Prototype clone();
//    }
//    public class Professor
//    {
//        private string name;
//        public string Name
//        {
//            get { return name; }
//            set { name = value; }
//        }
//        private int age;
//        public int Age
//        {
//            get { return age; }
//            set { age = value; }
//        }
//    }
//    public class Student : Prototype
//    {
//        private string name;
//        public string Name
//        {
//            get { return name; }
//            set { name = value; }
//        }
//        private int age;
//        public int Age
//        {
//            get { return age; }
//            set { age = value; }
//        }
//        Professor p;
//        public Professor P
//        {
//            get { return p; }
//            set { p = value; }
//        }
//        public override Prototype clone()
//        {
//            Student st = new Student();
//            st.Name = name;
//            st.Age = age;
//            return st;
//        }
//        public object deepClone() 
//        {
            
//        }
//    }
//    public class client
//    {
//        public void show(Student s)
//        {
//            Console.WriteLine("This student's name is: " + s.Name + " age is: " + s.Age + " and his professor is :" + s.P.Name);
//        }
//        public Student stu(string name, int age, string proname, int proage)
//        {
//            Student student = new Student();
//            student.Name = name;
//            student.Age = age;
//            Professor p = new Professor();
//            p.Name = proname;
//            p.Age = age;
//            student.P = p;
//            return student;
//        }
//        public static void Main(string[] args)
//        {
//            Student s = new Student();
//            Student s1 = (Student)s.clone();
//            client c1 = new client();
//            s1 = c1.stu("zhangshan", 20, "liming", 35);
//            c1.show(s1);
//            Student s2 = (Student)s1.clone();
//            s2 = c1.stu("lishi", 25, "zhanghua", 40);
//            c1.show(s2);
//            c1.show(s1);
//            Console.Read();
//        }
//    }
//}