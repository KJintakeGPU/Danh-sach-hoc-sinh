using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string StudentID { get; set; } = "";
    public string FullName { get; set; } = "";
    public float AverageScore { get; set; }
    public string Faculty { get; set; } = "";
    public int Age { get; set; }

    public void Input()
    {
        Console.Write("Nhập MSSV: ");
        StudentID = Console.ReadLine() ?? "";
        Console.Write("Nhập Họ tên Sinh viên: ");
        FullName = Console.ReadLine() ?? "";
        Console.Write("Nhập Điểm TB: ");
        if (float.TryParse(Console.ReadLine(), out float score))
            AverageScore = score;
        Console.Write("Nhập Khoa: ");
        Faculty = Console.ReadLine() ?? "";
        Console.Write("Nhập Tuổi: ");
        if (int.TryParse(Console.ReadLine(), out int age))
            Age = age;
    }

    public void Show()
    {
        Console.WriteLine($"MSSV:{StudentID} Họ Tên:{FullName} Khoa:{Faculty} ĐiểmTB:{AverageScore} Tuổi:{Age}");
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new();
        
        Console.Write("Nhập số lượng học sinh: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập thông tin học sinh thứ {i + 1}:");
                Student student = new();
                student.Input();
                students.Add(student);
            }
        }

        Console.WriteLine("\n=== KẾT QUẢ ===\n");

        // a. In danh sách toàn bộ học sinh
        Console.WriteLine("a. Danh sách toàn bộ học sinh:");
        students.ForEach(s => s.Show());

        // b. Học sinh có tuổi từ 15 đến 18
        Console.WriteLine("\nb. Học sinh có tuổi từ 15 đến 18:");
        var age15To18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
        if (age15To18.Any())
            age15To18.ToList().ForEach(s => s.Show());
        else
            Console.WriteLine("Không có học sinh nào trong độ tuổi 15-18");

        // c. Học sinh có tên bắt đầu bằng chữ "A"
        Console.WriteLine("\nc. Học sinh có tên bắt đầu bằng chữ 'A':");
        var nameStartsWithA = students.Where(s => 
            !string.IsNullOrEmpty(s.FullName) && s.FullName.StartsWith("A", StringComparison.OrdinalIgnoreCase));
        if (nameStartsWithA.Any())
            nameStartsWithA.ToList().ForEach(s => s.Show());
        else
            Console.WriteLine("Không có học sinh nào có tên bắt đầu bằng chữ 'A'");

        // d. Tính tổng tuổi
        Console.WriteLine($"\nd. Tổng tuổi của tất cả học sinh: {students.Sum(s => s.Age)}");

        // e. Học sinh có tuổi lớn nhất
        Console.WriteLine("\ne. Học sinh có tuổi lớn nhất:");
        if (students.Any())
        {
            var oldestStudent = students.OrderByDescending(s => s.Age).First();
            oldestStudent.Show();
        }
        else
            Console.WriteLine("Danh sách học sinh trống");

        // f. Sắp xếp theo tuổi tăng dần
        Console.WriteLine("\nf. Danh sách học sinh sắp xếp theo tuổi tăng dần:");
        var sortedByAge = students.OrderBy(s => s.Age);
        if (sortedByAge.Any())
            sortedByAge.ToList().ForEach(s => s.Show());
        else
            Console.WriteLine("Danh sách học sinh trống");
    }
}