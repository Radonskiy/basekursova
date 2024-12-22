using System;

namespace ChildrenGardenInterface
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class Child
    {
        public int ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ParentId { get; set; }
        public int? GroupId { get; set; }
    }

    public class Educator
    {
        public int EducatorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int EducatorId { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public int GroupId { get; set; }
    }

    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int ChildId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }

    public class Payment
    {
        public int PaymentId { get; set; }
        public int ChildId { get; set; }
        public double Amount { get; set; }
        public string Months { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }
    }
}