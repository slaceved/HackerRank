using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSafe
{
    public class Bank
    {
        public static void Main(string[] args)
        {
            Safe s = new BankSafe.Bank.Safe(2);

            Console.WriteLine(s.ToString());


            s.AddItem("stuff");
            s.AddItem("more stuff");
            Console.WriteLine(s.ToString());
            foreach (string i in s.Items)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine(s.Capacity);
 
            Console.ReadKey();
        }
    


    private class Safe
    {
        private readonly List<string> items = new List<string>();
        private readonly int _capacity;

        public Safe(int capacity)
        {
            _capacity = capacity;
        }

        public int Capacity { get { return _capacity; } }

        public IEnumerable<string> Items {
            get { return items; }
        }

        public void AddItem(string item)
        {
            if (items.Count >= _capacity)
                throw new InvalidOperationException();
            items.Add(item);
        }

        public override string ToString()
        {
            return String.Format("Safe: {0}/{1}", items.Count, _capacity);
        }

        public bool Empty()
        {
            items.Clear();
            return true;
        }

    }

}

}
