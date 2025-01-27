using MMCourseStore.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.Students.Domain;
public class Student:AggregateRoot<long>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Student(long id,string firstName,string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    private Student()
    {
        
    }
}
