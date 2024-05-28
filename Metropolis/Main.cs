using System;
using System.Drawing;
using System.Windows.Forms;

namespace Metropolis
{
    public partial class Main : Form
    {
        private int x = 0;
        private int y = 0;

        private Node currentNode;
        private Button currentButton;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public Main()
        {
            InitializeComponent();
            InitializeLinkedList();

            currentNode.Button.BackColor = Color.LightGreen;
            currentButton = currentNode.Button;
            currentNode.UpdateLabelTexts();
        }

        private void InitializeLinkedList()
        {
            Node node_a = new Node(button_a);
            Node node_b = new Node(button_b);
            Node node_c = new Node(button_c);
            Node node_d = new Node(button_d);
            Node node_e = new Node(button_e);
            Node node_f = new Node(button_f);
            Node node_g = new Node(button_g);
            Node node_h = new Node(button_h);
            Node node_i = new Node(button_i);
            Node node_j = new Node(button_j);
            Node node_k = new Node(button_k);
            Node node_l = new Node(button_l);
            Node node_m = new Node(button_m);
            Node node_n = new Node(button_n);
            Node node_o = new Node(button_o);
            Node node_p = new Node(button_p);
            Node node_q = new Node(button_q);
            Node node_r = new Node(button_r);
            Node node_s = new Node(button_s);
            Node node_t = new Node(button_t);
            Node node_u = new Node(button_u);
            Node node_v = new Node(button_v);
            Node node_w = new Node(button_w);
            Node node_x = new Node(button_x);
            Node node_y = new Node(button_y);
            Node node_z = new Node(button_z);
            Node node_space = new Node(button_space);
            Node node_backspace = new Node(button_backspace);
            
            Node node_empty1 = new Node(button_empty1);
            Node node_empty2 = new Node(button_empty2);

            currentNode = node_a;
            currentButton = currentNode.Button;

            node_a.SetDirections(node_u,        node_j,     node_space,     node_b);
            node_b.SetDirections(node_v,        node_i,     node_a,         node_c);
            node_c.SetDirections(node_w,        node_h,     node_b,         node_d);
            node_d.SetDirections(node_x,        node_g,     node_c,         node_e);
            node_e.SetDirections(node_y,        node_f,     node_d,         node_space);
            node_f.SetDirections(node_e,        node_o,     node_g,         node_backspace);
            node_g.SetDirections(node_d,        node_n,     node_h,         node_f);
            node_h.SetDirections(node_c,        node_m,     node_i,         node_g);
            node_i.SetDirections(node_b,        node_l,     node_j,         node_h);
            node_j.SetDirections(node_a,        node_k,     node_backspace, node_i);
            node_k.SetDirections(node_j,        node_t,     node_empty1,    node_l);
            node_l.SetDirections(node_i,        node_s,     node_k,         node_m);
            node_m.SetDirections(node_h,        node_r,     node_l,         node_n);
            node_n.SetDirections(node_g,        node_q,     node_m,         node_o);
            node_o.SetDirections(node_f,        node_p,     node_n,         node_empty1);
            node_p.SetDirections(node_o,        node_y,     node_q,         node_empty2);
            node_q.SetDirections(node_n,        node_x,     node_r,         node_p);
            node_r.SetDirections(node_m,        node_w,     node_s,         node_q);
            node_s.SetDirections(node_l,        node_v,     node_t,         node_r);
            node_t.SetDirections(node_k,        node_u,     node_empty2,    node_s);
            node_u.SetDirections(node_t,        node_a,     node_z,         node_v);
            node_v.SetDirections(node_s,        node_b,     node_u,         node_w);
            node_w.SetDirections(node_r,        node_c,     node_v,         node_x);
            node_x.SetDirections(node_q,        node_d,     node_w,         node_y);
            node_y.SetDirections(node_p,        node_e,     node_x,         node_z);
            node_z.SetDirections(node_empty2,   node_space, node_y,         node_u);

            node_space.SetDirections(       node_z,         node_backspace, node_e, node_a);
            node_backspace.SetDirections(   node_space,     node_empty1,    node_f, node_j);
            node_empty1.SetDirections(      node_backspace, node_empty2,    node_o, node_k);
            node_empty2.SetDirections(      node_empty1,    node_z,         node_p, node_t);

            node_a.SetLabels(label1,  label2,  label8,  label9);
            node_b.SetLabels(label2,  label3,  label9,  label10);
            node_c.SetLabels(label3,  label4,  label10, label11);
            node_d.SetLabels(label4,  label5,  label11, label12);
            node_e.SetLabels(label5,  label6,  label12, label13);
            node_f.SetLabels(label12, label13, label19, label20);
            node_g.SetLabels(label11, label12, label18, label19);
            node_h.SetLabels(label10, label11, label17, label18);
            node_i.SetLabels(label9,  label10, label16, label17);
            node_j.SetLabels(label8,  label9,  label15, label16);
            node_k.SetLabels(label15, label16, label22, label23);
            node_l.SetLabels(label16, label17, label23, label24);
            node_m.SetLabels(label17, label18, label24, label25);
            node_n.SetLabels(label18, label19, label25, label26);
            node_o.SetLabels(label19, label20, label26, label27);
            node_p.SetLabels(label26, label27, label33, label34);
            node_q.SetLabels(label25, label26, label32, label33);
            node_r.SetLabels(label24, label25, label31, label32);
            node_s.SetLabels(label23, label24, label30, label31);
            node_t.SetLabels(label22, label23, label29, label30);
            node_u.SetLabels(label29, label30, label36, label37);
            node_v.SetLabels(label30, label31, label37, label38);
            node_w.SetLabels(label31, label32, label38, label39);
            node_x.SetLabels(label32, label33, label39, label40);
            node_y.SetLabels(label33, label34, label40, label41);
            node_z.SetLabels(label34, label35, label41, label42);
            node_space.SetLabels(label35, label36, label42, label1);
            node_backspace.SetLabels(label36, label37, label2,  label8);
            node_empty1.SetLabels(label37, label38, label3,  label15);
            node_empty2.SetLabels(label38, label39, label4,  label22);

            node_a.SetLabelsText(new string[] {"n", "r", "l", "k"});
            node_b.SetLabelsText(new string[] {"i", "a", "e", "u"});
            node_c.SetLabelsText(new string[] {"a", "e", "i", "ı"});
            node_d.SetLabelsText(new string[] {"e", "a", "i", "ı"});
            node_e.SetLabelsText(new string[] {"r", "n", "l", "y"});
            node_f.SetLabelsText(new string[] {"i", "a", "e", "u"});
            node_g.SetLabelsText(new string[] {"e", "ö", "i", "ü"});
            node_h.SetLabelsText(new string[] {"a", "i", "e", "ı"});
            node_i.SetLabelsText(new string[] {"n", "r", "ş", "l"});
            node_j.SetLabelsText(new string[] {"d", "", "", ""});
            node_k.SetLabelsText(new string[] {"a", "ı", "o", "u"});
            node_l.SetLabelsText(new string[] {"a", "e", "i", "ı"});
            node_m.SetLabelsText(new string[] {"i", "ı", "a", "e"});
            node_n.SetLabelsText(new string[] {"i", "d", "a", "e"});
            node_o.SetLabelsText(new string[] {"ğ", "l", "r", "n"});
            node_p.SetLabelsText(new string[] {"e", "a", "ı", "l"});
            node_q.SetLabelsText(new string[] {"i", "a", "e", "m"});
            node_r.SetLabelsText(new string[] {"a", "e", "ı", "i"});
            node_s.SetLabelsText(new string[] {"a", "e", "i", "m"});
            node_t.SetLabelsText(new string[] {"a", "e", "i", "m"});
            node_u.SetLabelsText(new string[] {"r", "n", "z", "l"});
            node_v.SetLabelsText(new string[] {"e", "a", "u", "i"});
            node_w.SetLabelsText(new string[] {"", "", "", ""});
            node_x.SetLabelsText(new string[] {"", "", "", ""});
            node_y.SetLabelsText(new string[] {"a", "e", "ı", "i"});
            node_z.SetLabelsText(new string[] {"a", "l", "e", "ı"});
            node_space.SetLabelsText(new string[] {"", "", "", ""});
            node_backspace.SetLabelsText(new string[] {"", "", "", ""});
            node_empty1.SetLabelsText(new string[] {"", "", "", ""});
            node_empty2.SetLabelsText(new string[] {"", "", "", ""});
        }

