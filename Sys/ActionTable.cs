using System.Data;

namespace TGMacro
{
    public class ActionTable : DataTable
    {
        public enum TableRowDirection
        {
            Up,
            Down
        }
        public int MoveRow(DataRow row, TableRowDirection direction)
        {
            DataRow oldRow = row;
            DataRow newRow = NewRow();

            newRow.ItemArray = oldRow.ItemArray;

            int oldRowIndex = Rows.IndexOf(row);

            if (direction == TableRowDirection.Down)
            {
                int newRowIndex = oldRowIndex + 1;

                if (oldRowIndex < (Rows.Count))
                {
                    Rows.Remove(oldRow);
                    Rows.InsertAt(newRow, newRowIndex);
                    return Rows.IndexOf(newRow);
                }
            }

            if (direction == TableRowDirection.Up)
            {
                int newRowIndex = oldRowIndex - 1;

                if (oldRowIndex > 0)
                {
                    Rows.Remove(oldRow);
                    Rows.InsertAt(newRow, newRowIndex);
                    return Rows.IndexOf(newRow);
                }
            }

            return 0;
        }
    }
}
