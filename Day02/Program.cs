using AoCUtils;

Console.WriteLine("Day02: Bathroom Security");

string[] input = FileUtil.ReadFileByLine("input.txt");

int x = 1, y = 1;
string codePt1 = string.Empty;

foreach (string line in input)
{
    foreach (char c in line)
    {
        switch (c)
        {
            case 'U':
                y = Math.Min(y + 1, 2); break;
            case 'D':
                y = Math.Max(y - 1, 0); break;
            case 'R':
                x = Math.Min(x + 1, 2); break;
            case 'L':
                x = Math.Max(x - 1, 0); break;

        }
    }
    codePt1 += KeypadPt1(x, y);
}

x = 0; y = 2;
int limit = 0;
string codePt2 = string.Empty;

foreach (string line in input)
{
    foreach (char c in line)
    {
        switch (c)
        {
            case 'U':
                if (x == 0 || x == 4) limit = 2;
                if (x == 1 || x == 3) limit = 3;
                if (x == 2)           limit = 4;
                y = Math.Min(y + 1, limit); break;
            case 'D':
                if (x == 0 || x == 4) limit = 2;
                if (x == 1 || x == 3) limit = 1;
                if (x == 2)           limit = 0;
                y = Math.Max(y - 1, limit); break;
            case 'R':
                if (y == 0 || y == 4) limit = 2;
                if (y == 1 || y == 3) limit = 3;
                if (y == 2)           limit = 4;
                x = Math.Min(x + 1, limit); break;
            case 'L':
                if (y == 0 || y == 4) limit = 2;
                if (y == 1 || y == 3) limit = 1;
                if (y == 2)           limit = 0;
                x = Math.Max(x - 1, limit); break;
        }
    }
    codePt2 += KeypadPt2(x, y);
}

Console.WriteLine($"Part1: {codePt1}");
Console.WriteLine($"Part2: {codePt2}");

//============================================================================

string KeypadPt1(int x, int y)
{
    Dictionary<(int, int), string> decode = new()
    {
        { (0, 2), "1" }, { (1, 2), "2" }, { (2, 2), "3" },
        { (0, 1), "4" }, { (1, 1), "5" }, { (2, 1), "6" },
        { (0, 0), "7" }, { (1, 0), "8" }, { (2, 0), "9" }
    };

    return decode[(x, y)];
}

string KeypadPt2(int x, int y)
{
    Dictionary<(int, int), string> decode = new()
    {
                                          { (2, 4), "1" },
                         { (1, 3), "2" }, { (2, 3), "3" }, { (3, 3), "4" },
        { (0, 2), "5" }, { (1, 2), "6" }, { (2, 2), "7" }, { (3, 2), "8" }, { (4, 2), "9" },
                         { (1, 1), "A" }, { (2, 1), "B" }, { (3, 1), "C" },
                                          { (2, 0), "D" }
    };

    return decode[(x, y)];
}