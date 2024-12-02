using static IOUtils;

class Puzzle2
{
    const StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

    public static long Solve(string file)
    {
        long sum = 0;

        using var reader = new StreamReader(file);
        foreach (var line in reader.NonEmptyLines())
        {
            var levels = line.Split(' ', splitOptions).Select(x => int.Parse(x)).ToList();
            if (Validate1(levels))
            {
                sum++;
            }
            else if(Validate3(levels))
            {
                sum++;
                //println(levels, " ");
            }
        }

        return sum;
    }

    static bool Validate1(IList<int> list)
    {
        int prev = list[0];
        int next;
        bool? direction = null;
        for (int i = 1; i < list.Count; i++)
        {
            next = list[i];
            int diff = next - prev;
            bool dir = diff > 0;
            if (direction == null)
                direction = dir;
            if (dir != direction)
                return false;
            int d = Math.Abs(diff);
            if (d < 1 || d > 3)
                return false;

            prev = next;
        }
        return true;
    }

    static bool Validate2(IList<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var list1 = new List<int>(list);
            list1.RemoveAt(i);
            if(Validate1(list1)) 
                return true;

        }
        return false;
    }

    static bool Validate3(IList<int> list)
    {
        int prev = list[0];
        int next;
        bool? direction = null;
        for (int i = 1; i < list.Count; i++)
        {
            next = list[i];
            int diff = next - prev;
            bool dir = diff > 0;
            if (direction == null)
                direction = dir;
            
            bool bad = false;
            if (dir != direction)
                bad = true;

            int d = Math.Abs(diff);
            if (d < 1 || d > 3)
                bad = true;

            if(bad)
            {
                var list1 = new List<int>(list);
                list1.RemoveAt(i);
                if(Validate1(list1)) 
                    return true;

                var list2 = new List<int>(list);
                list2.RemoveAt(i-1);
                if(Validate1(list2)) 
                    return true;

                if(i-2 >= 0)
                {
                    var list3 = new List<int>(list);
                    list3.RemoveAt(i-2);
                    if(Validate1(list3)) 
                        return true;
                }

                return false;
            }

            prev = next;
        }
        
        return true;
    }
}

