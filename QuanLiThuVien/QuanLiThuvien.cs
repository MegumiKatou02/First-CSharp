using System;
using Userns;

namespace QuanLiThuVienNS
{
    public class QuanLiThuVien
    {
        public QuanLiThuVien()
        {
            admin = false;
            users = new List<User>();
        }
        private bool admin;
        public bool Admin 
        {
            get => admin;
            set => admin = value;
        }
        private List<User> users;
        public bool DangNhap()
        {
            do
            {   string? name = "", password;
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
                                return false;   // Thoát
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
                                return false;   // Thoát
                            }
                        }
                        // after complete user and password
                        foreach(User us in users)
                        {
                            
                            if(us.Password == password && us.UserName == name)
                            {
                                
                                return true;
                            }
                        }
                        if(name == "admin" && password == "admin")
                        {
                            admin = true;
                            return true;
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Không tìm thấy tài khoản !");
                        Console.ResetColor();
                        return false;                     
                    }
                }
            }
            while(true);
        }
        public void DangKy()
        {
            User user = new User();
            Console.WriteLine("Nhập tên người dùng: (1. Thoát)");
            user.Name = Console.ReadLine();
            if(user.Name == null)
            {
                user.Name = "Chưa cập nhật";
            }
            else if(user.Name == "1")
            {
                return;
            }
            string? userName;
            do
            {
                Console.WriteLine("Nhập nickname người dùng: (1. Thoát)");
                userName = Console.ReadLine();
                if(userName == null)
                {
                    Console.WriteLine("Nhập không hợp lệ");
                    userName = "";  
                    continue;
                }
                else if(userName == "1")
                {
                    return;
                }
            }
            while(userName.Length < 3 || userName.Length >= 20);
            user.UserName = userName;
            string? password;
            do
            {
                Console.WriteLine("Nhập mật khẩu: (1. Thoát)");
                password = Console.ReadLine();
                if(password == null)
                {
                    Console.WriteLine("Nhập không hợp lệ");
                    password = "";
                    continue;
                }
                else
                {
                    if(password.Contains(' '))
                    {
                        Console.WriteLine("Mật khẩu không được chứa khoảng trắng!");
                        continue;
                    }
                    else if(password == "1")
                    {
                        return;
                    }
                }
            }
            while(password.Length < 3 || password.Length >= 20);
            user.Password = password;
            users.Add(user);
        }
        public void QuanLiTaiKhoan()
        {

        }
    }
}