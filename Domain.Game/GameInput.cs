using System;
using System.Text.RegularExpressions;
using Domain;
using Domain.Abstract;
using Domain.Game.Abstract;

namespace App
{
    public class GameInput : IGameInput
    {
        readonly IInputOutput inputOutput;

        public GameInput(IInputOutput inputOutput) => this.inputOutput = inputOutput;

        public (int, int) Get(IBoard board, EnumCellType boardEntryType)
        {
            while (true)
            {
                inputOutput.Output(
                    $"{Environment.NewLine}Enter row and column for {(boardEntryType == EnumCellType.Cross ? "X" : "O")}");

                var line = inputOutput.Input()?.Trim();

                try
                {
                    return ParseAndValidateInput(board, line);
                }
                catch (ArgumentException exc)
                {
                    inputOutput.Output(exc.Message);
                }
            }
        }

        (int, int) ParseAndValidateInput(IBoard board, string line)
        {
            if (Regex.IsMatch(line, @"^\d\d"))
            {
                int row = int.Parse(line.Substring(0, 1));
                int column = int.Parse(line.Substring(1, 1));

                static bool ValidateBounds(int dim) => dim >= 0 && dim <= 2;

                if (ValidateBounds(row) && ValidateBounds(column))
                {
                    if (board.Entries[row, column] == null)
                    {
                        return (row, column);
                    }

                    throw new ArgumentException("Cell already used");
                }
            }

            throw new ArgumentException("Invalid input. Enter row and column as two single digits, each from 0 to 2. e.g. 01");
        }
    }
}
