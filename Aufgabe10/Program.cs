using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Aufgabe10
{

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child2");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);

            root.PrintTree();
        }
    }

    public class Tree<T>
    {
        public T Person;
        public List<Tree<T>> family = new List<Tree<T>>();

        public Tree<T> CreateNode(T _Person)
        {
            Tree<T> node = new Tree<T>
            {
               Person = _Person
            };
            return node;
        }

        public void AppendChild(Tree<T> child)
        {
            family.Add(child);
        }
        public void RemoveChild(Tree<T> child)
        {
            family.Remove(child);
        }

        public void PrintTree(String hierarchy = "")
        {
            Console.WriteLine(hierarchy + Person);
            foreach (Tree<T> child in family)
            {
                child.PrintTree(hierarchy + "*");
            }
        }
    }

}