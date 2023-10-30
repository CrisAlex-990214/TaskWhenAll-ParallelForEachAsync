namespace TaskWhenAll_ParallelForeach
{
    public class TaskRun
    {
        //1. CONCURRENCY - ASYNCHRONOUS PROGRAMMING - TASK.RUN(SEPARATE THREAD)
        public async Task ExecuteAsync(int duration)
        {
            Console.WriteLine("Starting main thread on thread: " + Thread.CurrentThread.ManagedThreadId);

            var task = Task.Run(() =>
            {
                Task.Delay(duration).Wait();
                Console.WriteLine($"Async method on thread: " + Environment.CurrentManagedThreadId);
            });

            Console.WriteLine("Continuing main thread on thread: " + Environment.CurrentManagedThreadId);

            await task;

            Console.WriteLine("----------------------");
            Console.WriteLine("Number of threads in the Thread pool: " + ThreadPool.ThreadCount);
        }
    }
}
