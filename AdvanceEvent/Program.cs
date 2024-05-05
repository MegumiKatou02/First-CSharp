using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace TestEvent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SinhVien sinhVien = new SinhVien();
            sinhVien.NameChanged += SinhVien_NameChanged;

            sinhVien.Name = "Thay đổi lần 1";
            sinhVien.Name = "Thay đổi lần 2";
            sinhVien.Name = "Thay đổi lần 3";
            sinhVien.Name = "Thay đổi lần 4";
        }
        private static void SinhVien_NameChanged(object sender, NameChangedEventArgs e)
        {
            Console.WriteLine($"Tên đã thay đổi thành: {e.name}");
        }
    }

    public class SinhVien{
        public SinhVien()
        {
            name = "";
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnNameChanged(value);
            }
        }
        private event EventHandler<NameChangedEventArgs>? nameChanged;
        public event EventHandler<NameChangedEventArgs>? NameChanged
        {
            add
            {
                nameChanged += value;
            }
            remove
            {
                nameChanged -= value;
            }
        }
        public void OnNameChanged(string name)
        {
            if(nameChanged != null)
            {
                nameChanged(this, new NameChangedEventArgs(name));
            }
        }
    }
    
    public class NameChangedEventArgs : EventArgs
    {
        public string name {get; set;}
        public NameChangedEventArgs(string name)
        {
            this.name = name;
        }
    }
}