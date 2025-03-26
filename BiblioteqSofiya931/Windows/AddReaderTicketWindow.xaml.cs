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
using System.Windows.Shapes;
using BiblioteqSofiya931.DBConnection;

namespace BiblioteqSofiya931.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddReaderTicketWindow.xaml
    /// </summary>
    public partial class AddReaderTicketWindow : Window
    {
        public static List<Reader> readers { get; set; }
        public static List<Employee> employees { get; set; }    
        public AddReaderTicketWindow()
        {
            InitializeComponent();
            readers = new List<Reader>(Connection.biblioteq.Reader.Where(i => i.IsDelete == false).ToList());
            employees = new List<Employee>(Connection.biblioteq.Employee.Where(i => i.IsDelete == false).ToList());
            this.DataContext = this;
        }

        private void SaveTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            ReadTicket readTicket = new ReadTicket();
            readTicket.IsDelete = false;
            readTicket.DateRegistr = DateTime.Now;
            var reader = ReaderCm.SelectedItem as Reader;
            readTicket.IdReader = reader.ID;
            var employee = EmployeeCm.SelectedItem as Employee;
            readTicket.IdEmployee = employee.ID;
            Connection.biblioteq.ReadTicket.Add(readTicket);
            Connection.biblioteq.SaveChanges();
            MessageBox.Show("Новый билет добавлен.");
            Close();
        }

        private void AddReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReaderWindow addReaderWindow = new AddReaderWindow();
            addReaderWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ReaderCm.ItemsSource = new List<Reader>(Connection.biblioteq.Reader.Where(i => i.IsDelete == false).ToList());
        }
    }
}
