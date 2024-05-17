using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraduationProject
{
    public partial class Main : Form
    {
        private const int innerSize = 2;
        private const int outerSize = 3;

        private static GroupBox currentGroup    = null;
        private static Button currentButton     = null;
        private static int currentOuterRow      = 1;
        private static int currentOuterColumn   = 1;
        private static int currentInnerRow      = 0;
        private static int currentInnerColumn   = 0;
        private static bool isGroupSelected     = false;

        private static int GetTabIndex(int row, int column, int size)
        {
            row = (row % size + size) % size;
            column = (column % size + size) % size;
            return row * size + column;
        }

        private void SelectGroupBoxByTabIndex(int index)
        {
            foreach (Control control in this.groupBox_keyboard.Controls)
            {
                if (control is GroupBox)
                {
                    GroupBox group = control as GroupBox;
                    if (group.TabIndex == index)
                    {
                        currentGroup = group;
                        break;
                    }
                }
            }
        }

        private void SelectButtonByTabIndex(int index)
        {
            foreach (Control control in currentGroup.Controls)
            {
                if (control is Button)
                {
                    Button button = control as Button;
                    if (button.TabIndex == index)
                    {
                        currentButton = button;
                        break;
                    }
                }
            }
        }

        private void CurrentGroupColorChange(Color color)
        {
            foreach (Control control in currentGroup.Controls)
            {
                if (control is Button)
                {
                    Button buttonControl = control as Button;

                    buttonControl.BackColor = color;
                }
            }
        }

        private void CurrentButtonColorChange(Color color)
        {
            currentButton.BackColor = color;
        }

        public Main()
        {
            InitializeComponent();

            timer_step.Start();

            SelectGroupBoxByTabIndex(GetTabIndex(currentOuterRow, currentOuterColumn, outerSize));
            CurrentGroupColorChange(Color.LightGray);
        }

        private void timer_step_Tick(object sender, EventArgs e)
        {
            if(!isGroupSelected)
            {
                int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                CurrentGroupColorChange(SystemColors.Control);
                SelectGroupBoxByTabIndex(currentGroupIndex);
            }
            else
            {
                int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                CurrentButtonColorChange(SystemColors.Control);
                SelectButtonByTabIndex(currentButtonIndex);
            }


            CurrentGroupColorChange(Color.LightGray);

            if(isGroupSelected)
            {
                CurrentButtonColorChange(Color.LightGreen);
            }
            else
            {
                CurrentGroupColorChange(Color.LightGray);
            }
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Console.WriteLine("Enter");

                if (!isGroupSelected)
                {
                    Console.WriteLine("Grup Seçildi");

                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    SelectButtonByTabIndex(currentButtonIndex);

                    isGroupSelected = true;
                }
                else
                {
                    Console.WriteLine("'" + currentButton.Text + "' Tıklandı");

                    if (currentButton.Text == "🡸")
                    {
                        richTextBox.Text = richTextBox.Text.Substring(0, richTextBox.Text.Length - 1);
                    }
                    else if (currentButton.Text == "﹈")
                    {
                        richTextBox.Text += " ";
                    }
                    else
                    {
                        richTextBox.Text += currentButton.Text;
                    }
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                Console.WriteLine("Escape");

                if (isGroupSelected)
                {
                    Console.WriteLine("Gruptan Çıkıldı");

                    currentInnerRow = 0;
                    currentInnerColumn = 0;

                    isGroupSelected = false;
                }
            }
            else
            {
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Console.WriteLine("Yukarı");

                if (!isGroupSelected)
                {
                    currentOuterRow--;
                }
                else
                {
                    currentInnerRow--;
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                Console.WriteLine("Aşağı");

                if (!isGroupSelected)
                {
                    currentOuterRow++;
                }
                else
                {
                    currentInnerRow++;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                Console.WriteLine("Sol");

                if (!isGroupSelected)
                {
                    currentOuterColumn--;
                }
                else
                {
                    currentInnerColumn--;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                Console.WriteLine("Sağ");

                if (!isGroupSelected)
                {
                    currentOuterColumn++;
                }
                else
                {
                    currentInnerColumn++;
                }
            }
        }
    }
}
