namespace Day1_AsynchronousProgramming
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start the tasks...\n");

            Console.WriteLine("\tDo task 3...");
            Task<string> task3 = TaskThree();

            Console.WriteLine("\tDo task 1...");
            Task<string> task1 = TaskOne();

            Console.WriteLine("\tDo task 2...");
            Task<string> task2 = TaskTwo();

            Console.WriteLine("\nWaiting for the tasks to be done...\n");

            List<Task<string>> pendingTasks = new List<Task<string>> { task1, task2, task3 };

            while (pendingTasks.Count > 0)
            {
                Task<string> finishTask = await Task.WhenAny(pendingTasks);
                pendingTasks.Remove(finishTask);
                Console.WriteLine(finishTask.Result);
            }

            Console.ReadLine();
        }

        static async Task<string> TaskOne()
        {
            await Task.Delay(4000);
            return "\tTask 1 done!";
        }

        static async Task<string> TaskTwo()
        {
            await Task.Delay(1000);
            return "\tTask 2 done!";
        }

        static async Task<string> TaskThree()
        {
            await Task.Delay(8000);
            return "\tTask 3 done!";
        }
    }
}
