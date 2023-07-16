using System;
using System.Collections.Generic;

// Base class for all users
class User
{
    public string Name { get; set; }
    public int ID { get; set; }
}

// Class representing a Student
class Student : User
{
    public string ContactInformation { get; set; }
}

// Class representing a Teacher
class Teacher : User
{
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

// Base class for administrative functions
class AdminFunctions
{
    public virtual void AddUser(User user)
    {
        // Implementation to add user
    }

    public virtual void UpdateUser(User user)
    {
        // Implementation to update user
    }

    public virtual void DeleteUser(User user)
    {
        // Implementation to delete user
    }
}

// Class representing the Student Management System
class StudentManagementSystem : AdminFunctions
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

    public override void AddUser(User user)
    {
        if (user is Student student)
        {
            Students.Add(student);
        }
        else if (user is Teacher teacher)
        {
            Teachers.Add(teacher);
        }
    }

    public override void UpdateUser(User user)
    {
        if (user is Student student)
        {
            // Implementation to update student record
        }
        else if (user is Teacher teacher)
        {
            // Implementation to update teacher record
        }
    }

    public override void DeleteUser(User user)
    {
        if (user is Student student)
        {
            Students.Remove(student);
        }
        else if (user is Teacher teacher)
        {
            Teachers.Remove(teacher);
        }
    }

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
        // Creating an instance of StudentManagementSystem
        StudentManagementSystem sms = new StudentManagementSystem();

        // Creating instances of users
        Student student1 = new Student()
        {
            Name = "John Doe",
            ID = 1,
            ContactInformation = "john.doe@example.com"
        };

        Teacher teacher1 = new Teacher()
        {
            Name = "Mr. Johnson",
            ID = 100,
            SubjectSpecialization = "Mathematics"
        };

        // Adding users to the StudentManagementSystem
        sms.AddUser(student1);
        sms.AddUser(teacher1);

        // Creating instances of courses
        Course course1 = new Course()
        {
            CourseName = "Mathematics",
            AssignedTeacher = teacher1
        };

        // Enrolling students in courses
        course1.EnrolledStudents.Add(student1);

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
