using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DeivizPassword
{
    public partial class Principal : Form
    {
        private const int CONS_REGISTROS = 1000;

        const string fic = @"i:\wifi\DeivizContra.csv";

        private DatosPaginas[] datos=new DatosPaginas[CONS_REGISTROS];
  
        public Principal()
        {
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String clave = new GeneradorPassword(25, 10, 15, 10).GetNewPassword();
            Clipboard.SetData(DataFormats.Text, clave);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String clave = new GeneradorPassword(25, 20, 0, 20).GetNewPassword();
            Clipboard.SetData(DataFormats.Text, clave);
        }

      

        
       

        

        private void Principal_Load(object sender, EventArgs e)
        {
            DatosPaginas[] datos = new DatosPaginas[CONS_REGISTROS];
            for (int g = 0; g < CONS_REGISTROS; g++)
            {
                datos[g] = new DatosPaginas();
            }

            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fic);
                string texto = sr.ReadToEnd();
                sr.Close();

                int contador = 0;
                int datosgrabar = 0;


                if (texto != "")
                {
                    string[] lineas = texto.Split('\n');

                    foreach (var linea in lineas)
                    {
                        if (contador >0 && linea!="") {


                            string[] datosleidos = linea.Split(';');

                            datos[datosgrabar].pagina = datosleidos[0];
                            datos[datosgrabar].usuario = datosleidos[1];
                            datos[datosgrabar].contraseña = datosleidos[2];
                            datos[datosgrabar].descripcion = datosleidos[3];
                            datosgrabar++;
                        }

                        contador++;
                    }

                }
            }catch (Exception )
            {

            }

            dataGridView1.DataSource = datos;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            String texto = "Pagina;Usuario;Contraseña;Descripción\n";

            int g = 0;
            while (g<dataGridView1.Rows.Count)
            {

                texto = texto
                    + dataGridView1.Rows[g].Cells[0].Value + ";"
                    + dataGridView1.Rows[g].Cells[1].Value + ";"
                    + dataGridView1.Rows[g].Cells[2].Value + ";"
                    + dataGridView1.Rows[g].Cells[3].Value + ";\n";
                
                g++;
            }


            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
            sw.WriteLine(texto);
            sw.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                int g = 0;
                while (g<dataGridView1.Rows.Count)
                {
                    if (dataGridView1.Rows[g].Cells[0].Value.ToString().Contains(textBox1.Text))
                        break;
                    g++;
                }

                if (g < dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows[g].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[g].Cells[0];
                }


            }
        }
    }
}
