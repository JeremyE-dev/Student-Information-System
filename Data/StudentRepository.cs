using StudentManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentManagementProject.Data
{
    //this class will do all the reading and writing to our student file

    public class StudentRepository
    {
        //will use different filed for "production vs testing) weill create a variable for the filepath
        private string _filePath;

        //with a constructo, we can force whoever instantiates this object to provide a filePath
        public StudentRepository(string filePath)
        {
            _filePath = filePath;
        }
        //list, add, edit, delete

            //because we are using subfolders - need using statement for where student 
            //can be found
        public List<Student>List()
        {
            //prevent error for not returning anything, so we can compile until we write real code
            //throw new NotImplementedException();
            List<Student> students = new List<Student>();
            
            //using statement will close and clean up file
            using(StreamReader sr = new StreamReader(_filePath))
            {   // this will just read the first line (which is the header) and no do anything so we can skip it

                sr.ReadLine();
                string line;

                //read next line of file, place it in the line variable, check if it is null, 
                //if not execute code block
                while((line= sr.ReadLine()) != null)
                {
                    //CONVERT INTO STUDENT OBJECT
                    Student newStudent = new Student();

                    string[] columns = line.Split(',');
                    //each column is in one position of the array


                    newStudent.FirstName = columns[0];
                    newStudent.LastName = columns[1];
                    newStudent.Major = columns[2];
                    newStudent.GPA = decimal.Parse(columns[3]);

                    students.Add(newStudent);

                  
                }

            }


                return students;

        }

        //this method will "Append" student to end of file
        public void Add(Student student)
        {
            using(StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCsvForStudent(student);

                sw.WriteLine(line);

            }
        }


        public void Edit(Student student, int index)
        {
            //call list method to get all students
            var students = List();
            
            students[index] = student;

            CreateStudentFile(students);

        }

        public void Delete(int index)
        {
            var students = List();

            students.RemoveAt(index);

            CreateStudentFile(students);
        }

        private string CreateCsvForStudent(Student student)
        {
            return string.Format("{0},{1},{2},{3}", student.FirstName,
                    student.LastName, student.Major, student.GPA.ToString());
        }



        //take list of students
        // delete existing file
        //open new streamwriter
        //write header
        //write csv line for each student



        private void CreateStudentFile(List<Student> students)
        {
            if(File.Exists(_filePath))
               File.Delete(_filePath);

                using (StreamWriter sr = new StreamWriter(_filePath))
                {

                    sr.WriteLine("FirstName,LastName,Major,GPA");
                    foreach(var student in students)
                    {
                    sr.WriteLine(CreateCsvForStudent(student));
                    }

                }

        }

    }
}
