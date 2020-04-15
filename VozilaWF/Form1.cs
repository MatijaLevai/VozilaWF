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
        //dole su definisani Eventi tj. dogadjavi usled kojih se poziva
        //Standardan šablon događaja zamišljen je tako da vam omogući
        //da upotrebom osnovne klase EventArgs iskoristite kontravarijantu parametara delegata.
        //Na primer, jednu metodu mogu pozvati dva različita delegata, 
        //od kojih joj jedan prosleđuje argumente tipa MouseEventArgs a drugi tipa KeyEventArgs. 
       //Pri korišćenju delegata obično se javljaju dve važne uloge: emiter ili
       //izvor(engl.broadcaster) i pretplatnik(engl.subscriber). Emiter je tip
       //koji sadrži polje tipa delegat.Emiter odlučuje kada će emitovati, tako
       //što poziva delegata. Pretplatnici su primaoci čije metode obrađuju događaje.
       //Pretplatnik odlučuje kada da započne i prekine osluškivanje,
       //tako što primenjuje operatore += i -= na delegata datog emitera. Jedan
       //pretplatnik ne zna za druge pretplatnike, niti se meša u njihov rad.
       //Događaji su komponenta programskog jezika pomoću koje se formalizuje ovakav način rada.
       //event je konstrukt koji eksponira samo onaj
       //podskup osobina delegata koji je potreban modelu emiter/pretplatnik.
       //Glavna namena događaja je da spreče pretplatnike da ometaju jedni druge.
       //
       //U nasem primeru definicija osluskivanja je generisana u parcijalnoj klasi Form1.
       //Designer dok su ovde definisane metode koje se pozivaju u svojstvu event handlera tj. obradjivaca dogadjaja
        private void button1_Click(object sender, EventArgs e)
        {//button1.Click se pokrece kada korisnik klikne na dugme dodaj Auto
            string poruka=""; //ukoliko bude gresaka poruka ce dobiti vrednost
            //koriscenje linq za dobijanje odgovora na pitanje da li je neki od list boxova ostao da nije selektovana jedna od ponudjenih opcija
           
            //definisemo listu lisboxeva u koju cemo smestiti svaki onaj lisbox koji ne bude imao izabranuvrednost
            List<ListBox> lbnumnull =new List<ListBox>( listaListBoxes.Where(lb => lb.SelectedItem == null));
           //uspevamo pomocu lambda izraza i proveravamo da li je vrednost selektovanog itema jednaka null
            int  brojGresaka = lbnumnull.Count();
           //zatim brojimo koliko ima takvih lisboxeva
            if (brojGresaka > 0)
            {
                //ovaj blok se izvrsava ukoliko je broj gresaka makar 1 ili veci

                if (brojGresaka == 1)
                {//ovaj blok koda se izvrsava ukoliko je broj gresaka tacno jedan

                    //posto je Svojstvo euro standarda vezano samo za MotorSus klasu
                    //proveravamo da li je korisnik izabrao motor na struju i ako jeste 
                    //i ako je jedina greska ta da mu fali euro standard znaci da se mora kreirati  objekat klase AutoElectrik
                    if (lbnumnull.First().AccessibleName == "EU standard" && listBox5.SelectedItem.ToString() == Motor.Gorivo.struja.ToString())
                    {
                        AutoElectric A = new AutoElectric((Auto.VrstaAuta)listBox1.SelectedItem, (Auto.VrstaMenjaca)listBox2.SelectedItem, (Motor.Snaga)listBox4.SelectedItem);
                        listaKola.Add(A);//kreirani objekat dodsajemo u listu kola

                        UpdateDataGridView();//pozivamo metodu za azuriranje tabele sa podacima
                        
                    }
                    else
                    {
                        poruka += "Preskočili ste opciju :" + lbnumnull.First().AccessibleName;
                    }//ukoliko je korisnik napravio gresku koja ne ispunjava prethodni uslov znaci da je prava greska i da mu je treba ispisati u vidu poruke
                    
                    
                }
                else
                {//ovaj blok se izvrsava ukoliko je broj gresaka veci od 1
                    poruka += "Preskočili ste opcije :";
                    for (int i = 0; i < brojGresaka; i++)//koristi se for petlja koja proverava svaki elemenat liste lbnumnull i stavlja ime listboxa kao tekst svake greske
                    {
                        if (i == brojGresaka - 1)//jednostavna provera da je poslednji elemenat, ukoliko jeste ne stavljamo zarez na kraju
                            poruka += lbnumnull[i].AccessibleName;
                        else
                            poruka += lbnumnull[i].AccessibleName + ", ";


                    }

                }
                
                if(!String.IsNullOrWhiteSpace(poruka))//konacno nakon svih provera gresaka proverava se da li je poruka dobila neku vrednost
                    MessageBox.Show(poruka);//ukoliko jeste ispuje se korisniku u vidu message boxa
            }
            else
            {//ovaj blok se izvrsava ukoliko nema gresaka i ukoliko korisnik nije izabrao auto na struju
                AutoSus A = new AutoSus( (Auto.VrstaAuta)listBox1.SelectedItem, (Auto.VrstaMenjaca)listBox2.SelectedItem, (SusMotor.Standard)listBox3.SelectedItem, (
                    Motor.Gorivo)listBox5.SelectedItem, (Motor.Snaga)listBox4.SelectedItem);
                //gde vidite npr. (Motor.Gorivo)listBox5.SelectedItem to je eksplicitna konverzija objekta u tip Enuma
                listaKola.Add(A);//kreirani auto se dodaje u listu i poziva se azuziranje datagridview tabele
                UpdateDataGridView();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {//korisniku se kliko na dugme pomic ispisuje objasnjenje vezano za kreiranje kola
            MessageBox.Show("Kako biste dodali novi Automobil u listu \n\r izaberite po jednu opciju iz dole navedenih lista.\n\r Kao što su tip auta, menjača, EU standarda motora, snage i vrste goriva.");
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {//ukoliko korisnik izaberestruju kao gorivo, lista eu standarda se blokira
            var listbox = sender as ListBox;
            if (listbox.SelectedItem.ToString() == Motor.Gorivo.struja.ToString())
            {
                listBox3.Enabled = false;
            }
            else
                listBox3.Enabled = true;
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
