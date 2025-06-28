using System.Runtime.CompilerServices;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        double[] multiples = new double[length]; // Create an array of doubles with the specified length
        multiples[0] = number; // Set the first element of the array to the input number
        for (int i = 1; i < length; i++) // Fill the array with multiples of the number
        {
            multiples[i] = multiples[i - 1] + number; // Each element is the previous one plus the number
        }
        return multiples; // Return the array containing the multiples
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        if (amount == 0 || data.Count == 0) // If the amount is zero or the list is empty, do nothing
        {
            return; // Exit the function early
        }

        List<int> rotated = new List<int>(); // Create a new list to hold the rotated elements
        for (int i = 0; i < data.Count; i++) // Iterate through each element in the original list
        {
            int pos = i; // Start with the current index as the position
            for (int mov = 0; mov < amount; mov++) // Move the position to the right by the specified amount
            {
                pos--; // Move the position to the left by one
                if (pos < 0) // If the position goes below zero, wrap around to the end of the list
                {
                    pos = data.Count - 1;
                }
            }
            rotated.Add(data[pos]); // Add the element at the new position to the rotated list
        }
        for (int i = 0; i < data.Count; i++) // Iterate through the original list to update it
        {
            data[i] = rotated[i]; // Replace each element in the original list with the corresponding element from the rotated list
        }
    }
}
