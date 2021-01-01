using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIcTacToe
{
    public partial class Form1 : Form
    {
        bool turno = true; // true = turno do x, false = turno do o
        int contador_de_turnos = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Versão 0.1"
                + Environment.NewLine
                + "Desenvolvedor: Daniel", "Sobre");
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turno)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turno = !turno;
            b.Enabled = false;
            contador_de_turnos++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            bool temVencedor = false;

            //checando na horizontal
            if ((btnA1.Text == btnA2.Text) && (btnA2.Text == btnA3.Text) && (!btnA1.Enabled))
                temVencedor = true;
            else if ((btnB1.Text == btnB2.Text) && (btnB2.Text == btnB3.Text) && (!btnB1.Enabled))
                temVencedor = true;
            else if ((btnC1.Text == btnC2.Text) && (btnC2.Text == btnC3.Text) && (!btnC1.Enabled))
                temVencedor = true;

            //checando na vertical
            if ((btnA1.Text == btnB1.Text) && (btnB1.Text == btnC1.Text) && (!btnA1.Enabled))
                temVencedor = true;
            else if ((btnA2.Text == btnB2.Text) && (btnB2.Text == btnC2.Text) && (!btnA2.Enabled))
                temVencedor = true;
            else if ((btnA3.Text == btnB3.Text) && (btnB3.Text == btnC3.Text) && (!btnA3.Enabled))
                temVencedor = true;

            //checando na diagonal
            if ((btnA1.Text == btnB2.Text) && (btnB2.Text == btnC3.Text) && (!btnA1.Enabled))
                temVencedor = true;
            else if ((btnA3.Text == btnB2.Text) && (btnB2.Text == btnC1.Text) && (!btnA3.Enabled))
                temVencedor = true;
            


            if (temVencedor)
            {
                disableButtons();

                String winner = "";
                if (turno)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " Ganhou!", "Eba!");

            }
            else
            {
                if (contador_de_turnos == 9)
                {
                    MessageBox.Show("Não tem vencedor :(", "Empate");
                }
            }
        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
           catch
            {

            }
        }

        private void novoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turno = true;
            contador_de_turnos = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {

            }

        }
    }
}
