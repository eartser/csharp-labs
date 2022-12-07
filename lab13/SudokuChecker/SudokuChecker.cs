namespace SudokuChecker;

public class SudokuChecker
{
    public bool Check(List<List<string>> table)
    {
        var res = true;
        for (int i = 0; i < 9; i++)
        {
            res &= CheckSequence(GetRowByIndex(table, i));
            res &= CheckSequence(GetColumnByIndex(table, i));
            res &= CheckSequence(GetBlockByIndex(table, i));

            if (!res)
                break;
        }

        return res;
    }

    private static List<string> GetRowByIndex(List<List<string>> table, int i)
    {
        return table[i];
    }

    private static List<string> GetColumnByIndex(List<List<string>> table, int i)
    {
        return table.Select(row => row[i]).ToList();
    }

    private static List<string> GetBlockByIndex(List<List<string>> table, int i)
    {
        var block = new List<string>();
        var r = (i / 3) * 3;
        var c = (i % 3) * 3;

        for (var k = r; k < r + 3; k++)
        {
            for (var m = c; m < c + 3; m++)
            {
                block.Add(table[k][m]);
            }
        }

        return block;
    }

    private static bool CheckSequence(IEnumerable<string> seq)
    {
        var numericList = seq
            .Where(it => it != ".")
            .Select(it => Convert.ToInt32(it))
            .ToList();
        numericList.Sort();
        var numericSet = new HashSet<int>(numericList);
        return numericList.All(it => it >= 1 && it <= 9) && numericList.Count == numericSet.Count;
    }
}