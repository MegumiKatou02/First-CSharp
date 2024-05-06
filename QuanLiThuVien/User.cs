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

        }
        private string? name;
        private string userName;
        private int age;
        private Date? ngayMuonSach;
        private Date? ngayTraSach;
        
    }
}