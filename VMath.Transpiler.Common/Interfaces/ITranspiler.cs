using System;
using System.Collections.Generic;

namespace VMath.Transpiler.Common.Interfaces
{
    public interface ITranspiler
    {
        IEnumerable<string> Transpile(IEnumerable<string> source);
        IEnumerable<string> Transpile(string filePath);
    }
}
