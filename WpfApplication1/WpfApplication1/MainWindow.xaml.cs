using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Csapat> csapatok = new List<Csapat>();
        static Random R = new Random();
          static CancellationTokenSource cts = new CancellationTokenSource();
         static CancellationToken ct = cts.Token;
         static List<Task> tlist = new List<Task>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)  //2. feladat egy feltöltés fájlba mentés
        { 
            csapatok.Clear();
            csapatok.Add(new Csapat() { Nev = "gabi", Varos = "Dunaujvaros", Alapitas = 1996 });
            csapatok.Add(new Csapat() { Nev = "hobo", Varos = "Dunaujvaros", Alapitas = 1997 });
            csapatok.Add(new Csapat() { Nev = "alice", Varos = "Dunaujvaros", Alapitas = 1990 });
            csapatok.Add(new Csapat() { Nev = "dani", Varos = "Dunaujvaros", Alapitas = 1993 });
            csapatok.Add(new Csapat() { Nev = "bob", Varos = "Pest", Alapitas = 1991 });
            csapatok.Add(new Csapat() { Nev = "elemer", Varos = "Dunaujvaros", Alapitas = 1994 });
            csapatok.Add(new Csapat() { Nev = "feri", Varos = "Dunaujvaros", Alapitas = 1995 });
            csapatok.Add(new Csapat() { Nev = "paksony", Varos = "Paks", Alapitas = 2000 });
            csapatok.Add(new Csapat() { Nev = "caci", Varos = "Dunaujvaros", Alapitas = 1992 });
            csapatok.Add(new Csapat() { Nev = "ilona", Varos = "Dunaujvaros", Alapitas = 1998 });
            csapatok.Add(new Csapat() { Nev = "takony", Varos = "Dunaujvaros", Alapitas = 1999 });
           

            var xEle = new XDocument(new XElement("Csapatok"));
            foreach (var emp in csapatok)
	        {
             xEle.Element("Csapatok").Add(new XElement("Csapat",
                                new XAttribute("Nev", emp.Nev ),
                               new XAttribute("Varos", emp.Varos),
                               new XAttribute("Alapitas", emp.Alapitas)               
                 ));
            }
            xEle.Save("pacman.xml");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  //3. fealadat, betöltés
        {
            XDocument loadfile = XDocument.Load("pacman.xml");
            csapatok.Clear();

            foreach (var akt in loadfile.Descendants("Csapat"))
            {
                csapatok.Add(new Csapat
                    {
                        Nev = akt.Attribute("Nev").Value,
                        Varos = akt.Attribute("Varos").Value,
                        Alapitas =   Int32.Parse(akt.Attribute("Alapitas").Value)
                    });
            }

            var sorbancsapat = csapatok.OrderBy(x => x.Nev);  //fogalmam nincs hogy kell a lekérdezésben sorbaállítani valamit de gondolom azt kellett volna
            listBox1.Items.Clear();
            foreach (var wtf in sorbancsapat)//listboxba pakolás, gondolom lehetne adatkötni a listboxot ehelyett dehát honnét tudnám hogy azt hogy kell
            {
                listBox1.Items.Add(wtf);
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //3. feladat
        {
            var meccsek = new List<Meccs>();
            meccsek.Clear();
            
            for (int i = 0; i < 5; i++)     //csinálunk 5 meccs osztályt
            {
                int localvar = R.Next(9);
                meccsek.Add(new Meccs { Elsocsap = csapatok[localvar].Nev, Masodikcsap = csapatok[localvar+1].Nev, Elsogol = 0, Masodikgol = 0 });
            }
         
            tlist.Clear();
            new Task(() => Display(meccsek)).Start();   //elindítjuk a megjelenítő taskot ami párhuzamosan fut a többivel..i guess
                foreach (var item in meccsek)       //elindítjuk az összes meccs taskját
	                {
                       Task t = new Task(item.play);
                       t.Start();
                       tlist.Add(t);  //beraktam őket egy listába hogy tudjuk mikor van végük
	                }

         
        }

        private void Display(List<Meccs> mec)  //kiírogató task
        {
            bool complete = false;
            while (!complete)  //addig fut a task amíg minden item nem completed, a WaitAll valamiért felfüggesztette ezt a taskot, nem értek hozzá hogy miért
            {
               complete = true;
                foreach (var item in tlist)
                {
                    if (!item.IsCompleted)
                    {
                        complete = false;
                    }
                }

           Dispatcher.Invoke(() => {        //kiírás rész, mondjuk szerintem dispatcher.invoke nélkül is lazán menne de gondolom ezzel kellett megcsinálni
               listBox2.Items.Clear();
               foreach (var item in mec)
               {
                   listBox2.Items.Add(item); 
               }
               });
        }
        }

    }
}
