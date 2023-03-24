public class SerieAnalysisResult
{
    public bool IsNumerous { get; set; }
    public bool IsSporadic { get; set; }
    public string MagnitudeTag { get; set; }
    public int NumberOfBuckets { get; set; }
    public int NullBucketsStreak { get; set; }
    public double Median { get; set; }
    public string MeanOfMedianTag { get; set; }

    public SerieAnalysisResult(bool isNumerous, bool isSporadic, string magnitudeTag, int numberOfBuckets, int nullBucketsStreak, double median, string meanOfMedianTag)
    {
        IsNumerous = isNumerous;
        IsSporadic = isSporadic;
        MagnitudeTag = magnitudeTag;
        NumberOfBuckets = numberOfBuckets;
        NullBucketsStreak = nullBucketsStreak;
        Median = median;
        MeanOfMedianTag = meanOfMedianTag;
    }

    public SerieAnalysisResult(bool isNumerous, bool isSporadic, int numberOfBuckets, int nullBucketsStreak, double median, string meanOfMedianTag)
    {
        IsNumerous = isNumerous;
        IsSporadic = isSporadic;
        NumberOfBuckets = numberOfBuckets;
        NullBucketsStreak = nullBucketsStreak;
        Median = median;
        MeanOfMedianTag = meanOfMedianTag;
    }

    public String toString(){
        return 
            "Numerosa: " + IsNumerous + "\n" +
            "Sporadica: " + IsSporadic + "\n" +
            "MagnitudeTag: " + MagnitudeTag + "\n" +
            "Bucket Non Nulli: " + NumberOfBuckets + "\n" +
            "Streak Nulla: " + NullBucketsStreak + "\n" +
            "Media delle Mediane del Tag: " + MeanOfMedianTag + "\n" +
            "Mediana: " + Median;
    }
}