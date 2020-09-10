using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementProject.Data;
using StudentManagementProject.Models;
using StudentManagementProject.Helpers;

namespace StudentManagementProject.Workflows
{
    class ListStudentWorkflow
    {
        public void Execute()
        {
            //needed to have using statement because student repository is in diff folder
            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> students = repo.List();

            Console.Clear();
            Console.WriteLine("StudentList");
            ConsoleIO.PrintStudentListHeader();


            foreach(var student in students)
            {
                Console.WriteLine(ConsoleIO.StudentLineFormat, student.LastName + ", " + student.FirstName, student.Major, student.GPA);
            }

            Console.WriteLine();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();





        }
    }
}
