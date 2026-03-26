using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Calculos 
{
    public partial class CalculadoraPlus : Form
    {
        decimal vNumAnt;
        string vOperacao;
        bool vLimparVisor;
        public CalculadoraPlus()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
   

        private void f_digitos(object sender, EventArgs e)
        {
            string digito = ((Button)sender).Text;
            if (lblVisor.Text == "0" || vLimparVisor)
            {
                lblVisor.Text = "";
                vLimparVisor = false;
            }
            lblVisor.Text += digito;
        }
        private void f_operacoes(object sender, EventArgs e)
        { 
            // tenta salvar o número atual antes de operar
            if (!decimal.TryParse(lblVisor.Text, out vNumAnt))
            {
                vNumAnt = 0;
            }
            vOperacao = ((Button)sender).Text;
            vLimparVisor = true;
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            // adicionar vírgula apenas se ainda não existir
            if (!lblVisor.Text.Contains(","))
            {
                if (vLimparVisor)
                {
                    lblVisor.Text = "0";
                    vLimparVisor = false;
                }
                lblVisor.Text += ",";
            }
        }

        private void btnLimpar_Click (object sender, EventArgs e)
        {
            vNumAnt = 0;
            lblVisor.Text = "0";
            vOperacao = null;
            vLimparVisor = false;
        }

        private void bntigual_Click_1(object sender, EventArgs e)
        {
            // obter o número atual com segurança
            if (!decimal.TryParse(lblVisor.Text, out decimal vNumAtual))
            {
                return;
            }

            // decidir que operação realizar
            switch (vOperacao)
            {
                case "+":
                    lblVisor.Text = (vNumAnt + vNumAtual).ToString();
                    break;
                case "-":
                    lblVisor.Text = (vNumAnt - vNumAtual).ToString();
                    break;
                case "x":
                case "X":
                case "*":
                    lblVisor.Text = (vNumAnt * vNumAtual).ToString();
                    break;
                case "/":
                    if (vNumAtual == 0)
                    {
                        MessageBox.Show("Erro: divisão por zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblVisor.Text = "0";
                    }
                    else
                    {
                        lblVisor.Text = (vNumAnt / vNumAtual).ToString();
                    }
                    break;
                default:
                    // nenhuma operação selecionada
                    break;
            }

            // preparar para nova entrada após resultado
            vLimparVisor = true;
            vOperacao = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblVisor.Text.Length > 1)
            {
                lblVisor.Text = lblVisor.Text.Substring(0, lblVisor.Text.Length - 1);
            }
            else
            {
                lblVisor.Text = "0";
            }
        }

        private void CalculadoraPlus_Load(object sender, EventArgs e)
        {

        }
    }
}
