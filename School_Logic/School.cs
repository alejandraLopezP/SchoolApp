using School_Logic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace School_Logic
{
    public class School
    {
        
        public School()
        {
            #region std
            /*
            this.Students = new List<Student> {

                        new Student
                        {
                            Id = 1,
                            Name = "Pedro",
                            LastName = "López",
                            Email = "pedro@gmail.com",
                            Phone = "625147896"

                        },
                        new Student
                        {
                            Id = 2,
                            Name = "Alex",
                            LastName = "Harris",
                            Email = "alex@gmail.com",
                            Phone = "728147896"
                        },
                        new Student
                        {
                            Id = 3,
                            Name = "Karl",
                            LastName = "Eriksson",
                            Email = "katr@gmail.com",
                            Phone = "214147896"
                        },
                        new Student
                        {
                            Id = 4,
                            Name = "Jhon",
                            LastName = "Hamilton",
                            Email = "jhon@gmail.com",
                            Phone = "444147896"
                        },
                        new Student
                        {
                            Id = 5,
                            Name = "Anna",
                            LastName = "Larsson",
                            Email = "anna@gmail.com",
                            Phone = "985147896"
                        },
                        new Student
                        {
                            Id = 6,
                            Name = "Sussan",
                            LastName = "Johansson",
                            Email = "sussi@gmail.com",
                            Phone = "321147896"
                        },

            };
            */
            #endregion

            Courses = ReadCourses();
            Students = ReadStudents();
            #region courses
            /*
            this.Courses = new List<Course>
            {
                new Course
                {
                    Id = 10,
                    Code = "PY-01",
                    Name = "Phyton",
                    Point = 10
                },
                new Course
                {
                    Id = 11,
                    Code = "AWS",
                    Name = "Amazon Web Services",
                    Point = 20
                },
                new Course
                {
                    Id = 12,
                    Code = "JAVA-01",
                    Name = "Java",
                    Point = 30
                }
            };
            */

            /*
            this.Teachers = new List<Teacher>
            {
                new Teacher
                {
                    Id = 20,
                    Name = "Tony",
                    LastName = "Lunden",
                    Email = "tony@gmail.com",
                    Phone = "111963741"
                    
                },
                new Teacher
                {
                    Id = 20,
                    Name = "Wille",
                    LastName = "Jhonson",
                    Email = "wille@hotmail.com",
                    Phone = "259963841"
                   

                },
                new Teacher
                {
                    Id = 20,
                    Name = "Anders",
                    LastName = "Yngve",
                    Email = "anders@yahoo.com",
                    Phone = "233963741"
                   
                }
            };
            */
            #endregion
            Teachers = ReadTeacher();
            
            
            this.RelationStudentCourse = new Dictionary<IIdentificable, IEnumerable<Course>>();
            this.RelationTeacherCourse = new Dictionary<IIdentificable, Course>();
            
            ReadRelationshipStudentsCourses();
            //FillingUpRelations();
            FillingUpTeachersCourses();
        }

        private void ReadRelationshipStudentsCourses()
        {
            List<string[]> process = new List<string[]>();


            try
            {
                string studentsPath = "studentsCourses.csv";
                FileStream file = new FileStream(studentsPath, FileMode.OpenOrCreate, FileAccess.Read);

                StreamReader sr = new StreamReader(file);
                while (true)
                {
                    string line = sr.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    process.Add(line.Split(';'));
                    
                }
                sr.Close();
                file.Close();
                ProcessLineStudentCourses(process);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
           
        }
        //KeyValuePair<INameable,IEnumerable<Course>>
        private void  ProcessLineStudentCourses(List<string[]> idStListIdCourses)
        {
            var sp = idStListIdCourses.GroupBy(p => p[0]);
            var idStudents = sp.Select(s => s.Key).ToList();
            var idCourses = sp.Select(g => g.Select(n => n.Skip(1)).ToList()).ToList();
            foreach (var item in idStudents)
            {
                Student n = Students.FirstOrDefault(s => s.Id == int.Parse(item));
                List<Course> lc = new List<Course>();
                foreach (var idC in idCourses)
                {
                    
                    Course c = Courses.FirstOrDefault(c => c.Id == int.Parse(item));
                    lc.Add(c);
                }
                RelationStudentCourse.Add(n, lc);
            }
        }

        public void AssignCourses(string idStudent, string[] idDataCourses)
        {
            Student s = Students.FirstOrDefault(s => s.Id == int.Parse(idStudent));
            var coursesSelected = idDataCourses.Select(id => Courses.First(c => c.Id == int.Parse(id))).ToList();
            s.Courses = coursesSelected;
        }

        public void RegisterStudent(string[] data)
        {
            Student newOne = new Student() { 
            Id = int.Parse(data[0]),
            Name = data[1],
            LastName = data[2],
            Email = data[3],
            Phone = data[4],
            //Courses = data[5]
            };
            Students.Add(newOne);
        }

        private void FillingUpTeachersCourses()
        {
            Random r = new Random();
            var copyCourses = Courses.ToList();
            for (int i = 0; i < Teachers.Count; i++)
            {
                int indexR = r.Next(copyCourses.Count);//create a random number between 0 till teachers count
                var courseToTeach = copyCourses[indexR];//course type
                Teachers[i].Course = courseToTeach;
                //erasing the course previously assigned so I will not repeat it.
                copyCourses.RemoveAt(indexR);
            }
        }

        public bool SaveStudentList()
        {
            bool howWas = true;
            try
            {
                string studentsPath = "students.csv";
                FileStream file = new FileStream(studentsPath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                foreach (var item in Students)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
                file.Close();
                SaveRelationStudentCourses();
            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                howWas = false;
            }
            return howWas;
        }

        private void SaveRelationStudentCourses()
        {

            string studentsPath = "studentsCourses.csv";
            FileStream file = new FileStream(studentsPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            foreach (var item in RelationStudentCourse)
            {
                foreach (var course in item.Value)
                {
                    sw.WriteLine($"{item.Key.Id};{course.Id}");
                }
            }
            
            sw.Close();
            file.Close();
        }

        private List<Student> ReadStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                string studentsPath = "students.csv";
                FileStream file = new FileStream(studentsPath, FileMode.OpenOrCreate, FileAccess.Read);

                StreamReader sr = new StreamReader(file);
                while (true)
                {
                    string line = sr.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    var student = ProcessLine(line);
                    students.Add(student);
                }
                sr.Close();
                file.Close();
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            return students;
        }

        private Student ProcessLine(string line)
        {
            string[] boxes = line.Split(';');
            Student s = new Student()
            {
                Id = int.Parse(boxes[0]),
                Name = boxes[1],
                LastName = boxes[2],
                Email = boxes[3],
                Phone = boxes[4]
            };
            return s;
        }

        public bool SaveTeacherList()
        {
            bool howWas = true;
            try
            {
                string teachersPath = "teachers.csv";
                FileStream file = new FileStream(teachersPath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                foreach (var item in Teachers)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
                file.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                howWas = false;
            }
            return howWas;
        }
        private List<Teacher> ReadTeacher()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                string teachersPath = "teachers.csv";
                FileStream file = new FileStream(teachersPath, FileMode.OpenOrCreate, FileAccess.Read);

                StreamReader sr = new StreamReader(file);
                while (true)
                {
                    string line = sr.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    var teacher = ProcessLineTeacher(line);
                    teachers.Add(teacher);
                }
                sr.Close();
                file.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            return teachers;
        }
        private Teacher ProcessLineTeacher(string line)
        {
            string[] boxesT = line.Split(';');
            Teacher t = new Teacher()
            {
                Id = int.Parse(boxesT[0]),
                Name = boxesT[1],
                LastName = boxesT[2],
                Email = boxesT[3],
                Phone = boxesT[4],
                //Course = boxesT[5]
            };
            return t;
        }
        private void FillingUpRelations()
        {
            //RelationStudentCourse.Add(Students[0], new List<Course>() { Courses[0], Courses[1] });
            //RelationStudentCourse.Add(Students[1], new List<Course>() { Courses[0], Courses[2] });
            //RelationStudentCourse.Add(Students[2], new List<Course>() { Courses[2], Courses[0] });
            //RelationStudentCourse.Add(Students[3], new List<Course>() { Courses[2], Courses[1] });
            //RelationStudentCourse.Add(Students[4], new List<Course>() { Courses[1], Courses[0] });
            //RelationStudentCourse.Add(Students[5], new List<Course>() { Courses[0], Courses[2] });

            //For assign random values to student courses
            Random r = new Random();

            foreach (var student in Students)
            {
                var copyCourses = Courses.ToList();
                List<Course> studentCourses = new List<Course>();
                int cant = r.Next(1, Courses.Count);
                for (int i = 0; i < cant; i++)
                {
                    int randomIndex = r.Next(copyCourses.Count);
                    studentCourses.Add(copyCourses[randomIndex]);
                    copyCourses.RemoveAt(randomIndex);
                }
                RelationStudentCourse.Add(student,studentCourses);
            }
            
        }

        public bool SaveCoursesList()
        {
            bool howWas = true;
            try
            {
                string coursePath = "courses.csv";
                FileStream file = new FileStream(coursePath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                foreach (var item in Courses)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
                file.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                howWas = false;
            }
            return howWas;
        }
        private Course ProcessCourseLine(string line)
        {
            string[] boxes = line.Split(';');
            Course c = new Course()
            {
                Id = int.Parse(boxes[0]),
                Name = boxes[1],
                Code = boxes[2],
                Point = int.Parse(boxes[3])
            };
            return c;
        }

        //public Student AddStudent(int id,string name, string lastName)
        //{

           
        //}
        private List<Course> ReadCourses()
        {
            List<Course> courses = new List<Course>();
            try
            {
                string coursesPath = "courses.csv";
                FileStream file = new FileStream(coursesPath, FileMode.OpenOrCreate, FileAccess.Read);

                StreamReader sr = new StreamReader(file);
                while (true)
                {
                    string line = sr.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    var course = ProcessCourseLine(line);
                    courses.Add(course);
                }
                sr.Close();
                file.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            return courses;
        }

        public IEnumerable<Course> ReturnUserCourses(string userId)
        {
            int id = int.Parse(userId);
            IIdentificable sample = Students.FirstOrDefault(s => s.Id == id);
            if (sample == null)
            {
                return null;
            }
            //Si falla arreglar el equality comparer, ya que por defecto el solo comparar referencias
            //y necesitamos que compare contenido.
            var result = RelationStudentCourse[sample];
            return result;
        }

        public List<Student> Students { get; private set; }
        public List<Course> Courses { get; private set; }
        public List<Teacher> Teachers { get; private set; }
        public Dictionary<IIdentificable, IEnumerable<Course>> RelationStudentCourse { get; private set; }
        public Dictionary<IIdentificable, Course> RelationTeacherCourse { get; private set; }


    }
}
