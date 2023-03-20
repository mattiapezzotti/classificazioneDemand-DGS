const int NUMBER_OF_SERIES = 10;

FakeDB fakeDB = new FakeDB();
List<Serie> series = new List<Serie>();

for(int i = 0; i < NUMBER_OF_SERIES; i++){

    double[] newArray = fakeDB.GenerateArray();
    Serie newSerie = new Serie(newArray, "");

    series.Add(newSerie);
}

int numerosityThreshold = 12;
double sporadicThreshold = 0.5;
double minMagnitudeThreshold = 0.2;
double maxMagnitudeThreshold = 1.8;

SeriesAnalyzer seriesAnalyzer = new SeriesAnalyzer(numerosityThreshold, sporadicThreshold, minMagnitudeThreshold, maxMagnitudeThreshold);
seriesAnalyzer.AnalyzeSeries(series);
