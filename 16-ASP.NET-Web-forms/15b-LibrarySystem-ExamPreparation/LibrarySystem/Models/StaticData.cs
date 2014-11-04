using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class StaticData
    {
        private static IList<Category> categories = new List<Category>()
        {
            new Category() { CategoryId = 1, Name = "Programming" },
            new Category() { CategoryId = 2, Name = "Databases" },
            new Category() { CategoryId = 3, Name = "Web Development" },
            new Category() { CategoryId = 4, Name = "System Administration" },
            new Category() { CategoryId = 5, Name = "Data Structures and Algorithms" },
            new Category() { CategoryId = 6, Name = "Rocket Science" }
        };

        public static IList<Category> Categories
        {
            get
            {
                return categories;
            }
        }

        private static List<Book> books = new List<Book>()
        {
            new Book() { 
                BookId = 1, Title = "Fundamentals of Computer Programming with C#",
                Author = "Svetlin Nakov & Co.", ISBN = "978-954-400-773-7",
                WebSite = "http://www.introprogramming.info/english-intro-csharp-book/",
                Description = "The free book \"Fundamentals of Computer Programming with C#\" aims to provide novice programmers solid foundation of basic knowledge regardless of the programming language. This book covers the fundamentals of programming that have not changed significantly over the last 10 years. Educational content was developed by an authoritative author team led by Svetlin Nakov and covers topics such as variables conditional statements, loops and arrays, and more complex concepts such as data structures (lists, stacks, queues, trees, hash tables, etc.), and recursion recursive algorithms, object-oriented programming and high-quality code. From the book you will learn how to think as programmers and how to solve efficiently programming problems. You will master the fundamental principles of programming and basic data structures and algorithms, without which you can't become a software engineer.",
                Category = Categories[0]
            },
            new Book() { 
                BookId = 2, Title = "C# Yellow Book",
                Author = "Rob Miles", ISBN = "B003UN7WHS",
                WebSite = "http://www.csharpcourse.com",
                Description = "The C# Book is used by the Department of Computer Science in the University of Hull as the basis of the First Year programming course.",
                Category = Categories[0]
            },
            new Book() { 
                BookId = 3, Title = "Programming = ++ Algorithms;",
                Author = "Preslav Nakov and Panayot Dobrikov", ISBN = "954-8905-06-X",
                WebSite = "http://www.programirane.org",
                Description = "The “Programming=++Algorithms;” book is now available for free download as PDF. Everyone who speaks Bulgarian could benefit from the free non-commercial edition of this highly-valuable book on algorithms and competitive programming.",
                Category = Categories[4]
            },
            new Book() { 
                BookId = 4, Title = "SQL in a Nutshell: A Desktop Quick Reference",
                Author = "Kevin Kline", ISBN = "978-156-592-744-5",
                Category = Categories[1]
            },
            new Book() { 
                BookId = 5, Title = "Beginning HTML and CSS",
                Author = "Rob Larsen", 
                Category = Categories[2]
            },
            new Book() { 
                BookId = 6, Title = "Beginning ASP.NET 4.5 in C# Coding Skills Kit",
                Author = "Imar Spaanjaars", WebSite="http://www.goodreads.com/book/show/17129477",
                Category = Categories[2]
            },
            new Book() { 
                BookId = 7, Title = "Advanced Linux Programming",
                Author = "CodeSourcery LLC", WebSite="http://www.advancedlinuxprogramming.com",
                Category = Categories[3]
            },            
        };

        public static IList<Book> Books
        {
            get
            {
                return books;
            }
        }
    }
}