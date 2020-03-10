using System;
using System.Collections.Generic;
using System.IO;
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
            FileStream writer = new FileStream(file, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia));
            Uczelnia uczelnia=new Uczelnia{studenci = students,author = "Maciej Petrykowski",createdAt = System.DateTime.Now.ToString()};
            
            serializer.Serialize(writer, uczelnia);
        }
    }
}