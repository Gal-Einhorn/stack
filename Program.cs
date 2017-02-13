using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new LinkedList<string>();   
            UserInterface(stack);
        }

        static void UserInterface(LinkedList<string> stack)
        {
            Actions action;
            Console.WriteLine("\nThe stack is:\n");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nTo pop type 1, to push type 2, to exit type 3");
            
            var userChoise = Console.ReadLine();
            if (Enum.TryParse(userChoise, out action) && Enum.IsDefined(typeof(Actions), action))
            {
                switch (action)
                {
                    case Actions.Pop:
                        Pop(stack);
                        break;
                    case Actions.Push:
                        Add(stack);
                        break;
                    case Actions.Exit:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nYou typed {0} - which is neither '1' nor '2'", userChoise);
                UserInterface(stack);
            }
        }

        static void Add(LinkedList<string> stack)
        {
            Console.WriteLine("\nType the string you woyld like to add to the stack");
            var stringToAdd = Console.ReadLine();
            stack.AddLast(stringToAdd);
            UserInterface(stack);
        }
        static void Pop(LinkedList<string> stack)
        {
            stack.RemoveLast();
            UserInterface(stack);
        }
    }

    enum Actions
    {
        Pop = 1,
        Push = 2,
        Exit = 3
    }
}
