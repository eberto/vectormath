using VMath.Transpiler.Analysis;
using VMath.Transpiler;
using VMath.Transpiler.Common.Interfaces;
using System;
using System.IO;

namespace MatrixMath
{
    class Program
    {
        static void Main(string[] args)
        {
            ILexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer();
            ITranspiler transpiler = new Transpiler(lexicalAnalyzer);

            transpiler.Transpile(Directory.GetCurrentDirectory() + @"\Program.vm");

            Console.ReadLine();
        }
    }
}
