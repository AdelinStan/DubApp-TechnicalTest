namespace DubAppTechnicalTest.Tests;

public class MergeSortStrategyTests
{
    public static IEnumerable<object[]> SortTestData =>
        new List<object[]>
        {
            new object[] { Array.Empty<int>() }, //Empty list 
            new object[] { new[] { 12 } }, //One element
            new object[] { new[] { 12, 4 } }, // Two elements
            new object[] { new[] { 12, 15, 23, 4, 6, 10, 35, 28 } }, //Even number of element
            new object[] { new[] { 12, 15, 23, 4, 6, 10, 35 } }, //Odd length array
            new object[] { new[] { 4, 6, 10, 12, 15, 23, 28, 35 } }, //Already sorted array
            new object[] { new[] { 35, 28, 23, 15, 12, 10, 6, 4 } }, //Descending sorted array input
            new object[] { new[] { 12, 15, -23, -4, 6, 10, -35, 28 } }, //Negative elements
            new object[] { new[] { 12, 12, 23, 4, 6, 6, 10, -35, 28 } }, //Duplicate elements
            new object[] { new[] { 12, 12, 12, 12, 12 } }, //Same element
            new object[]
            {
                Enumerable.Repeat(0, 5000).Select(i => Random.Shared.Next(int.MinValue, int.MaxValue)).ToArray()
            } //Large list of elements 
        };

    [Theory]
    [MemberData(nameof(SortTestData))]
    public void Sort_MemberDataArrayProvided_SuccessfullySorted(int[] array)
    {
        //Arrange
        ISortingStrategy sortingStrategy = new MergeSortStrategy();
        var expected = new List<int>(array);
        expected.Sort();

        //Act
        var result = sortingStrategy.Sort(array);

        //Assert
        Assert.Equal(expected, result);
    }
}