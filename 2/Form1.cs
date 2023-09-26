using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = Interaction.InputBox("Ingrese el Nombre:", "Ingresar Nombre");
                string Apellido = Interaction.InputBox("Ingrese el Apellido:", "Ingresar Apellido");
                string Dni = Interaction.InputBox("Ingrese el Dni:", "Ingresar Dni");
                if (!Information.IsNumeric(Dni))
                {
                    throw new Exception("Ingrese un numero");
                }

                var FechaNacimiento = dateTimePicker1.Value.Date.ToString();
                int Edad = CalcularEdad();
                dataGridView1.Rows.Add($"{Nombre}", $"{Apellido}", $"{FechaNacimiento}", $"{Edad}", $"{Dni}");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }






        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("No hay alumnos");
                }
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int CalcularEdad()
        {

            var DiasHoys = DateTime.Now.Date;
            var DiasCumple = dateTimePicker1.Value.Date;
            MessageBox.Show($"{DiasCumple},{DiasHoys}");
            var Edad = DiasHoys.Year - DiasCumple.Year;
            if (DiasHoys < DiasCumple.AddYears(Edad))
            {
                Edad--;
            }
            int dad = Edad;

            return dad;
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("No hya alumnos para modificar");
                }
                var fila = dataGridView1.SelectedRows[0];
                fila.Cells[1].Value = Interaction.InputBox("Nombre: ", "Ingresando el nombre !!!", fila.Cells[1].Value.ToString());
                fila.Cells[2].Value = Interaction.InputBox("Apellido: ", "Ingresando el Apellido !!!", fila.Cells[2].Value.ToString());
                fila.Cells[3].Value = dateTimePicker1.Value.ToShortDateString();
                fila.Cells[4].Value = CalcularEdad();
                fila.Cells[5].Value = Interaction.InputBox("Ingrese el Dni:", "Ingresar Dni", fila.Cells[5].Value.ToString());

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
            
        }
    }
}
