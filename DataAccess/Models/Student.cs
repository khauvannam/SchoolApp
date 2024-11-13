namespace DataAccess.Models;

public class Student(int age, string username, string email, string fullName)
    : Person(age, username, email, fullName) { }
