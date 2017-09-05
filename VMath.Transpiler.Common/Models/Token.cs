using VMath.Transpiler.Common.Exceptions;

namespace VMath.Transpiler.Common.Models
{
    public class Token
    {
        public TokenType TokenType { get; set; }
        public int StartIndex { get; set; }
        public int CharCount { get; set; }
        public string Content { get; set; }
        public string SourceLine { get; set; }

        public Token()
        {
        }

        public Token(TokenType tokenType, int startIndex, int charCount, string sourceLine)
        {
            TokenType = tokenType;
            StartIndex = startIndex;
            CharCount = charCount;
            SourceLine = sourceLine;
        }

        public override string ToString()
        {
            return string.Format("<{0},{1},{2}>", TokenType, StartIndex, CharCount);
        }

        public void PopulateContent()
        {
            if(string.IsNullOrEmpty(SourceLine) || CharCount == 0)
            {
                throw new PopulateEmptyTokenException();
            }
            Content = SourceLine.Substring(StartIndex, CharCount);
        }
    }
}
