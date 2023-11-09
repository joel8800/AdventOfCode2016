Console.WriteLine("Day01: No Time for a Taxicab");

string[] input = File.ReadAllText("input.txt").Split(',', StringSplitOptions.TrimEntries);

int dir = 0, x = 0, y = 0;
List<(int x, int y)> visited = new();

foreach (string inst in input)
{
    char turn = inst[0];
    int dist = int.Parse(inst[1..]);

    (x, y, dir) = DoInstruction(x, y, dir, turn, dist, visited);
    //Console.WriteLine($"{turn} {dist}: now facing:{dir} at x:{x} y:{y}");
}
int hqDistance = ManhattanDistance(x, y);

// LINQ query
// check each XY, count number of occurances, return first XY that has more than 1
var firstTwiceVisit = visited.First(xy => visited.Count(loc => (loc == xy)) > 1);
int firstTwiceDist = ManhattanDistance(firstTwiceVisit.x, firstTwiceVisit.y);

Console.WriteLine($"Part1: {hqDistance}");
Console.WriteLine($"Part2: {firstTwiceDist}");

//============================================================================

int ManhattanDistance(int x, int y)
{
    return Math.Abs(x) + Math.Abs(y);
}

(int x, int y, int d) DoInstruction(int x, int y, int direction, char turn, int distance, List<(int x, int y)> visited)
{
    // N = 0
    direction += turn == 'R' ? 1 : 3;
    direction %= 4;

    for (int i = 0; i < distance; i++)
    {
        switch (direction)
        {
            case 0:
                y++; break;
            case 1:
                x++; break;
            case 2:
                y--; break;
            case 3:
                x--; break;
        }
        visited.Add((x, y));
    }

    return (x, y, direction);
}

