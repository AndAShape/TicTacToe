using System;
using System.Text;
using Domain.Abstract;

namespace Domain
{
    public class Renderer : IRenderer
    {
        public string Render(IBoard board)
        {
            var sb = new StringBuilder();

            IterateRows(board.Entries, sb);

            return sb.ToString();
        }

        static void IterateRows(EnumCellType?[,] entries, StringBuilder sb)
        {
            for (var i = 0; i < entries.GetLength(0); i++)
            {
                IterateColumns(entries, sb, i);

                sb.Append(Environment.NewLine);
            }
        }

        static void IterateColumns(EnumCellType?[,] entries, StringBuilder sb, int i)
        {
            for (var j = 0; j < entries.GetLength(1); j++)
            {
                var character = LookupCharacter(entries[i, j]);

                sb.Append(character);
            }
        }

        static string LookupCharacter(EnumCellType? boardEntryType)
        {
            switch (boardEntryType)
            {
                case EnumCellType.Cross:
                    {
                        return "X";
                    }
                case EnumCellType.Naught:
                    {
                        return "O";
                    }
                default:
                    {
                        return "-";
                    }
            }
        }
    }
}
