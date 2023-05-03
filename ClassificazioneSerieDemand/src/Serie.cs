/// <summary>Classe <c>Serie</c> modella una serie con Tag e Valori
/// </summary>
public class Serie
{

    public double[] Values { get; set; }
    public string Tag { get; set; }

    /// <summary> Construttore per inizializzare una Serie
    /// (<paramref name="values"/>,
    /// <paramref name="tag"/>).
    /// </summary>
    /// <param name="values">
    /// Array di double che contiene i valori dei bucket della serie </param>
    /// <param name="tag">
    /// Tag alfanumerico attribuito alla serie. </param>
    public Serie(double[] values, string tag)
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