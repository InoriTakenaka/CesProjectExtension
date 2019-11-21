using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Infrastructure;
namespace ConsoleDllTest
{
    class Program
    {
        class A {
            public string a { get; set; }
            public string b { get; set; }
            public DateTime? time { get; set; }
            public decimal? n { get; set; }
            public int i { get; set; }
        } 


        static void Main(string[] args)
        {
            var instance = Activator.CreateInstance<A>();
        }
    }
}
