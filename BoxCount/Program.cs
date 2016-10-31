using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxCount
{
    public static class Boxes
    {
        public static int MinimalNumberOfBoxes(int products, int availableLargeBoxes, int availableSmallBoxes)
        {
            int largeBoxHolds = 5;
            int smallBoxHolds = 1;
            int totNumOfLargeBoxesToUse = 0;

            int totNumOfBoxes = availableLargeBoxes + availableSmallBoxes;

            int largeBoxCapasityNeeded = products / largeBoxHolds;

            if (largeBoxCapasityNeeded <= availableLargeBoxes)
            {
                totNumOfLargeBoxesToUse = largeBoxCapasityNeeded;
            }
            else { totNumOfLargeBoxesToUse = availableLargeBoxes; }


            int remainingProducts = products - (totNumOfLargeBoxesToUse * largeBoxHolds);

            int smallBoxCapasityNeeded = remainingProducts / smallBoxHolds;

            if (smallBoxCapasityNeeded <= availableSmallBoxes)
            {
                return totNumOfLargeBoxesToUse + smallBoxCapasityNeeded;
            }
            else
            {
                return -1; //not enough boxes 
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(Boxes.MinimalNumberOfBoxes(20, 3, 3));
            Console.ReadKey();
        }
    }
}
