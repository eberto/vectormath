namespace VMath.Transpiler.Common.Models
{
    public enum TokenType
    {
        ID,
        Assignment,
        MatrixStart,
        MatrixEnd,
        VectorStart,
        VectorEnd,
        Integer,
        Comma,
        OperatorAdd,
        OperatorSubs,
        OperatorMult
    }
}
