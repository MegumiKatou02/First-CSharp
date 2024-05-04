using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinh 
{
    public class Program
    {
        public struct SinhVien 
        {
            public int id
            {
                get { return id; }
                set { id = value; }
            }
            public string? name
            {
                get { return name; }
                set { name = value; }
            }
            public int age
            {
                get { return age; }
                set { age = value; }
            }
        }
    
        public static void NhapSinhVien(out SinhVien sinhVien)
        {   
            Console.WriteLine("Nhập ID của sinh viên:");
            sinhVien.id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nhập tên của sinh viên:");
            sinhVien.name = Console.ReadLine();

            Console.WriteLine("Nhập tuổi của sinh viên:");
            sinhVien.age = Convert.ToInt32(Console.ReadLine());
        }

        public static void Main(string[] args)
        {
            SinhVien sv = new SinhVien();

            NhapSinhVien(out sv);

            Console.WriteLine("Thông tin sinh viên vừa nhập:");
            Console.WriteLine($"ID: {sv.id}");
            Console.WriteLine($"Tên: {sv.name}");
            Console.WriteLine($"Tuổi: {sv.age}");

            Console.ReadKey(); 
        }
    }
}