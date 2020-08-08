using System;

namespace DragonkinTransposerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DragonkinTransposer.Transposer.Transpose(string.Join(' ', args)).Save("output.png");
        }
    }
}
