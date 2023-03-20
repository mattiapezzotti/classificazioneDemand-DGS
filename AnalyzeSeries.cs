public class SeriesAnalyzer{
    public int NumerosityThreshold{get; set;}
    public double SporadicThreshold{get; set;}
    public double MinMagnitudeThreshold{get; set;}
    public double MaxMagnitudeThreshold{get; set;}

    public SeriesAnalyzer(int numerosityThreshold, double sporadicThreshold, double minMagnitudeThreshold, double maxMagnitudeThreshold){
        NumerosityThreshold = numerosityThreshold;
        SporadicThreshold = sporadicThreshold;
        MinMagnitudeThreshold = minMagnitudeThreshold;
        MaxMagnitudeThreshold = maxMagnitudeThreshold;
    }

    // Il metodo in realtà ritorna List<SerieAnalysisResult>
    public void AnalyzeSeries(List<Serie> series){
        foreach(Serie serie in series){
            //TODO: codice serissimo
        }
    }
    

}
