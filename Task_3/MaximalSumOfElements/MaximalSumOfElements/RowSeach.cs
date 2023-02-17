using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MaximumSumOfElements
{
    public class RowSeach
    {
        private List<string> _rows = new List<string>();
        private List<int> _brokenRows = new List<int>();
        private List<int> _maxRows = new List<int>();

        public double? MaxSum { get; private set; }

        public List<int> MaxRow
        {
            get { return _maxRows; }
        }

        public List<int> BrokenRows
        {
            get { return _brokenRows; }
        }

        public RowSeach(string path)
        {
            GetRows(path);
            GetRowsInfo();
        }

        private void GetRows(string path)
        {
            if (!File.Exists(path))
                _rows.Clear();
            else
                _rows = File.ReadAllLines(path).ToList();
        }

        private void GetRowsInfo()
        {
            for (int i = 0; i < _rows.Count; i++)
            {
                if (CheckRowsValid(_rows[i]))
                {
                    var sumOfRow = GetSumOfRow(_rows[i]);
                    MaxSum ??= sumOfRow;
                    if (sumOfRow >= MaxSum)
                    {
                        if (sumOfRow > MaxSum)
                            _maxRows.Clear();
                        _maxRows.Add(i + 1);
                        MaxSum = sumOfRow;
                    }
                }
                else
                    _brokenRows.Add(i + 1);
            }
        }

        private bool CheckRowsValid(string row)
        {
            if (string.IsNullOrEmpty(row))
                return false;
            var elemetArray = row.Split(",", StringSplitOptions.TrimEntries);
            foreach (var element in elemetArray)
                if (!double.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out double itemParse))
                    return false;
            return true;
        }

        private double GetSumOfRow(string row)
        {
            double sumOfRow = 0;
            var elemetArray = row.Split(",", StringSplitOptions.TrimEntries);
            foreach (var element in elemetArray)
                sumOfRow += double.Parse(element, NumberStyles.Any, CultureInfo.InvariantCulture);
            return sumOfRow;
        }
    }
}

