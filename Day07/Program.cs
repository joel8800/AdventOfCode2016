using AoCUtils;
using System.Text.RegularExpressions;

Console.WriteLine("Day07: Internet Protocol Version 7");

string[] input = FileUtil.ReadFileByLine("input.txt");

bool tls, ssl;
int ipCountPt1 = 0;
int ipCountPt2 = 0;
foreach (string line in input)
{
    (tls, ssl) = AnalyzeIP(line);

    if (tls)
        ipCountPt1++;
    if (ssl)
        ipCountPt2++;
}


Console.WriteLine($"Part1: {ipCountPt1}");
Console.WriteLine($"Part2: {ipCountPt2}");

//============================================================================

(bool tls, bool ssl) AnalyzeIP(string line)
{
    bool supportsTLS = false;
    bool supportsSSL = false;

    List<string> hyperNet = new();
    List<string> superNet = new();

    string reHyp = @"(\[\w+\])+";
    Regex re = new(reHyp);
    MatchCollection matches = re.Matches(line);

    int nonHypStart = 0; int nonHypStop = 0;
    foreach (Match match in matches)
    {
        hyperNet.Add(match.Value);
        
        nonHypStop = match.Index;
        superNet.Add(line[nonHypStart..nonHypStop]);
        nonHypStart = match.Index + match.Length;
    }
    superNet.Add(line[nonHypStart..]);

    if (ContainsABBA(superNet) == true && ContainsABBA(hyperNet) == false)
        supportsTLS = true;

    if (SupportsSSL(superNet, hyperNet))
        supportsSSL = true;

    return (supportsTLS, supportsSSL);
}

bool ContainsABBA(List<string> strings)
{
    foreach (string s in strings)
        for (int i = 0; i <= s.Length - 4; i++)
        {
            string abba = s.Substring(i, 4);
            if (abba[0] == abba[3] && abba[1] == abba[2] && abba[0] != abba[1])
                return true;
        }
    return false;
}

bool SupportsSSL(List<string> super, List<string> hyper)
{
    foreach(string s in super)
    {
        for (int i = 0; i <= s.Length - 3; i++)
        {
            string aba = s.Substring(i, 3);
            if (aba[0] == aba[2] && aba[0] != aba[1])
            {
                string bab = new($"{aba[1]}{aba[0]}{aba[1]}");
                if (hyper.Any(h => h.Contains(bab)))
                    return true;
            }
        }
    }

    return false;
}