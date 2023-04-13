/// <summary>Classe <c>SerieAnalysisResult</c> modella il risultato di una analisi di una serie storica
/// </summary>
public class SerieAnalysisResult
{

    public bool IsShort { get; set; }
    public bool IsSporadic { get; set; }
    public Magnitude MagnitudeClass { get; set; }
    public int NumberOfBuckets { get; set; }
    public int NullBucketsStreak { get; set; }
    public double Median { get; set; }
    public string Tag { get; set; }
    public double TagMeanOfMedian { get; set; }

    /// <summary> Construttore per creare una SerieAnalysisResult
    /// (<paramref name="isShort"/>,
    /// <paramref name="isSporadic"/>,
    /// <paramref name="magnitudeClass"/>,
    /// <paramref name="numberOfBuckets"/>,
    /// <paramref name="nullBucketsStreak"/>,
    /// <paramref name="median"/>,
    /// <paramref name="tag"/>),
    /// <paramref name="tagMeanOfMedian"/>.
    /// </summary>
    /// <param name="isShort">
    /// true se una serie è corta; altrimenti false </param>
    /// <param name="isSporadic">
    /// true se una serie è sporadica; altrimenti false. </param>
    /// <param name="magnitudeClass">
    /// Indica l'Ordine di Grandezza della serie. I valori permessi sono Magra, Normale, Grassa. </param>
    /// <param name="numberOfBuckets">
    /// Numero di Bucket nella serie (senza quelli nulli iniziali). </param>
    /// <param name="nullBucketsStreak">
    /// Numero massimo di Bucket nulli consecutivi nella serie. </param>
    /// <param name="median">
    /// Mediana della serie. </param>
    /// <param name="tag">
    /// Tag assegnato alla serie in input. </param>
    /// <param name="tagMeanOfMedian">
    /// Media delle mediane delle serie con lo stesso tag. </param>
    public SerieAnalysisResult(bool isShort, bool isSporadic, Magnitude magnitudeClass, 
        int numberOfBuckets, int nullBucketsStreak, double median, string tag, double tagMeanOfMedian)
    {
        IsShort = isShort;
        IsSporadic = isSporadic;
        MagnitudeClass = magnitudeClass;
        NumberOfBuckets = numberOfBuckets;
        NullBucketsStreak = nullBucketsStreak;
        Median = median;
        Tag = tag;
        TagMeanOfMedian = tagMeanOfMedian;
    }

    /// <summary> Construttore per inizializzare una SerieAnalysisResult senza MagnitudeTag e senza TagMedianMean
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
        Tag = meanOfMedianTag;
    }

    public String toString(){
        return 
            "Numerosa: " + IsShort + "\n" +
            "Sporadica: " + IsSporadic + "\n" +
            "MagnitudeTag: " + Enum.GetName(typeof(Magnitude), MagnitudeClass) + "\n" +
            "Bucket Non Nulli: " + NumberOfBuckets + "\n" +
            "Streak Nulla: " + NullBucketsStreak + "\n" +
            "Tag Serie: " + Tag + "\n" +
            "Mediana: " + Median + "\n" +
            "Media delle Mediane" + TagMeanOfMedian;
    }
}