using System;
using System.Collections.Generic;
using System.Collections;
using School_Logic;
using System.Linq;
using School_Logic.Infrastructure;
using System.IO;

namespace EXERCISE9_SCHOOL
{
    class Program
    {
        static void PrintMainMenu()
        {
            Console.WriteLine("WELCOME TO THE COURSE PROGRAM \n");
            Console.WriteLine("Please select the option: ");
            Console.WriteLine("Option 0: Save List of STUDENTS");
            Console.WriteLine("Option -1: Save List of TEACHERS");
            Console.WriteLine("Option -2: Save List of COURSES");
            Console.WriteLine("Option 1: Add a new Student");
            Console.WriteLine("Option 2: Get List of Students");
            Console.WriteLine("Option 3: Add a new Course");
            Console.WriteLine("Option 4: Get List of Courses");
            Console.WriteLine("Option 5: Get all courses for a specific STUDENT Id(Use option 1 for to get Id)");
            Console.WriteLine("Option 6: Get all Students by alphabetic Name");
            Console.WriteLine("Option 7: Get all Students by alphabetic Last Name");
            Console.WriteLine("Option 8: Get all Courses by alphabetic course name");
            Console.WriteLine("Option 9: Get all courses code(Use option 2)");
            Console.WriteLine("Option 10: Add a new Teacher");
            Console.WriteLine("Option 11: Get all Teachers by alphabetic Name");
            Console.WriteLine("Option 12: Get all Teachers by alphabetic Last Name");
            Console.WriteLine("Option 13: Get all Teachers by subject");
            Console.WriteLine("Option 14: Get the subject for a specific Teacher");
            Console.WriteLine("Option 15: Exit the program");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            School mySchool = new School();

            while (true)
            {
                PrintMainMenu();
                string option = Console.ReadLine();
                Console.WriteLine();
                switch (option)
                {
                    case "0":
                        //bool resultS = Utilies.SaveStudentList(mySchool.Students);
                        bool resultS = mySchool.SaveStudentList();
                        if (resultS)
                        {
                            Console.WriteLine("Student were successfully saved");
                        }
                        else
                        {
                            Console.WriteLine("An error ocurred");
                        }
                        break;
                    case "-1":
                        bool resultT = mySchool.SaveTeacherList();
                        if (resultT)
                        {
                            Console.WriteLine("Teacher were successfully saved");
                        }
                        else
                        {
                            Console.WriteLine("An error ocurred");
                        }
                        break;
                    case "-2":
                        bool resultC = mySchool.SaveCoursesList();
                        if (resultC)
                        {
                            Console.WriteLine("Course were successfully saved");
                        }
                        else
                        {
                            Console.WriteLine("An error ocurred");
                        }
                        break;
                    case "1":
                        DisplayStudentCreationMenu();
                        string[] data = Console.ReadLine().Split(',');
                        mySchool.RegisterStudent(data);
                        string[] dataCourses = SelectCourses(mySchool);
                        mySchool.AssignCourses(data[0], dataCourses);
                        Console.WriteLine("Thank you!");
                        break;
                    case "2":
                        DisplayElements(mySchool.Students);
                        
                        break;
                    case "3":
                        

                        break;
                    case "4":
                        DisplayCourses(mySchool.Courses);
                        break;
                    case "5":
                        Console.WriteLine("Introduce the ID of student to search: ");
                        var userId = Console.ReadLine();

                        var result = mySchool.ReturnUserCourses(userId);
                        DisplayCourses(result);
                        break;
                    case "6":
                        var stuN = Utilies.OrderEntityByName(mySchool.Students);
                        DisplayElements(stuN);
                        break;
                    case "7":
                        var stuL = Utilies.OrderEntityByLastName(mySchool.Students);
                        DisplayElements(stuL);
                        break;
                    case "8":
                        var courN = Utilies.OrderEntityByName(mySchool.Courses);
                        DisplayElements(courN);
                        break;
                    case "9":
                        var courC = Utilies.OrderCourseByCode(mySchool.Courses);
                        DisplayElements(courC);
                        break;
                    case "10":
                        break;
                    case "11":
                        var teachN = Utilies.OrderEntityByName(mySchool.Teachers);
                        DisplayElements(teachN);
                        break;
                    case "12":
                        var teachL = Utilies.OrderEntityByLastName(mySchool.Teachers);
                        DisplayElements(teachL);
                        break;
                    case "13":
                        break;
                    case "14":
                        break;
                    case "15":
                        Console.WriteLine("Thanks for using the SCHOOL App!Bye Bye! Adiosssssss!!!!!");
                        return;
                    default:
                        break;

                }
            }
        }

        private static string[] SelectCourses(School mySchool)
        {
            Console.WriteLine("\nSelect the courses id as shown below:");
            Console.WriteLine("1,3,5");
            DisplayCourses(mySchool.Courses);
            string[] result = Console.ReadLine().Split(',');
            return result;
        }

        private static void DisplayStudentCreationMenu()
        {
            Console.WriteLine("Enter the student data as shown below:");
            Console.WriteLine("id,name,last name,email,phone,courses");

        }

        private static void DisplayCourses(IEnumerable<Course> courses)
        {
            
            foreach (var item in courses)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void DisplayElements(IEnumerable<INameable> elements)
        {
            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            
        }



       
    }
}
