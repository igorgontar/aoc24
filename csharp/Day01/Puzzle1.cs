class Puzzle1
{
    const StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

    public static long Solve(string file)
    {
        List<int> list1 = new();
        List<int> list2 = new();
        long sum  = 0;

        using var reader = new StreamReader(file);
        foreach (var line in reader.NonEmptyLines())
        {
            var nums = line.Split(' ', splitOptions); 
            int left = int.Parse(nums[0]);
            int right = int.Parse(nums[1]);
            list1.Add(left);
            list2.Add(right);
        }

        list1.Sort();    
        list2.Sort();    
        int c = list1.Count;
        for(int i=0; i<c; i++)
        {
            int n1 = list1[i];
            int n2 = list2[i];
            int s = Math.Abs(n1 - n2);
            sum += s;
        }

        return sum;
    }

}

