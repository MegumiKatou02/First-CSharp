using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinh 
{
    public class Program
    {
        public class SinhVien 
        {
            private int id;
            private string? name;
            private int age;
            private static int count = 0;
            public static int Count() 
            {
                return count;
            }
            public SinhVien()
            {
                count++;
            }
            public int Id 
            {
                get { return id; }
                set { id = value; }
            }
            public string? Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Age
            {
                get { return age; }
                set { age = value; }
            }
            public virtual void health()
            {
                name = "con chau chau";
            }
        }

        public class Hello : SinhVien
        {
            public override void health()
            {
                Name = "con kiki";
                // base.health();
            }
        }

        interface Animal
        {
            void Show();
        }

        class Cat : Animal
        {
            public void Show()
            {
                Console.WriteLine("lo con chim");
            }
        }

        public static void Main(string[] args)
        {
           Animal chinh = new Cat();
           chinh.Show();
        }
    }
}