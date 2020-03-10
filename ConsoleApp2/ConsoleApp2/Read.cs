using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace ConsoleApp2
{
    public class Read
    {
        public static List<Student> readStudents(String file)
        {
            List<Student> studentsList = new List<Student>();
            try
            {
                if (!File.Exists(file))
                    throw
                        new ArgumentException("Plik nie istnieje"); //jak warunek dla "Podana ścieżka jest niepoprawna"


                using (var stream = new StreamReader(file))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {

                        string[] student = line.Split(',');
                        
                        if (student.Length < 9)//TODO
                            Write.writelog(line + ":   za mało parametrów");
                        
                        var regex = new Regex(@"[A-Z,a-z]*");
                        student[1] = regex.Match(student[1]).Value;


                        var st = new Student
                        {
                            fname = student[0],
                            lname = student[1],
                            index = "s" + student[4],
                            birthdate = student[5].Substring(8, 2) + "." + student[5].Substring(5, 2) + "." +
                                        student[5].Substring(0, 4),
                            email = student[6],
                            fathersName = student[8],
                            mothersName = student[7],
                            studies = new Studies {name = student[2], mode = student[3]}
                        };
                        studentsList.Add(st);
                        // System.Console.WriteLine(st);
                    }
                }

                return studentsList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}