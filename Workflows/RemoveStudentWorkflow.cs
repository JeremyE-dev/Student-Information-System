using System;
using StudentManagementProject.Helpers;
using StudentManagementProject.Data;
using StudentManagementProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementProject.Workflows
{
    public class RemoveStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Remove Student");
           

            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> student = repo.List();

            ConsoleIO.PrintPickListOfStudents(student);
            Console.WriteLine();

            int index = ConsoleIO.GetStudentIndexFromUser("which student would you like to delete?", student.Count());
            index--;

          

            string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to " +
                $"remove {student[index].FirstName} {student[index].LastName}");

            if(answer == "Y")
            {
                repo.Delete(index);
                Console.WriteLine("Student Removed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Remove Cancelled");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();


            }
        }
    }
}
