using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using SMSJSON;

namespace SMSJSON
{
    internal class DeleteStudentData
    {
        public static void DeleteStudentJsonData()
        {
            var json = File.ReadAllText(Program.studentJsonFile);

            var jObject = JObject.Parse(json);
            JArray StudentArray = (JArray)jObject["students"];
            Console.Write("Enter student ID to Delete : ");
            var studentId = Convert.ToInt32(Console.ReadLine());


            var firstNamestudent = string.Empty;
            var studentToBeDeleted = StudentArray.FirstOrDefault(obj => obj["Id"].Value<int>() == studentId);

            StudentArray.Remove(studentToBeDeleted);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Program.studentJsonFile, output);



        }
    }
}