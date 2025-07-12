using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities, then dequeue all.
    // Expected Result: Each dequeue returns the item with the highest priority at that time.
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        //Assert.Fail("Implement the test case and then remove this.");

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // B has the highest priority (3)
        Assert.AreEqual("C", priorityQueue.Dequeue()); // C is next (2)
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Then A (1)
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority, then dequeue all.
    // Expected Result: When there is a tie, dequeue returns the earliest inserted item (FIFO among equals).
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        //Assert.Fail("Implement the test case and then remove this.");

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // B and C have highest priority (5), B was inserted first
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Now C (still priority 5)
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Next highest is D (3)
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Last is A (2)
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with increasing priorities, then dequeue all.
    // Expected Result: Dequeue should always return the latest enqueued item.
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue()); // Highest is C (3)
        Assert.AreEqual("B", priorityQueue.Dequeue()); // Next is B (2)
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Last is A (1)
    }

    [TestMethod]
    // Scenario: Enqueue multiple items, all with the same priority.
    // Expected Result: Dequeue should return items in the order they were added (FIFO).
    // Defect(s) Found: 
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 7);
        priorityQueue.Enqueue("Y", 7);
        priorityQueue.Enqueue("Z", 7);

        Assert.AreEqual("X", priorityQueue.Dequeue());
        Assert.AreEqual("Y", priorityQueue.Dequeue());
        Assert.AreEqual("Z", priorityQueue.Dequeue());
    }
}