using AoCUtils;

Console.WriteLine("Day08: Two-Factor Authentication");

string[] input = FileUtil.ReadFileByLine("input.txt");

int[,] screen = new int[50,6];

foreach (string line in input)
{
    if (line.StartsWith("rect"))
        Rectangle(screen, line);

    if (line.StartsWith("rotate row"))
        RotateRow(screen, line);

    if (line.StartsWith("rotate column"))
        RotateCol(screen, line);
}


Console.WriteLine($"Part1: {GetLitPixelCount(screen)}");
Console.WriteLine("Part2:");
PrintScreen(screen);

//============================================================================

void Rectangle(int[,] screen, string inst)
{
    string[] parts = inst.Split(' ');
    string[] xy = parts[1].Split('x');
    int x = int.Parse(xy[0]);
    int y = int.Parse(xy[1]);
    for (int row = 0; row < y; row++)
        for (int col = 0; col < x; col++)
            screen[col, row] = 1;
}

void RotateRow(int[,] screen, string inst)
{
    string[] parts = inst.Split(' ');
    string[] xy = parts[2].Split('=');
    int row = int.Parse(xy[1]);
    int amt = int.Parse(parts[4]);

    // only positive, to the right
    for (int i = 0; i < amt; i++)
    {
        int tmp = screen[49, row];
        for (int j = 48; j >= 0; j--)
            screen[j + 1, row] = screen[j, row];
        screen[0, row] = tmp;
    }
}

void RotateCol(int[,] screen, string inst)
{
    string[] parts = inst.Split(' ');
    string[] xy = parts[2].Split('=');
    int col = int.Parse(xy[1]);
    int amt = int.Parse(parts[4]);

    // only positive, down
    for (int i = 0; i < amt; i++)
    {
        int tmp = screen[col, 5];
        for (int j = 4; j >= 0; j--)
            screen[col, j + 1] = screen[col, j];
        screen[col, 0] = tmp;
    }

}

int GetLitPixelCount(int[,] screen)
{
    int count = 0;

    for (int r = 0; r < 6; r++)
        for (int c = 0; c < 50; c++)
            if (screen[c,r] == 1)
                count++;
    
    return count;
}

void PrintScreen(int[,] screen)
{
    for (int r = 0; r < 6; r++)
    {
        for (int c = 0; c < 50; c++)
            if (screen[c, r] == 1)
                Console.Write("#");
            else
                Console.Write(" ");
        Console.WriteLine();
    }
    Console.WriteLine();
}