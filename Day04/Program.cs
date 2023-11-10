using AoCUtils;
using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Security Through Obscurity");

string[] input = FileUtil.ReadFileByLine("input.txt");

List<int> realRoomSectors = new();

string pattern = @"([a-z,\-]+)(\d{3})(\[[a-z]{5}\]$)";
Regex re = new(pattern);
int idSum = 0;
int npoSector = 0;
List<string> rooms = new();

foreach (string line in input)
{
   MatchCollection mc = re.Matches(line);

    string roomName = mc[0].Groups[1].ToString();
    string sectorID = mc[0].Groups[2].ToString();
    string checksum = mc[0].Groups[3].ToString().Replace("[", "").Replace("]", "");

    int sectID = int.Parse(sectorID);

    if (IsRealRoom(roomName, checksum))
    {
        idSum += sectID;
        string decryptedName = Decrypt(roomName, sectID);
        rooms.Add(decryptedName);
        if (decryptedName.Contains("northpole"))
            npoSector = sectID;
    }
}

//string output = Decrypt("qzmt-zixmtkozy-ivhz-", 343);
//Console.WriteLine(output);

Console.WriteLine($"Part1: {idSum}");
Console.WriteLine($"Part2: {npoSector}");

//=============================================================================

bool IsRealRoom(string name, string checkSum)
{
    string noDashes = name.Replace("-", "");
    List<char> chars = noDashes.ToCharArray().ToList();
    chars.Sort();

    List<char> ordered = chars
        .GroupBy(c => c)
        .ToDictionary(gr => gr.Key, gr => gr.Count())
        .OrderByDescending(k => k.Value)
        .Take(5)
        .Select(x => x.Key)
        .ToList();
    
    string nameCheck = new(ordered.ToArray());

    if (nameCheck == checkSum)
        return true;
    else
        return false;
}

string Decrypt(string roomName, int sectorID)
{
    StringBuilder sb = new();

    int shift = sectorID % 26;
    
    string decrypted = roomName;
    for (int i = 0; i < decrypted.Length; i++)
    {
        char ch = decrypted[i];
        if (ch == '-')
        {
            sb.Append(' ');
            continue;
        }
        else
        {
            if (ch - 'a' + shift >= 26)
                ch = (char)(ch + shift - 26);
            else
                ch = (char)(ch + shift);
            sb.Append(ch);
        }
     }

    return sb.ToString();
}