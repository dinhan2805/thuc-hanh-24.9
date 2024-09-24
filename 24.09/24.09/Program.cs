using System;
using System.Collections.Generic;

class SinhVien
{
    public string HoTen { get; set; }
    public string MSSV { get; set; }
    public double DiemTrungBinh { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Nhap ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhap MSSV: ");
        MSSV = Console.ReadLine();
        Console.Write("Nhap diem trung binh: ");
        DiemTrungBinh = double.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho ten: {HoTen}, MSSV: {MSSV}, Diem trung binh: {DiemTrungBinh}");
    }
}

class DanhSachSinhVien
{
    private List<SinhVien> danhSach = new List<SinhVien>();

    public void ThemSinhVien(SinhVien sv)
    {
        danhSach.Add(sv);
    }

    public void HienThiDanhSach()
    {
        foreach (var sv in danhSach)
        {
            sv.HienThiThongTin();
        }
    }

    public SinhVien TimSinhVienTheoMSSV(string mssv)
    {
        foreach (var sv in danhSach)
        {
            if (sv.MSSV == mssv)
            {
                return sv;
            }
        }
        return null;
    }

    public SinhVien TinhDiemTrungBinhCaoNhat()
    {
        SinhVien svMax = null;
        double maxDiem = double.MinValue;

        foreach (var sv in danhSach)
        {
            if (sv.DiemTrungBinh > maxDiem)
            {
                maxDiem = sv.DiemTrungBinh;
                svMax = sv;
            }
        }
        return svMax;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DanhSachSinhVien ds = new DanhSachSinhVien();

        for (int i = 0; i < 3; i++)
        {
            SinhVien sv = new SinhVien();
            sv.NhapThongTin();
            ds.ThemSinhVien(sv);
        }

        Console.WriteLine("\nDanh sach sinh vien:");
        ds.HienThiDanhSach();

        SinhVien svMax = ds.TinhDiemTrungBinhCaoNhat();
        if (svMax != null)
        {
            Console.WriteLine("\nSinh vien co diem trung binh cao nhat:");
            svMax.HienThiThongTin();
        }

        Console.Write("\nNhap MSSV de tim kiem: ");
        string mssv = Console.ReadLine();
        SinhVien svTim = ds.TimSinhVienTheoMSSV(mssv);
        if (svTim != null)
        {
            Console.WriteLine("\nThong tin sinh vien tim thay:");
            svTim.HienThiThongTin();
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien voi MSSV nay.");
        }
    }
}
