using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int Id = IDGenerator.Instance.GenerateNewID();
            Console.WriteLine(Id);
            int Id2 = IDGenerator.Instance.GenerateNewID();
            Console.WriteLine(Id2);
        }
    }


    public class IDGenerator
    {
        private int ID;
        private IDGenerator()
        {
            ID = 1;
        }

        private static IDGenerator _instance;

        public static IDGenerator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IDGenerator();
                return _instance;
            }
        }
        public int GenerateNewID()
        {
            return ID++;
        }

    }


}
