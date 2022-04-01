using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_3.Models
{
    class Student
    {
        public static int _idCounter = 0;
        public int Id { get; private set; }
        public string FullName { get; set; }
        public int Point { get; set; }
        public string Password { get; set; }
        private Student()
        {
            Id = ++_idCounter;
        }
        public Student(string fullname, int point) : this()
        {
            FullName = fullname;
            Point = point;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}\nFullname: {FullName}\nPoint: {Point}");
        }
    }
}
