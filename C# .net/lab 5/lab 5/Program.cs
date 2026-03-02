using lab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO; 

namespace lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 1 person class
            Person p = new Person { Age = 30, FirstName = "John", LastName = "Doe" };
            Console.WriteLine($"Name: {p.FirstName} {p.LastName}, Age: {p.Age}");
            Console.WriteLine("-----------------------");
            //task 2 rectangle class auto properties
            Rectangle rect = new Rectangle { Width = 5.0, Height = 10.0 };
            Console.WriteLine($"Rectangle Width: {rect.Width}, Height: {rect.Height}, Area: {rect.Area},color:{rect.Color}");
            Console.WriteLine("-----------------------");
            //task3 student gradebook indexer
            GradeBook gb = new GradeBook(3);
            gb[0] = 85.5;
            gb[1] = 90.0;
            gb[2] = 78.5;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Grade {i + 1}: {gb[i]}");

            }
            Console.WriteLine("-----------------------");
            //task4 stringcollection indexer
            StrugCollection strugCollection = new StrugCollection(3);
            strugCollection[0] = "Hello";
            strugCollection[1] = "World";
            strugCollection[2] = "!";
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Item {i + 1}: {strugCollection[i]}");
            }
            strugCollection["first"] = "First Item";
            strugCollection["second"] = "Second Item";
            Console.WriteLine($"Item with key 'first': {strugCollection["first"]},{strugCollection["second"]}");
            Console.WriteLine("-----------------------");
            //task5 shoppingcart
            ArrayList cart = new ArrayList();
            cart.Add(42);
            cart.Add("milk");
            cart.Add(3.99);
            cart.Remove(42);
            foreach (var item in cart)
            {
                Console.WriteLine($"Cart Item: {item}");
            }
            Console.WriteLine("-----------------------");
            //task6 list student
            List<Student> students = new List<Student>
            {
                new Student{Name="ali",StudentId=1,GPA=3},
                new Student{Name="Ahmed",StudentId=2,GPA=4},
                new Student{Name="alooolo",StudentId=3,GPA=2}
            };
            Student findstudent = students.Find(s => s.GPA > 2.5);
            Console.WriteLine($"the found student with high gpa: {findstudent.Name}");

            students.Sort((s1, s2) => s1.GPA.CompareTo(s2.GPA));
            foreach (Student s in students)
            {
                Console.WriteLine($"{s.Name} - GPA: {s.GPA}");
            }
            Console.WriteLine("--------------------------");
            //task 7 try exception
            try
            {
                Calculator.divide(2, 0);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("undefined HOW YOU DIVIDE BY ZEROOOOO");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
            //task 8 finally
            StreamWriter writer = null;
            try
            {
                Console.WriteLine("opening file ");
                // MAKE SURE THIS PATH EXISTS ON YOUR COMPUTER OR CHANGE IT
                writer = new StreamWriter("C:/Users/20100/Downloads/text.txt");
                writer.WriteLine("I LOVE C#");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error caught: {ex.Message}");
            }
            finally

            {
                if (writer != null) writer.Close();
                Console.WriteLine("3. File closed successfully in 'finally' block.");
            }
        }
    }
}