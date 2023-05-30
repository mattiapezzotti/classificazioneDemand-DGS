/// <summary>Classe <c>Serie</c> modella una serie con Tag e Valori
/// </summary>
public class Serie
{
    public string Tag { get; set; }
    public double[] Values { get; set; }

    /// <summary> Construttore per inizializzare una Serie
    /// (<paramref name="tag"/>, <paramref name="values"/>).
    /// </summary>
    /// <param name="values">
    /// Array di double che contiene i valori dei bucket della serie </param>
    /// <param name="tag">
    /// Tag alfanumerico attribuito alla serie. </param>
    public Serie(string tag, double[] values)
    {
        Values = values;
        Tag = tag;
    }

    public string toString(){
        string values = "[";
        foreach(double d in Values)
            values += d + ", ";
        return "Tag: " + Tag + "\n" + "Values: " + values.Remove(values.Length - 2) + "]";
    }
}