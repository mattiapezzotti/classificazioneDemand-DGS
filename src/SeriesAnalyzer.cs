/// <summary>Classe <c>SeriesAnalyzer</c> per analizzare le serie storiche
/// </summary>
public class SeriesAnalyzer
{
    public int NumerosityThreshold { get; set; }
    public double SporadicThreshold { get; set; }
    public double MinMagnitudeThreshold { get; set; }
    public double MaxMagnitudeThreshold { get; set; }

    /// <summary> Construttore per inizializzare SeriesAnalyzer
    /// (<paramref name="numerosityThreshold"/>,
    /// <paramref name="sporadicThreshold"/>,
    /// <paramref name="minMagnitudeThreshold"/>,
    /// <paramref name="maxMagnitudeThreshold"/>).
    /// </summary>
    /// <param name="numerosityThreshold">
    /// Limite numerico superiore per cui una serie è considerata corta. </param>
    /// <param name="sporadicThreshold">
    /// Limite percentuale superiore per cui una serie è considerata sporadica (valori tra 0 e 1). </param>
    /// <param name="minMagnitudeThreshold">
    /// Limite percentuale inferiore per cui una serie è considerata <c>Normale</c>. 
    /// Al di sotto viene considerata <c>Magra</c> </param>
    /// <param name="maxMagnitudeThreshold">
    /// Limite percentuale superiore per cui una serie è considerata <c>Normale</c>. 
    /// Al di sopra viene considerata <c>Grassa</c> </param>
    public SeriesAnalyzer(int numerosityThreshold, double sporadicThreshold,
        double minMagnitudeThreshold, double maxMagnitudeThreshold)
    {
        NumerosityThreshold = numerosityThreshold;
        SporadicThreshold = sporadicThreshold;
        MinMagnitudeThreshold = minMagnitudeThreshold;
        MaxMagnitudeThreshold = maxMagnitudeThreshold;
    }

    /// <summary> Metodo principale utilizzato per analizzare una lista di serie
    /// (<paramref name="series"/>)
    /// </summary>
    /// <param name="series"> Lista di serie. </param> 
    /// <returns> Una <c>List</c> di <c>SerieAnalysisResult</c>, con posizioni corrispondenti alla lista in input </returns>
    public List<SerieAnalysisResult> AnalyzeSeries(List<Serie> series)
    {

        bool isShort;
        bool isSporadic;
        string magnitudeTag;
        int numberOfBuckets;
        int nullBucketsStreak;
        double median;

        // Dizionari utilizzati per tenere traccia delle Mediane di ogni serie per ogni tag
        var tagMedians = new Dictionary<string, List<double>>();

        // Dizionari utilizzati per tenere traccia della Media di ogni Mediana
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
            
            isShort = IsShort(serieValues);
            isSporadic = IsSporadic(serieValues);
            numberOfBuckets = CountBuckets(serieValues);
            nullBucketsStreak = NullStreak(serieValues);

            SerieAnalysisResult serieAnalysisResult = new SerieAnalysisResult(
                isShort, isSporadic, numberOfBuckets, nullBucketsStreak, median, serie.Tag
            );
            seriesAnalysisResults.Add(serieAnalysisResult);
        }

        // Per ogni Mediana associo la corrispondente Media delle Mediane
        foreach(var tagMedian in tagMedians){
            tagMeans.Add(tagMedian.Key, MeanValue(tagMedian.Value.ToArray()));
        }

        // Per ogni Serie calcolo il corrispondente tag (Magra, Normale, Grassa)
        foreach (var serieAnalysisResults in seriesAnalysisResults)
        {
            magnitudeTag = MagnitudeTag(serieAnalysisResults.Median, tagMeans[serieAnalysisResults.MeanOfMedianTag]);
            serieAnalysisResults.MagnitudeTag = magnitudeTag;
        }

        return seriesAnalysisResults;
    }

    /// <summary> Rimuove i Bucket nulli a inizio serie se presenti
    /// </summary>
    /// <param name="series"> Una Serie Storica. </param> 
    /// <returns> Una copia della <c>Serie Storica</c>, senza Bucket nulli iniziali </returns>
    private double[] TrimSerie(double[] serie)
    {
        foreach (double d in serie)
        {
            if (d != 0.0 || d != 0)
                break;

            serie = serie.Where(
                (val, index) => index != Array.IndexOf(serie, d)
            ).ToArray();
        }
        return serie;
    }

    /// <summary> Calcola il tag per ogni 
    /// </summary>
    /// <param name="series"> Una Serie Storica. </param> 
    /// <returns> Una copia della <c>Serie Storica</c>, senza Bucket nulli iniziali </returns>
    private string MagnitudeTag(double median, double medianMean)
    {
        string serieTag = "Normale";
        if (medianMean * MaxMagnitudeThreshold <= median)
            serieTag = "Grassa";
        else if (medianMean * MinMagnitudeThreshold >= median)
            serieTag = "Magra";
        return serieTag;
    }

    /// <summary> Conta il numero di Bucket non nulli
    /// </summary>
    /// <param name="series"> Una Serie Storica. </param> 
    /// <returns> Un <c>int</c>, il numero di bucket non nulli </returns>
    private int CountBuckets(double[] serie)
    {
        return serie.Count(
            n => (n != 0 || n != 0.0)
        );
    }

    /// <summary> Conta il numero massimo di Bucket non nulli in fila
    /// </summary>
    /// <param name="series"> Una Serie Storica. </param> 
    /// <returns> Un <c>int</c>, il numero di bucket non nulli in fila </returns>
    private int NullStreak(double[] serie)
    {
        int nullBucketsStreak = 0;
        int maxStreak = 0;

        foreach (double d in serie)
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

    /// <summary> Calcola il valore mediano della Serie
    /// </summary>
    /// <param name="series"> Una Serie Storica. </param> 
    /// <returns> Un <c>double</c>, il valore medio della Serie </returns>
    private double MedianValue(double[] serie)
    {
        double[] sortedArr = serie.OrderBy(num => num).ToArray();

        int size = sortedArr.Length;
        int mid = size / 2;

        if (size % 2 != 0)
            return sortedArr[mid];

        double value1 = sortedArr[mid];
        double value2 = sortedArr[mid - 1];
        return (value1 + value2) / 2;
    }

    /// <summary> Calcola il valore medio della Serie
    /// </summary>
    /// <param name="series"> Una Serie Storica. </param> 
    /// <returns> Un <c>double</c>, il valore medio della Serie </returns>
    private double MeanValue(double[] serie)
    {
        return serie.Average();
    }

    /// <summary> Calcola se una serie è Sporadica 
    /// (se ha un numero di bucket inferiore a sporadicThreshold)
    /// </summary>
    /// <param name="series"> Una Serie Storica. </param> 
    /// <returns> <c>true</c> se sporadica; altrimenti <c>false</c> </returns>
    private bool IsSporadic(double[] serie)
    {
        int nullBuckets = 0;

        foreach (double d in serie)
        {
            if (d == 0)
                nullBuckets++;
        }

        return (nullBuckets * 100 / serie.Length) > SporadicThreshold;
    }

    /// <summary> Calcola se una serie è corta 
    /// (se ha un numero di bucket inferirore a numerosityThreshold)
    /// </summary>
    /// <param name="series"> Una Serie Storica. </param> 
    /// <returns> <c>true</c> se corta; altrimenti <c>false</c> </returns>
    private bool IsShort(double[] serie)
    {
        return serie.Length < NumerosityThreshold;
    }


}
