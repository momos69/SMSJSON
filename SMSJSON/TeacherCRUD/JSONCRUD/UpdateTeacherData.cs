using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SMSJSON
{
    internal class UpdateTeacherData
    {
        public static void AddNewTeacherJsonData()
        {
            try
            {
                // Gather teacher details
                Console.WriteLine("Enter Teacher Details");

                Console.WriteLine("Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Id:");
                var id = Convert.ToInt32(Console.ReadLine());

                // Create a new teacher JSON object
                string newTeacherDetail = "{ \"Name\": \"" + name + "\", \"Id\": " + id + " }";
                Console.WriteLine(newTeacherDetail);

                // Read existing teacher data from file
                var jsonFilePath = "teachers.json"; // Assuming the file name is teachers.json
                var json = File.ReadAllText(jsonFilePath);
                var jsonObject = JObject.Parse(json);

                // Ensure that the teachers array exists
                JArray teacherArray = (JArray)jsonObject["teachers"] ?? new JArray();

                // Check if the teacher with the same ID already exists
                foreach (var teacher in teacherArray)
                {
                    if (teacher["Id"]?.ToString() == id.ToString())
                    {
                        Console.WriteLine($"Teacher with ID {id} already exists.");
                        return;
                    }
                }

                // Parse the new teacher data and add to the array
                var newTeacherData = JObject.Parse(newTeacherDetail);
                teacherArray.Add(newTeacherData);

                // Update the JSON object and write back to file
                jsonObject["teachers"] = teacherArray;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFilePath, newJsonResult);

                Console.WriteLine("New teacher data added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
