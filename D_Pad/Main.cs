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
        private bool upPressed          = false;
        private bool downPressed        = false;
        private bool leftPressed        = false;
        private bool rightPressed       = false;
        private bool enterPressed       = false;

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
            if (upPressed)
            {
                if(currentGroup == null)
                {
                    return;
                }

                Console.WriteLine("Buton Değiştirildi");

                currentInnerButtonIndex++;
                int currentButtonIndex = GetTabIndex(currentInnerButtonIndex, innerSize);
                CurrentButtonColorChange(SystemColors.Control);
                SelectButtonByTabIndex(currentButtonIndex);

                upPressed = false;
            }
            else if (downPressed)
            {
                if (currentGroup == null)
                {
                    return;
                }

                Console.WriteLine("Buton Değiştirildi");

                currentInnerButtonIndex--;
                int currentButtonIndex = GetTabIndex(currentInnerButtonIndex, innerSize);
                CurrentButtonColorChange(SystemColors.Control);
                SelectButtonByTabIndex(currentButtonIndex);

                downPressed = false;
            }
            else if (leftPressed)
            {
                if (currentGroup == null)
                {
                    return;
                }

                Console.WriteLine("Grup Değiştirildi");

                currentOuterGroupIndex--;
                int currentGroupIndex = GetTabIndex(currentOuterGroupIndex, outerSize);
                CurrentGroupColorChange(SystemColors.Control);
                SelectGroupBoxByTabIndex(currentGroupIndex);
                SelectButtonByTabIndex(currentInnerButtonIndex);

                leftPressed = false;
            }
            else if (rightPressed)
            {
                if (currentGroup == null)
                {
                    return;
                }

                Console.WriteLine("Grup Değiştirildi");

                currentOuterGroupIndex++;
                int currentGroupIndex = GetTabIndex(currentOuterGroupIndex, outerSize);
                CurrentGroupColorChange(SystemColors.Control);
                SelectGroupBoxByTabIndex(currentGroupIndex);
                SelectButtonByTabIndex(currentInnerButtonIndex);

                rightPressed = false;
            }
            else if (enterPressed)
            {
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

                enterPressed = false;
            }
            else
            {
            }

            CurrentGroupColorChange(Color.LightGray);
            CurrentButtonColorChange(Color.LightGreen);
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Console.WriteLine("Enter");
                enterPressed = true;
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
                upPressed = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                Console.WriteLine("Aşağı");
                downPressed = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                Console.WriteLine("Sol");
                leftPressed = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                Console.WriteLine("Sağ");
                rightPressed = true;
            }
        }
    }
}
