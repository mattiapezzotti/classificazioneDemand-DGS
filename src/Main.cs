FakeDB fakeDB = new FakeDB();

List<Serie> series = fakeDB.readFromFile("fakeDatabase.json");

/*
foreach(Serie s in series)
    Console.WriteLine(s.toString());
*/

int numerosityThreshold = 12;
double sporadicThreshold = 0.5;
double minMagnitudeThreshold = 0.2;
double maxMagnitudeThreshold = 1.5;

List<SerieAnalysisResult> seriesAnalysisResults = new List<SerieAnalysisResult>();

SeriesAnalyzer seriesAnalyzer = new SeriesAnalyzer(numerosityThreshold, sporadicThreshold, minMagnitudeThreshold, maxMagnitudeThreshold);
seriesAnalysisResults = seriesAnalyzer.AnalyzeSeries(series);

fakeDB.printToFile(seriesAnalysisResults, "fakeResults.json");