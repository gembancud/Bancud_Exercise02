using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Exercise02_A
{
    public class View
    {
        public int choice { get; set; }
        public LinkedList<Student> StudentList = new LinkedList<Student>();
        private Student refStudent;
        private Course refCourse;
        private bool _exitFlag = false;
        public View()
        {
            openSavedRecord();
            while (!_exitFlag)
            {
                choice = Query();
                doDecision(choice);
            }
        }

        public void openSavedRecord()
        {
            var filePath = @"C:\saved.text";
            int flag = 0;
            IEnumerable<string> SavedFile = null;
            try
            {
                SavedFile=File.ReadLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("No File was Loaded!\n\n");
            }
            if (SavedFile==null) return;
            foreach (var line in SavedFile)
            {
                var newStudent = new Student();
                var newCourse= new Course();
                foreach (var variable in GetWordsEnumerable(line))
                {
                    switch (flag)
                    {
                        case 0:
                            newStudent.StudentName = (string)variable;
                            flag++;
                            break;
                        case 1:
                            newCourse.CourseName = (string) variable;
                            flag++;
                            break;
                        case 2:
                            newCourse.Units = Convert.ToInt32(variable);
                            flag++;
                            break;
                        case 3:
                            newCourse.CourseGrade = Convert.ToInt32(variable);
                            newStudent.CourseList.AddToTail(newCourse);
                            flag = 1;
                            break;
                    }
                }
                StudentList.AddToTail(newStudent);
                flag = 0;
            }
            Console.WriteLine("Save File Successfully Loaded");
        }

        public IEnumerable GetWordsEnumerable(string line)
        {
            string word = null;
            foreach (char letter in line)
            {
                if (letter != ',')
                {
                    word += letter;
                }
                else
                {
                    yield return word;
                    word = null;
                }
                
            }
        }

        public void SaveRecord()
        {
            var filePath = @"C:\saved.text";
            LinkedList<string> SavedList= new LinkedList<string>();
            string save = null;
            foreach (Student student in StudentList)
            {
                save += student.StudentName+",";
                foreach (Course course in student.CourseList)
                {
                    save += course.CourseName + ",";
                    save += course.Units + ",";
                    save += course.CourseGrade + ",";
                }
                SavedList.AddToTail(save);
                save = null;
            }

            try
            {
                File.WriteAllLines(filePath, SavedList);
            }
            catch (Exception e)
            {
                Console.WriteLine("Drive not Accessible, File Not Saved");
                Console.ReadLine();
            }
        }

        public int Query()
        {
            Console.WriteLine("Choose your Options:\n(1)Add Student\n(2)Delete Student\n(3)Add Course from Students Record\n(4)Delete Course from Students Record\n(5)Print Student's Records\n(6)Save and Exit");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void doDecision(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    AddStudentCourse();
                    break;
                case 4:
                    DeleteStudentCourse();
                    break;
                case 5:
                    PrintStudentRecords();
                    break;
                case 6:
                    SaveRecord();
                    _exitFlag = true;
                    break;
                default:
                    Console.WriteLine("Please enter proper choice!\n");
                    break;
            }
        }

        public void AddStudent()
        {
            Console.Write("Please Input Name: ");
            var inputName = Console.ReadLine();
            if (inputName == null) { Console.WriteLine("Name cannot be empty"); return; }
            StudentList.AddToTail(new Student(inputName));
            Console.WriteLine("Succesfully Added!\n");
        }

        public void DeleteStudent()
        {
            Console.Write("Please Input Name: ");
            var inputName = Console.ReadLine();
            if (inputName == null) { Console.WriteLine("Name cannot be empty"); return; }
            var inputNameIndex = SearchStudentIndex(inputName);
            if (inputNameIndex == -1)
            {
                Console.WriteLine("Name not found\n");
                return;
            }

            StudentList.RemoveAt(inputNameIndex);
            Console.WriteLine("Student Deleted");
        }

        private int SearchStudentIndex(string inputName)
        {
            var temp = StudentList.Head;
            for (int i = 0; i < StudentList.Size; i++)
            {
                if (inputName == temp.Data.StudentName) return i;
                temp = temp.Next;
            }

            return -1;
        }

        private ref Student SearchStudent(string inputName)
        {
            var temp = StudentList.Head;
            for (int i = 0; i < StudentList.Size; i++)
            {
                if (temp.Data.StudentName.Equals(inputName, StringComparison.CurrentCultureIgnoreCase))
                {
                    refStudent = temp.Data;
                    return ref refStudent;
                }

                temp = temp.Next;
            }

            refStudent = null;
            return ref refStudent;
        }

        public void AddStudentCourse()
        {
            Console.Write("Please Input Name: ");
            var inputName = Console.ReadLine();
            if (inputName == null) throw new IOException();


            var student = SearchStudent(inputName);
            if (student == null)
            {
                Console.WriteLine("Student not Found");
                return;
            }

            Console.Write("Please input coursename:");
            var inputCourseName = Console.ReadLine();
            if (inputCourseName == null) throw new IOException();

            Console.Write("Please input unit number:");
            var input = Console.ReadLine();
            if (input == null) throw new IOException();
            var inputUnits = Convert.ToInt32(input);

            Console.Write("Please input course grade:");
            input = Console.ReadLine();
            if (input == null) throw new IOException();
            var inputGrade = Convert.ToInt32(input);

            var newCourse = new Course(inputCourseName, inputUnits, inputGrade);
            student.CourseList.AddToTail(newCourse);
        }

        private void DeleteCourse(string inputCourseName)
        {
            var temp = refStudent.CourseList.Head;
            for (int i = 0; i < StudentList.Size; i++)
            {
                if (temp.Data.CourseName.Equals(inputCourseName, StringComparison.CurrentCultureIgnoreCase))
                {
                    refStudent.CourseList.RemoveAt(i);
                    Console.WriteLine("Course Deleted\n");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine(" Course match not found\n");
        }

        public void DeleteStudentCourse()
        {
            Console.Write("Please Input Name: ");
            var inputName = Console.ReadLine();

            var student = SearchStudent(inputName);
            if (student == null)
            {
                Console.WriteLine("Student not Found");
                return;
            }

            Console.Write("Please input coursename:");
            var inputCourseName = Console.ReadLine();

            DeleteCourse(inputCourseName);

        }

        public void PrintStudentRecords()
        {
            Console.Write("Please Input Name: ");
            var inputName = Console.ReadLine();
            if (inputName == null) throw new IOException();


            var student = SearchStudent(inputName);
            if (student == null)
            {
                Console.WriteLine("Student not Found");
                return;
            }

            var temp = student.CourseList.Head;
            if (temp == null)
            {
                Console.WriteLine("No Records found");
                return;
            }
            while (temp.Data != null)
            {
                Console.WriteLine($"Course:{temp.Data.CourseName}\nUnits:{temp.Data.Units}\nGrade:{temp.Data.CourseGrade}\n");
                temp = temp.Next;
            }
            Console.WriteLine($"GPA:{student.GPA}");
        }
    }
}