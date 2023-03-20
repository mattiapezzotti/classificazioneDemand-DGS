public class Serie{
    
    public double[] Values{get; set;}
    public string Tag {get; set;}

    public Serie(double[] values, string tag){
        Values = values;
        Tag = tag;
    }
}