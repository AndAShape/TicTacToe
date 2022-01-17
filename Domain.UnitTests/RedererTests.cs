using System;
using Xunit;

namespace Domain.UnitTests
{
    public class RendererTests
    {
        static string FormatOutput(string row0, string row1, string row2) =>
            string.Format("{1}{0}{2}{0}{3}{0}", Environment.NewLine, row0, row1, row2);

        [Theory]
        [InlineData(null, "---", "---", "---")]
        [InlineData(EnumCellType.Cross, "XXX", "XXX", "XXX")]
        [InlineData(EnumCellType.Naught, "OOO", "OOO", "OOO")]

        public void constant_patterns(EnumCellType? type,
            string row0, string row1, string row2)
        {
            var renderer = new Renderer();

            var board = new Board();

            board.Clear(type);

            var output = renderer.Render(board);

            Assert.Equal(FormatOutput(row0, row1, row2), output);
        }

        [Theory]
        [InlineData(0, 1, EnumCellType.Naught, "-O-", "---", "---")]
        [InlineData(2, 2, EnumCellType.Cross, "---", "---", "--X")]
        [InlineData(1, 1, EnumCellType.Naught, "---", "-O-", "---")]

        public void specific_element(int row, int column, EnumCellType type,
            string row0, string row1, string row2)
        {
            var renderer = new Renderer();

            var board = new Board();

            board.Set(row, column, type);

            var output = renderer.Render(board);

            Assert.Equal(FormatOutput(row0, row1, row2), output);
        }
    }
}
