using System.Text.Json;

public class FakeDB
{
    /*
    Random rand = new Random();
    const int MAX_SERIE_SIZE = 36;
    const int MIN_SERIE_SIZE = 1;

    public FakeDB() { }

    public double[] GenerateArray()
    {
        int arraySize = rand.Next(MIN_SERIE_SIZE, MAX_SERIE_SIZE);

        double[] array = new double[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            array[i] = Math.Round(rand.NextDouble() * 100, 2);
        }

        return array;
    }

    public List<Serie> GenerateSerie(){
        List<Serie> series = new List<Serie>();
        double[][] mat = new double[][]
        {
            new double[] { 0,2,3,4,5,6,7,8,9,10 },   
            new double[] { 0,0,5,0,0,10,11,12,1,0 },
            new double[] { 0,0,0,4,0,10,11,12,0,0 },
            new double[] { 0,0,2,5,6,10,11,12,0,0 },
            new double[] { 10,8,7,9,0,0,0,0,0,0 },
            new double[] { 12,13,14,15,16,17,0,0,0,1 }
        };

        for(int i = 0; i < 6; i++){
            Serie serie = new Serie(mat[i], "");
            series.Add(serie);
        }
        return series;
    }
    */

    public List<Serie> readFromFile(string filename){
        string jsonString = File.ReadAllText(filename);
        List<Serie> serieJSON = JsonSerializer.Deserialize<List<Serie>>(jsonString)!;

        return serieJSON;
    }

    public void printToFile(List<SerieAnalysisResult> result, string filename){
        string jsonString = JsonSerializer.Serialize(result);
        File.WriteAllText(filename, jsonString);
    }
}