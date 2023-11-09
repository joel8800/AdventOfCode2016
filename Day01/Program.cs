
using System.Net.Security;
using System.Security.Cryptography;

Console.WriteLine("Day01: No Time for a Taxicab");

string[] input = File.ReadAllText("input.txt").Split(',', StringSplitOptions.TrimEntries);

List<(char dir, int dist)> directions = new();
List<(int xPos, int yPos)> locations = new();

int facing = 0;
int x = 0;
int y = 0;

foreach (string inst in input)
{
    char dir = inst[0];
    int dist = int.Parse(inst[1..]);
    directions.Add((dir, dist));
}

int xRep = 0;
int yRep = 0;
bool repeat = false;

foreach ((char dir, int dist) in directions)
{
    facing = ChangeDirection(dir, facing);

    switch (facing)
    {
        case 0:
            y += dist; break;
        case 1:
            x += dist; break;
        case 2:
            y -= dist; break;
        case 3:
            x -= dist; break;
    }

    if (locations.Contains((x, y)) && !repeat)
    {
        xRep = x;
        yRep = y;
        repeat = true;
    }

    locations.Add((x, y));
    Console.WriteLine($"{dir} {dist}: now facing:{facing} at x:{x} y:{y}");
}

int distance = Math.Abs(x) + Math.Abs(y);
int repeatDist = Math.Abs(xRep) + Math.Abs(yRep);

Console.WriteLine($"Part1: {distance}");
Console.WriteLine($"Part2: {repeatDist}");

//============================================================================

int ChangeDirection(char dir, int facing)
{
    if (dir == 'R')
        facing += 1;
    else
        facing += 3;

    facing %= 4;

    return facing;
}
