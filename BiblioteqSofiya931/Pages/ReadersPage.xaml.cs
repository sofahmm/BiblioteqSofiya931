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
        public static List<Employee> employees { get; set; }
        public ReadersPage()
        {
            InitializeComponent();
            readersTicket  = new List<ReadTicket>(DBConnection.Connection.biblioteq.ReadTicket.
                Where(i => i.Reader.IsDelete == false && i.IsDelete == false).ToList());
            employees = new List<Employee>(DBConnection.Connection.biblioteq.Employee.
                Where(i => i.IsDelete == false).ToList());
            employees.Insert(0, new Employee() { ID = -1, Lastname = "Вывести всех" });
            this.DataContext = this;
        }

        private void TicketSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TicketSearchTb.Text.Trim();
            if (search == "")
                ReadersLv.ItemsSource = readersTicket.ToList();
            else
                ReadersLv.ItemsSource = readersTicket.Where(i => i.ID.ToString() == search).ToList();
        }

        private void FiltrEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var t = FiltrEmployee.SelectedItem as Employee;
           
            if (t.ID != -1)
                ReadersLv.ItemsSource = readersTicket.Where(i => i.IdEmployee == t.ID).ToList();
            else
                ReadersLv.ItemsSource = readersTicket.ToList();

        }

        private void AddReaderTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddReaderTicketWindow addReaderTicket = new Windows.AddReaderTicketWindow();
            addReaderTicket.Show();
        }

        private void ReadersListBtn_Click()
        {

        }
    }
}
