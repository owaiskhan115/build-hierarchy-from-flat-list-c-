using System;
using System.Collections.Generic;
using System.Linq;

namespace ListProject
{
    class Category
    {

        public string Name { get; set; }
        public List<Category> Subs { get; set; }

    }


    class Program
    {

       List<string>  lines = System.IO.File.ReadAllLines(@"D:\categories.txt").ToList();



        static void Main(string[] args)
        {
            //want to lines list object into category object. 
            
        }
    }
}
