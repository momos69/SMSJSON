using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using SMSJSON;

namespace SSMSJSON
{
    internal class GetStudentData
    {
        public static void GetDetailsStudent()
        {
            //accessing data from existing json file
            var json = File.ReadAllText(Program.studentJsonFile);
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray StudentArrary = (JArray)jObject["students"];
                    if (StudentArrary != null)
                    {
                        foreach (var item in StudentArrary)
                        {
                            Console.WriteLine("Name:" + item["Name"].ToString());
                            Console.WriteLine("Id :" + item["Id"].ToString());
                            Console.WriteLine("Class :" + item["Class"].ToString() );
                            Console.WriteLine("Percentage :" + item["Percentage"].ToString() );
                            Console.WriteLine("Grade :" + item["Grade"].ToString() + "\n");
                            
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
