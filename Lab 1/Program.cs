 /*Описати клас Студент (Прізвище, Ім'я, Спеціальність, Курс, Масив балів від 1 до 100). 
Описати підсистему для генерування Групи студентів випадковим чином - списка об'єктів Студент. 
При генеруванні надати можливість вказати кількість студентів, кількість предметів, спеціальність та курс. 
Врахувати, що Прізвище та Ім'я  повинні бути випадковою обрані із наперед визначених значень.
Згенерувати групу з 23 студентів Системного аналізу 2 курсу, що мають по 6 оцінок. 
Вивести дані студентів в консоль.*/

﻿using System;
using System.Collections.Generic;

namespace Lab1
{
    internal class Program
    {
        public class Student
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Specialty { get; set; }
            public int Course { get; set; }
            public int[] Grades { get; set; }
        }

        public abstract class StudentFactory
        {
            public abstract Student CreateStudent(string specialty, int course, int numGrades);
        }


        public class RandomStudentFactory : StudentFactory
        {
            private static readonly string[] _surnames = { "Popovych", "Petrenko", "Kovalenko", "Ivanenko", "Shevchenko" };
            private static readonly string[] _names = { "Ivan", "Olga", "Mary", "Andrew", "Oleksandra" };
            private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

            public override Student CreateStudent(string specialty, int course, int numGrades)
            {
                var surname = _surnames[_random.Next(_surnames.Length)];
                var name = _names[_random.Next(_names.Length)];
                var grades = new int[numGrades];
                for (int i = 0; i < numGrades; i++)
                {
                    grades[i] = _random.Next(1, 101);
                }
                return new Student { Surname = surname, Name = name, Specialty = specialty, Course = course, Grades = grades };
            }
        }

        public class StudentGroupGenerator
        {
            public List<Student> GenerateGroup(int numStudents, string specialty, int course, int numGrades)
            {
                var factory = new RandomStudentFactory();
                var students = new List<Student>();
                for (int i = 0; i < numStudents; i++)
                {
                    students.Add(factory.CreateStudent(specialty, course, numGrades));
                }
                return students;
            }
        }

        static void Main(string[] args)
        {
            var generator = new StudentGroupGenerator();
            var students = generator.GenerateGroup(23, "System Analysis", 2, 6);

            foreach (var student in students)
            {
                Console.WriteLine($"Surname: {student.Surname}, Name: {student.Name}, Specialty: {student.Specialty}, Course: {student.Course}");
                Console.WriteLine("Grades:");
                foreach (var grade in student.Grades)
                {
                    Console.WriteLine($"  {grade}");
                }
                Console.WriteLine();
            }
        }
    }
}
