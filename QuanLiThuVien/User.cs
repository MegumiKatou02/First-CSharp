using System;
using Datens;

namespace Userns
{
    public class User
    {
        public User()
        {
            age = 6;
            userName = "user";
            Random rand = new Random();
            for(int i = 0; i < 8; i++)
            {
                int key = rand.Next(1, 99);
                userName = userName + "" + key;
            }
            count++;

        }
        ~User()
        {
            count--;
        }
        private static int count = 0;
        public static int UserSize()
        {
            return count;
        }
        private string? name;
        public string? Name
        {
            get => name;
            set => name = value;
        }
        private string userName;
        public string UserName
        {
            set => userName = value;
            get => userName;
        }
        private string? password;
        public string? Password
        {
            get => password;
            set => password = value;
        }
        private int age;
        private Date? ngayMuonSach;
        private Date? ngayTraSach;
        
    }
}