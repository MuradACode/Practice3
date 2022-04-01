using System;
using System.Collections.Generic;
using System.Text;

namespace Practice3.Models
{
    class Group
    {
        private int _studentLimit;
        public int GroupNo { get; set; }
        public int StudentLimit
        {
            get { return _studentLimit; }
            set
            {
                if (value > 4 && value < 19)
                {
                    _studentLimit = value;
                }
            }
        }
        private static List<Student> students = new List<Student>();
        public Group(int groupNo, int studentLimit)
        {
            GroupNo = groupNo;
            StudentLimit = studentLimit;
        }
        public bool CheckGroupNo(string groupNo)
        {
            short n = 0;
            char[] check = groupNo.ToCharArray();
            for (int i = 0; i < 2; i++)
            {
                if (check[i] < 91 || check[i] > 64)
                {
                    n++;
                }
            }
            foreach (char item in check)
            {
                if (item < 58 || item > 47)
                {
                    n++;
                }
            }
            if (n == 5) return true;
            else return false;
        }
        public static void AddStudent(Student student)
        {
            students.Add(student);
        }
        public static Student GetStudent(int? id)
        {
            return students.Find(n => n.Id == id);
        }
        public static List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
