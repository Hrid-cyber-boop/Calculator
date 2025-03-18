namespace Calculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        String operationPerformed = "";
        bool isoperationDone = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if ((textBox_result.Text == "0") || (isoperationDone))
            {
                textBox_result.Clear();
            }
            isoperationDone = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_result.Text.Contains("."))
                {
                    textBox_result.Text = textBox_result.Text + button.Text;
                }
            }
            else
            {

                textBox_result.Text = textBox_result.Text + button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // If there's already a result and an operation, perform the calculation first
            if (result != 0)
            {
                if (!isoperationDone) // Prevent immediate execution when switching operators
                {
                    button19.PerformClick();
                }
            }

            // Set the current operation and prepare for the next input
            operationPerformed = button.Text;
            result = double.Parse(textBox_result.Text);
            isoperationDone = true;

            // Update the label to reflect the ongoing operation
            label1.Text = $"{result} {operationPerformed}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
            result = 0;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                switch (operationPerformed)
                {
                    case "+":
                        textBox_result.Text = (result + double.Parse(textBox_result.Text)).ToString();
                        break;
                    case "-":
                        textBox_result.Text = (result - double.Parse(textBox_result.Text)).ToString();
                        break;
                    case "*":
                        textBox_result.Text = (result * double.Parse(textBox_result.Text)).ToString();
                        break;
                    case "/":
                        if (double.Parse(textBox_result.Text) != 0)
                        {
                            textBox_result.Text = (result / double.Parse(textBox_result.Text)).ToString();
                        }
                        else
                        {
                            textBox_result.Text = "Error"; // Handle division by zero
                        }
                        break;
                    default:
                        break;
                }

                // Update result for further calculations
                result = double.Parse(textBox_result.Text);
                operationPerformed = ""; // Reset operation
                label1.Text = ""; // Clear label
            }
            catch (Exception ex)
            {
                textBox_result.Text = "Error";
                Console.WriteLine(ex.Message);
            }
        }

    }
}
