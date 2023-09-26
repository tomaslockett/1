using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ImporteTotal;
            int ImporteAux = 0;
            string patron = @"^[A-Za-z][0-9]{3}";
            try
            {
                

                string Codigo = Interaction.InputBox("Ingrese el codigo de vendedor:", "Ingrese el dato");

                if (!Regex.IsMatch(Codigo, patron))
                {
                    throw new Exception("El codigo es invalido");
                }


                string Importe = Interaction.InputBox("Ingrese el importe de la venta", "Ingrese el importe");

                if (!Information.IsNumeric(Importe))
                {
                    throw new Exception("El importe es invalido");
                }

                DateTime Fecha = dateTimePicker1.Value;
                
                bool BoolImporte = false;

                ImporteAux = Convert.ToInt32(Importe);

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string valorCodigo = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    MessageBox.Show($"{valorCodigo}");

                    if (valorCodigo.Equals(Codigo))
                    {
                        ImporteAux += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

                        BoolImporte = true;
                    }
                }

                if (BoolImporte)
                {
                    ImporteTotal = ImporteAux.ToString();

                    for(int i = 0;i  < dataGridView1.RowCount;i++)
                    {
                        var fila = dataGridView1.Rows[i];
                        fila.Cells[0].Value = ImporteTotal;
                    }
                }
                else
                {
                    ImporteTotal = Importe.ToString();
                }



                dataGridView1.Rows.Add(new object[] {ImporteTotal,Fecha,Importe,Codigo });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Codigo = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            string ImporteTotal;

            MessageBox.Show($"{Codigo}");

            int ImporteAux;

            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("No hay nada que borrar");
                }

                bool BoolImporte = false;

                string Aux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                ImporteAux = Convert.ToInt32(Aux);

                for (int i = 0; i < dataGridView1.Rows.Count;i++) 
                {
                    string valorCodigo = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    MessageBox.Show($"{valorCodigo}");

                    

                    if (valorCodigo.Equals(Codigo))
                    {
                        ImporteAux -= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);

                        BoolImporte = true;
                        break;
                    }
                }

                if (BoolImporte)
                {
                    ImporteTotal = ImporteAux.ToString();

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        var fila = dataGridView1.Rows[i];
                        fila.Cells[0].Value = ImporteTotal;
                    }
                }
                


                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("No hay nada para modificar");
                }
                var fila = dataGridView1.SelectedRows[0];
                fila.Cells[1].Value = Interaction.InputBox("Ingrese el codigo de vendedor:", "Ingrese el dato");
                fila.Cells[2].Value = Interaction.InputBox("Ingrese el importe de la venta", "Ingrese el importe");


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
