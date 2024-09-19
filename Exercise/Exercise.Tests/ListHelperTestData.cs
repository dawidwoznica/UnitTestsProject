namespace Exercise.Tests;

using System.Collections;

public class ListHelperTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
            new List<int>{1, 3, 5, 7, 9}];

        yield return [new List<int>{10, 11, 12, 13, 14, 15},
            new List<int>{11, 13, 15}];

        yield return [new List<int>(),
            new List<int>()];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}