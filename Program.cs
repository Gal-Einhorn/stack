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
            var state = new State {state = true};
            UserInterface(stack,state);
        }

        static void UserInterface(LinkedList<string> stack, State state)
        {
            Actions action;
            while (state.state == true)
            {
                Console.WriteLine("\n\nThe stack is:");
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Please pick one of the following options:");
                for (int i = 1; i <= Enum.GetNames(typeof (Actions)).Length; i++)
                {
                    Console.WriteLine("{0}. {1}",i, Enum.GetName(typeof(Actions),i));
                }

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
                        case Actions.Peek:
                            Peek(stack);
                            break;
                        case Actions.Exit:
                            Environment.Exit(0);
                            state.state = false;
                            break;
                    }
                }
            }
        }

        static void Add(LinkedList<string> stack)
        {
            Console.WriteLine("\nType the string you woyld like to add to the stack");
            var stringToAdd = Console.ReadLine();
            stack.AddLast(stringToAdd);
        }
        static void Pop(LinkedList<string> stack)
        {
            stack.RemoveLast();
        }
        static void Peek(LinkedList<string> stack)
        {
            Console.WriteLine("\n\nThe last item in the stack is:");
            Console.WriteLine(stack.Last.Value);
        }
    }

    enum Actions
    {
        Pop = 1,
        Push = 2,
        Peek = 3,
        Exit = 4
    }

    public class State
    {
        public bool state { get; set; }
    }
}
