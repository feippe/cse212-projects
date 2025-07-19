public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> Features { get; set; } // List of features in the collection
}

public class Feature
{
    public Properties Properties { get; set; } // Properties of the feature
}

public class Properties
{
    public string Place { get; set; } // The name of the place
    public double? Mag { get; set; } // The magnitude of the earthquake
}