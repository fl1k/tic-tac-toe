using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            turnCheck();
        }

        bool players = true;
        int player1 = 0, player2 = 0, draw = 0;
        private void buttonClick(object sender, EventArgs e)
        {
            Button playerbutton = (Button)sender;
            if (playerbutton.Text == "")
            {
                if (players == true)
                    playerbutton.Text = "X";
                else
                    playerbutton.Text = "O";

                draw++;
                if (winCheck() == true)
                {
                    if (playerbutton.Text == "X")
                    {
                        player1++;
                        MessageBox.Show("X Won.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        label1.Text = $"X: {player1}";
                    }
                    else
                    {
                        player2++;
                        MessageBox.Show("O Won.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        label2.Text = $"O: {player2}";
                    }
                    newGame();
                    draw = 0;
                }

                if (draw == 9)
                {
                    MessageBox.Show("Draw.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newGame();
                }
                players = !players;
                turnCheck();
            }
        }

        private void newGame()
        {
            draw = 0;
            A1.Text = A2.Text = A3.Text = B1.Text = B2.Text = B3.Text = C1.Text = C2.Text = C3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            label1.Text = "X: ";
            label2.Text = "O: ";
            players = true;
            newGame();
            turnCheck();
        }

        private void turnCheck()
        {
            if (players == true)
                label3.Text = $"Turn: X";
            else if (players == false)
                label3.Text = $"Turn: O";
        }

        private bool winCheck()
        {
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && A1.Text != "")
                return true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && B1.Text != "")
                return true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && C1.Text != "")
                return true;

            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && A1.Text != "")
                return true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && A2.Text != "")
                return true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && A3.Text != "")
                return true;

            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && A1.Text != "")
                return true;
            else if ((C1.Text == B2.Text) && (B2.Text == A3.Text) && A3.Text != "")
                return true;
            else
                return false;
        }
    }
}
