using BiblioteqSofiya931.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace BiblioteqSofiya931.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Page
    {
        public static List<ReadTicket> readersTicket { get; set; } 
        public ReadersPage()
        {
            InitializeComponent();
            readersTicket  = new List<ReadTicket>(DBConnection.Connection.biblioteq.ReadTicket.
                Where(i => i.Reader.IsDelete == false && i.IsDelete == false).ToList());
            this.DataContext = this;
        }
    }
}
