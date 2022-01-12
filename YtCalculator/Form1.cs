namespace YtCalculator
{
    public partial class CalculatorForm : Form
    {

        #region variables 
        // as I said simple calculator only support these operations
        string[] _operatorList = new string[] { "+", "-", "/", "*" };

        // reservednumber1 is before operator entered, 2 will be set after = 
        double? _reservedNumber1 = null, _reservedNumber2 = null;

        // I need to know which operator selected 

        string _operator = null;
        // as you see after calculation it continue to keep previous value in textbox . we want to clear after  = 

        bool _clearText = false;
        #endregion  
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // all buttons will be handled here. 

            var text = ((Button)sender).Text;



            // if the button is an operator we need store the first value 

            var isOpeartor = _operatorList.Any(p => p == text);
            if (isOpeartor)
            {
                if (double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber1 = temp;
                    txtInput.Clear();
                    lblResult.Text = $"{_reservedNumber1} {text}";
                    _operator = text;
                }
            }
            else
            if (text == "=")
            {
                if (double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber2 = temp;
                }
                Calculate();
                _clearText = true;
            }
            else
            {
                if (_clearText)
                {
                    txtInput.Text = text;
                    // only once will be cleared then rest will be the same flow.
                    _clearText = false;
                }
                else
                {
                    txtInput.Text += text;
                }
            }
        }

        private void Calculate()
        {
            double? result = 0;
            switch (_operator)
            {
                case "+":
                    result = _reservedNumber2 + _reservedNumber1;
                    break;
                case "/":
                    result = _reservedNumber1 / _reservedNumber2;
                    break;
                case "-":
                    result = _reservedNumber1 - _reservedNumber2;
                    break;
                case "*":
                    result = _reservedNumber2 * _reservedNumber1;
                    break;
                default:
                    break;
            }
            lblResult.Text = result.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            lblResult.Text = String.Empty;
        }
    }
}