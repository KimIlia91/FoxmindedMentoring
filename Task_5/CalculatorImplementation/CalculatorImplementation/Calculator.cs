using System.Globalization;

namespace CalculatorImplementation
{
    public class Calculator
    {
        private Stack<string> _numbersStack = new Stack<string>();
        private Stack<char> _operatorsStack = new Stack<char>();
        private readonly Exception _exceptionWrongFormat = new Exception("Wrong expression format.");
        private readonly Exception _exceptionWrongInput = new Exception("Exception! Wrong input.");
        private readonly Exception _exceptionDivideByZero = new Exception("Exception! Divide by zero.");
        private readonly Dictionary<char, uint> _operationPriority = new Dictionary<char, uint>
        {
            {'(', 0},
            {')', 0},
            {'+', 1},
            {'-', 1},
            {'*', 2},
            {'/', 2},
            {'^', 3},
        };

        public Calculator()
        {
            _numbersStack = new Stack<string>();
            _operatorsStack = new Stack<char>();
        }

        public string Calculate(string userInput)
        {
            _numbersStack.Clear();
            _operatorsStack.Clear();
            if (string.IsNullOrEmpty(userInput))
                return userInput;
            if (!HandleValidInputCheck(userInput))
                throw _exceptionWrongInput;
            return FillStacksForCalculation(userInput.Replace(" ", ""));
        }

        private bool HandleValidInputCheck(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
                if (char.IsLetter(expression[i]))
                    return false;
            return true;
        }

        private string FillStacksForCalculation(string expr)
        {
            for (int i = 0; i < expr.Length; i++)
            {
                if (char.IsDigit(expr[i]) || (expr[i] == '-' && (i == 0 || (i > 1 && _operationPriority.ContainsKey(expr[i - 1])))))
                {
                    _numbersStack.Push(GetStringNumber(expr, ref i) + " ");
                    continue;
                }
                if (_operationPriority.ContainsKey(expr[i]))
                {
                    if (_operatorsStack.Count == 0)
                    {
                        _operatorsStack.Push(expr[i]);
                        continue;
                    }
                    if (_operationPriority[_operatorsStack.Peek()] == _operationPriority[expr[i]] && expr[i] != '(')
                    {
                        _numbersStack.Push(ParseToCalculate().ToString());
                        _operatorsStack.Push(expr[i]);
                    }
                    if (_operationPriority[_operatorsStack.Peek()] < _operationPriority[expr[i]] || expr[i] == '(')
                        _operatorsStack.Push(expr[i]);
                    if (_operationPriority[_operatorsStack.Peek()] > _operationPriority[expr[i]])
                    {
                        _numbersStack.Push(ParseToCalculate().ToString());
                        if (expr[i] == ')')
                        {
                            if (_operatorsStack.Peek() == '(')
                            {
                                _operatorsStack.Pop();
                                continue;
                            }
                            i--;
                            continue;
                        }
                        if (_operatorsStack.Count > 0)
                            if (_operationPriority[_operatorsStack.Peek()] == _operationPriority[expr[i]] && expr[i] != '(')
                                _numbersStack.Push(ParseToCalculate().ToString());
                        _operatorsStack.Push(expr[i]);
                    }
                }
            }
            return StackCalculation();
        }

        private string GetStringNumber(string expr, ref int pos)
        {
            string strNumber = string.Empty;
            for (; pos < expr.Length; pos++)
            {
                char num = expr[pos];
                if (Char.IsDigit(num) || num == '.' || num == ',' || num == '-'
                    && (pos == 0 || (pos > 1 && _operationPriority.ContainsKey(expr[pos - 1]))))
                {
                    strNumber += num;
                    continue;
                }
                pos--;
                break;
            }
            return strNumber;
        }

        private string StackCalculation()
        {
            while (_operatorsStack.Count > 0)
                _numbersStack.Push(ParseToCalculate().ToString());
            if (_numbersStack.Count > 1)
                throw _exceptionWrongFormat;
            return _numbersStack.Pop();
        }

        private double ParseToCalculate()
        {
            if (_operatorsStack.Count == 0 || _numbersStack.Count <= 1)
                throw _exceptionWrongFormat;
            if (!double.TryParse(_numbersStack.Pop().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double rightNumber))
                throw _exceptionWrongFormat;
            if (!double.TryParse(_numbersStack.Pop().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double leftNumber))
                throw _exceptionWrongFormat;
            var operation = _operatorsStack.Pop();
            if (operation == '/' && rightNumber == 0)
                throw _exceptionDivideByZero;
            return Math.Round(MathCalculation(operation, leftNumber, rightNumber), 2);
        }

        private double MathCalculation(char op, double first, double second)
        {
            if (op == '+')
                return first + second;
            if (op == '-')
                return first - second;
            if (op == '*')
                return first * second;
            if (op == '/')
                return first / second;
            if (op == '^')
            {
                if (first < 0)
                    return - Math.Pow(first, second);
                return Math.Pow(first, second);
            }
            return 0;
        }
    }
}
