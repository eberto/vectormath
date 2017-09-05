using Microsoft.VisualStudio.TestTools.UnitTesting;
using VMath.Transpiler.Common.Exceptions;
using VMath.Transpiler.Common.Models;

namespace VMath.Transpiler.Test
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        [ExpectedException(typeof(PopulateEmptyTokenException))]
        public void PopulateContentNullLineFailTest()
        {
            //Arrange
            var token = new Token(TokenType.ID, 0, 1, null);
            
            //Act
            token.PopulateContent();
        }

        [TestMethod]
        [ExpectedException(typeof(PopulateEmptyTokenException))]
        public void PopulateContentEmptyLineFailTest()
        {
            //Arrange
            var token = new Token(TokenType.ID, 0, 1, "");

            //Act
            token.PopulateContent();
        }

        [TestMethod]
        [ExpectedException(typeof(PopulateEmptyTokenException))]
        public void PopulateContentZeroCharCountFailTest()
        {
            //Arrange
            var token = new Token(TokenType.ID, 0, 0, "A");

            //Act
            token.PopulateContent();
        }

        [TestMethod]
        public void PopulateContentSuccessTest()
        {
            //Arrange
            var token = new Token(TokenType.ID, 4, 1, "A = B + C");

            //Act
            token.PopulateContent();

            //Assert
            Assert.AreEqual("B", token.Content);
        }
    }
}
