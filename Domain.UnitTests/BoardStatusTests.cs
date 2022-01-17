using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Domain.UnitTests
{
    public class BoardStatusTests
    {
        [Theory]
        [ClassData(typeof(TestDataWinningLinesGenerator))]
        public void detects_winning_lines(EnumCellType type,
            (int, int)[] cells)
        {
            var board = new Board();

            foreach (var cell in cells)
            {
                board.Set(cell.Item1, cell.Item2, type);
            }

            var boardstatus = new BoardStatus();

            var status = boardstatus.Status(board);

            Assert.Equal((EnumBoardStatus.Win, type), status);
        }

        [Theory]
        [ClassData(typeof(TestDataNonWinningGenerator))]
        public void no_winning_lines_then_not_a_win(EnumCellType type,
            (int, int)[] cells)
        {
            var board = new Board();

            foreach (var cell in cells)
            {
                board.Set(cell.Item1, cell.Item2, type);
            }

            var boardstatus = new BoardStatus();

            var status = boardstatus.Status(board);

            Assert.NotEqual((EnumBoardStatus.Win, type), status);
        }

        [Theory]
        [ClassData(typeof(TestDataDrawGenerator))]
        public void detects_draws((int, int, EnumCellType)[] cells)
        {
            var board = new Board();

            foreach (var cell in cells)
            {
                board.Set(cell.Item1, cell.Item2, cell.Item3);
            }

            var boardstatus = new BoardStatus();

            var status = boardstatus.Status(board);

            Assert.Equal((EnumBoardStatus.Draw, null), status);
        }

        [Theory]
        [ClassData(typeof(TestDataDrawGenerator))]
        public void detects_game_in_progress((int, int, EnumCellType)[] cells)
        {
            var board = new Board();

            foreach (var cell in cells.Skip(1))
            {
                board.Set(cell.Item1, cell.Item2, cell.Item3);
            }

            var boardstatus = new BoardStatus();

            var status = boardstatus.Status(board);

            Assert.Equal((EnumBoardStatus.InProgress, null), status);
        }

        [Fact]
        public void show_winning_lines()
        {
            var renderer = new Renderer();

            var board = new Board();

            var boardstatus = new BoardStatus();

            var sb = new StringBuilder();

            foreach (var line in boardstatus.WinningLines)
            {
                board.Clear();

                foreach (var pair in line)
                {
                    board.Set(pair.Item1, pair.Item2, EnumCellType.Cross);
                }

                sb.Append(renderer.Render(board));
                sb.Append(Environment.NewLine);
            };

            var allLines = sb.ToString();
        }
    }

    public class TestDataWinningLinesGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { EnumCellType.Cross, new [] { (0, 0), (0, 1), (0, 2) } },
            new object[] { EnumCellType.Cross, new [] { (1, 0), (1, 1), (1, 2) } },
            new object[] { EnumCellType.Cross, new [] { (2, 0), (2, 1), (2, 2) } },

            new object[] { EnumCellType.Cross, new [] { (0, 0), (1, 0), (2, 0) } },
            new object[] { EnumCellType.Cross, new [] { (0, 1), (1, 1), (2, 1) } },
            new object[] { EnumCellType.Cross, new [] { (0, 2), (1, 2), (2, 2) } },

            new object[] { EnumCellType.Cross, new [] { (0, 0), (1, 1), (2, 2) } },
            new object[] { EnumCellType.Cross, new [] { (0, 2), (1, 1), (2, 0) } },

            new object[] { EnumCellType.Naught, new [] { (0, 0), (0, 1), (0, 2) } },
            new object[] { EnumCellType.Naught, new [] { (1, 0), (1, 1), (1, 2) } },
            new object[] { EnumCellType.Naught, new [] { (2, 0), (2, 1), (2, 2) } },

            new object[] { EnumCellType.Naught, new [] { (0, 0), (1, 0), (2, 0) } },
            new object[] { EnumCellType.Naught, new [] { (0, 1), (1, 1), (2, 1) } },
            new object[] { EnumCellType.Naught, new [] { (0, 2), (1, 2), (2, 2) } },

            new object[] { EnumCellType.Naught, new [] { (0, 0), (1, 1), (2, 2) } },
            new object[] { EnumCellType.Naught, new [] { (0, 2), (1, 1), (2, 0) } },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }

    public class TestDataNonWinningGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { EnumCellType.Cross, new [] { (0, 0), (0, 2), (1, 1) } },
            new object[] { EnumCellType.Cross, new [] { (1, 0), (1, 1), (2, 2) } },
            new object[] { EnumCellType.Cross, new [] { (2, 0), (2, 1), (2, 0) } },

            new object[] { EnumCellType.Naught, new [] { (0, 0), (0, 2), (1, 1) } },
            new object[] { EnumCellType.Naught, new [] { (1, 0), (1, 1), (2, 2) } },
            new object[] { EnumCellType.Naught, new [] { (2, 0), (2, 1), (2, 0) } },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }

    public class TestDataDrawGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new []
            {
                (0, 0, EnumCellType.Cross), (0, 1, EnumCellType.Naught), (0, 2, EnumCellType.Naught),
                (1, 0, EnumCellType.Naught), (1, 1, EnumCellType.Cross), (1, 2, EnumCellType.Cross),
                (2, 0, EnumCellType.Cross), (2, 1, EnumCellType.Naught), (2, 2, EnumCellType.Naught) }
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
