using AoCUtils;

Console.WriteLine("Day03: Squares with Three Sides");

string[] input = FileUtil.ReadFileByLine("input.txt");

int validPt1 = 0;
foreach (string line in input)
{
    string[] sides = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int a0 = int.Parse(sides[0]);
    int a1 = int.Parse(sides[1]);
    int a2 = int.Parse(sides[2]);

    if (a0 + a1 > a2 && a0 + a2 > a1 && a1 + a2 > a0)
        validPt1++;
}

int validPt2 = 0;
for (int i = 0; i < input.Length; i += 3)
{
    string[] sides0 = input[i + 0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string[] sides1 = input[i + 1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string[] sides2 = input[i + 2].Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int a0 = int.Parse(sides0[0]);
    int a1 = int.Parse(sides1[0]);
    int a2 = int.Parse(sides2[0]);

    int b0 = int.Parse(sides0[1]);
    int b1 = int.Parse(sides1[1]);
    int b2 = int.Parse(sides2[1]);

    int c0 = int.Parse(sides0[2]);
    int c1 = int.Parse(sides1[2]);
    int c2 = int.Parse(sides2[2]);

    if (a0 + a1 > a2 && a0 + a2 > a1 && a1 + a2 > a0)
        validPt2++;

    if (b0 + b1 > b2 && b0 + b2 > b1 && b1 + b2 > b0)
        validPt2++;

    if (c0 + c1 > c2 && c0 + c2 > c1 && c1 + c2 > c0)
        validPt2++;
}

Console.WriteLine($"Part1: {validPt1}");
Console.WriteLine($"Part2: {validPt2}");
//============================================================================