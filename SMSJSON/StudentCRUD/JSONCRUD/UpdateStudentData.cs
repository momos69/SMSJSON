using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using SMSJSON.JSON;

namespace SMSJSON
{
    internal class UpdateStudentData
    {
        public static void AddNewSchoolJsondata()
        {
            try
            {
                
                Console.WriteLine("Enter Student Details");

                Console.WriteLine("Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Id:");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Class (Class1...Class12):");
                if (!Enum.TryParse(Console.ReadLine(), out Enums.Class cclass))
                {
                    Console.WriteLine("Invalid class entered. Please try again.");
                    return;
                }

                Console.WriteLine("Enter Percentage:");
                var percentage = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Grade (A,B,C,D,F):");
                if (!Enum.TryParse(Console.ReadLine(), out Enums.Grade grade))
                {
                    Console.WriteLine("Invalid grade entered. Please try again.");
                    return;
                }

                string newStudentDetail = "{ \"Name\": \"" + name + "\", \"Id\": " + id + ", \"Class\": \"" + cclass.ToString() + "\", \"Percentage\": " + percentage + ", \"Grade\": \"" + grade.ToString() + "\" }";
                Console.WriteLine(newStudentDetail);

             
                var jsonFilePath = Program.studentJsonFile;
                var json = File.ReadAllText(jsonFilePath);
                var jsonObject = JObject.Parse(json);

           
                JArray studentArray = (JArray)jsonObject["students"] ?? new JArray();

              
                var newStudentData = JObject.Parse(newStudentDetail);
                studentArray.Add(newStudentData);

                jsonObject["students"] = studentArray;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFilePath, newJsonResult);

                Console.WriteLine("New student data added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
