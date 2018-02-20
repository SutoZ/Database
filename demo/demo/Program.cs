using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //sql scripteket tudunk futtatni az EMPDEPT.MDF-en
            //jöjjön a DBConnection-ös módszer <-- SqlConnection kell, mert LocalDBhez az kell


            ///DataDirectory
            /*
            |DataDirectory| (enclosed in pipe symbols) is a substitution string that indicates the path to the database. It eliminates the need to hard-code the full path which leads to several problems as the full path to the database could be serialized in different places. DataDirectory also makes it easy to share a project and also to deploy an application.

For example, instead of having the following connection string:

"Data Source= c:\program files\MyApp\Mydb.sdf"
Using DataDirectory, you can have the following connection string:

“Data Source = |DataDirectory|\Mydb.sdf” 
             */


            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|" + @"EMPDEPT.mdf;Integrated Security=True");      //milyen Connectionstring kell MSSqlhez
            //hogy lehet ezt server-property-ből kiszedni
            connection.Open();
            Console.WriteLine("Csatlakozva");

            //csináljunk parancsot
            SqlCommand command = new SqlCommand("select * from dept order by dname;", connection);
            //a readerből kell kiolvasni amit kaptunk eredményként az adatbázisból.
            SqlDataReader reader = command.ExecuteReader();        //Execute: milyen választ várok vissza az adatbázistól : pl: sok sort várok vissza / egy számot ad visza pl:(darabszám)

            //reader <-- adatsoronként lehet léptetni
            while (reader.Read())   //amíg nem false, addig van még mit kiolvasni
            {
                //most épp egy soron áll a reader <-- kell egy for ciklus

                for (int i = 0; i < reader.FieldCount; i++)   //hány oszlop van az eredménysorban
                {
                    Console.Write(reader[i] + "\t");    //kiírja az oszloptartalmat
                }
                Console.WriteLine();
            }

            //DataSet módszerrel <-- osztályokkal dolgozunk.

            //sor + oszlop osztályaink lesznek generálva.
            //kapcsolat nélküli módban működik (az egész adatot elmenti memóriába)

            //hátrány: memóriaigény + ha többen használják, akkor szinkornizációs problémák)
            //erős a GUI támogatottság.


            //new Project hozzáadása + jobb klikk ( set as Startup Project)
            //Data Sources megnyitása (Shift + Alt + D)

            Console.ReadKey();

        }
    }
}
