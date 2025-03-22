package aoc24.day1;

import java.io.*;
import java.util.*;
import java.util.stream.*;

import aoc24.utils.*;

public class Puzzle1
{
    static final PrintStream log = System.out;

    public static long Solve(String inputFile) {
        Reader file = null;
        var list1 = new ArrayList<Integer>();
        var list2 = new ArrayList<Integer>();
        try {
            file = new FileReader(inputFile);
            var reader = new BufferedReader(file);
            Stream<String> stream = reader.lines();
            stream.filter(s -> !s.isBlank()).forEach(s -> {
              var digits = s.split(" ");
              int d1 = Integer.parseInt(digits[0]);
              int d2 = Integer.parseInt(digits[digits.length -1]);
              list1.add(d1);
              list2.add(d2);
            });
            Collections.sort(list1);
            Collections.sort(list2);
            int sum  = 0;
            for(int i=0; i<list1.size(); i++)
            {
                int diff = Math.abs(list1.get(i) - list2.get(i));
                sum += diff;
            };
            return sum;

        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            close(file);
        }
        return 0;
    }

    static void close(Reader reader) {
        if (reader == null) return;
        try {
            reader.close();
        } catch (IOException e) {
        }
    }
}
