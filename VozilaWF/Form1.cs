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
        private List<Auto> listaKola { get; set; }//privatno svojstvo u vidu liste objekata klase Automobil

        private List<ListBox> listaListBoxes;//posto je potrebno da proverimo stanje svakog listBoxa, lakse je kada je u obliku liste

        private BindingSource bindingSource1 = new BindingSource();//BindingSource je objekat koji koristimo za za potrebe populacije tabele dataGridView1

        public Form1()//konstruktor klase form1
        {
            InitializeComponent();//inicijalizacija forme sa svim njenim elemetima tj. poziva se funcija InitializeComponent iz parcijalne klase Form1.Designer
            InstanciranjeListBoxes();//poziv metode koja inicijalizuje sve listboxeve,dodeljuje im imena i daje im vrednosti rayli;itih enuma iz razli;itih klasa, kao sto su Motor,Auto,MotorSus..
            inicijalizujListKola();//poziv metode za kreiranje objekata klase AutoSus i smestanje istih u listuKola
            InstaciranjeDataGridView();//poziv metode za kreiranje kolona u tabeli datagridview1 i definisanje povezivanja sa svojstvom objektom Modela tj. objakta klase DataTableCarModel koji je kreiran radi lakseg pristupanja vrednostima, postoji i mogucnost kreiranja anonimne klase, ali to cemo drugi put
            UpdateDataGridView();//poziv metode koja uzima svaki auto i pretvara ga u model i stavlja u bindingSource koji na kraju dodeli objektu dataGridView1

        }
        
        private void InstanciranjeListBoxes()
        {
            listBox1.AccessibleName = "Vrsta";
            listBox2.AccessibleName = "Menjac";
            listBox3.AccessibleName = "EU standard";
            listBox4.AccessibleName = "Snaga kw";
            listBox5.AccessibleName = "Gorivo";

            Array enums = Enum.GetValues(typeof(AutoSus.VrstaAuta));//kreira se niz vrednosti enuma i svaki elemenat niza se ubacuje u listbox
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

            listaListBoxes = new List<ListBox>();

            listaListBoxes.Add(listBox1);
            listaListBoxes.Add(listBox2);
            listaListBoxes.Add(listBox3);
            listaListBoxes.Add(listBox4);
            listaListBoxes.Add(listBox5);
        }
        private void InstaciranjeDataGridView()
        {
            InstaciranjeDataGridViewColumn("ID", "ID");
        InstaciranjeDataGridViewColumn("Tip", "Tip");
        InstaciranjeDataGridViewColumn("Menjac", "Menjač");
        InstaciranjeDataGridViewColumn("EuroStandard", "Euro standard");
        InstaciranjeDataGridViewColumn("Gorivo", "Gorivo");
        InstaciranjeDataGridViewColumn("Snaga", "Snaga");
            InstaciranjeDataGridViewColumn("SnagaKS", "Snaga KS");
        }
        private void InstaciranjeDataGridViewColumn(string title,string propertyName)
        {
            
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
                AutoSus A = new AutoSus( (Auto.VrstaAuta)listBox1.SelectedItem, (Auto.VrstaMenjaca)listBox2.SelectedItem, (SusMotor.Standard)listBox3.SelectedItem, (
                    Motor.Gorivo)listBox5.SelectedItem, (Motor.Snaga)listBox4.SelectedItem);
                listaKola.Add(A);
                UpdateDataGridView();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kako biste dodali novi Automobil u listu \n\r izaberite po jednu opciju iz dole navedenih lista.\n\r Kao što su tip auta, menjača, EU standarda motora, snage i vrste goriva.");
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
                else{
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite povećate snagu automobilu.?", "Brisanje auta : ", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        {
                            Auto auto = listaKola.Where(a => a.Id == CarID).FirstOrDefault();
                            if (auto.Motor.PovecajSnagu())
                            {
                                MessageBox.Show("Uspešno je povećana snaga automobilu.\n\r" + auto.ToString());
                                UpdateDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("Autu je vec povecana snaga.");
                            }
                        }
                    }
                }
            }


        }
    }
}
