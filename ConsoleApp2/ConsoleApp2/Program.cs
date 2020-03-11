using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            var inFile = args.Length > 0 ? args[0] : "data.csv";
            var outFile = args.Length > 1 ? args[1] : "result.xml";
            var type = args.Length > 2 ? args[2] : "xml";
            //
            List<Student> students= Read.readStudents(inFile);
            //
            
            if (type == "xml") 
                Write.writeToXML(outFile,students);
            else if (type == "json")
                Write.writeToJson(outFile, students);
        }        
    }
}