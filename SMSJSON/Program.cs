// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.ComponentModel.Design;
using System.Linq;
using Spectre.Console;
using SSMSJSON;

namespace SMSJSON
{
    internal class Program
    {
        public static string studentJsonFile= @"C:\SRDEV\SMSJSON\JSON\Student.json";
        public static string teacherJsonFile = @"C:\SRDEV\SMSJSON\JSON\Teacher.json";
        static void Main(string[] args)
        {
            bool flag = true;

            int i = 1;int j = 1;
            while (flag)
            {
                AnsiConsole.MarkupLine("Choose from the following [red]options[/]");
                //Console.WriteLine("choose between teacher/student");
                //AnsiConsole.MarkupLine("[yellow]1-> Student[/]");
                //Console.WriteLine("1-> student");
                //AnsiConsole.MarkupLine("[purple]2-> Teacher[/]");
                //Console.WriteLine("2-> teacher");
                //AnsiConsole.MarkupLine("[green]3-> Display all Students data[/]");
                //Console.WriteLine("3-> Display all Students data");
                //AnsiConsole.MarkupLine("[blue]4-> Display all Teachers Data[/]");
                //Console.WriteLine("4-> Display all Teachers Data");
                //AnsiConsole.MarkupLine("[red]5-> Exit[/]");
                //Console.WriteLine("5-> Exit");
                //string choose = Console.ReadLine();


                string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(new[] { "Add Student Data", "Add Teacher Data", "Delete Student Data", "Delete Teacher Data", "Display all Students data", "Display all Teachers data", "Exit" })
                .Title("Choose Options")
                );

                switch (choice)
                {
                    case "Add Student Data":
                        UpdateStudentData.AddNewSchoolJsondata();

                        i++;
                        break;
                    case "Add Teacher Data":
                        UpdateTeacherData.AddNewTeacherJsonData();

                        j++;
                        break;

                    case "Delete Student Data":
                        DeleteStudentData.DeleteStudentJsonData();
                        break;

                    case "Delete Teacher Data":
                        DeleteTeacherData.DeleteTeacherJsonData();                       
                        break;

                    case "Display all Students data":
                        GetStudentData.GetDetailsStudent();
                  
                        break;
                    case "Display all Teachers data":
                        GetTeacherData.GetDetailsTeacher();
                        break;
                    case "Exit":
                        Console.WriteLine("Exit Successfull !!!");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }

            }

        }

    }
}
