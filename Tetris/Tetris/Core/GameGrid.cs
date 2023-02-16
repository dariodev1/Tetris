namespace Tetris.Core
{
    public class GameGrid
    {
        private readonly int[,] _grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int row, int column]
        {
            get { return _grid[row, column]; }
            set { _grid[row, column] = value; }
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _grid = new int[rows, columns];
        }

        public bool IsInside(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        public bool IsEmpty(int row, int columns)
        {
            return IsInside(row, columns) && _grid[row, columns] == 0;
        }

        public bool IsRowFull(int row)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (_grid[row, col] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int row)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (_grid[row, col] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int row)
        {
            for (int col = 0; col < Columns; col++)
            {
                _grid[row, col] = 0;
            }
        }

        private void MoveRowDown(int row, int numRows)
        {
            for (int col = 0; col < Columns; col++)
            {
                _grid[row + numRows, col] = _grid[row, col];
                _grid[row, col] = 0;
            }
        }

        public int ClearFullRows()
        {
            int numberOfClearedRows = 0;

            for (int row = Rows - 1; row >= 0; row--)
            {
                if (IsRowFull(row))
                {
                    ClearRow(row);
                    numberOfClearedRows++;
                }
                else if (numberOfClearedRows > 0)
                {
                    MoveRowDown(row, numberOfClearedRows);
                }
            }

            return numberOfClearedRows;
        }
    }
}
