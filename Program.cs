using System.Diagnostics;
using TaskWhenAll_ParallelForeach;


var watch = new Stopwatch();
watch.Start();

var idealDuration = 4000;

await new TaskRun().ExecuteAsync(idealDuration);

//var taskCount = 800;

//await new TaskWhenAll().ExecuteAsync(idealDuration, taskCount);

//new ParallelForEachAsync().Execute(idealDuration, taskCount);
//await new ParallelForEachAsync().ExecuteAsync(idealDuration, taskCount);

watch.Stop();

//Console.WriteLine("Number of Tasks: " + taskCount);
Console.WriteLine("Ideal duration: " + idealDuration);
Console.WriteLine("Elapsed time: " + watch.ElapsedMilliseconds);




Console.ReadKey();

