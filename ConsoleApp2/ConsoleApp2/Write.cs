using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    public class Write
    {

        public static void writelog(String log)
        {
            using (StreamWriter writer = new StreamWriter("log.txt",true))
            {
                writer.WriteLine(log);
            }
        }
        public static void writeToXML(String file,List<Student> students)
        {
            FileStream writer = new FileStream(file, FileMode.Append);
            XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia));
            Uczelnia uczelnia=new Uczelnia{studenci = students,author = "Maciej Petrykowski",createdAt = System.DateTime.Now.ToString()};
            
            serializer.Serialize(writer, uczelnia);
        }

        public static void writeToJson(string file, List<Student> students)
        {
            Uczelnia uczelnia=new Uczelnia{author = "Maciej Petrykowski",createdAt = System.DateTime.Now.ToString(),studenci = students};
            var jsonString ="{\"uczelnia\":"+ JsonSerializer.Serialize(uczelnia)+"}";
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.Write(jsonString);
            }
            
        }
    }
}