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
                            
                            if(us.Password == password && us.UserName == name)
                            {
                                Console.WriteLine("Đăng nhập thành công");
                                break;
                            }
                        }
                        Console.WriteLine("Đăng nhập không thành công");
                        break;                        
                    }
                }
            }
            while(true);
        }
        public void DangKy()
        {
            User user = new User();
            Console.WriteLine("Nhập tên người dùng: ");
            user.Name = Console.ReadLine();
            if(user.Name == null)
            {
                user.Name = "Chưa cập nhật";
            }
            string? userName;
            do
            {
                Console.WriteLine("Nhập nickname người dùng:");
                userName = Console.ReadLine();
                if(userName == null)
                {
                    Console.WriteLine("Nhập không hợp lệ");
                    userName = "";
                    continue;
                }
            }
            while(userName.Length < 3 || userName.Length >= 20);
            user.UserName = userName;
            string? password;
            do
            {
                Console.WriteLine("Nhập mật khẩu");
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
                }
            }
            while(password.Length < 3 || password.Length >= 20);
            user.Password = password;
            users.Add(user);
        }
    }
}