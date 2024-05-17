using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_Pad
{
    public partial class Main : Form
    {
        private const int innerSize = 7;
        private const int outerSize = 4;

        private static GroupBox currentGroup        = null;
        private static Label currentButton          = null;
        private static int currentOuterGroupIndex   = 1;
        private static int currentInnerButtonIndex  = 0;

        public Main()
        {
            InitializeComponent();

            timer_step.Start();

            SelectGroupBoxByTabIndex(GetTabIndex(currentOuterGroupIndex, outerSize));
            CurrentGroupColorChange(Color.LightGray);
            SelectButtonByTabIndex(0);
        }

        private static int GetTabIndex(int index, int size)
        {
            index = (index % size + size) % size;
            return index;
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
                if (control is Label)
                {
                    Label button = control as Label;
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
                if (control is Label)
                {
                    Label button = control as Label;

                    button.BackColor = color;
                }
            }
        }

        private void CurrentButtonColorChange(Color color)
        {
            currentButton.BackColor = color;
        }

        private void timer_step_Tick(object sender, EventArgs e)
        {
            if(currentGroup == null || currentButton == null)
            {
                return;
            }

            int currentButtonIndex = GetTabIndex(currentInnerButtonIndex, innerSize);
            CurrentButtonColorChange(SystemColors.Control);
            SelectButtonByTabIndex(currentButtonIndex);

            int currentGroupIndex = GetTabIndex(currentOuterGroupIndex, outerSize);
            CurrentGroupColorChange(SystemColors.Control);
            SelectGroupBoxByTabIndex(currentGroupIndex);
            SelectButtonByTabIndex(currentInnerButtonIndex);

            CurrentGroupColorChange(Color.LightGray);
            CurrentButtonColorChange(Color.LightGreen);
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Console.WriteLine("Enter");

                Console.WriteLine("'" + currentButton.Text + "' Tıklandı");

                if (currentButton.Text == "🡸")
                {
                    Console.WriteLine("Silindi");
                    richTextBox.Text = richTextBox.Text.Substring(0, richTextBox.Text.Length - 1);
                }
                else if (currentButton.Text == "﹈")
                {
                    Console.WriteLine("Boşluk");
                    richTextBox.Text += " ";
                }
                else
                {
                    richTextBox.Text += currentButton.Text;
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

                currentInnerButtonIndex++;
            }

            if (e.KeyCode == Keys.Down)
            {
                Console.WriteLine("Aşağı");

                currentInnerButtonIndex--;
            }

            if (e.KeyCode == Keys.Left)
            {
                Console.WriteLine("Sol");

                currentOuterGroupIndex--;
            }

            if (e.KeyCode == Keys.Right)
            {
                Console.WriteLine("Sağ");

                currentOuterGroupIndex++;
            }
        }
    }
}
