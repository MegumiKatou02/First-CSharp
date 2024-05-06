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

        private User? currentUser;
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
                                admin = false;
                                currentUser = us;
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
                        admin = false;
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
                    Console.WriteLine("Nhập không hợp lệ !");
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
            bool loop = true;
            while(loop)
            {
                ChooseMenu();
                int choose;
                if(int.TryParse(Console.ReadLine(), out choose))
                {
                    if(choose == 1)
                    {
                        // đoạn này lười code quá :P
                        Console.WriteLine("Số lượng sách trong thư viện: 0");
                        Console.WriteLine("Nhấn nút bất kỳ để thoát");
                        Console.ReadKey();
                    }
                    else if(choose == 2)
                    {
                        Console.Write("Bạn đang đăng nhập với tư cách: ");
                        Console.WriteLine((admin) ? "Admin" : "Thành viên");
                        Console.WriteLine();
                        if(admin)
                        {
                            Console.WriteLine("Số thành viên đăng ký tài khoản trong thư viện: " + users.Count);
                            Console.WriteLine();
                            foreach(User us in users)
                            {
                                Console.WriteLine($"Tên người dùng: {us.Name}");
                                Console.WriteLine($"Tên tài khoản: {us.UserName}");
                                Console.WriteLine($"Mật khẩu: {us.Password}");
                                Console.WriteLine($"Tuổi: {us.Age}");
                                Console.WriteLine($"Ngày mượn sách: none");
                                Console.WriteLine($"Ngày trả sách: none");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            if(currentUser != null)
                            {
                                Console.WriteLine($"Tên người dùng: {currentUser.Name}");
                                Console.WriteLine($"Tên tài khoản: {currentUser.UserName}");
                                Console.WriteLine($"Mật khẩu: {currentUser.Password}");
                                Console.WriteLine($"Tuổi: {currentUser.Age}");
                                Console.WriteLine($"Ngày mượn sách: none");
                                Console.WriteLine($"Ngày trả sách: none");
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Nhấn phím bất kỳ để thoát");
                        Console.ReadKey();
                    }
                    else if(choose == 3)
                    {
                        loop = false;
                    }
                }
            }
        }
        public void ChooseMenu()
        {
            Console.Clear();
            Console.WriteLine("\tChương trình quản lí thư viện\t\n");
            if(admin)
            {
                Console.WriteLine("1. Xem danh sách sách trong thư viện");
                Console.WriteLine("2. Xem danh sách tài khoản");
                Console.WriteLine("3. Thoát");
            }
            else
            {
                Console.WriteLine("1. Xem danh sách sách trong thư viện");
                Console.WriteLine("2. Xem tài khoản");
                Console.WriteLine("3. Thoát");
            }
        }
    }
}