        private void ChangeNode(Node node)
        {
            currentNode.ClearLabelTexts();

            currentNode.Button.BackColor = Color.White;
            currentNode = node;
            currentButton = currentNode.Button;
            currentNode.Button.BackColor = Color.LightGreen;

            currentNode.UpdateLabelTexts();
        }

        private void ChangeCurrentNode(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    ChangeNode(currentNode.Up);
                    break;
                case Direction.Down:
                    ChangeNode(currentNode.Down);
                    break;
                case Direction.Left:
                    ChangeNode(currentNode.Left);
                    break;
                case Direction.Right:
                    ChangeNode(currentNode.Right);
                    break;
            }
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
                richTextBox.Text += currentNode.UpRightLabel.Text;
            }
            else if (x == -1 && y == 1)
            {
                Console.WriteLine("Sol Yukarı Çapraz");
                richTextBox.Text += currentNode.UpLeftLabel.Text;
            }
            else if (x == 1 && y == -1)
            {
                Console.WriteLine("Sağ Aşağı Çapraz");
                richTextBox.Text += currentNode.DownRightLabel.Text;
            }
            else if (x == -1 && y == -1)
            {
                Console.WriteLine("Sol Aşağı Çapraz");
                richTextBox.Text += currentNode.DownLeftLabel.Text;
            }
            else if (x == 1)
            {
                Console.WriteLine("Sağ");
                ChangeCurrentNode(Direction.Right);
            }
            else if (x == -1)
            {
                Console.WriteLine("Sol");
                ChangeCurrentNode(Direction.Left);
            }
            else if (y == 1)
            {
                Console.WriteLine("Yukarı");
                ChangeCurrentNode(Direction.Up);
            }
            else if (y == -1)
            {
                Console.WriteLine("Aşağı");
                ChangeCurrentNode(Direction.Down);
            }
            else
            {
            }

