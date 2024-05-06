using System;
using Userns;

namespace QuanLiThuVienNS
{
    public class QuanLiThuVien
    {
        public QuanLiThuVien()
        {
            users = new List<User>();
        }
        private List<User> users;
        public void DangNhap()
        {
            do
            {   string? name, password;
                bool completetUser = false;
                if(!completetUser)
                {
                    Console.WriteLine("Nhập nickname người dùng (1 để thoát):");
                    name = Console.ReadLine();
                    if(name == null)
                    {
                        Console.WriteLine("Nhập tên người dùng không hợp lệ");
                        continue;
                    }
                    else
                    {
                        if(int.TryParse(name, out int id))
                        {
                            if(id == 1)
                            {
                                break;   // Thoát
                            }
                        }
                        completetUser = true;   
                    }
                }
                if(completetUser)
                {
                    Console.WriteLine("Nhập mật khẩu (1 để thoát)");
                    password = Console.ReadLine();
                    if(password == null)
                    {
                        Console.WriteLine("Mật khẩu không được bỏ trống");
                        continue;
                    }
                    else
                    {
                        if(int.TryParse(password, out int id))
                        {
                            if(id == 1)
                            {
                                break;   // Thoát
                            }
                        }
                        // after complete user and password
                        foreach(User us in users)
                        {
                            
                        }
                    }
                }
            }
            while(true);
        }
    }
}