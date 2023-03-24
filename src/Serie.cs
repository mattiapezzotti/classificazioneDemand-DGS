public class Serie
{

    public double[] Values { get; set; }
    public string Tag { get; set; }

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