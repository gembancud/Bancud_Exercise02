using System;
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
            while (!_exitFlag)
            {
                choice = Query();
                doDecision(choice);
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

        public int SearchStudentIndex(string inputName)
        {
            var temp = StudentList.Head;
            for (int i = 0; i < StudentList.Size; i++)
            {
                if (inputName == temp.Data.StudentName) return i;
                temp = temp.Next;
            }

            return -1;
        }

        public ref Student SearchStudent(string inputName)
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

        public void DeleteCourse(string inputCourseName)
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