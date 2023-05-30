namespace UnitTest;
using Xunit.Abstractions;

public class UnitTest1
{
    private readonly ITestOutputHelper console;
    private SeriesAnalyzer seriesAnalyzer = new SeriesAnalyzer(8, 0.5, 0.2, 1.5);


    public UnitTest1(ITestOutputHelper console)
    {
        this.console = console;
    }

    [Fact]
    public void Test1()
    {
        double[] bucket = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1};
        Serie serie = new Serie("a", bucket);
        List<Serie> input = new List<Serie>();

        input.Add(serie);

        SerieAnalysisResult output = new SerieAnalysisResult(false, true, Magnitude.AVERAGE, 10, 1, 4, "a", 4);

        Assert.Equal(output.toString(), seriesAnalyzer.AnalyzeSeries(input)[0].toString());
    }
}