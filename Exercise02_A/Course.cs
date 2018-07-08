namespace Exercise02_A
{
    public class Course
    {
        private int _units;

        public int Units
        {
            get { return _units; }
            set { _units = value; }
        }

        private int _courseGrade;

        public int CourseGrade
        {
            get { return _courseGrade; }
            set { _courseGrade = value; }
        }

        private string _courseName;

        public string CourseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        public Course(string courseName, int units, int courseGrade)
        {
            _units = units;
            _courseGrade = courseGrade;
            _courseName = courseName;
        }
    }
}