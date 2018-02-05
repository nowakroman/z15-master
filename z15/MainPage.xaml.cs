using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Pomelo.Data.MySql;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace z15
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            //using (var conn = new MySqlConnection("server=ADRES_HOSTA;Port=3306;database=BAZA_DANYCH;uid=USER_Database;pwd=Haslo"))
            using (var conn = new MySqlConnection("server=127.0.0.1;Port=3306;database=programowanie;uid=root")) //connect
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding.GetEncoding("utf-8");
                conn.Open(); //open database
                int i = 0;
                while (i < 5)
                {
                    var cmd = new MySqlCommand("SELECT nazwisko FROM pracownik WHERE id_pracownik='"+i+"';", conn);
                    string nazwisko = Convert.ToString(cmd.ExecuteScalar());

                    nazwiska.Text += i + ": " + nazwisko + "\n";
                    i++;
                }
                conn.Close(); //close database
            }
        }
    }
}
