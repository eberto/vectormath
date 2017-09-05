using VMath.Transpiler.Common.Interfaces;
using VMath.Transpiler.Common.Models;
using System.Collections.Generic;

namespace VMath.Transpiler.Mocks.Analysis
{
    public class LexicalAnalyzer : ILexicalAnalyzer
    {
        public IEnumerable<Token> GetTokens(IEnumerable<string> source)
        {
            return new Token[]
            {
                new Token(TokenType.ID, 0, 1, "A")
            };
        }
    }
}
