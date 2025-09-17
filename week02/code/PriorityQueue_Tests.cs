using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{

    /* 
      The code is fixed in order to ensure that the index of the highest priority value is removed first from the queue.
      If there is tight, then the code ensure that the first occurence of the tight is maintained and removed.
    */
    [TestMethod]
    // Scenario: Two item with the same values in the queue.
    // Expected Result: The result is expected to remove the item with the first ocurrence of equal value.
    // Item5, Item6, Item3, Item4, Item1, Item2 are the expected result
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
      
       // Assert.Fail("Implement the test case and then remove this.");
        var Item1 = new PriorityItem("First", 3);
        var Item2 = new PriorityItem("Second", 2);
        var Item3 =  new PriorityItem("Third", 4);
        var Item4 = new PriorityItem("Fourth", 4);
        var Item5 = new PriorityItem("Fith", 7);
        var Item6 = new PriorityItem("Sixth", 5); 
        PriorityItem[] ExpectedResult = [Item5, Item6, Item3, Item4, Item1, Item2];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(Item1.Value, Item1.Priority);
        priorityQueue.Enqueue(Item2.Value, Item2.Priority);
        priorityQueue.Enqueue(Item3.Value, Item3.Priority);
        priorityQueue.Enqueue(Item4.Value, Item4.Priority);
        priorityQueue.Enqueue(Item5.Value, Item5.Priority);
        priorityQueue.Enqueue(Item6.Value, Item6.Priority);

        int i = 0;
        for(; i < ExpectedResult.Length; i++){
             string value = priorityQueue.Dequeue();
             Assert.AreEqual(ExpectedResult[i].Value, value);
        }
    }

    [TestMethod]
    // Scenario: Item is Added at the back of the queue, but remove from the queue  based on the highest priority value.
    // Expected Result: Item4, Item5, Item3, Item1, Item2, the expected result is the have a list of item starting with the highest value to the lowest.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        
      
        var Item1 = new PriorityItem("First", 3);
        var Item2 = new PriorityItem("Second", 2);
        var Item3 =  new PriorityItem("Third", 4);
        var Item4 = new PriorityItem("Fouth", 7);
        var Item5 = new PriorityItem("Fith", 5); 
        PriorityItem[] ExpectedResult = [Item4, Item5, Item3, Item1, Item2];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(Item1.Value, Item1.Priority);
        priorityQueue.Enqueue(Item2.Value, Item2.Priority);
        priorityQueue.Enqueue(Item3.Value, Item3.Priority);
        priorityQueue.Enqueue(Item4.Value, Item4.Priority);
        priorityQueue.Enqueue(Item5.Value, Item5.Priority);
       
        int i = 0;
        for(; i < ExpectedResult.Length; i++){
             string value = priorityQueue.Dequeue();
             Assert.AreEqual(ExpectedResult[i].Value, value);
        }
    }

    // Add more test cases as needed below.
    [TestMethod]
      // Scenario: Try to get the next person from an empty queue
      // Expected Result: Exception should be thrown with appropriate error message.
      // Defect(s) Found:
    public void TestPriorityQueue_3(){
        var priorityQueue = new PriorityQueue();

        try
        {
            string value = priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

}