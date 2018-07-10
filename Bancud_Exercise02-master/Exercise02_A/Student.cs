using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02_A
{
    public class Student
    {
        private string _studentName;

        public string StudentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        private LinkedList<Course> _courseList;

        public LinkedList<Course> CourseList
        {
            get { return _courseList; }
            set { _courseList = value; }
        }

        public Student(string studentName)
        {
            StudentName = studentName;
            _courseList = new LinkedList<Course>();;
        }

        public Student()
        {
            _courseList=new LinkedList<Course>();
        }
        
        public float GPA
        {
            get
            {
                float getGPA = 0;
                var temp = CourseList.Head;
                if (temp == null) return 0;
                while (temp.Data != null)
                {
                    getGPA += temp.Data.CourseGrade*temp.Data.Units;
                    temp = temp.Next;
                }

                return getGPA/totalUnits;
            }
            
        }

        private int totalUnits
        {
            get
            {
                int total = 0;
                var temp = CourseList.Head;
                while (temp.Data != null)
                {
                    total += temp.Data.Units;
                    temp = temp.Next;
                }

                return total;
            }
        }

    }

   
}
