
using System;
using NLua;

namespace dangobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Lua state = new Lua();
            var res = state.DoString("return 1+1")[0] as double?;
            Console.WriteLine(res);
        }
    }
}
