using Dapper;
using Microsoft.Data.Sqlite;
using System.Net.Mail;

namespace Tap.Solid.Srp
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SocialSecurityNumber { get; set; }

        public string AddStudent()
        {
            if (!Email.Contains("@uaic.ro"))
                return "Invalid email. Please use your uaic email!";

            if (SocialSecurityNumber.Length != 13)
                return "Invalid social security number!";

            var sqlCommand = "INSERT INTO students (Name, Email, SocialSecurityNumber) values (@Name, @Email, @SocialSecurityNumber)";
            using (var connection = new SqliteConnection("Data Source=:memory:"))
            {
                var affectedRows = connection.Execute(sqlCommand);
            }
            return "Student enroled!";
        }

    }

    internal class EmailSender
    {
        public void SendEmail(string name, string email)
        {
            var mail = new MailMessage("demo@solid.principles.srp", email);
            var client = new SmtpClient
            {
                Port = 25,
                Host = "smtp.demo.exercise"
            };

            mail.Subject = "Welcome to the lab!";
            mail.Body = $"Hey Robert! Glad to have you!";
            client.Send(mail);
        }
    }

    internal class StudentRepository
    {
        public string Student(string name, string Email, string SocialSecurityNumber)
        {
            var sqlCommand = "INSERT INTO students (Name, Email, SocialSecurityNumber) values (@Name, @Email, @SocialSecurityNumber)";
            using (var connection = new SqliteConnection("Data Source=:memory:"))
            {
                var affectedRows = connection.Execute(sqlCommand);
            }
        }
    }





    internal class ValidStudents
    {
        private readonly EmailSender emailSender;

        public ValidStudents(EmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public void Process(Student student)
        {
            emailSender.SendEmail(student.Name, student.Email);
        }
    }

    internal class ValidationResult
    {
        public bool IsValid { get; }
        public bool IsNotValid { get; }

        public ValidationResult(bool isValid, bool isNotValid)
        {
            IsValid = isValid;
            IsNotValid = isNotValid;
        }
    }
}
