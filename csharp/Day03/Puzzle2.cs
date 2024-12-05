using static IOUtils;
using System.Text.RegularExpressions;

class Puzzle2
{
    public static long Solve(string file)
    {
        long sum  = 0;

        using var reader = new StreamReader(file);
        var code = reader.ReadToEnd();
        code = code.Replace("do()", "\u0001");
        code = code.Replace("don't()", "\u0002");
        code = code.Replace("mul", "\u0003");

        bool on = true;  
        for(int i=0; i<code.Length; i++)
        {
            int ch = code[i];
            if(ch == 1)
            {
                on = true;
                print(">");
            }
            else if(ch == 2)
            {
                on = false;
                print("|");
            }
            else if(ch == 3 && on)
            {
                int n = i+1;
                var mul = code.Substring(n, Math.Min(code.Length-n, 9));        
                long res =  ProcessBlock(mul);
                if(res != 0)
                {
                    print("m");
                    sum += res;
                }
            }

        }
        println("");

        return sum;
    }

    static Regex reg1 = new Regex(@"\(([0-9]+),([0-9]+)\)", RegexOptions.CultureInvariant|RegexOptions.Compiled);

    static long ProcessBlock(string text)
    {
        long sum  = 0;
        foreach(Match m in reg1.Matches(text))
        {
            int x = int.Parse(m.Groups[1].Value);
            int y = int.Parse(m.Groups[2].Value);
            sum += (x * y);
        }   
        return sum;
    } 
}


