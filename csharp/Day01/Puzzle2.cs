class Puzzle2
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

        foreach(int n in list1)
        {
            int freq = list2.Count(x => x == n);
            int score = n * freq;
            sum += score;
        }

        return sum;
    }

}

