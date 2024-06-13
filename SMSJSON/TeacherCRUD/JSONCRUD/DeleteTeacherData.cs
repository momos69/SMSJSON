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
    internal class DeleteTeacherData
    {
        public static void DeleteTeacherJsonData()
        {
            var json = File.ReadAllText(Program.teacherJsonFile);

            var jObject = JObject.Parse(json);
            JArray TeacherArray = (JArray)jObject["teachers"];
            Console.Write("Enter teacher ID to Delete : ");
            var teacherId = Convert.ToInt32(Console.ReadLine());


            var firstNameteacher = string.Empty;
            var teacherToBeDeleted = TeacherArray.FirstOrDefault(obj => obj["Id"].Value<int>() == teacherId);

            TeacherArray.Remove(teacherToBeDeleted);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Program.teacherJsonFile, output);



        }
    }
}