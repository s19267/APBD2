using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ConsoleApp2;

namespace ConsoleApp2
{
    [Serializable]
    public class Student
    {
        public override string ToString()
        {
            return fname + " " + lname + " " + birthdate + " " + studies.name + " " + studies.mode + " " + index + " " +
                   email + " " + mothersName + " " + fathersName;
        }

        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public Studies studies { get; set; }
        [XmlAttribute] public string index { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
    }

    public class Studies
    {
        public string name { get; set; }
        public string mode { get; set; }
    }
}

[Serializable]
public class Uczelnia
{ 
   
    [XmlAttribute] public String createdAt { get; set; }
    [XmlAttribute] public String author { get; set; }
    
    public List<Student> studenci { get; set; }
}