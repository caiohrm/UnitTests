using System.Collections;
using UnitTest;


namespace Tests;


public class ParalellUnitTest
{

    private readonly Calculator _sut;

    public ParalellUnitTest()
    {
        _sut = new Calculator();
    }


    [Fact(Skip = "this is broken")]
    public void AddTwoNumbersShouldBeEqual()
    {
        var result = _sut.Sum(1, 1);
        Assert.Equal(2, result);
    }


    [Theory]
    [MemberData(nameof(TestData))]
    public void AddTwoNumberShouldBeEqualTheory(decimal expected,params decimal[] valuesToAdd)
    {
        var result = _sut.Sum(valuesToAdd);
        Assert.Equal(expected, result);
    }


    [Theory]
    [ClassData(typeof(TestData))]
    public void AddTwoNumberShouldBeEqualTheoryClass(decimal expected, params decimal[] valuesToAdd)
    {
        var result = _sut.Sum(valuesToAdd);
        Assert.Equal(expected, result);
    }


    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 15, new decimal[] { 10, 5 } };
        yield return new object[] { 10, new decimal[] { 5, 5 } };
        yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
    }

}



public class TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 15, new decimal[] { 10, 5 } };
        yield return new object[] { 10, new decimal[] { 5, 5 } };
        yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
