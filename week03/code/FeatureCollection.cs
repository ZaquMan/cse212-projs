using System.Reflection.Metadata.Ecma335;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Feature[] features { get; set; }

}

public class Feature
{
    public string Type { get; set; }
    public Earthquake Properties { get; set; }
}

public class Earthquake
{
    public float Mag { get; set; }
    public string Place { get; set; }
}