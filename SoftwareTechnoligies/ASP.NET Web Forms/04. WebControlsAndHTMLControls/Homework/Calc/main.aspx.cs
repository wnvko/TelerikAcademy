namespace Calc
{
    using System;
    using System.Web.UI.WebControls;
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.InitControls();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            this.ProcessButton(button);
        }

        private void InitControls()
        {
            this.textResult.Enabled = false;
            this.lableResult.Visible = false;
            this.labelOperand.Visible = false;
            this.labelNewNumber.Visible = false;

            this.button0.Click += Button_Click;
            this.button1.Click += Button_Click;
            this.button2.Click += Button_Click;
            this.button3.Click += Button_Click;
            this.button4.Click += Button_Click;
            this.button5.Click += Button_Click;
            this.button6.Click += Button_Click;
            this.button7.Click += Button_Click;
            this.button8.Click += Button_Click;
            this.button9.Click += Button_Click;
            this.buttonClear.Click += Button_Click;
            this.buttonDivide.Click += Button_Click;
            this.buttonEqual.Click += Button_Click;
            this.buttonMinus.Click += Button_Click;
            this.buttonMultiply.Click += Button_Click;
            this.buttonPlus.Click += Button_Click;
            this.buttonSquareRoot.Click += Button_Click;
        }

        private void ProcessButton(Button button)
        {
            var curentInput = 0d;
            double.TryParse(this.textResult.Text, out curentInput);

            switch (button.Text)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (this.labelNewNumber.Text == "true")
                    {
                        this.textResult.Text = string.Empty;
                    }

                    this.textResult.Text += button.Text;
                    this.labelNewNumber.Text = string.Empty;
                    break;
                case "+":
                case "-":
                case "X":
                case "/":
                    this.ProcessPrevOperand(curentInput);
                    this.labelNewNumber.Text = "true";
                    this.labelOperand.Text = button.Text;
                    break;
                case "√":
                    if (curentInput < 0)
                    {
                        this.lableResult.Text = "0";
                        this.labelOperand.Text = string.Empty;
                        this.textResult.Text = "Invalid input";
                        return;
                    }

                    curentInput = Math.Sqrt(curentInput);
                    this.textResult.Text = curentInput.ToString();
                    break;
                case "Clear":
                    this.textResult.Text = string.Empty;
                    this.labelOperand.Text = string.Empty;
                    this.lableResult.Text = "0";
                    break;
                case "=":
                    this.ProcessPrevOperand(curentInput);
                    this.labelNewNumber.Text = "true";
                    this.labelOperand.Text = string.Empty;
                    this.lableResult.Text = "0";
                    break;
            }
        }

        private void ProcessPrevOperand(double curentInput)
        {
            if (string.IsNullOrEmpty(this.labelOperand.Text))
            {
                this.lableResult.Text = curentInput.ToString();
                return;
            }

            var curentResult = 0d;
            double.TryParse(this.lableResult.Text, out curentResult);

            switch (this.labelOperand.Text)
            {
                case "+":
                    curentResult += curentInput;
                    break;
                case "-":
                    curentResult -= curentInput;
                    break;
                case "X":
                    curentResult *= curentInput;
                    break;
                case "/":
                    if (curentInput == 0)
                    {
                        this.lableResult.Text = "0";
                        this.labelOperand.Text = string.Empty;
                        this.textResult.Text = "Cannot divide by zero!";
                        return;
                    }

                    curentResult /= curentInput;
                    break;
            }

            this.lableResult.Text = curentResult.ToString();
            this.textResult.Text = curentResult.ToString();
            this.labelOperand.Text = string.Empty;
        }
    }
}