using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        var wordSet = new HashSet<string>(words); // O(n)
        var result = new List<string>();
        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // Skip words with the same letters (e.g., "aa")
            var reversedWord = $"{word[1]}{word[0]}"; // Reverse the word (e.g., "am" -> "ma")
            // Check if the reversed word exists in the set and is not the same as the original word
            if (wordSet.Contains(reversedWord) && word != reversedWord)
            {
                result.Add($"{word} & {reversedWord}"); // Add the pair to the result
                // Remove both words from the set to avoid duplicates
                wordSet.Remove(word);
                wordSet.Remove(reversedWord);
            }
        }
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            if (fields.Length < 4) continue; // Skip lines with fewer than 4 fields
            var degree = fields[3].Trim(); // Get the degree from the 4th column and trim whitespace
            if (string.IsNullOrEmpty(degree)) continue; // Skip empty degrees
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++; // Increment the count if the degree already exists
            }
            else
            {
                degrees[degree] = 1; // Initialize the count to 1 if it's a new degree
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        if (string.IsNullOrWhiteSpace(word1) || string.IsNullOrWhiteSpace(word2)) {
            return false; // If either word is null or empty, they cannot be anagrams
        }
        word1 = word1.Replace(" ", "").ToLower(); // Remove spaces and convert to lowercase the first word
        word2 = word2.Replace(" ", "").ToLower(); // Remove spaces and convert to lowercase the second word
        if (word1.Length != word2.Length) {
            return false; // If lengths differ, they cannot be anagrams
        }
        var charCount = new Dictionary<char, int>();
        // Count characters in the first word
        foreach (char c in word1)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }
        // Subtract character counts using the second word
        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c))
            {
                return false; // If character in word2 is not found in word1, they are not anagrams
            }
            charCount[c]--;
            if (charCount[c] < 0){
                    return false; // More occurrences in word2 than in word1
            }
        }
        // Check if all counts are zero
        foreach (char count in charCount.Values)
        {
            if (count != 0)
            {
                return false; // If any count is not zero, they are not anagrams
            }
        }
        return true; // All counts are zero, so they are anagrams
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        var result = new List<string>(); // Initialize a list to hold the results
        if (featureCollection?.Features != null) // Check if Features is not null
        {
            foreach (var feature in featureCollection.Features) // Iterate through each feature
            {
                var place = feature.Properties.Place; // Get the place name from the feature properties
                var mag = feature.Properties.Mag; // Get the magnitude from the feature properties

                if (!string.IsNullOrEmpty(place) && mag.HasValue) // Check if place is not null or empty and magnitude has a value
                {
                    result.Add($"{place} - Mag {mag.Value:F2}"); // Format the string and add it to the result list
                }
            }
        }
        return result.ToArray();// Convert the list to an array and return it
    }
}