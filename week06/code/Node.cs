public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) // Ensure we do not insert duplicates
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)// Check if the value is equal to the current node's value
        {
            return true;
        }
        else if (value < Data && Left != null)// Check if the value is less than the current node's value
        {
            return Left.Contains(value);// Check the left subtree
        }
        else if (value > Data && Right != null)// Check if the value is greater than the current node's value
        {
            return Right.Contains(value);// Check the right subtree
        }
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = Left?.GetHeight() ?? 0; // If Left is null, height is 0
        int rightHeight = Right?.GetHeight() ?? 0; // If Right is null, height is 0
        return 1 + Math.Max(leftHeight, rightHeight);// the height of the tree is 1 plus the maximum height of the left and right subtrees
    }

    //additional code for the Node class
    public IEnumerable<int> TraverseBackwards() // Traverse the tree in reverse order (right, root, left)
    {
        if (Right != null)// Check if the right subtree exists
        {
            foreach (var value in Right.TraverseBackwards())// Traverse the right subtree
            {
                yield return value;
            }
        }

        yield return Data;

        if (Left != null)// Traverse the left subtree
        {
            foreach (var value in Left.TraverseBackwards())// Traverse the left subtree
            {
                yield return value;
            }
        }
    }
}