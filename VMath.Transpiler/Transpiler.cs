using VMath.Transpiler.Common.Exceptions;
using VMath.Transpiler.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VMath.Transpiler
{
    public class Transpiler : ITranspiler
    {
        private ILexicalAnalyzer _lexicalAnalyzer;

        public Transpiler(ILexicalAnalyzer lexicalAnalyzer)
        {
            _lexicalAnalyzer = lexicalAnalyzer;
        }

        public IEnumerable<string> Transpile(IEnumerable<string> source)
        {
            if(source == null || source.Count() == 0)
            {
                throw new NullOrEmptySourceException();
            }

            var tokens = _lexicalAnalyzer.GetTokens(source);
            
            //TODO: take tokens to the syntax and semantic analyzers.
            throw new NotImplementedException();
        }

        public IEnumerable<string> Transpile(string filePath)
        {
            return Transpile(File.ReadLines(filePath));            
        }
    }
}
