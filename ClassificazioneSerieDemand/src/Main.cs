FakeDB fakeDB = new FakeDB();

//List<Serie> series = fakeDB.readFromJSON("fakeDatabase.json");

List<Serie> series = fakeDB.readFromCSV("fakeDatabaseCSV.csv");
fakeDB.printSerieToJSON(series, "input.json");

int numerosityThreshold = 8;
double sporadicThreshold = 0.5;
double minMagnitudeThreshold = 0.2;
double maxMagnitudeThreshold = 1.5;

List<SerieAnalysisResult> seriesAnalysisResults = new List<SerieAnalysisResult>();

SeriesAnalyzer seriesAnalyzer = new SeriesAnalyzer(numerosityThreshold, sporadicThreshold, minMagnitudeThreshold, maxMagnitudeThreshold);
seriesAnalysisResults = seriesAnalyzer.AnalyzeSeries(series);

fakeDB.printResultToJSON(seriesAnalysisResults, "fakeResults.json");
