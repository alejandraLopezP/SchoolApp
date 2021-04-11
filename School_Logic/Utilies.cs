using System;
using System.Collections.Generic;
using System.Linq;
using School_Logic.Infrastructure;
using System.IO;

namespace School_Logic
{
    //in case that I want to change the default comparision criteria
    public class NameComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, true);
        }
    }
    public class Utilies
    {
        public static IEnumerable<T> OrderEntityByName<T>(IEnumerable<T> entities) where T : INameable
        {
            var result = entities.OrderBy(e => e.Name, new NameComparer());
            return result;
        }

        public static IEnumerable<T> OrderEntityByLastName<T>(IEnumerable<T> entities) where T : ILastNameable
        {
            var result = entities.OrderBy(e => e.LastName);
            return result;
        }

        public static IEnumerable<Course> OrderCourseByCode(IEnumerable<Course> courses)
        {
            var result = courses.OrderBy(c => c.Code);
            return result;
        }

        public static IEnumerable<Teacher> OrderTeachingAreas(IEnumerable<Teacher> teachers)
        {
            //var result = teachers.OrderBy(t => t.Course);
            //return result;
            throw new NotImplementedException();
        }
    }
}
