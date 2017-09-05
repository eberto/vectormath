using VMath.Transpiler.Common.Models;
using System.Collections.Generic;

namespace VMath.Transpiler.Common.Interfaces
{
    public interface ILexicalAnalyzer
    {
        IEnumerable<Token> GetTokens(IEnumerable<string> source);
    }
}
