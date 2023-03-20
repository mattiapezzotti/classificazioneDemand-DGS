public class FakeDB{
    Random rand = new Random();
    const int MAX_SERIE_SIZE = 36;
    const int MIN_SERIE_SIZE = 1;

    public FakeDB(){}

    public double[] GenerateArray(){
        int arraySize = rand.Next(MIN_SERIE_SIZE, MAX_SERIE_SIZE);
        
        double[] array = new double[arraySize];
        for(int i = 0; i < arraySize; i++){
            array[i] = rand.Next();
        }

        return array;
    }

    public void GetDataFromJSON(){

    }
}