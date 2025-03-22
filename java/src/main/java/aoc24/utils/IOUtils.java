package aoc24.utils; 

import java.io.*;

public class IOUtils
{
    public static void ForEachNonEmptyLine(BufferedReader reader, IAction<String> action) throws IOException
    {
        String line;
        while ((line = reader.readLine()) != null)
        {
            
            if (!line.isBlank())
                action.run(line);
        }
    }
}
