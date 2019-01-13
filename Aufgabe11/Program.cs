using System;
using System.Collections.Generic;
using System.Globalization;

namespace Aufgabe11
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
            var grandgrand1 = tree.CreateNode("grandgrand1");
            grand11.AppendChild(grandgrand1);
            root.PrintTree();
            root.ForEach(Func);
        }
        public static void Func(String node)
        {
            Console.Write(node + " | ");
        }
    }

    public class Tree<T>
    {     
    
        public T Data;
        public T parent;
        public List<Tree<T>> children = new List<Tree<T>>();
        public Tree<T> CreateNode(T _Data)
        {
            Tree<T> node = new Tree<T>
            {
                Data = _Data
            };
            return node;
        }
        public void AppendChild(Tree<T> child)
        {
            child.parent = this.Data;
            children.Add(child);
        }
        public void RemoveChild(Tree<T> child)
        {
            children.Remove(child);
        }
        public void PrintTree(String hierarchy = "")
        {
            Console.WriteLine(hierarchy + Data);
            foreach (Tree<T> child in children)
            {
                child.PrintTree(hierarchy + "*");
            }
        }
        public void ForEach(Action<string> function)
        {
            for (int i = 0; i < children.Count; i++)
            {
                function(children[i].ToString());
                children[i].ForEach(Program.Func);
            }
        }

        public override string ToString()
        {
            return this.Data.ToString();
        }
    }
}