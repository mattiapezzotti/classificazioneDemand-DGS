using System.Text.Json;

public class FakeDB
{

    public List<Serie> readFromJSON(string filename){
        string jsonString = File.ReadAllText(filename);
        List<Serie> serieJSON = JsonSerializer.Deserialize<List<Serie>>(jsonString)!;

        return serieJSON;
    }

    public void printResultToJSON(List<SerieAnalysisResult> result, string filename){
        string jsonString = JsonSerializer.Serialize(result);
        File.WriteAllText(filename, jsonString);
    }

    public void printSerieToJSON(List<Serie> result, string filename){
        string jsonString = JsonSerializer.Serialize(result);
        File.WriteAllText(filename, jsonString);
    }

    public List<Serie> readFromCSV(string filename)
    {
        var reader = new StreamReader(filename);
        List<Serie> seriesCSV = new List<Serie>();

        reader.ReadLine();

        while (!reader.EndOfStream){
            var line = reader.ReadLine();

            if(line == null)
                continue;

            string[] values = line.Split(';');

            string tag = values[0];
            var sValues = values.Skip(2).Take(values.Length - 1).ToList();
            sValues = sValues.Select(x => x.Replace(".", ",")).ToList();
            sValues = sValues.Select(x => x.Replace("NULL", "0")).ToList();

            double[] dValues = sValues.ConvertAll(new Converter<string, Double>(Convert.ToDouble)).ToArray();

            seriesCSV.Add(new Serie(tag, dValues));
        }

        return seriesCSV;
    }
}