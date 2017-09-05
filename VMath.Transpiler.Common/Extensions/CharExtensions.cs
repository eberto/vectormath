namespace VMath.Transpiler.Common.Extensions
{
    public static class CharExtensions
    {
        public static bool IsMathOperator(this char c)
        {
            return c == '=' || c == '+' || c == '-' || c == '*' || c == '/';
        }
    }
}
