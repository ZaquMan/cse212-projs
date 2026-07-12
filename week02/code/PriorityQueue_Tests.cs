using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items and priorities: Moon (2), Asteroid (1), Planet (3)
    // and run until the queue is empty
    // Expected Result: Planet, Moon, Asteroid
    // Defect(s) Found: The Dequeue function is not returning the item with the highest priority.
    //    Issue 1: The Dequeue function is stopping short of checking the last item in the queue.
    //    Issue 2: The Dequeue function is not removing the item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        //Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("Moon", 2);
        priorityQueue.Enqueue("Asteroid", 1);
        priorityQueue.Enqueue("Planet", 3);

        string[] expectedResult = ["Planet", "Moon", "Asteroid"];

        for (int i = 0; i < expectedResult.Count(); i++)
        {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], value);
        }
        Assert.AreEqual("[]", priorityQueue.ToString()); // The queue should be empty at the end.

    }

    [TestMethod]
    // Scenario: Create a queue with the following items and priorities: Moon (2), Station (2), Planet(3)
    // amd run until the queue is empty
    // Expected Result: Planet, Moon, Station
    // Defect(s) Found: The first entry with equal priorities is not being returned
    //    Issue 3: The Dequeue function is checking if priorities are greater OR EQUAL when updating the highest priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        //Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("Moon", 2);
        priorityQueue.Enqueue("Station", 2);
        priorityQueue.Enqueue("Planet", 3);

        string[] expectedResult = ["Planet", "Moon", "Station"];

        for (int i = 0; i < expectedResult.Count(); i++)
        {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], value);
        }
        Assert.AreEqual("[]", priorityQueue.ToString()); // The queue should be empty at the end.
    }

    [TestMethod]
    // Scenario: Create a queue without adding any items and attempt to Dequeue the next item.
    // Expected Result: Error "The queue is empty"
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        //Assert.Fail("Implement the test case and then remove this.");

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown");
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