using NSubstitute;
using NUnit.Framework;

namespace CharacterCopyTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Copy_WhenOnlyNewLine_ShouldCopyNewLine()
        {
            //Arrange
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();

            source.ReadChar().Returns('\n');

            var sut = new Copier(source, destination);

            //Act
            sut.Copy();

            //Assert
            source.Received(1).ReadChar();
        }

        [Test]
        public void Copy_WhenNewLineInCharacter_ShouldCopyUntilNewLine()
        {
            //Arrange
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();

            source.ReadChar().Returns('a', 'b', 'c', 'd', '\n', 'e', 'f');

            var sut = new Copier(source, destination);

            //Act
            sut.Copy();

            //Assert
            source.Received(5).ReadChar();
        }

        [Test]
        public void Copy_WhenCharactersStartsWithNewLine_ShouldCopyNewLine()
        {
            //Arrange
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();

            source.ReadChar().Returns('\n', 'a', 'b', 'c', 'd', '\n', 'e', 'f');

            var sut = new Copier(source, destination);

            //Act
            sut.Copy();

            //Assert
            source.Received(1).ReadChar();
        }
    }
}