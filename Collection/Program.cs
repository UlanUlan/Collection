using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            /// Stack
            void Stackzadanie14()
            {
                /*14.	Пусть символ # определен в текстовом редакторе как стирающий символ Backspace, 
                 * т.е. строка abc#d##c в действительности является строкой ac.*/

                string s = "abc#d##c";
                Stack<char> stack = new Stack<char>();
                foreach (char item in s)
                {
                    if (item == '#' && stack.Count > 0)
                        stack.Pop();
                    else
                        stack.Push(item);
                }
                foreach (char item in stack.Reverse())
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
            void Stackzadanie8()
            {
                /*8.	В текстовом файле записана без ошибок формула вида:
                    	<формула>=<цифра>|M(<формула>,<формула>)|m(<формула>,<формула>)
                        <цифра>=0|1|2|3|4|5|6|7|8|9
                        M обозначает вычисление максимума, m - минимума
                        Вычислить значение этой формулы
                        Например M(m(3,5),M(1,2))=3*/

                string c = "M(m(3,5)M(1,2))";
                Stack<char> stack1 = new Stack<char>();
                Stack<int> stack2 = new Stack<int>();
                int i1 = 0;
                int i2 = 0;
                foreach (char item in c)
                {
                    if (item == 'M' || item == 'm')
                    {
                        stack1.Push(item);
                    }
                    else if (item == ')')
                    {
                        i1 = stack2.Pop();
                        i2 = stack2.Pop();
                        if (stack1.Pop() == 'M')
                        {
                            //i1 > i2 ? stack2.Push((char)i1) : stack2.Push((char)i2);
                            if (i1 > i2)
                                stack2.Push(i1);
                            else
                                stack2.Push(i2);
                        }
                        else
                        {
                            //i1 < i2 ? stack2.Push((char)i2) : stack2.Push((char)i1) :;
                            if (i1 > i2)
                                stack2.Push(i2);
                            else
                                stack2.Push(i1);
                        }
                    }
                    else if ((int)item - 48 >= 0 && (int)item - 48 <= 9)
                    {
                        stack2.Push((int)item - 48);
                    }
                }
                foreach (int item in stack2)
                {
                    Console.WriteLine(item);
                }
            }
            void Stackzadanie10()
            {
                string c = "m (9, p (p (3, 5), m (3, 8)))";
                Stack<char> stack1 = new Stack<char>();
                Stack<int> stack2 = new Stack<int>();
                int i1 = 0;
                int i2 = 0;
                foreach (char item in c)
                {
                    if (item == 'm' || item == 'p')
                    {
                        stack1.Push(item);
                    }
                    else if (item == ')')
                    {
                        i1 = stack2.Pop();
                        i2 = stack2.Pop();
                        if (stack1.Pop() == 'p')
                            stack2.Push((i1 + i2) % 10);
                        else
                            stack2.Push((i2 - i1) % 10);
                    }
                    else if ((int)item - 48 >= 0 && (int)item - 48 <= 9)
                    {
                        stack2.Push((int)item - 48);
                    }
                }
                foreach (int item in stack2)
                {
                    Console.WriteLine(item);
                }
            }

            //Stackzadanie14();
            //Stackzadanie8();
            //Stackzadanie10();

            /// Stack

            /// Queue
            void QueueZadanie8()
            {
                /*8.	Дан файл, содержащий информацию о сотрудниках фирмы: фамилия, имя, отчество, пол, возраст, размер зарплаты. 
                 * За один просмотр файла напечатать элементы файла в следующем порядке: сначала все данные о сотрудниках младше 30 лет,
                 * потом данные об остальных сотрудниках, сохраняя исходный порядок в каждой группе сотрудников.*/

                Queue<Sotrudnik> queue = new Queue<Sotrudnik>();
                // одним циклом никак
                for (int i = 0; i < 20; i++)
                {
                    queue.Enqueue(new Sotrudnik("XJ" + rand.Next(1, 100), true, rand.Next(18, 120), rand.Next(100, 1000000)));
                }
                Console.WriteLine("\n------------------------------------------Младше 30 лет\n");
                foreach (Sotrudnik item in queue)
                {
                    if (item.age < 30)
                        Console.WriteLine("Full name: " + item.fullName + " | Male: " + item.pol + " | Age: " + item.age + " | Salary size: " + item.salarySize);
                }
                Console.WriteLine("\n------------------------------------------Старше 30 лет\n");
                foreach (Sotrudnik item in queue)
                {
                    if (item.age >= 30)
                        Console.WriteLine("Full name: " + item.fullName + " | Male: " + item.pol + " | Age: " + item.age + " | Salary size: " + item.salarySize);
                }

                //foreach (Sotrudnik item in queue.OrderBy(o => o.age < 30))
                //{
                //    if (item.age < 30)
                //        Console.WriteLine("Full name: " + item.fullName + " | Male: " + item.pol + " | Age: " + item.age + " | Salary size: " + item.salarySize);
                //}

            }
            void QueueZadanie9()
            {
                /*9.	Дан файл, содержащий информацию о студентах: фамилия, имя, отчество, номер группы, 
                 * оценки по трем предметам текущей сессии. За один просмотр файла напечатать элементы файла в 
                 * следующем порядке: сначала все данные о студентах, успешно сдавших сессию, потом данные об остальных
                 * студентах, сохраняя исходный порядок в каждой группе сотрудников.*/

                Queue<Student> queue = new Queue<Student>();
                // одним циклом никак
                int[] scores;
                for (int i = 0; i < 200; i++)
                {
                    scores = new int[3] { rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5) };
                    queue.Enqueue(new Student("XJ" + rand.Next(1, 100), rand.Next(18, 120), scores));
                }

                Console.WriteLine("Успешно сдавшие сессию\n");
                foreach (Student item in queue)
                {
                    double avg = item.scores.Average(o => (int)(o));
                    if (avg >= 4)
                    {
                        Console.WriteLine("Full name: " + item.fullName + " | Number of gourp: " + item.numberOfGroup);
                        //Console.WriteLine(avg);
                    }
                }

                Console.WriteLine("\nНеуспешно сдавшие сессию\n");
                foreach (Student item in queue)
                {
                    double avg = item.scores.Average(o => (int)(o));
                    if (avg < 4)
                    {
                        Console.WriteLine("Full name: " + item.fullName + " | Number of gourp: " + item.numberOfGroup);
                        // Console.WriteLine(avg);
                    }
                }


            }
            void QueueZadanie10()
            {
                Queue<Student> queue = new Queue<Student>();
                // одним циклом никак
                int[] scores;
                for (int i = 0; i < 200; i++)
                {
                    scores = new int[3] { rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5) };
                    queue.Enqueue(new Student("XJ" + rand.Next(1, 100), rand.Next(18, 120), scores));
                }
                Console.WriteLine("Успешно обучающиеся на 4 и 5\n");
                foreach (Student item in queue)
                {
                    double avg = item.scores.Average(o => (int)(o));
                    if (avg >= 4)
                    {
                        Console.WriteLine("Full name: " + item.fullName + " | Number of gourp: " + item.numberOfGroup);
                        //Console.WriteLine(avg);
                    }
                }
                Console.WriteLine("\nУспешно обучающиеся на 3 и ниже\n");
                foreach (Student item in queue)
                {
                    double avg = item.scores.Average(o => (int)(o));
                    if (avg < 4)
                    {
                        Console.WriteLine("Full name: " + item.fullName + " | Number of gourp: " + item.numberOfGroup);
                        // Console.WriteLine(avg);
                    }
                }
            }

            //QueueZadanie8();
            //QueueZadanie9();
            //QueueZadanie10();

            /// Queue

            /// HashTable


            Dictionary<string, string> hashtable = new Dictionary<string, string>();

            hashtable.Add("Nautilus-Pompilius", "Gibraltar-Labrador");
            hashtable.Add("DDT", "Zaberi etu noch");

            foreach (var item in hashtable)
            {
                Console.WriteLine("Группа: "+item.Key +" | Песня: " +item.Value);
            }
            hashtable.Remove("DDT");

            /// HashTable

        }
    }
}
