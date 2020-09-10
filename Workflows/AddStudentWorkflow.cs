using StudentManagementProject.Helpers;
using StudentManagementProject.Models;
using StudentManagementProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementProject.Workflows
{
    class AddStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add Student");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();

            Student newStudent = new Student();

            newStudent.FirstName = ConsoleIO.GetRequiredStringFromUser("FirstName: ");
            newStudent.LastName = ConsoleIO.GetRequiredStringFromUser("LastName: ");
            newStudent.Major  = ConsoleIO.GetRequiredStringFromUser("Major: ");
            newStudent.GPA = ConsoleIO.GetRequiredDecimalFromUser("GPA: ");

            Console.WriteLine();
            ConsoleIO.PrintStudentListHeader();
            Console.WriteLine(ConsoleIO.StudentLineFormat, newStudent.LastName + ", " + 
                newStudent.FirstName, newStudent.Major, newStudent.GPA);

            Console.WriteLine();
            if(ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            {
                StudentRepository repo = new StudentRepository(Settings.FilePath);
                repo.Add(newStudent);
                Console.WriteLine("Student Added!");
                Console.WriteLine("Press and key to continue...");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Add Cancelled");
                Console.WriteLine("Press and key to continue...");
                Console.ReadKey();

            }



        }
    }
}
