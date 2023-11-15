using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Day05: How About a Nice Game of Chess?");

string input = "ojvtpuvg";

MD5 md5 = MD5.Create();

int index = 0;
List<string> passHashes = new();
char[] truePwd = "--------".ToCharArray();

while (index < int.MaxValue)
{
    string inputIdx = input + index.ToString();

    byte[] bytes = Encoding.ASCII.GetBytes(inputIdx);
    byte[] hash = md5.ComputeHash(bytes);
    string hashString = Convert.ToHexString(hash);

    if (hashString.Substring(0, 5) == "00000")
    {
        // part 1
        passHashes.Add(hashString);

        // part 2
        (int pos, char ch) = GetPositionAndValue(hashString);
        if (pos < 8)
        {
            if (truePwd[pos] == '-')
            {
                truePwd[pos] = ch;
                Console.WriteLine(truePwd.ToArray());
            }
        }
    }

    if (truePwd.Contains('-') == false)
        break;

    index++;
}

//foreach (string passHash in passHashes)
//    Console.WriteLine(passHash);

List<char> positions = passHashes.Select(x => x[5]).Take(8).ToList();
string passwordPt1 = new(positions.ToArray());
string passwordPt2 = new(truePwd.ToArray());


Console.WriteLine($"Part1: {passwordPt1.ToLower()}");
Console.WriteLine($"Part2: {passwordPt2.ToLower()}");

//============================================================================

static (int, char) GetPositionAndValue(string hash)
{
    char posChar = hash[5];
    char valChar = hash[6];
    int pos = 9;

    if (posChar - '0' < 8)
        pos = (int) (posChar - '0');

    return (pos, valChar);
}

