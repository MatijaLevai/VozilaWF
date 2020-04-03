using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VozilaWF
{
    public partial class Form1 : Form
    {
        private List<AutoSus> listaKola { get; set; }

        public Form1()
        {
            inicijalizujListKola();
            InitializeComponent();
            inicijalizujDataGridView();
            spremiZaTabelu();
        }
        private void inicijalizujDataGridView()
        {
            dataGridView1.ColumnCount = 9;
            dataGridView1.AutoResizeColumns();

            dataGridView1.Columns[0].Name = "Vrsta";
            dataGridView1.Columns[1].Name = "Broj Vrata";
            dataGridView1.Columns[2].Name = "Menjac";
            dataGridView1.Columns[3].Name = "Cipovanје";
            dataGridView1.Columns[4].Name = "Gorivo";
            dataGridView1.Columns[5].Name = "Potrosnja";
            dataGridView1.Columns[6].Name = "Snaga kw";
            dataGridView1.Columns[7].Name = "Snaga ks";
            dataGridView1.Columns[8].Name = "Zapremina";
            
           
        }
        private void inicijalizujListKola()
        {
            listaKola = new List<AutoSus>()
            {new AutoSus (AutoSus.VrstaAuta.hecbek,3, AutoSus.VrstaMenjaca.manuelni, SusMotor.Gorivo.dizel,6,66,90,1900,false),
             new AutoSus (AutoSus.VrstaAuta.limunzina,3, AutoSus.VrstaMenjaca.automatski, SusMotor.Gorivo.benzin,6,199,280,2200,false),
             new AutoSus (AutoSus.VrstaAuta.karavan,3, AutoSus.VrstaMenjaca.manuelni, SusMotor.Gorivo.dizel,6,130,160,1900,false),
             new AutoSus (AutoSus.VrstaAuta.kabriolet,3, AutoSus.VrstaMenjaca.manuelni, SusMotor.Gorivo.benzin,6,74,103,1600,false),
             new AutoSus (AutoSus.VrstaAuta.minivan,3, AutoSus.VrstaMenjaca.automatski, SusMotor.Gorivo.dizel,6,84,116,2000,false)
            };
        }
        private void spremiZaTabelu()
        {
            foreach (var item in listaKola)
            {
                dataGridView1.Rows.Add(item.Ispis());
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
