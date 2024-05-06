using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiThuVienNS;

namespace ProgramNS
{
    public class Program{
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLiThuVien quanLiThuVien = new QuanLiThuVien();

            bool loop = true;
            while(loop)
            {
                // /Console.Clear();
                Menu();
                int choose;
                if(int.TryParse(Console.ReadLine(), out choose))
                {
                    if(choose == 1)
                    {
                        Console.Clear();
                        if(quanLiThuVien.DangNhap())
                        {

                        }
                    }
                    else if(choose == 2)
                    {
                        Console.Clear();
                        quanLiThuVien.DangKy();
                    }
                    else if(choose == 3)
                    {
                        Console.Clear();
                        loop = false;
                        Console.WriteLine("Thoát chương trình thành công");
                    }
                }
            }
        }
        public static void Menu()
        {
            Console.WriteLine("\tChương trình quản lí thư viện\t\t\n");
            Console.WriteLine("1. Đăng nhập");
            Console.WriteLine("2. Đăng ký");
            Console.WriteLine("3. Thoát chương trình");
        }
    }
}