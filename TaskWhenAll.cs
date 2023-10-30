namespace TaskWhenAll_ParallelForeach
{
    public class TaskWhenAll
    {
        //2. CONCURRENCY - ASYNCHRONOUS PROGRAMMING - TASK.WHENALL(MULTITHREADING) 
        public async Task ExecuteAsync(int duration, int taskCount)
        {
            Console.WriteLine("Starting main thread on thread: " + Thread.CurrentThread.ManagedThreadId);

            var threadIds = new List<int>();
            List<Task> tasks = new();
            for (int i = 1; i <= taskCount; i++) tasks.Add(GetTask(duration / i));

            Console.WriteLine("Continuing main thread on thread: " + Environment.CurrentManagedThreadId);

            await Task.WhenAll(tasks);

            Console.WriteLine("----------------------");
            Console.WriteLine("Number of threads in the Thread pool: " + ThreadPool.ThreadCount);
            Console.WriteLine("Threads used: " + threadIds.Count);

            Task GetTask(int delay)
            {
                var task = Task.Run(() =>
                {
                    Task.Delay(delay).Wait();
                    var threadId = Environment.CurrentManagedThreadId;
                    Console.WriteLine($"Async method on thread: " + threadId + " with delay: " + delay);
                    if (!threadIds.Contains(threadId)) threadIds.Add(threadId);
                });
                return task;
            }
        }
    }
}
