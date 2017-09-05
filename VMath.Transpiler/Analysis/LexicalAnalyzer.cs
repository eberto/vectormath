using VMath.Transpiler.Common.Exceptions;
using VMath.Transpiler.Common.Interfaces;
using VMath.Transpiler.Common.Models;
using VMath.Transpiler.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace VMath.Transpiler.Analysis
{
    public class LexicalAnalyzer : ILexicalAnalyzer
    {
        public IEnumerable<Token> GetTokens(IEnumerable<string> source)
        {
            var tokens = new List<Token>();
            var scanningId = false;
            var scanningInteger = false;
            var idStartIndex = -1;
            var integerStartIndex = -1;            

            for (var l = 0; l < source.Count(); l++)
            {
                var line = source.ElementAt(l);

                for (var i = 0; i < line.Length; i++)
                {
                    var c = line[i];

                    if (char.IsLetterOrDigit(c))
                    {
                        ProcessLetterOrDigit(line, i, c, tokens, ref scanningId, ref scanningInteger, ref idStartIndex, ref integerStartIndex);
                    }                    
                    else if (char.IsSeparator(c) || c == ',')
                    {
                        AddIdOrIntegerToken(line, i, c, tokens, ref scanningId, ref scanningInteger, ref idStartIndex, ref integerStartIndex);

                        if (c == ',')
                        {
                            tokens.Add(new Token(TokenType.Comma, i, 1, line));
                        }
                    }
                    else if(c == '[')
                    {
                        tokens.Add(new Token(TokenType.VectorStart, i, 1, line));                 
                    }
                    else if (c == ']')
                    {
                        AddIdOrIntegerToken(line, i, c, tokens, ref scanningId, ref scanningInteger, ref idStartIndex, ref integerStartIndex);
                        tokens.Add(new Token(TokenType.VectorEnd, i, 1, line));
                    }
                    else if(c.IsMathOperator())
                    {
                        AddIdOrIntegerToken(line, i, c, tokens, ref scanningId, ref scanningInteger, ref idStartIndex, ref integerStartIndex);
                        var token = MapOperatorToToken(c);
                        token.SourceLine = line;
                        token.StartIndex = i;
                        tokens.Add(token);
                    }
                    else
                    {
                        throw new UnexpectedCharException(l, i);
                    }
                }
            }

            return tokens;
        }

        public void ProcessLetterOrDigit(string line, int i, char c, List<Token> tokens, ref bool scanningId, ref bool scanningInteger, ref int idStartIndex, ref int integerStartIndex)
        {
            if (char.IsLetter(c))
            {
                if (!scanningId)
                {
                    scanningId = true;
                    idStartIndex = i;
                }
            }
            else if (char.IsDigit(c))
            {
                if (!scanningId && !scanningInteger)
                {
                    scanningInteger = true;
                    integerStartIndex = i;
                }
            }
            if (i == line.Length - 1 && (scanningId || scanningInteger))
            {
                AddIdOrIntegerToken(line, i, c, tokens, ref scanningId, ref scanningInteger, ref idStartIndex, ref integerStartIndex);
            }
        }

        public void AddIdOrIntegerToken(string line, int i, char c, List<Token> tokens, ref bool scanningId, ref bool scanningInteger, ref int idStartIndex, ref int integerStartIndex)
        {
            if (scanningId || scanningInteger)
            {
                var tokenType = scanningId ? TokenType.ID : TokenType.Integer;
                var startIndex = scanningId ? idStartIndex : integerStartIndex;
                var charCount = i - startIndex;
                if(i == line.Length - 1)
                {
                    charCount++;
                }
                tokens.Add(new Token(tokenType, startIndex, charCount, line));
                scanningId = false;
                scanningInteger = false;
                idStartIndex = -1;
                integerStartIndex = -1;
            }
        }

        public Token MapOperatorToToken(char c)
        {
            switch (c)
            {
                case '=':
                    return new Token { TokenType = TokenType.Assignment, CharCount = 1 };
                case '+':
                    return new Token { TokenType = TokenType.OperatorAdd, CharCount = 1 };
                case '-':
                    return new Token { TokenType = TokenType.OperatorSubs, CharCount = 1 };
                case '*':
                    return new Token { TokenType = TokenType.OperatorMult, CharCount = 1 };
                default:
                    throw new NotSupportedOperatorException();
            }
        }
    }
}
