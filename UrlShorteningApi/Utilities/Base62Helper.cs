using System.Collections.Generic;
using System.Linq;

namespace UrlShorteningApi.Utilities;

public static class Base62Helper
{
    private static readonly char[] EncodingArray =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray(); 
    
    public static string Encode(int data)
    {
        var st = new Stack<char>();

        while (data > 0)
        {
            st.Push(EncodingArray[data % 62]);
            data /= 62;
        }

        return string.Join("", st);
    }

    public static int Decode(string str)
    {
        return str.Aggregate(0, (current, t) => t switch
        {
            >= 'a' and <= 'z' => current * 62 + t - 'a',
            >= 'A' and <= 'Z' => current * 62 + t - 'A' + 26,
            >= '0' and <= '9' => current * 62 + t - '0' + 52,
            _ => current
        });
    }
}