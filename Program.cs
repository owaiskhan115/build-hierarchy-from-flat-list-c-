using System;
using System.Collections.Generic;
using System.Linq;

namespace Hierarchy
{
    class Category
    {

        public string Name { get; set; }
        public List<Category> Subs { get; set; }

    }


    class Program
    {

       public static List<string>  lines = System.IO.File.ReadAllLines(@"D:\categories.txt").ToList();

        static void Main(string[] args)
        {
            Stack<string> myStack = new Stack<string>();
            string _parent = "";

            for (int i = 0; i < lines.Count; i++)
            {
                int nextLineIndex = (i + 1) == lines.Count ? i : i + 1;

                string nextLine = lines[nextLineIndex].Replace("\t","    ");
                string currentLine = lines[i].Replace("\t", "    ");

                myStack.Push(currentLine);

                if (myStack.Count > 0)
                {

                    int currentlevel = currentLine.Length - currentLine.TrimStart(new char[] { ' ' }).Length;
                    int nextLevel = nextLine.Length - nextLine.TrimStart(new char[] { ' ' }).Length;

                    if (nextLevel > currentlevel)
                    {
                        var temp = currentLine;
                        if (string.IsNullOrEmpty(_parent) || currentlevel == 0)
                            _parent = temp;
                        else
                        {
                            temp = myStack.Pop();
                            _parent = _parent + "_" + temp.Remove(0, currentlevel);
                            myStack.Push(_parent);

                        }

                    }
                    else if (nextLevel <= currentlevel)
                    {
                        currentLine = myStack.Pop();
                        myStack.Push(_parent + "_" + currentLine.Remove(0, currentlevel));
                    }
                        
                }
            }


            foreach (var a in myStack)
            {
                Console.WriteLine(a);
            }

            Console.ReadLine();

        }
    }
}
