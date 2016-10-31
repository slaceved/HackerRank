using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Delivery
{
    internal class Solution
    {
        public static void Main(string[] args)
        {
            const char splitBy = ' ';
            var nums = Console.ReadLine()?.Split(splitBy.ToString().ToCharArray());
            Debug.Assert(nums != null, "nums != null");
            var nodes = Convert.ToInt32(nums[0]); //intersections
            var foodTypes = Convert.ToInt32(nums[1]); //types of food
            var requests = Convert.ToInt32(nums[2]); //requests

            var cityMap = new Dictionary<string, DetailedObject>(); //sets up the city what food is located where
            for (var x = 1; x <= nodes; x++)
            {
                cityMap.Add(x.ToString(), new DetailedObject());
            }

            for (var f = 1; f <= foodTypes; f++)
            {
                nums = Console.ReadLine()?.Split(splitBy.ToString().ToCharArray());
                Debug.Assert(nums != null, "nums != null");
                for (var l = 1; l < nums.Length; l++)
                {
                    cityMap[nums[l]].Subs.Add(new SubStructure { Food = f });
                }
            }
        
            //need to build nodes collection

            var current = 1;
            var time = 0;
            for (var j = 0; j < requests; j++)
            {
                nums = Console.ReadLine()?.Split(splitBy.ToString().ToCharArray());
                Debug.Assert(nums != null, "nums != null");

                //find the closest pickup point
                var result = cityMap.Where(kvp => kvp.Value.Subs.Any(ss => ss.Food == Convert.ToInt32(nums[0])) && Math.Abs(Convert.ToInt32(kvp.Key) - current) >= 0)
                   .OrderBy(t => t.Key)
                   .FirstOrDefault();

                //tbd: correct this time calc to use the traversal count from current to result.key-pickup to nums[1]-destination
                time += Math.Abs(Convert.ToInt32(result.Key) - current) + Convert.ToInt32(nums[1]);
                current = Convert.ToInt32(nums[1]);
            }

            Console.WriteLine(time);
            Console.Read();
        }//main

    }//class program

    public struct SubStructure
    {
        public int Food;
    }

    public class DetailedObject
    {
        public int Id; //node
        public List<SubStructure> Subs = new List<SubStructure>();
    }

   public class BinaryTreeNode
    {
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public int Data { get; set; }
        public List<BinaryTreeNode> Nodes { get; } = new List<BinaryTreeNode>();
        public override string ToString()
        {
            return Data.ToString();
        }
    }

    public class BreadthFirstAlgorithm
    {
        public BinaryTreeNode BuildGraph(int numOfNodes)
        {
            var root = new BinaryTreeNode {Data = 1};
            //need to add code here to populate the tree
            return root;
        }
        
        public BinaryTreeNode Search(BinaryTreeNode root, int nodeToSearchFor)
        {
            var q = new Queue<BinaryTreeNode>();
            var s = new HashSet<BinaryTreeNode>();
            q.Enqueue(root);
            s.Add(root);

            while (q.Count > 0)
            {
                var p = q.Dequeue();
                if (p.Data == nodeToSearchFor)
                    return p;
                foreach (var node in p.Nodes)
                {
                    if (s.Contains(node)) continue;
                    q.Enqueue(node);
                    s.Add(node);
                }
            }
            return q.Peek();
        }

        public int Traverse(BinaryTreeNode root)
        {
            var traverseOrder = new Queue<BinaryTreeNode>();
            var q = new Queue<BinaryTreeNode>();
            var s = new HashSet<BinaryTreeNode>();
            q.Enqueue(root);
            s.Add(root);

            while (q.Count > 0)
            {
                var p = q.Dequeue();
                traverseOrder.Enqueue(p);

                foreach (var node in p.Nodes)
                {
                    if (s.Contains(node)) continue;
                    q.Enqueue(node);
                    s.Add(node);
                }
            }

            return traverseOrder.Count;
        }
        public static IEnumerable<BinaryTreeNode> BreadthFirstTopDownTraversal<BinaryTreeNode>(BinaryTreeNode root, Func<BinaryTreeNode, IEnumerable<BinaryTreeNode>> children)
        {
            var q = new Queue<BinaryTreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                yield return current;
                foreach (var child in children(current))
                    q.Enqueue(child);
            }
        }
    }


}//solution
