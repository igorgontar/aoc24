class Puzzle1
{
    const StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

    public static long Solve(string file)
    {
        long sum  = 0;

        using var reader = new StreamReader(file);
        foreach (var line in reader.NonEmptyLines())
        {
            var levels = line.Split(' ', splitOptions).Select(x => int.Parse(x)).ToList(); 
            if(Validate(levels))
                sum++;
        }

        return sum;
    }

    static bool Validate(IList<int> list)
    {
        int prev=list[0];
        int next;
        bool? increasing = null;
        for(int i=1; i<list.Count; i++)
        {   
            next = list[i];
            int diff = next - prev;
            bool up = diff > 0;
            if(increasing == null)
                increasing = up;
            if(up != increasing)
                return false;
            int d = Math.Abs(diff);    
            if(d < 1 || d > 3)
                return false;

            prev = next;
        }
        return true;
    }
}

