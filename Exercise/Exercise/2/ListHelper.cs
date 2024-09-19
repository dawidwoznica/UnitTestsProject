namespace Exercise
{
    public static class ListHelper
    {
        public static List<int> FilterOddNumber(List<int> listOfNumbers)
        {
            return listOfNumbers.Where(number => number % 2 != 0).ToList();
        }
    }
}
