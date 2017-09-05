using Microsoft.VisualStudio.TestTools.UnitTesting;
using VMath.Transpiler.Analysis;
using VMath.Transpiler.Common.Exceptions;
using VMath.Transpiler.Common.Models;
using System.Collections.Generic;

namespace VMath.Transpiler.Test
{
    [TestClass]
    public class LexicalAnalyzerTests
    {
        private LexicalAnalyzer _lexicalAnalyzer;

        [TestInitialize]
        public void Initialize()
        {
            _lexicalAnalyzer = new LexicalAnalyzer();
        }

        #region MapOperatorToToken

        [TestMethod]
        [ExpectedException(typeof(NotSupportedOperatorException))]
        public void MapOperatorToTokenFailTest()
        {
            //Arrange at Initialize.
            //Act
            _lexicalAnalyzer.MapOperatorToToken('^');
        }

        [TestMethod]
        public void MapOperatorToTokenAssignmentSuccessTest()
        {
            //Arrange at Initialize.
            //Act
            var token = _lexicalAnalyzer.MapOperatorToToken('=');
            //Assert
            Assert.IsNotNull(token);
            Assert.AreEqual(TokenType.Assignment, token.TokenType);
            Assert.AreEqual(1, token.CharCount);
        }

        [TestMethod]
        public void MapOperatorToTokenAddSuccessTest()
        {
            //Arrange at Initialize.
            //Act
            var token = _lexicalAnalyzer.MapOperatorToToken('+');
            //Assert
            Assert.IsNotNull(token);
            Assert.AreEqual(TokenType.OperatorAdd, token.TokenType);
            Assert.AreEqual(1, token.CharCount);
        }

        [TestMethod]
        public void MapOperatorToTokenSubstractSuccessTest()
        {
            //Arrange at Initialize.
            //Act
            var token = _lexicalAnalyzer.MapOperatorToToken('-');
            //Assert
            Assert.IsNotNull(token);
            Assert.AreEqual(TokenType.OperatorSubs, token.TokenType);
            Assert.AreEqual(1, token.CharCount);
        }

        [TestMethod]
        public void MapOperatorToTokenMultSuccessTest()
        {
            //Arrange at Initialize.
            //Act
            var token = _lexicalAnalyzer.MapOperatorToToken('*');
            //Assert
            Assert.IsNotNull(token);
            Assert.AreEqual(TokenType.OperatorMult, token.TokenType);
            Assert.AreEqual(1, token.CharCount);
        }

        #endregion

        #region AddIdOrIntegerToken

        [TestMethod]
        public void AddIdOrIntegerTokenIdSuccessTest()
        {
            //Arrange at Initialize
            //Arrange
            var line = "Three = One + Two";
            var lineIndex = 5;
            var c = ' ';
            var tokens = new List<Token>();
            var scanningId = true;
            var scanningInteger = false;
            var idStartIndex = 0;
            var integerStartIndex = -1;

            //Act
            _lexicalAnalyzer.AddIdOrIntegerToken(line, lineIndex, c, tokens, ref scanningId, ref scanningInteger, ref idStartIndex, ref integerStartIndex);
            tokens[0].PopulateContent();

            //Assert
            Assert.IsTrue(tokens.Count == 1);
            Assert.AreEqual(TokenType.ID, tokens[0].TokenType);
            Assert.AreEqual(0, tokens[0].StartIndex);
            Assert.AreEqual(5, tokens[0].CharCount);
            Assert.AreEqual(line, tokens[0].SourceLine);
            Assert.AreEqual("Three", tokens[0].Content);
        }

        [TestMethod]
        public void AddIdOrIntegerTokenIntegerSuccessTest()
        {
            //Arrange at Initialize
            //Arrange
            var line = "Three = 1 + Two";
            var lineIndex = 9;
            var c = ' ';
            var tokens = new List<Token>();
            var scanningId = false;
            var scanningInteger = true;
            var idStartIndex = -1;
            var integerStartIndex = 8;

            //Act
            _lexicalAnalyzer.AddIdOrIntegerToken(line, lineIndex, c, tokens, ref scanningId, ref scanningInteger, ref idStartIndex, ref integerStartIndex);
            tokens[0].PopulateContent();

            //Assert
            Assert.IsTrue(tokens.Count == 1);
            Assert.AreEqual(TokenType.Integer, tokens[0].TokenType);
            Assert.AreEqual(8, tokens[0].StartIndex);
            Assert.AreEqual(1, tokens[0].CharCount);
            Assert.AreEqual(line, tokens[0].SourceLine);
            Assert.AreEqual("1", tokens[0].Content);
        }

        [TestMethod]
        public void AddIdOrIntegerTokenIdLastInLineSuccessTest()
        {
            //Arrange at Initialize
            //Arrange
            var line = "Three = One + Two";
            var lineIndex = 16;
            var c = 'o';
            var tokens = new List<Token>();
            var scanningId = true;
            var scanningInteger = false;
            var idStartIndex = 14;
            var integerStartIndex = -1;

            //Act
            _lexicalAnalyzer.AddIdOrIntegerToken(line, lineIndex, c, tokens, ref scanningId, ref scanningInteger, ref idStartIndex, ref integerStartIndex);
            tokens[0].PopulateContent();

            //Assert
            Assert.IsTrue(tokens.Count == 1);
            Assert.AreEqual(TokenType.ID, tokens[0].TokenType);
            Assert.AreEqual(14, tokens[0].StartIndex);
            Assert.AreEqual(3, tokens[0].CharCount);
            Assert.AreEqual(line, tokens[0].SourceLine);
            Assert.AreEqual("Two", tokens[0].Content);
        }

        #endregion


    }
}
