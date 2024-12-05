using Utils.Profiler;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            ColorConsole.Enabled = true;

            //Profiler.Debug("Current dir: {0}\n", Environment.CurrentDirectory);

            Profiler.Warn("=== AoC 2024 Day03 ===");

            using(Profiler.CheckPoint("Puzzle1"))
            {
                using(Profiler.CheckPoint("Test"))
                    Profiler.Trace("Result: {0} (161)", Puzzle1.Solve("inputTest1.txt"));
                
                using(Profiler.CheckPoint("Input"))
                     Profiler.Trace("Result: {0} (167650499)", Puzzle1.Solve("input.txt"));
            }        
            
            using(Profiler.CheckPoint("Puzzle2"))
            {
                using(Profiler.CheckPoint("Test"))
                    Profiler.Trace("Result: {0} (48)", Puzzle2.Solve("inputTest2.txt"));
                
                using(Profiler.CheckPoint("Input"))
                    Profiler.Trace("Result: {0} (95846796)", Puzzle2.Solve("input.txt"));
            }        
        }
        catch (Exception ex)
        {
            Profiler.Error("Main() - {0}", ex);
        }
    }
}
