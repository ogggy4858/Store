using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    public class Exceptionn
    {
        /// <summary>
        /// Kiểm tra đầu vào kiểu int, long, double
        /// </summary>
        /// <param name="soluong"></param>
        /// <param name="chieudai"></param>
        /// <returns></returns>
        public bool KiemTraSoLuong(string soluong, int chieudai)
        {
            // kiem tra so dau vao co phai la so hay k
            char[] ch = soluong.ToCharArray();
            int kiemtra = 0;
            for (int i = 0; i < ch.Length; i++)
            {
                for (int j = 32; j < 127; j++)
                {
                    if ((ch[i] == (char)j) && j > 47 && j < 58)
                    {
                        kiemtra++;
                    }
                    else
                    {

                    }
                }
            }
            if (kiemtra == soluong.Length && soluong.Length < chieudai)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool KiemTraChuoi(string chuoi, int chieudai)
        {
            if (chuoi.Length > chieudai)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool KiemTraChuoi(string[] str, int[] length)
        {
            int f = 0;
            if (str.Length == length.Count())
            {
                for (int i = 0, j = 0; i < str.Length; i++, j++)
                {
                    if (j < length.Count())
                    {
                        if (str[i].Length <= length[j])
                        {
                            f++;
                        }
                    }
      
                }
                if(f == str.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        
        }
    }
}
