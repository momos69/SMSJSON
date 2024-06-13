using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using SMSJSON;

namespace SMSJSON
{
    internal class GetTeacherData
    {
        public static void GetDetailsTeacher()
        {

            var json = File.ReadAllText(Program.teacherJsonFile);
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray TeacherArrary = (JArray)jObject["teachers"];
                    if (TeacherArrary != null)
                    {
                        foreach (var item in TeacherArrary)
                        {
                            Console.WriteLine("Name:" + item["Name"].ToString() );
                            Console.WriteLine("ID :" + item["Id"].ToString() + "\n");

                        }

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}