using Xunit;

namespace Domain.UnitTests
{
    public class BoardTests
    {
        [Theory]
        [InlineData(0, 0, EnumCellType.Cross)]
        [InlineData(1, 1, EnumCellType.Naught)]
        [InlineData(2, 2, EnumCellType.Cross)]

        public void can_set_element(int row, int column, EnumCellType type)
        {
            var board = new Board();

            board.Set(row, column, type);

            Assert.Equal(type, board.Entries[row, column]);
        }
    }
}
