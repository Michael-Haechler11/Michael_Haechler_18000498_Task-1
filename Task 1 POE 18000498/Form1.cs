using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1_POE_18000498
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[20, 20];

        Map m = new Map(3);

        public int round = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameTick.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m.GenerateBattlefield();
            Placebuttons();
        }

        public void GameEng()
        {
            foreach (Unit u in m.units)
            {
                u.CheckAttackRange(m.units, m.unitMap);
            }
            m.PlaceUnits();
            round++;
            Placebuttons();

        }

        public void Placebuttons()
        {
            gb1.Controls.Clear();

            Size btnSize = new Size(30, 30);

            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Button btn = new Button();

                    btn.Size = btnSize;
                    btn.Location = new Point(x * 30, y * 30);

                    if (m.map[x, y] == "R")
                    {
                        btn.Text = "︻デ═一";
                        btn.Name = m.unitMap[x, y].ToString();
                        btn.Click += MyButtonClick;

                        if (m.unitMap[x, y].factionType == Faction.Overwatch)
                        {
                            btn.BackColor = Color.Aquamarine;
                        }
                        else
                        {
                            btn.BackColor = Color.BlueViolet;
                        }
                    }
                    else if (m.map[x, y] == "M") 
                    {
                        btn.Text = "▬===>";
                        btn.Name = m.unitMap[x, y].ToString();
                        btn.Click += MyButtonClick;

                        if (m.unitMap[x, y].factionType == Faction.Overwatch)
                        {
                            btn.BackColor = Color.Aquamarine;
                        }
                        else
                        {
                            btn.BackColor = Color.BlueViolet;
                        }
                    }
                    else
                    {
                        btn.Text = "";
                    }

                    buttons[x, y] = btn;
                }
            }


            for (int x = 0; x < 20; x++)
            {
                for( int y = 0; y < 20; y++)
                {
                    gb1.Controls.Add(buttons[x, y]);
                }
            }
        }

        private void GameTick_Tick(object sender, EventArgs e)
        {
            GameEng();

            lbl1.Text = "Round: " + round;
        }

        public void MyButtonClick(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);

            foreach(Unit u in m.units)
            {
                if (btn.Name == u.ToString())
                {
                    rtb1.Text = u.ToString();
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            GameTick.Enabled = true;
        }
    }
}
