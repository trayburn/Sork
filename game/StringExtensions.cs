using System.Text;

namespace Sork;

public static class StringExtensions
{
    public static string NetworkCleanup(this string input)
    {
        var sb = new StringBuilder();
        foreach (var c in input)
        {
            if (c == '\b' || c == '\u007f')
            {
                if (sb.Length > 0)
                {
                    sb.Length--;
                }
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