            x = 0;
            y = 0;
        }
    }

    public class Node
    {
        public Button Button { get; set; }
        public Node Up { get; set; }
        public Node Down { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Label UpRightLabel { get; set; }
        public Label UpLeftLabel { get; set; }
        public Label DownRightLabel { get; set; }
        public Label DownLeftLabel { get; set; }

        private String[] labelText;


        public Node(Button button)
        {
            Button = button;
        }

        public void SetDirections(Node up, Node down, Node left, Node right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }

        public void SetLabels(Label upLeft, Label upRight, Label downLeft, Label downRight)
        {
            UpRightLabel = upRight;
            UpLeftLabel = upLeft;
            DownRightLabel = downRight;
            DownLeftLabel = downLeft;
        }

        public void SetLabelsText(string[] texts)
        {
            labelText = texts;
        }

        public void UpdateLabelTexts()
        {
            UpRightLabel.Text = labelText[0];
            UpLeftLabel.Text = labelText[1];
            DownRightLabel.Text = labelText[2];
            DownLeftLabel.Text = labelText[3];
        }

        public void ClearLabelTexts()
        {
            UpRightLabel.Text = "";
            UpLeftLabel.Text = "";
            DownRightLabel.Text = "";
            DownLeftLabel.Text = "";
        }
    }
}
