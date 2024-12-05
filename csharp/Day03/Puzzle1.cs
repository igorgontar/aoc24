using System.Text.RegularExpressions;

class Puzzle1
{
    public static long Solve(string file)
    {
        long sum  = 0;
        var reg = new Regex(@"mul\(([0-9]+),([0-9]+)\)", RegexOptions.CultureInvariant|RegexOptions.Compiled);

        using var reader = new StreamReader(file);
        var text = reader.ReadToEnd();
        
        foreach(Match m in reg.Matches(text))
        {
            int x = int.Parse(m.Groups[1].Value);
            int y = int.Parse(m.Groups[2].Value);
            sum += (x * y);
        }   

        return sum;
    }
}

