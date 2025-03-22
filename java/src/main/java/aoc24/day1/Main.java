package aoc24.day1;

import java.io.PrintStream;

public class Main 
{
    static final PrintStream log = System.out;

    public static void main(String[] args) 
    {
        log.println("=== AoC 2024 - Day 1 ===");
        log.printf("Puzzle1 test result: %d\n", Puzzle1.Solve("inputTest.txt"));
        log.printf("Puzzle1 main result: %d\n", Puzzle1.Solve("input.txt"));

        log.printf("Puzzle2 test result: %d\n", Puzzle2.Solve("inputTest.txt"));
        log.printf("Puzzle2 main result: %d\n", Puzzle2.Solve("input.txt"));
    }
}                          
