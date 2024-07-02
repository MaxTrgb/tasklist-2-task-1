using System.Threading;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public string numbersPriority;
        public string lettersPriority;
        public string symbolsPriority;
        public Form1()
        {
            InitializeComponent();

            initializeComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numbersPriority = comboBox1.SelectedItem.ToString();
            lettersPriority = comboBox2.SelectedItem.ToString();
            symbolsPriority = comboBox3.SelectedItem.ToString();


            printNumbers(numbersPriority);
            printLetters(lettersPriority);
            printSymbols(symbolsPriority);
        }

        private void printNumbers(string numbersPriority)
        {
            listBox1.Items.Clear();

            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };

            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Invoke((Action)(() =>
                    {
                        listBox1.Items.Add(nums[i]);

                    }));
                }
            });
            thread.Start();
            thread.Priority = getPriority(symbolsPriority);
        }
        private void printLetters(string lettersPriority)
        {
            string abc = "abcdefghijklmnopqrstuvwxyz";

            Thread thread = new Thread(() =>
            {

                for (int i = 0; i < 5; i++)
                {
                    Invoke((Action)(() =>
                    {
                        listBox1.Items.Add(abc[i]);

                    }));
                }
            });
            thread.Start();
            thread.Priority = getPriority(symbolsPriority);
        }

        private void printSymbols(string symbolsPriority)
        {
            string symbols = "!@#$%^&*()_+";

            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Invoke((Action)(() =>
                    {
                        listBox1.Items.Add(symbols[i]);
                    }));
                }
            });
            thread.Start();
            thread.Priority = getPriority(symbolsPriority);
        }

        private void initializeComboBox()
        {
            comboBox1.Items.Add("High");
            comboBox1.Items.Add("Medium");
            comboBox1.Items.Add("Low");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedItem = "Medium";

            comboBox2.Items.Add("High");
            comboBox2.Items.Add("Medium");
            comboBox2.Items.Add("Low");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedItem = "Medium";


            comboBox3.Items.Add("High");
            comboBox3.Items.Add("Medium");
            comboBox3.Items.Add("Low");
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.SelectedItem = "Medium";
        }

        private ThreadPriority getPriority(string priority)
        {
            switch (priority)
            {
                case "High":
                    return ThreadPriority.Highest;
                case "Medium":
                    return ThreadPriority.Normal;
                case "Low":
                    return ThreadPriority.Lowest;
                default:
                    return ThreadPriority.Normal;

            }
        }
    }
}