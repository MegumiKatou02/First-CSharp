using System;
using System.Collections.Generic;
using System.Text;
using SinhVienNameSpace;

namespace MainNameSpace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<SinhVien> list = new List<SinhVien>();
            bool loop = true;
            while(loop)
            {
                Menu();
                Console.Write("Nhập lựa chọn: ");
                int choose;
                bool checkValid = int.TryParse(Console.ReadLine(), out int passChoose);
                if(!checkValid)
                {
                    Console.Clear();
                    Console.WriteLine("Nhap khong thanh cong");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    choose = passChoose;
                }
                if(choose == 1)
                {
                    SinhVien sinhVien = new SinhVien();
                    sinhVien.NhapThongTinSinhVien();
                    list.Add(sinhVien);
                    Console.Clear();
                }
                else if(choose == 2)
                {
                    Console.Clear();
                    foreach(SinhVien sinhVien in list)
                    {
                        Console.WriteLine("Tên sinh viên: " + sinhVien.Name);
                        Console.WriteLine("Tuổi: " + sinhVien.Age);
                        Console.WriteLine("Điểm trung bình: " + sinhVien.DiemTrungBinh);
                        Console.WriteLine();
                    }
                }
                else if(choose == 3)
                {
                    loop = false;
                }
                else{
                    Console.Clear();
                }
            }
        }
        public static void Menu()
        {
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Xem danh sách sinh viên");
            Console.WriteLine("3. Thoát chương trình");
        }
    }
}