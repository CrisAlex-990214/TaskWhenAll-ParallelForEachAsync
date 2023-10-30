namespace TaskWhenAll_ParallelForeach
{
    public class ParallelForEachAsync
    {
        //3. CONCURRENCY - SYNCHRONOUS PROGRAMMING - PARALLEL.FOREACH (PARALLELLISM) 
        public void Execute(int duration, int taskCount)
        {
            Console.WriteLine("Starting main thread on thread: " + Thread.CurrentThread.ManagedThreadId);

            var threadIds = new List<int>();
            var delays = new List<int>();
            for (int i = 1; i <= taskCount; i++) delays.Add(duration / i);

            Parallel.ForEach(delays, new ParallelOptions { MaxDegreeOfParallelism = -1 }, d =>
            {
                Thread.Sleep(d);
                var threadId = Environment.CurrentManagedThreadId;
                Console.WriteLine($"Parallel method on thread: " + threadId + " with delay: " + d);
                if (!threadIds.Contains(threadId)) threadIds.Add(threadId);
            });

            Console.WriteLine("Continuing main thread on thread: " + Environment.CurrentManagedThreadId);

            Console.WriteLine("----------------------");
            Console.WriteLine("Number of threads in the Thread pool: " + ThreadPool.ThreadCount);
            Console.WriteLine("Threads used: " + threadIds.Count);
            Console.WriteLine("Logical Processors: " + Environment.ProcessorCount);
        }

        //4. CONCURRENCY - ASYNCHRONOUS PROGRAMMING - PARALLEL.FOREACHASYNC (PARALLELLISM) 
        public async Task ExecuteAsync(int duration, int taskCount)
        {
            Console.WriteLine("Starting main thread on thread: " + Thread.CurrentThread.ManagedThreadId);

            var threadIds = new List<int>();
            var delays = new List<int>();
            for (int i = 1; i <= taskCount; i++) delays.Add(duration / i);

            var task = Parallel.ForEachAsync(delays, new ParallelOptions { MaxDegreeOfParallelism = 3 }, async (d, cancellationtoken) =>
            {
                await Task.Delay(d, cancellationtoken);
                var threadid = Environment.CurrentManagedThreadId;
                Console.WriteLine($"parallel method on thread: " + threadid + " with delay: " + d);
                if (!threadIds.Contains(threadid)) threadIds.Add(threadid);
            });

            Console.WriteLine("Continuing main thread on thread: " + Environment.CurrentManagedThreadId);

            await task;

            Console.WriteLine("----------------------");
            Console.WriteLine("Number of threads in the Thread pool: " + ThreadPool.ThreadCount);
            Console.WriteLine("Threads used: " + threadIds.Count);
            Console.WriteLine("Logical Processors: " + Environment.ProcessorCount);
        }
    }
}
