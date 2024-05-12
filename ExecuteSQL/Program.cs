using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace ExcuteSQL
{
    public class Program
    {   
        
        public enum TypeDate
        {
            VARCHAR,
            INTEGER,
            DOUBLEF 
        }

        public static List<string> TachDong(string? s)
        {
            List<string> contains = new List<string>();
            bool check = false;
            string temp = "";
            s = s + " ";
            if(s != null)
            {
                foreach(char ch in s)
                {
                    if(ch != ' ')
                    {   
                        check = true;
                        temp += ch;
                    }
                    else 
                    {
                        if(check)
                        {
                            contains.Add(temp);
                            temp = "";
                            check = false;
                        }   
                    }
                }
            }
            // Console.WriteLine("###");
            // foreach(string x in contains)
            // {
            //     Console.Write(x + " - ");
            // }
            // Console.WriteLine("###");
            return contains;
        }

        public static int DemCau(string? s)
        {
            return TachDong(s).Count;
        }

        public static void ViTriCacChuoi(string raw)
        {
            int n = raw.Length;
            for(int i = 0; i < n; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for(int i = 0; i < n; i++)
            {
                if(i > 10)
                {
                    Console.Write(" " + raw[i] + " ");
                }
                else if(i > 100)
                {
                    Console.Write("  " + raw[i] + "  ");
                }
                else Console.Write(raw[i] + " ");
            }
        }

        public static string? Trim(string? s)
        {
            string out1 = "";
            List<string> v = TachDong(s);
            foreach(string ch in v)
            {
                out1 = out1 + ch + " ";
            }
            // Console.WriteLine(out1);
            return out1;
        }

        public static string StringSQL(string current, int j, int end, int dataType)
        {
            if(j == 0 && j == end)
            {
                return ((dataType == (int)TypeDate.VARCHAR) ?  "(\'" + current + "\')" : "(" + current + ")"); 
            }
            else if(j == 0)
            {
                return ((dataType == (int)TypeDate.VARCHAR) ?  "(\'" + current + "\'" : "(" + current); 
            }
            else if(j == end)
            {
                return ((dataType == (int)TypeDate.VARCHAR) ?  "\'" + current + "\')" : current + ")"); 
            }
            else 
            {
                return ((dataType == (int)TypeDate.VARCHAR) ?   "\'" + current + "\'" : current);
            }
        }

        public static List<string> TachChuoi(List<string>[] dongSQL, List<int> dataType, int batDauCau, int ketThucCau, int soDong, int soCot)
        {
            List<string> completed = new List<string>();
            string theoDong = "", temp;
            batDauCau--; ketThucCau--;
            // duyet theo hang doc
            for(int i = 1; i <= soDong; i++)
            {
                // duyet theo hang ngang
                for(int j = 0; j < dongSQL[i].Count; j++)
                {
                    string current = dongSQL[i][j];
                    //Console.WriteLine($"So sanh hang thu {i}: " + dongSQL[i].Count + " - " + soCot);
                    if(j >= batDauCau && j <= ketThucCau && dongSQL[i].Count > soCot)
                    {
                        temp = "";
                        for(int k = batDauCau; k <= ketThucCau; k++)
                        {
                            temp = temp + dongSQL[i][k];
                            if(k != ketThucCau)
                            {
                                temp = temp + " ";
                            }
                        }
                        int pround = -1;
                        if(batDauCau == 0) pround = batDauCau;
                        if(ketThucCau == dongSQL[i].Count - 1) pround = ketThucCau;

                        theoDong = theoDong + StringSQL(temp, pround, dongSQL[i].Count - 1, dataType[batDauCau]);
                        if(ketThucCau != dongSQL[i].Count - 1)
                        {
                            theoDong = theoDong + ", ";
                        }
                        dongSQL[i][batDauCau] = temp;

                        for(int m = batDauCau + 1; m + ketThucCau - batDauCau < dongSQL[i].Count; m++)
                        {
                            dongSQL[i][m] = dongSQL[i][m + ketThucCau - batDauCau];
                        }
                        dongSQL[i].EnsureCapacity(soCot);
                        if (dongSQL[i].Count > soCot)
                        {
                            dongSQL[i].RemoveRange(soCot, dongSQL[i].Count - soCot);
                        }
                        //Console.WriteLine($"new size: {dongSQL[i].Count}");
                    }
                    else 
                    {
                        theoDong = theoDong + StringSQL(current, j, dongSQL[i].Count - 1, dataType[j]);
                        if(j != dongSQL[i].Count - 1)
                        {
                            theoDong = theoDong + ", ";
                        }
                    }
                }
                completed.Add(theoDong);
                theoDong = "";
            }
            return completed;
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<int> dataType = new List<int>();
            Console.Write("Nhập số dòng: ");
            int soDong, soCot; 
            int.TryParse(Console.ReadLine(), out soDong);
            Console.Write("Nhập số cột: ");
            int.TryParse(Console.ReadLine(), out soCot);
            Console.WriteLine("Nhập kiểu dữ liệu của từng cột:");
            for(int i = 0; i < soCot; i++)
            {
                Console.Write("0. VARCHAR, 1. INTEGER, 2.DOUBLE/FLOAT: ");
                int type = 0;
                int.TryParse(Console.ReadLine(), out type);
                if(type == (int)TypeDate.VARCHAR) dataType.Add((int)TypeDate.VARCHAR);
                if(type == (int)TypeDate.INTEGER) dataType.Add((int)TypeDate.INTEGER);
                if(type == (int)TypeDate.DOUBLEF) dataType.Add((int)TypeDate.DOUBLEF);
            }
            int testCase = soDong;
            List<string>[] dongSQL = new List<string>[soDong + 1];
            for(int i = 0; i <= soDong; i++)
            {
                dongSQL[i] = new List<string>();
            }
            int batDauCau = -1, ketThucCau = -1;
            bool chinhCau = false;
            while(testCase > 0)
            {
                string? inputSQL = Console.ReadLine();

                inputSQL = Trim(inputSQL);
                //Console.WriteLine(inputSQL);
            
                if(DemCau(inputSQL) > soCot && !chinhCau)
                {
                    
                    Console.WriteLine("Số từ trong câu lớn hơn số cột");
                    if(inputSQL != null)
                    {
                        ViTriCacChuoi(inputSQL.Substring(0, inputSQL.Length - 1));
                        Console.WriteLine("\nNhập vị trí bắt đầu và kết thúc để gộp thành một kiểu dữ liệu:");
                        int start; int.TryParse(Console.ReadLine(), out start);
                        int end; int.TryParse(Console.ReadLine(), out end);
                        int count = 0;
                        
                        for(int i = 0; i < inputSQL.Length; i++)
                        {
                            char ch = inputSQL[i];
                            if(start == i || end == i)
                            {
                                int step = count + 1;
                                if(start == i)
                                {
                                    batDauCau = step;
                                }
                                else ketThucCau = step;
                            }
                            if(ch == ' ')
                            {
                                count++;
                            }
                        }
                        chinhCau = true;
                    }
                }
                if(inputSQL != null)
                {
                    string temp = "";
                    for(int i = 0; i < inputSQL.Length; i++)
                    {
                        char ch = inputSQL[i];
                        if(ch == ' ')
                        {
                            dongSQL[soDong - testCase + 1].Add(temp);
                            // Console.WriteLine($"{soDong - testCase + 1} : {temp}");
                            temp = "";
                        }
                        else temp += ch;   
                    }
                }
                testCase--;
            }
            List<string> containsSQL = TachChuoi(dongSQL, dataType, batDauCau, ketThucCau, soDong, soCot);  
            int countX = 1;
            foreach(string s in containsSQL)
            {
                Console.Write(s);
                if(countX != containsSQL.Count)
                {
                    Console.Write(",");
                }
                Console.WriteLine();
                countX++;
            }
        }  
    }
}