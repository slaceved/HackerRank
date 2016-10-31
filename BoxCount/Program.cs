using System;

namespace BoxCount
{
    public static class Boxes
    {
        public static int MinimalNumberOfBoxes(int products, int availableLargeBoxes, int availableSmallBoxes)
        {
            const int largeBoxHolds = 5;
            const int smallBoxHolds = 1;
            var largeBoxCapasityNeeded = products / largeBoxHolds;

            var totNumOfLargeBoxesToUse = largeBoxCapasityNeeded <= availableLargeBoxes ? largeBoxCapasityNeeded : availableLargeBoxes;

            var remainingProducts = products - (totNumOfLargeBoxesToUse * largeBoxHolds);

            var smallBoxCapasityNeeded = remainingProducts / smallBoxHolds;

            if (smallBoxCapasityNeeded <= availableSmallBoxes)
            {
                return totNumOfLargeBoxesToUse + smallBoxCapasityNeeded;
            }
            return -1; //not enough boxes 
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(MinimalNumberOfBoxes(20, 3, 3));
            Console.ReadKey();
        }
    }
}
