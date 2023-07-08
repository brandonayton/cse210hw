using System;
using System.Collections.Generic;

// Class representing a Student
class Student
{
    public string Name { get; set; }
    public int ID { get; set; }
    public string ContactInformation { get; set; }
}

// Class representing a Teacher
class Teacher
{
    public string Name { get; set; }
    public int ID { get; set; }
    public string SubjectSpecialization { get; set; }
}

// Class representing a Course
class Course
{
    public string CourseName { get; set; }
    public Teacher AssignedTeacher { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    public Course()
    {
        EnrolledStudents = new List<Student>();
    }
}

// Class representing Attendance
class Attendance
{
    public bool IsPresent { get; set; }
    public Student Student { get; set; }
    public DateTime Date { get; set; }
}

// Class representing Grades
class Grade
{
    public string Assignment { get; set; }
    public float Score { get; set; }
    public Student Student { get; set; }
}

// Class representing the Student Management System
class StudentManagementSystem
{
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Course> Courses { get; set; }

    public StudentManagementSystem()
    {
        Students = new List<Student>();
        Teachers = new List<Teacher>();
        Courses = new List<Course>();
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void UpdateStudent(Student student)
    {
        // Implementation to update student record
    }

    public void DeleteStudent(Student student)
    {
        Students.Remove(student);
    }

    public void AddTeacher(Teacher teacher)
    {
        Teachers.Add(teacher);
    }

    public void UpdateTeacher(Teacher teacher)
    {
        // Implementation to update teacher record
    }

    public void DeleteTeacher(Teacher teacher)
    {
        Teachers.Remove(teacher);
    }

    // Other administrative functions can be added here

    // Method to input grades
    public void InputGrades(Student student, string assignment, float score)
    {
        Grade grade = new Grade()
        {
            Student = student,
            Assignment = assignment,
            Score = score
        };

        // Implementation to store the grade
    }

    // Method to mark attendance
    public void MarkAttendance(Student student, bool isPresent)
    {
        Attendance attendance = new Attendance()
        {
            Student = student,
            IsPresent = isPresent,
            Date = DateTime.Now
        };

        // Implementation to store the attendance record
    }

    // Method to generate reports
    public void GenerateReport()
    {
        // Implementation to generate reports
    }
}

// Example usage
class Program
{
    static void Main()
    {
        // Creating instances of StudentManagementSystem
        StudentManagementSystem sms = new StudentManagementSystem();

        // Creating instances of students
        Student student1 = new Student()
        {
            Name = "John Doe",
            ID = 1,
            ContactInformation = "john.doe@example.com"
        };

        Student student2 = new Student()
        {
            Name = "Jane Smith",
            ID = 2,
            ContactInformation = "jane.smith@example.com"
        };

        // Adding students to the StudentManagementSystem
        sms.AddStudent(student1);
        sms.AddStudent(student2);

        // Creating instances of teachers
        Teacher teacher1 = new Teacher()
        {
            Name = "Mr. Johnson",
            ID = 100,
            SubjectSpecialization = "Mathematics"
        };

        // Adding teachers to the StudentManagementSystem
        sms.AddTeacher(teacher1);

        // Creating instances of courses
        Course course1 = new Course()
        {
            CourseName = "Mathematics",
            AssignedTeacher = teacher1
        };

        // Enrolling students in courses
        course1.EnrolledStudents.Add(student1);
        course1.EnrolledStudents.Add(student2);

        // Adding courses to the StudentManagementSystem
        sms.Courses.Add(course1);

        // Marking attendance for a student
        sms.MarkAttendance(student1, true);

        // Inputting grades for a student
        sms.InputGrades(student1, "Assignment 1", 90.5f);

        // Generating reports
        sms.GenerateReport();
    }
}
