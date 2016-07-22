﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TypeScriptBuilder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var
                builder = new TypeScriptBuilder();
            
            builder.AddCSType(typeof(Employee));

            File.WriteAllText("Test.txt", builder.ToString());
        }
    }


    public enum EmployeeType
    {
        Normal = 1,
        Temporary = 2
    }

    public class Pair<T1, T2>
    {
        public T1 t1;
        public T2 t2;

        public int TestProperty { get; set; }
    }

    public class Entity<T>
    {
        public T Id;

        public Pair<int, Entity<int>> Map1;
        public Pair<string, Entity<string>> Map2;

        [TSAny]
        public DateTimeOffset TestAny;
    }

    public class Employee : Entity<int>
    {
        public string Login;
        public EmployeeType? EmployeeType;

        public string[] ArrayTest;
        public List<DateTime> ListTest;

        public Dictionary<int, string> LastIPs;

        public ICollection<Entity<DateTime>> CollectionTest;

        // exclude
        public Skip Skip;
        [TSExclude]
        public int Skip2;
    }

    [TSExclude]
    public class Skip
    {
    }
}
