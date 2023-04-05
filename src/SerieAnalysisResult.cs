/// <summary>Classe <c>SerieAnalysisResult</c> modella il risultato di una analisi di una serie storica
/// </summary>
public class SerieAnalysisResult
{
    public bool IsShort { get; set; }
    public bool IsSporadic { get; set; }
    public string MagnitudeTag { get; set; }
    public int NumberOfBuckets { get; set; }
    public int NullBucketsStreak { get; set; }
    public double Median { get; set; }
    public string MeanOfMedianTag { get; set; }

    /// <summary> Construttore per creare una SerieAnalysisResult
    /// (<paramref name="isShort"/>,
    /// <paramref name="isSporadic"/>,
    /// <paramref name="magnitudeTag"/>,
    /// <paramref name="numberOfBuckets"/>,
    /// <paramref name="nullBucketsStreak"/>,
    /// <paramref name="median"/>,
    /// <paramref name="meanOfMedianTag"/>).
    /// </summary>
    /// <param name="isShort">
    /// true se una serie è corta; altrimenti false </param>
    /// <param name="isSporadic">
    /// true se una serie è sporadica; altrimenti false. </param>
    /// <param name="magnitudeTag">
    /// Indica l'Ordine di Grandezza della serie. I valori permessi sono Magra, Normale, Grassa. </param>
    /// <param name="numberOfBuckets">
    /// Numero di Bucket nella serie (senza quelli nulli iniziali). </param>
    /// <param name="nullBucketsStreak">
    /// Numero massimo di Bucket nulli consecutivi nella serie. </param>
    /// <param name="median">
    /// Mediana della serie. </param>
    /// <param name="meanOfMedianTag">
    /// Media delle mediane delle serie con lo stesso tag. </param>
    public SerieAnalysisResult(bool isShort, bool isSporadic, string magnitudeTag, 
        int numberOfBuckets, int nullBucketsStreak, double median, string meanOfMedianTag)
    {
        IsShort = isShort;
        IsSporadic = isSporadic;
        MagnitudeTag = magnitudeTag;
        NumberOfBuckets = numberOfBuckets;
        NullBucketsStreak = nullBucketsStreak;
        Median = median;
        MeanOfMedianTag = meanOfMedianTag;
    }

    /// <summary> Construttore per inizializzare una SerieAnalysisResult senza MagnitudeTag
    /// (<paramref name="isShort"/>,
    /// <paramref name="isSporadic"/>,
    /// <paramref name="numberOfBuckets"/>,
    /// <paramref name="nullBucketsStreak"/>,
    /// <paramref name="median"/>,
    /// <paramref name="meanOfMedianTag"/>).
    /// </summary>
    /// <param name="isShort">
    /// true se una serie è corta; altrimenti false </param>
    /// <param name="isSporadic">
    /// true se una serie è sporadica; altrimenti false. </param>
    /// <param name="numberOfBuckets">
    /// Numero di Bucket nella serie (senza quelli nulli iniziali). </param>
    /// <param name="nullBucketsStreak">
    /// Numero massimo di Bucket nulli consecutivi nella serie. </param>
    /// <param name="median">
    /// Mediana della serie. </param>
    /// <param name="meanOfMedianTag">
    /// Media delle mediane delle serie con lo stesso tag. </param>
    public SerieAnalysisResult(bool isShort, bool isSporadic, int numberOfBuckets, 
        int nullBucketsStreak, double median, string meanOfMedianTag)
    {
        IsShort = isShort;
        IsSporadic = isSporadic;
        NumberOfBuckets = numberOfBuckets;
        NullBucketsStreak = nullBucketsStreak;
        Median = median;
        MeanOfMedianTag = meanOfMedianTag;
    }

    public String toString(){
        return 
            "Numerosa: " + IsShort + "\n" +
            "Sporadica: " + IsSporadic + "\n" +
            "MagnitudeTag: " + MagnitudeTag + "\n" +
            "Bucket Non Nulli: " + NumberOfBuckets + "\n" +
            "Streak Nulla: " + NullBucketsStreak + "\n" +
            "Media delle Mediane del Tag: " + MeanOfMedianTag + "\n" +
            "Mediana: " + Median;
    }
}