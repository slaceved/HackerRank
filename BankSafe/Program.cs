using System;
using System.Collections.Generic;

namespace BankSafe
{
    public class Bank
    {
        public static void Main(string[] args)
        {
            var s = new Safe(2);
            Console.WriteLine(s.ToString());

            s.AddItem("stuff");
            s.AddItem("more stuff");
            Console.WriteLine(s.ToString());
            foreach (var i in s.Items)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(s.Capacity);
            Console.Read();
        }
    }

    internal class Safe
    {
        private readonly List<string> _items = new List<string>();
        private readonly int _capacity;

        public Safe(int capacity)
        {
            _capacity = capacity;
        }

        public int Capacity => _capacity;

        public IEnumerable<string> Items => _items;

        public void AddItem(string item)
        {
            if (_items.Count >= _capacity)
                throw new InvalidOperationException();
            _items.Add(item);
        }

        public override string ToString()
        {
            return $"Safe: {_items.Count}/{_capacity}";
        }

        public bool Empty()
        {
            _items.Clear();
            return true;
        }
    }
}