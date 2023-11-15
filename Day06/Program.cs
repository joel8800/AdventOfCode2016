using AoCUtils;
using System.Text;

Console.WriteLine("Day06: Signals and Noise");

string[] input = FileUtil.ReadFileByLine("input.txt");

int width = input[0].Length;
StringBuilder answerPt1 = new();
StringBuilder answerPt2 = new();

for (int i = 0; i < width; i++)
{
    List<char> column = input.Select(c => c[i]).ToList();

    answerPt1.Append(column.GroupBy(c => c).OrderByDescending(g => g.Count()).Select(c => c.Key).First());
    answerPt2.Append(column.GroupBy(c => c).OrderBy(g => g.Count()).Select(c => c.Key).First());
}

Console.WriteLine($"Part1: {answerPt1}");
Console.WriteLine($"Part2: {answerPt2}");

//============================================================================