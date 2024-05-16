using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraduationProject
{
    public partial class Main : Form
    {
        private int x = 0;
        private int y = 0;

        private bool upPressed          = false;
        private bool downPressed        = false;
        private bool leftPressed        = false;
        private bool rightPressed       = false;
        private bool RightUpPressed     = false;
        private bool RightDownPressed   = false;
        private bool LeftUpPressed      = false;
        private bool LeftDownPressed    = false;
        private bool enterPressed       = false;
        private bool escapePressed      = false;

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

        private void CurrentGroupButtonColorChange(Color color)
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
            CurrentGroupButtonColorChange(Color.LightGray);
        }

        private void timer_step_Tick(object sender, EventArgs e)
        {
            if(upPressed)
            {
                if(!isGroupSelected)
                {
                    currentOuterRow--;
                    int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                    CurrentGroupButtonColorChange(SystemColors.Control);
                    SelectGroupBoxByTabIndex(currentGroupIndex);
                }
                else
                {
                    currentInnerRow--;
                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    CurrentButtonColorChange(SystemColors.Control);
                    SelectButtonByTabIndex(currentButtonIndex);
                }

                upPressed = false;
            }
            else if(downPressed)
            {
                if (!isGroupSelected)
                {
                    currentOuterRow++;
                    int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                    CurrentGroupButtonColorChange(SystemColors.Control);
                    SelectGroupBoxByTabIndex(currentGroupIndex);
                }
                else
                {
                    currentInnerRow++;
                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    CurrentButtonColorChange(SystemColors.Control);
                    SelectButtonByTabIndex(currentButtonIndex);
                }

                downPressed = false;
            }
            else if(leftPressed)
            {
                if (!isGroupSelected)
                {
                    currentOuterColumn--;
                    int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                    CurrentGroupButtonColorChange(SystemColors.Control);
                    SelectGroupBoxByTabIndex(currentGroupIndex);
                }
                else
                {
                    currentInnerColumn--;
                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    CurrentButtonColorChange(SystemColors.Control);
                    SelectButtonByTabIndex(currentButtonIndex);
                }

                leftPressed = false;
            }
            else if(rightPressed)
            {
                if (!isGroupSelected)
                {
                    currentOuterColumn++;
                    int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                    CurrentGroupButtonColorChange(SystemColors.Control);
                    SelectGroupBoxByTabIndex(currentGroupIndex);
                }
                else
                {
                    currentInnerColumn++;
                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    CurrentButtonColorChange(SystemColors.Control);
                    SelectButtonByTabIndex(currentButtonIndex);
                }

                rightPressed = false;
            }
            else if(RightUpPressed)
            {
                if (!isGroupSelected)
                {
                    currentOuterColumn++;
                    currentOuterRow--;
                    int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                    CurrentGroupButtonColorChange(SystemColors.Control);
                    SelectGroupBoxByTabIndex(currentGroupIndex);
                }
                else
                {
                    currentInnerColumn++;
                    currentInnerRow--;
                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    CurrentButtonColorChange(SystemColors.Control);
                    SelectButtonByTabIndex(currentButtonIndex);
                }

                RightUpPressed = false;
            }
            else if(RightDownPressed)
            {
                if (!isGroupSelected)
                {
                    currentOuterColumn++;
                    currentOuterRow++;
                    int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                    CurrentGroupButtonColorChange(SystemColors.Control);
                    SelectGroupBoxByTabIndex(currentGroupIndex);
                }
                else
                {
                    currentInnerColumn++;
                    currentInnerRow++;
                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    CurrentButtonColorChange(SystemColors.Control);
                    SelectButtonByTabIndex(currentButtonIndex);
                }

                RightDownPressed = false;
            }
            else if(LeftUpPressed)
            {
                if (!isGroupSelected)
                {
                    currentOuterColumn--;
                    currentOuterRow--;
                    int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                    CurrentGroupButtonColorChange(SystemColors.Control);
                    SelectGroupBoxByTabIndex(currentGroupIndex);
                }
                else
                {
                    currentInnerColumn--;
                    currentInnerRow--;
                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    CurrentButtonColorChange(SystemColors.Control);
                    SelectButtonByTabIndex(currentButtonIndex);
                }

                LeftUpPressed = false;
            }
            else if(LeftDownPressed)
            {
                if (!isGroupSelected)
                {
                    currentOuterColumn--;
                    currentOuterRow++;
                    int currentGroupIndex = GetTabIndex(currentOuterRow, currentOuterColumn, outerSize);
                    CurrentGroupButtonColorChange(SystemColors.Control);
                    SelectGroupBoxByTabIndex(currentGroupIndex);
                }
                else
                {
                    currentInnerColumn--;
                    currentInnerRow++;
                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    CurrentButtonColorChange(SystemColors.Control);
                    SelectButtonByTabIndex(currentButtonIndex);
                }

                LeftDownPressed = false;
            }
            else if(enterPressed)
            {
                if(!isGroupSelected)
                {
                    Console.WriteLine("Grup Seçildi");

                    int currentButtonIndex = GetTabIndex(currentInnerRow, currentInnerColumn, innerSize);
                    SelectButtonByTabIndex(currentButtonIndex);

                    isGroupSelected = true;
                }
                else
                {
                    Console.WriteLine("'" + currentButton.Text + "' Tıklandı");

                    if(currentButton.Text == "🡸")
                    {
                        richTextBox.Text = richTextBox.Text.Substring(0, richTextBox.Text.Length - 1);
                    }
                    else if(currentButton.Text == "﹈")
                    {
                        richTextBox.Text += " ";
                    }
                    else
                    {
                        richTextBox.Text += currentButton.Text;
                    }
                }
                
                enterPressed = false;
            }
            else if(escapePressed)
            {
                if (isGroupSelected)
                {
                    Console.WriteLine("Gruptan Çıkıldı");

                    currentInnerRow = 0;
                    currentInnerColumn = 0;

                    isGroupSelected = false;
                }

                escapePressed = false;
            }
            else
            {
            }

            CurrentGroupButtonColorChange(Color.LightGray);

            if(isGroupSelected)
            {
                CurrentButtonColorChange(Color.LightGreen);
            }
            else
            {
                CurrentGroupButtonColorChange(Color.LightGray);
            }
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Console.WriteLine("Enter");
                enterPressed = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                Console.WriteLine("Escape");
                escapePressed = true;
            }
            else
            {
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                y++;
            }

            if (e.KeyCode == Keys.Down)
            {
                y--;
            }

            if (e.KeyCode == Keys.Left)
            {
                x--;
            }

            if (e.KeyCode == Keys.Right)
            {
                x++;
            }

        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (x == 1 && y == 1)
            {
                Console.WriteLine("Sağ Yukarı Çapraz");
                RightUpPressed = true;
            }
            else if (x == -1 && y == 1)
            {
                Console.WriteLine("Sol Yukarı Çapraz");
                LeftUpPressed = true;
            }
            else if (x == 1 && y == -1)
            {
                Console.WriteLine("Sağ Aşağı Çapraz");
                RightDownPressed = true;
            }
            else if (x == -1 && y == -1)
            {
                Console.WriteLine("Sol Aşağı Çapraz");
                LeftDownPressed = true;
            }
            else if (x == 1)
            {
                Console.WriteLine("Sağ");
                rightPressed = true;
            }
            else if (x == -1)
            {
                Console.WriteLine("Sol");
                leftPressed = true;
            }
            else if (y == 1)
            {
                Console.WriteLine("Yukarı");
                upPressed = true;
            }
            else if (y == -1)
            {
                Console.WriteLine("Aşağı");
                downPressed = true;
            }
            else
            {
            }

            x = 0;
            y = 0;
        }

        private void button_a_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_b_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_g_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_h_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_d_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_i_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void buttonj_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_e_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_f_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_k_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_l_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_m_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_n_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_s_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_t_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_o_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_p_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_u_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_v_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_q_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_r_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_w_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_x_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_y_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_z_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_comma_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_shift_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_op_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_cp_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("'" + button.Text + "' Tıklandı");
        }
    }
}
