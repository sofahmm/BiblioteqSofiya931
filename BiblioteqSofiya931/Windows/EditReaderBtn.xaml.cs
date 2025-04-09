using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для EditReaderBtn.xaml
    /// </summary>
    public partial class EditReaderBtn : Window
    {
        public static Reader reader1 = new Reader();
        public EditReaderBtn(Reader reader)
        {
            InitializeComponent();
            reader1 = reader;
            LastNameTb.Text = reader1.Lastname;
            NameTb.Text = reader1.Name; 
            PatronymicTb.Text = reader1.Patronymic;
            BirthDateDp.SelectedDate = reader1.Birthdate;
            PhoneTb.Text = reader1.Phone;
            this.DataContext = this;
        }

        private void SaveEditBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult message = MessageBox.Show($"Вы действительно хотите изменить читателя {reader1.Lastname} {reader1.Name} ?", "Удаление", MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
                reader1.Lastname = LastNameTb.Text;
                reader1.Name = NameTb.Text;
                reader1.Patronymic = PatronymicTb.Text;
                reader1.Birthdate = BirthDateDp.SelectedDate;
                reader1.Phone = PhoneTb.Text;
                Connection.biblioteq.SaveChanges();
                ReadersListWindow readersListWindow = new ReadersListWindow();
                readersListWindow.ReadersLv.ItemsSource = new List<Reader>(DBConnection.Connection.biblioteq.Reader.Where(i => i.IsDelete == false).ToList());
            }
            MessageBox.Show("Читатель успешно изменен");
            Close();
            
        }
    }
}
