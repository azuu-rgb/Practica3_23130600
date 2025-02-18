using System.Windows.Forms;

namespace Practica3_23130600
{
    public partial class formData : Form
    {
        public formData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = openFileDialog1.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string filePatch = openFileDialog1.FileName;
                string texto = File.ReadAllText(filePatch);

                char[] delimitadores = { ',', '\n' };
                string[] lineas = texto.Split("\n");
                string[] palabras = texto.Split(delimitadores);
                string[][] palabrasMatriz = new string[lineas.Length][];


                int cont = 0;

                //contamos las comas
                foreach (char c in lineas[0])
                {
                    if (c == ',')
                    {
                        cont++;
                    }
                }

                //se crean las columnas 

                for (int i = 0; i < cont + 1; i++)
                {
                    dataGridView1.Columns.Add(palabras[i], palabras[i]);
                };

                //guarda todas las palabras en una mtriz para pasarla al showGrid  
               

                for (int i = 1; i < lineas.Length; i++)
                {
                    
                    palabrasMatriz[i] = lineas[i].Split(delimitadores);
                }

                for (int i = 1; i < palabrasMatriz.Length - 1; i++)
                {

                    string[] fila = palabrasMatriz[i];


                    dataGridView1.Rows.Add(fila);
                }


            }
        }

    

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
