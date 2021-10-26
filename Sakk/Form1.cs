using System;
using Sakk;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sakk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            tablaGeneralas sakktabla = new tablaGeneralas();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameGrid.Invoke((MethodInvoker)delegate
            {
                gameGrid.Controls.Clear();
                gameGrid.ColumnCount = 8;
                gameGrid.RowCount = 8;
                gameGrid.ColumnStyles.Clear();
                gameGrid.RowStyles.Clear();
            });
            for (int i = 0; i < 8; i++)
            {
                gameGrid.Invoke((MethodInvoker)delegate
                {
                    gameGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / 8));
                });
            }
            for (int i = 0; i < 8; i++)
            {
                gameGrid.Invoke((MethodInvoker)delegate
                {
                    gameGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / 8));
                });
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //🏴💣 
                    var button = new Button
                    {
                        Text = " ",
                        Name = string.Format("button_{0}:{1}", i, j),
                        Tag = string.Format("{0}:{1}", i, j),
                        Height = 25,
                        Width = 25
                    };
                    button.MouseDown += (s, args) =>
                    {
                        string tag = button.Tag.ToString();
                        if (args.Button == MouseButtons.Left)
                        {


                        }
                        if (args.Button == MouseButtons.Right)
                        {

                        }
                    };
                    gameGrid.Invoke((MethodInvoker)delegate
                    {
                        gameGrid.Controls.Add(button, j, i);
                    });

                }
            }
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
