public class SeriesAnalyzer
{
    public int NumerosityThreshold { get; set; }
    public double SporadicThreshold { get; set; }
    public double MinMagnitudeThreshold { get; set; }
    public double MaxMagnitudeThreshold { get; set; }

    public SeriesAnalyzer(int numerosityThreshold, double sporadicThreshold,
        double minMagnitudeThreshold, double maxMagnitudeThreshold)
    {
        NumerosityThreshold = numerosityThreshold;
        SporadicThreshold = sporadicThreshold;
        MinMagnitudeThreshold = minMagnitudeThreshold;
        MaxMagnitudeThreshold = maxMagnitudeThreshold;
    }

    public List<SerieAnalysisResult> AnalyzeSeries(List<Serie> series)
    {

        bool numerous;
        bool sporadic;
        string magnitudeTag;
        int numberOfBuckets;
        int nullBucketsStreak;
        double median;
        var tagMedians = new Dictionary<string, List<double>>();
        var tagMeans = new Dictionary<string, double>();

        List<SerieAnalysisResult> seriesAnalysisResults = new List<SerieAnalysisResult>();

        foreach (Serie serie in series)
        {
            double[] serieValues = TrimSerie(serie.Values);

            // Una serie nulla fa sballare l'ordine, quindi bisogna capire cosa è meglio fare
            if(serieValues.Length == 0){
                continue;
            }

            tagMedians.TryAdd(serie.Tag, new List<double>());

            median = MedianValue(serieValues);

            tagMedians[serie.Tag].Add(median);
            
            numerous = IsNumerous(serieValues);
            sporadic = IsSporadic(serieValues);
            numberOfBuckets = Buckets(serieValues);
            nullBucketsStreak = NullStreak(serieValues);

            SerieAnalysisResult serieAnalysisResult = new SerieAnalysisResult(
                numerous, sporadic, numberOfBuckets, nullBucketsStreak, median, serie.Tag
            );
            seriesAnalysisResults.Add(serieAnalysisResult);
        }

        foreach(var tagMedian in tagMedians){
            tagMeans.Add(tagMedian.Key, MeanValue(tagMedian.Value));
        }

        foreach (var serieAnalysisResults in seriesAnalysisResults)
        {
            magnitudeTag = MagnitudeTag(serieAnalysisResults.Median, tagMeans[serieAnalysisResults.MeanOfMedianTag]);
            serieAnalysisResults.MagnitudeTag = magnitudeTag;
        }

        return seriesAnalysisResults;
    }

    private double[] TrimSerie(double[] arr)
    {
        foreach (double d in arr)
        {
            if (d != 0.0 || d != 0)
                break;

            arr = arr.Where(
                (val, index) => index != Array.IndexOf(arr, d)
            ).ToArray();
        }
        return arr;
    }

    private string MagnitudeTag(double median, double medianMean)
    {
        string serieTag = "Normale";
        if (medianMean * MaxMagnitudeThreshold <= median)
            serieTag = "Grassa";
        else if (medianMean * MinMagnitudeThreshold >= median)
            serieTag = "Magra";
        return serieTag;
    }

    private int Buckets(double[] arr)
    {
        return arr.Count(
            n => (n != 0 || n != 0.0)
        );
    }

    private int NullStreak(double[] arr)
    {
        int nullBucketsStreak = 0;
        int maxStreak = 0;

        foreach (double d in arr)
        {
            if (d == 0 || d == 0.0)
            {
                nullBucketsStreak++;
            }
            else
            {
                if (maxStreak < nullBucketsStreak)
                    maxStreak = nullBucketsStreak;
                nullBucketsStreak = 0;
            }
        }

        if (maxStreak < nullBucketsStreak)
            maxStreak = nullBucketsStreak;

        return maxStreak;
    }

    private double MedianValue(double[] arr)
    {
        double[] sortedArr = arr.OrderBy(num => num).ToArray();

        int size = sortedArr.Length;
        int mid = size / 2;

        if (size % 2 != 0)
            return sortedArr[mid];

        double value1 = sortedArr[mid];
        double value2 = sortedArr[mid - 1];
        return (value1 + value2) / 2;
    }

    private double MeanValue(List<double> arr)
    {
        return arr.Average();
    }

    private bool IsSporadic(double[] arr)
    {
        int nullBuckets = 0;

        foreach (double d in arr)
        {
            if (d == 0)
                nullBuckets++;
        }

        return (nullBuckets * 100 / arr.Length) > SporadicThreshold;
    }

    private bool IsNumerous(double[] arr)
    {
        return arr.Length > NumerosityThreshold;
    }


}
