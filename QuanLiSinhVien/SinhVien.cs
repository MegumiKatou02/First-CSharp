using System;

namespace SinhVienNameSpace
{
    class SinhVien
    {
        public SinhVien()
        {
            name = "";
            mssv++;
        }
        private static int mssv = 0;
        public int Mssv
        {
            get => mssv;
        }
        private string? name;
        public string? Name
        {
            get => name;
            set
            {
                name = value;
            }
        }
        private int age;
        public int Age
        {
            get => age;
            set
            {
                age = value;
            }
        }
        private float diemTrungBinh;
        public float DiemTrungBinh
        {
            get => diemTrungBinh;
            set
            {
                diemTrungBinh = value;
            }
        }
        public void NhapThongTinSinhVien()
        {   
            Console.WriteLine("Nhập tên:");
            name = Console.ReadLine();
            Console.WriteLine("Nhập tuổi:");
            if(int.TryParse(Console.ReadLine(), out int passAge))
            {
                age = passAge;
            }
            Console.WriteLine("Nhập điểm trung bình:");
            if(float.TryParse(Console.ReadLine(), out float passDiemTrungBinh))
            {
                diemTrungBinh = passDiemTrungBinh;
            }
        }
    }
}