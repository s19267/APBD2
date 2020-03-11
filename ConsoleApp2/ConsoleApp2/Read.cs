using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace ConsoleApp2
{
    public class Read
    {
        static List<Student> studentsList = new List<Student>();
        public static List<Student> readStudents(String file)
        {
            
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

                        bool ok= check(student, line);

                        if (ok)
                        {

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
                            
                        }
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

        public static bool check(String[] student,String line)
        {
            bool ok=true;
            if (student.Length < 9)
            {
                Write.writelog(line + ":   za mało parametrów");
                ok = false;
            }
            else
            {
                var regex1=new Regex(@",[ ]*,");
                for (int i = 0; i < student.Length; i++)
                {
                    if (student[i].Equals("")|| regex1.IsMatch(student[i]))
                    {
                        Write.writelog(line+":   jeden z parametrów jest pusty");
                        ok = false;
                    }
                }
                
                
                var regex = new Regex(@"[A-Z,a-z]*");
                student[1] = regex.Match(student[1]).Value;
                
                foreach (var stud in studentsList)
                {
                    if (stud.fname.Equals(student[0]) && stud.lname.Equals(student[1]) &&
                        stud.index.Equals("s" + student[4]))
                    {
                        Write.writelog(line + ":   student juz istnieje");
                        ok = false;
                    }
                }
                
            }
            
            
            return ok;
        } 
        
    }
}