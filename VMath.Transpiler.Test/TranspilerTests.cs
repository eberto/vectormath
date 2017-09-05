using Microsoft.VisualStudio.TestTools.UnitTesting;
using VMath.Transpiler.Mocks.Analysis;
using VMath.Transpiler.Common.Exceptions;
using VMath.Transpiler.Common.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace VMath.Transpiler.Test
{
    [TestClass]
    public class TranspilerTests
    {
        private ITranspiler _transpiler;
        ILexicalAnalyzer _lexicalAnalyzer;

        [TestInitialize]
        public void Initialize()
        {
            _lexicalAnalyzer = new LexicalAnalyzer();
            _transpiler = new Transpiler(_lexicalAnalyzer);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFoundFailTest()
        {
            //Arrange at Initialize
            //Act
            _transpiler.Transpile(@"C:\NonExistent.vm");
        }

        [TestMethod]
        [ExpectedException(typeof(NullOrEmptySourceException))]
        public void NullSourceFailTest()
        {
            //Arrange at Initialize
            //Arrange
            IEnumerable<string> source = null;
            //Act
            _transpiler.Transpile(source);
        }

        [TestMethod]
        [ExpectedException(typeof(NullOrEmptySourceException))]
        public void EmptySourceFailTest()
        {
            //Arrange at Initialize
            //Arrange
            IEnumerable<string> source = new List<string>();
            //Act
            _transpiler.Transpile(source);
        }

        //TODO: Implement Transpile test.
    }
}
