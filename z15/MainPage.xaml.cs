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
            using (var conn = new MySqlConnection("server=TWOJ_ADRES_HOSTA;database=TWOJA_BAZA_DANYCH;uid=TWOJ_USER;pwd=TWOJE_HASLO")) //łączenie z bazą danych
  //        using (var conn = new MySqlConnection("server=kdkj.nazwa.pl;database=ZTP;uid=odczyt;pwd=12345678")) //łączenie z bazą danych
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding.GetEncoding("latin2");
                conn.Open(); //otwarcie połączenia z bazą
                int i = 1;
                while (i < 4)
                {
                    var cmd = new MySqlCommand("SELECT nazwisko FROM pracownik WHERE id='"+i+"';", conn);
                    string nazwisko = Convert.ToString(cmd.ExecuteScalar());
                    PoleTekstowe.Text += "Nazwisko: "+nazwisko+"\n";
                    i++;
                }
                conn.Close(); //zamykanie połączenia z bazą
            }
        }
    }
}
