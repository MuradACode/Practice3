using Practice_3.Models;
using System;

namespace Practice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------\nUser creating\n----------------------------------------");
            Console.Write("Name:");
            string userName = Console.ReadLine();
            Console.Write("Email:");
            string userEmail = Console.ReadLine();
            Console.Write("Password:");
            string userPassword = Console.ReadLine();
            User user = new User(userName, userEmail, userPassword);
            if (string.IsNullOrEmpty(user.Email))
            {
                throw new NullReferenceException("Email must contain @ & '.'");
            }
            if (user.PasswordChecker(userPassword) == false)
            {
                throw new NullReferenceException("Password must contain at least 8, 1 upper, 1 lower and 1 digit character");
            }
            Console.WriteLine("----------------------------------------\nUser successfully created\n----------------------------------------");
        Menu1:
            Console.WriteLine("----------------------------------------\n1.Show info\n2.Create new group\n0.Continue\n----------------------------------------");
            string input1 = Console.ReadLine();
            switch (input1)
            {
                case "1":
                    user.ShowInfo();
                    goto Menu1;
                case "2":
                    Console.Write("Enter the group no:");
                    string groupNo = Console.ReadLine();
                    Console.Write("Enter the student limit:");
                    int studentLimit = Convert.ToInt32(Console.ReadLine());
                    Group group = new Group(groupNo, studentLimit);
                    if (!group.CheckGroupNo(groupNo))
                    {
                        throw new NullReferenceException("Group no must contain 2 upper characters and 3 digits");
                    }
                    if (group.StudentLimit == 0)
                    {
                        throw new NullReferenceException("Limit must be between 5 and 18");
                    }
                    Console.WriteLine("----------------------------------------\nGroup successfully created\n----------------------------------------");
                    goto Menu1;
                case "0":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input try again!");
                    goto Menu1;
            }
        Menu2:
            Console.WriteLine("----------------------------------------\n1.Show all students\n2.Get student by id\n3.Add student\n0.Quit\n----------------------------------------");
            string input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    if (Group.GetAllStudents().Count is 0) throw new NullReferenceException("Students list is empty");
                    foreach (Student item in Group.GetAllStudents())
                    {
                        item.ShowInfo();
                    }
                    goto Menu2;
                case "2":
                    Console.Write("Enter the student id:");
                    int studentId = Convert.ToInt32(Console.ReadLine());
                    Group.GetStudent(studentId).ShowInfo();
                    goto Menu2;
                case "3":
                    Console.Write("Name:");
                    string studentName = Console.ReadLine();
                    Console.Write("Enter the point:");
                    int point = Convert.ToInt32(Console.ReadLine());
                    Student student = new Student(studentName, point);
                    Group.AddStudent(student);
                    goto Menu2;
                case "0":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input try again!");
                    goto Menu2;
            }
        }
    }
}
