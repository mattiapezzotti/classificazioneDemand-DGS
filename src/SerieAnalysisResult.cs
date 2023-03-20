public class SerieAnalysisResult{
    public string NumerosityTag {get; set;}
    public string SporadicityTag {get; set;}
    public string MagnitudeTag {get; set;}
    public int NumberOfBuckets {get; set;}
    public int NullBucketsStreak {get; set;}

    public SerieAnalysisResult(string numerosityTag, string sporadicityTag, string magnitudeTag, int numberOfBuckets, int nullBucketsStreak){
        NumerosityTag = numerosityTag;
        SporadicityTag = sporadicityTag;
        MagnitudeTag = magnitudeTag;
        NumberOfBuckets = numberOfBuckets;
        NullBucketsStreak = nullBucketsStreak;
    }
}