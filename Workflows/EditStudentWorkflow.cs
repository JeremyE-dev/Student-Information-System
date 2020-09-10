using StudentManagementProject.Data;
using StudentManagementProject.Helpers;
using StudentManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementProject.Workflows
{
    public class EditStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Edit Student GPA");


            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> student = repo.List();

            ConsoleIO.PrintPickListOfStudents(student);
            Console.WriteLine();

            int index = ConsoleIO.GetStudentIndexFromUser("which student would you like to edit?", student.Count());
            index--;

            Console.WriteLine();
            Console.Write("Enter new GPA for {0} {1}; ", student[index].FirstName, student[index].LastName);

            student[index].GPA = ConsoleIO.GetRequiredDecimalFromUser(string.Format("Enter new GPA for {0} {1}; ",
                student[index].FirstName, student[index].LastName));

            repo.Edit(student[index], index);
            Console.WriteLine("GPA updated!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
