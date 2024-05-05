using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chinh
{
    public class Program{

        delegate void UpdateName(string name);
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            SinhVien sinhVien = new SinhVien();
            sinhVien.NameChanged += Hs_NameChange;

            sinhVien.Name = "Le Dinh Chinh";
            Console.WriteLine("Tên từ class: " + sinhVien.Name);
            sinhVien.Name = "what the f*ck";
            Console.WriteLine("Tên từ class: " + sinhVien.Name);
        }

        private static void Hs_NameChange(string name)
        {
            Console.WriteLine("Tên mới  : " + name);

        }

        class SinhVien
        {
            public event UpdateName? NameChanged;
            private string name;
            public string Name{
                get => name;
                set
                {
                    name = value;
                    if(NameChanged != null)
                    {
                        NameChanged(name);
                    }
                }
            }
            public SinhVien() 
            {
                name = "";
            }
        }
    }
   
}