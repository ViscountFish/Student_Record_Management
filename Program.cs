using System;
using System.Collections.Generic;
using System.Linq;

class Student_Record_Management
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<double> Grades { get; set; }

    public double AverageGrade => Grades.Count > 0 ? Grades.Average() : 0;

    public Student_Record_Management(int id, string name, List<double> grades)
    {
        ID = id;
        Name = name;
        Grades = grades;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Grades: {string.Join(", ", Grades)}, Average: {AverageGrade:F2}";
    }
}

class Program
{
    static List<Student_Record_Management> students = new List<Student_Record_Management>();

    internal static List<Student_Record_Management> Students { get => students; set => students = value; }

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Student Record Management ---");
            Console.WriteLine("1. Add a Student");
            Console.WriteLine("2. Remove a Student by ID");
            Console.WriteLine("3. Update Student Information");
            Console.WriteLine("4. View All Students");
            Console.WriteLine("5. Find the Student with the Highest Average Grade");
            Console.WriteLine("6. Search Students by Name");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    RemoveStudent();
                    break;
                case 3:
                    UpdateStudent();
                    break;
                case 4:
                    ViewAllStudents();
                    break;
                case 5:
                    FindTopStudent();
                    break;
                case 6:
                    SearchStudentByName();
                    break;
                case 7:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student ID: ");
        int id = int.Parse(Console.ReadLine());

        // Check for duplicate ID
        if (Students.Any(s => s.ID == id))
        {
            Console.WriteLine("A student with this ID already exists.");
            return;
        }

        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        List<double> grades = new List<double>();
        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Enter grade {i}: ");
            grades.Add(double.Parse(Console.ReadLine()));
        }

        Students.Add(new Student_Record_Management(id, name, grades));
        Console.WriteLine("Student added successfully.");
    }

    static void RemoveStudent()
    {
        Console.Write("Enter student ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        var student = Students.FirstOrDefault(s => s.ID == id);
        if (student != null)
        {
            Students.Remove(student);
            Console.WriteLine("Student removed successfully.");
        }
        else
        {
            Console.WriteLine("Student with the given ID not found.");
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter student ID to update: ");
        int id = int.Parse(Console.ReadLine());

        var student = Students.FirstOrDefault(s => s.ID == id);
        if (student == null)
        {
            Console.WriteLine("Student with the given ID not found.");
            return;
        }

        Console.Write("Enter new student name: ");
        student.Name = Console.ReadLine();

        List<double> newGrades = new List<double>();
        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Enter new grade {i}: ");
            newGrades.Add(double.Parse(Console.ReadLine()));
        }
        student.Grades = newGrades;

        Console.WriteLine("Student information updated successfully.");
    }

    static void ViewAllStudents()
    {
        if (Students.Count == 0)
        {
            Console.WriteLine("No students to display.");
            return;
        }

        foreach (var student in Students)
        {
            Console.WriteLine(student);
        }
    }

    static void FindTopStudent()
    {
        if (Students.Count == 0)
        {
            Console.WriteLine("No students to evaluate.");
            return;
        }

        var topStudent = Students.OrderByDescending(s => s.AverageGrade).First();
        Console.WriteLine($"Student with the highest average grade: {topStudent}");
    }

    static void SearchStudentByName()
    {
        Console.Write("Enter student name to search: ");
        string name = Console.ReadLine();

        var foundStudents = Students.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();



        if (foundStudents.Count == 0)
        {
            foreach (var student in foundStudents)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("No students found with the given name.");
        }

    }
}
