using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sap.Data.Hana;



namespace OrdenesCompras
{
    public partial class Form1 : Form
    {
        System.Threading.Thread EjecutaProcesso;
        Timer Timer1 = new Timer();
        int Progreso = 0;

        public void Proceso()
        {
            for (int i = 0; i <= 100; i++)
            {
                Progreso += 1;
                System.Threading.Thread.Sleep(100);
            }

        }

        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = 0;
            progressBar1.Maximum = 100;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var filaSeleccionada = dataGridView1.CurrentRow;
            //string strDocEntry, numFactura;
            //int DocEntry;

            //if (filaSeleccionada != null)
            //{


            //    strDocEntry = filaSeleccionada.Cells[0].Value.ToString();

            //    DocEntry = Int32.Parse(strDocEntry);
            //    numFactura = txtFactura.Text;

            //    //MessageBox.Show(DocEntry.ToString());
            //    //MessageBox.Show(numFactura);
            //    //MessageBox.Show(filaSeleccionada.Cells[0].Value.ToString());

            //    ActualizarOC.AutorizarEntrada(DocEntry, numFactura);





            //}

        }



        private void btnAct_Click(object sender, EventArgs e)
        {
            var filaSeleccionada = dataGridView1.CurrentRow;
            string strDocEntry, numFactura;
            int DocEntry;

            if (filaSeleccionada != null)
            {


                strDocEntry = filaSeleccionada.Cells[0].Value.ToString();

                DocEntry = Int32.Parse(strDocEntry);
                numFactura = txtFactura.Text;

                //MessageBox.Show(DocEntry.ToString());
                //MessageBox.Show(numFactura);
                //MessageBox.Show(filaSeleccionada.Cells[0].Value.ToString());

                ActualizarOC.AutorizarEntrada(DocEntry, numFactura);





            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            var filaSeleccionada = dataGridView1.CurrentRow;
            //string hola;

            label1.Visible = false;
            label1.Refresh();


            /////////////////////////////////////////////////////

            //Configurar progress barr
            progressBar2.Maximum = 100;
            // Configuras timer
            Timer1.Interval = 100;
            Timer1.Tick += timer2_Tick;
            Timer1.Start();
            //Configuras Hilon e inicia hilo
            EjecutaProcesso = new System.Threading.Thread(new System.Threading.ThreadStart(Proceso));
            EjecutaProcesso.Start();

            ////////////////////////////////////////////////////
            if(filaSeleccionada != null)
            {
                //hola = filaSeleccionada.Cells[6].Value.ToString();
                txtFactura.Text = filaSeleccionada.Cells[6].Value.ToString();

            }

            //Form1 Form= new Form1();
            //Form.BackColor = ColorTranslator.FromHtml("#245c64");

            //HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");

            //conn.Open();

            //Me.Guardarbtn.BackColor = ColorTranslator.FromHtml("#007ACC");
            //Form1 = Color.FromArgb(148,164,172);

            btnAct.BackColor = ColorTranslator.FromHtml("#245c64");
            btnAct.ForeColor = ColorTranslator.FromHtml("#c8d2d8");

            actBtn.BackColor = ColorTranslator.FromHtml("#245c64");
            actBtn.ForeColor = ColorTranslator.FromHtml("#c8d2d8");

            dataGridView1.ForeColor = ColorTranslator.FromHtml("#245c64");
            Factura.ForeColor = ColorTranslator.FromHtml("#245c64");

            dataGridView1.ReadOnly = true;


            //string query = "SELECT \"DocEntry\", \"DocNum\", \"CardCode\", \"CardName\",\"DocDate\", \"DocTotal\" from SB1PRUEBA.OPOR WHERE  \"DocStatus\" = 'O' AND \"U_EntradaAut\" = '1'";

            //HanaCommand cmd = new HanaCommand(query,conn);
            //HanaDataAdapter data = new HanaDataAdapter(cmd);
            //DataTable tabla = new DataTable();
            //data.Fill(tabla);
            ConexionHana conexionHana = new ConexionHana();
            
            var tabla = conexionHana.Abierta();

            dataGridView1.DataSource = tabla;

            ConexionHana.Cerrada();

            //inicial();

            //Almacen 18 y 19 , entradas para Puebla
        }

        

     
        private void btnAct_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
          
            


            var filaSeleccionada = dataGridView1.CurrentRow;
            string strDocEntry, numFactura;
            int DocEntry;
            
                if (filaSeleccionada != null)
                {
                       // progressBar1.Value = 50;
                    if (txtFactura.Text != "")
                    {
                        label1.Visible = true;
                        label1.Refresh();

                        //label1.Enabled = true;
                        //label1.Visible=true;
                        //mostrarLabel();
                        nueva();
                        strDocEntry = filaSeleccionada.Cells[0].Value.ToString();

                        DocEntry = Int32.Parse(strDocEntry);
                        numFactura = txtFactura.Text;
                        txtFactura.Text = "";


                        //MessageBox.Show(DocEntry.ToString());
                        //MessageBox.Show(numFactura);
                        //MessageBox.Show(filaSeleccionada.Cells[0].Value.ToString());

                       
                        //System.Threading.Thread.Sleep(50);

                        ActualizarOC.AutorizarEntrada(DocEntry, numFactura);


                        ConexionHana conexionHana = new ConexionHana();

                        var tabla = conexionHana.Abierta();

                        dataGridView1.DataSource = tabla;

                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); // Ajusta automáticamente el ancho de las columnas al contenido
                        dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells); // Ajusta automáticamente la altura de las filas al contenido

                        //this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        //dataGridView1.Columns[dataGridView1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        ConexionHana.Cerrada();


                        

                    }
                    else
                    {
                        MessageBox.Show("No puedes Aprobar una Orden sino tiene numero de Factura");

                    }

                    label1.Visible = false;
                    progressBar1.Value = 0;

                }
               
        }

        public void inicial()
        {
            progressBar1.Value = 0;
            label1.Visible = false;
        }

        public void mostrarLabel()
        {
            label1.Visible = true;
        }

        public void nueva()
        {
            for (int i = 50; i < progressBar1.Maximum; i++)
            {
                
                progressBar1.Value = 50;
                label1.Visible = true;
                progressBar1.Increment(i);
                progressBar1.Refresh();
               

            }
            //progressBar1.Value = 0;


        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == 8)
            //{
            //    return;
            //}
            //if (e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 127)
            //{
            //    e.Handled = true;
            //    return;

            //}
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Progreso <= progressBar1.Maximum)
            {
                progressBar2.Value = Progreso;
            }
            else
            {
                Timer1.Stop();
            }
        }

        private void actBtn_Click(object sender, EventArgs e)
        {

            ConexionHana conexionHana = new ConexionHana();

            var tabla = conexionHana.Abierta();

            dataGridView1.DataSource = tabla;
        }
    }
}
