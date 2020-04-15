using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.Data;

namespace VozilaWF
{
    public partial class Form1 : Form
    {
        private List<Auto> listaKola { get; set; }

        private List<ListBox> listaListBoxes;

        private BindingSource bindingSource1 = new BindingSource();

        public Form1()
        {
            InitializeComponent();//probajte prebaciti donjih 5 linija koda iznad ove kako biste primetrili da mora da postoji redosled izvr[avanja. u ovom slucaju ne mozemo koristiti elemente forme pre njihove inicijalizacije.


            listBox1.AccessibleName = "Vrsta";
            listBox2.AccessibleName = "Menjac";
            listBox3.AccessibleName = "EU standard";
            listBox4.AccessibleName = "Snaga kw";
            listBox5.AccessibleName = "Gorivo";

            inicijalizujListKola();
            UpdateDataGridView();
            Array enums = Enum.GetValues(typeof(AutoSus.VrstaAuta));
            foreach (var item in enums)
            {
                listBox1.Items.Add(item);
            }
            
            enums = Enum.GetValues(typeof(AutoSus.VrstaMenjaca));
            foreach (var item in enums)
            {
                listBox2.Items.Add(item);
            }
           
            enums = Enum.GetValues(typeof(SusMotor.Standard));
            foreach (var item in enums)
            {
                listBox3.Items.Add(item);
            }
            
            enums = typeof(Motor.Snaga).GetEnumValues();
            foreach (var item in enums)
            {
                listBox4.Items.Add(item);
            }
            enums = Enum.GetValues(typeof(Motor.Gorivo));
            foreach (var item in enums)
            {
                listBox5.Items.Add(item);
            }
            InstaciranjeDataGridView("ID", "ID");
            InstaciranjeDataGridView("Tip", "Tip");
            InstaciranjeDataGridView("Menjac", "Menjač");
            InstaciranjeDataGridView("EuroStandard", "Euro standard");
            InstaciranjeDataGridView("Gorivo", "Gorivo");
            InstaciranjeDataGridView("Snaga", "Snaga");





            listaListBoxes = new List<ListBox>();

            listaListBoxes.Add(listBox1);
            listaListBoxes.Add(listBox2);
            listaListBoxes.Add(listBox3);
            listaListBoxes.Add(listBox4);
            listaListBoxes.Add(listBox5);

            
        }
        private void InstaciranjeDataGridView(string title,string propertyName)
        {
            //object param,
            //DataGridViewColumn column = new DataGridViewTextBoxColumn();
            //column.DataPropertyName = propertyName;
            //column.Name = title;
            //dataGridView1.Columns.Add(column);
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = title;
            column.Name = title;
            dataGridView1.Columns.Add(column);
            
        }
        private void UpdateDataGridView()
        {
            bindingSource1 = new BindingSource();
            foreach (var kola in listaKola)
            {
                bindingSource1.Add(new DataTableCarModel(kola));
            }
            
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = bindingSource1;
            

        }
        private void inicijalizujListKola()
        {
            listaKola = new List<Auto>()
            {new AutoSus (AutoSus.VrstaAuta.hecbek, AutoSus.VrstaMenjaca.manuelni, SusMotor.Standard.Euro2, Motor.Gorivo.dizel, Motor.Snaga.kW66),
             new AutoSus (AutoSus.VrstaAuta.limunzina, AutoSus.VrstaMenjaca.automatski,SusMotor.Standard.Euro3,Motor.Gorivo.benzin,Motor.Snaga.kW74),
             new AutoSus (AutoSus.VrstaAuta.karavan, AutoSus.VrstaMenjaca.manuelni,SusMotor.Standard.Euro4,Motor.Gorivo.dizel,Motor.Snaga.kW85),
             new AutoSus (Auto.VrstaAuta.kabriolet, Auto.VrstaMenjaca.manuelni,SusMotor.Standard.Euro5,Motor.Gorivo.benzin,Motor.Snaga.kW96),
             new AutoSus (Auto.VrstaAuta.minivan,   Auto.VrstaMenjaca.automatski,SusMotor.Standard.Euro3,Motor.Gorivo.dizel,Motor.Snaga.kW110)
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka="";
            //koriscenje linq za dobijanje odgovora na pitanje da li je neki od list boxova ostao da nije selektovana jedna od ponudjenih opcija
           
            List<ListBox> lbnumnull =new List<ListBox>( listaListBoxes.Where(lb => lb.SelectedItem == null));
           
            int  brojGresaka = lbnumnull.Count();
           
            if (brojGresaka > 0)
            {
                

                if (brojGresaka == 1)
                {


                    if (lbnumnull.First().AccessibleName == "EU standard" && listBox5.SelectedItem.ToString() == Motor.Gorivo.struja.ToString())
                    {
                        AutoElectric A = new AutoElectric((Auto.VrstaAuta)listBox1.SelectedItem, (Auto.VrstaMenjaca)listBox2.SelectedItem, (Motor.Snaga)listBox4.SelectedItem);
                        listaKola.Add(A);

                        UpdateDataGridView();
                        
                    }
                    else
                    {
                        poruka += "Preskočili ste opciju :" + lbnumnull.First().AccessibleName;
                    }
                    
                    
                }
                else
                {
                    poruka += "Preskočili ste opcije :";
                    for (int i = 0; i < brojGresaka; i++)
                    {
                        if (i == brojGresaka - 1)
                            poruka += lbnumnull[i].AccessibleName;
                        else
                            poruka += lbnumnull[i].AccessibleName + ", ";


                    }

                }
                
                if(!String.IsNullOrWhiteSpace(poruka))
                    MessageBox.Show(poruka);
            }
            else
            {
                AutoSus A = new AutoSus( (Auto.VrstaAuta)listBox1.SelectedItem, (Auto.VrstaMenjaca)listBox2.SelectedItem, (SusMotor.Standard)listBox3.SelectedItem, (SusMotor.Gorivo)listBox5.SelectedItem, (Motor.Snaga)listBox4.SelectedItem);
                listaKola.Add(A);
                UpdateDataGridView();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kako biste dodali novi Automobil u listu \n\r izaberite po jednu opciju iz dole navedenih lista.\n\r Kao što su tip auta, menjača, EU standarda motora, snage i goriva.");
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listbox = sender as ListBox;
            if (listbox.SelectedItem.ToString() == Motor.Gorivo.struja.ToString())
            {
                listBox3.Enabled = false;
            }
            else
                listBox3.Enabled = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                MessageBox.Show(listaKola[dataGridView1.SelectedRows[0].Index].ToString());
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selektuj samo jedan red.");
            }

        }

        private void dataGridView1_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            if (dataGridView1.CurrentRow.Index - 1 >= 0)
            {

                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
                var CarID = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                if (CarID < 0) return;
                DialogResult dialogResult = MessageBox.Show(listaKola.Where(a => a.Id == CarID).First().ToString(), "Detalji auta : ", MessageBoxButtons.YesNo);
            
                if(dialogResult== DialogResult.Yes)
                { dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    listaKola.Remove(listaKola.Where(a => a.Id == CarID).First());
                }
            }


        }
    }
}
