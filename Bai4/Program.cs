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
        }

        public static void Main(string[] args)
        {
           SinhVien chinh1 = new SinhVien();
           SinhVien chinh2 = new SinhVien();
           SinhVien chinh3 = new SinhVien();
           SinhVien chinh4 = new SinhVien();
           int count = SinhVien.Count();
           Console.WriteLine($"count: {count}");
        }
    }
}