using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace SQLite_databáze_1
{
    internal class DataSQLite
    {
        public static string Cs { get; private set; }
        public static SQLiteConnection Connection { get; private set; }// zde je označení serveru, označení databáze a autentikace uživatele
        private SQLiteCommand prikaz;
        public DataSQLite()
        {
            Cs = @"URI=file:test.db"; //cesta k db souboru
            Connection = new SQLiteConnection(Cs);
        }

        public static void Pripoj()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void VytvorTabulku()
        {
            try
            {
                Pripoj(); 
                prikaz = new SQLiteCommand(Connection);
                prikaz.CommandText = "DROP TABLE IF EXISTS cars"; 
                prikaz.ExecuteNonQuery(); 
                prikaz.CommandText = "CREATE TABLE cars(AutoID INTEGER PRIMARY KEY AUTOINCREMENT, nazev VARCHAR(15), cena INTEGER);";
                prikaz.ExecuteNonQuery();
                prikaz.CommandText = "INSERT INTO cars(nazev, cena) VALUES('Audi',52642)";
                prikaz.ExecuteNonQuery();
                prikaz.CommandText = "INSERT INTO cars(nazev, cena) VALUES('Mercedes',57262)";
                prikaz.ExecuteNonQuery();
                prikaz.CommandText = "INSERT INTO cars(nazev, cena) VALUES('Škoda',75832)";
                prikaz.ExecuteNonQuery();
                prikaz.CommandText = "INSERT INTO cars(nazev, cena) VALUES('Lambo',69420)";
                prikaz.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
        public BindingList<Car> GetValues()
        {
            BindingList<Car> carList = new BindingList<Car>();
            Pripoj();
            prikaz.CommandText = "SELECT * FROM cars order by nazev";
            using (var reader = prikaz.ExecuteReader()){while (reader.Read()){carList.Add(new Car(Convert.ToInt32(reader["AutoID"]), reader["nazev"].ToString(), Convert.ToInt32(reader["cena"])));}}
            return carList;
        }
    }
}
