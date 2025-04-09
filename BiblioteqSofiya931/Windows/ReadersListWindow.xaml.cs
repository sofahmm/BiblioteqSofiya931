using BiblioteqSofiya931.DBConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
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

namespace BiblioteqSofiya931.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReadersListWindow.xaml
    /// </summary>
    public partial class ReadersListWindow : Window
    {
        public static List<Reader> readers {  get; set; }
        public ReadersListWindow()
        {
            InitializeComponent();
            readers = new List<Reader>(DBConnection.Connection.biblioteq.Reader.Where(i => i.IsDelete == false).ToList());
      

            this.DataContext = this;
        }

        private void SearchReadersTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var phone = SearchReadersTb.Text;
            if(phone == "")
                ReadersLv.ItemsSource = new List<Reader>(DBConnection.Connection.biblioteq.Reader.Where(i => i.IsDelete == false).ToList());
            else
                ReadersLv.ItemsSource = new List<Reader>(Connection.biblioteq.Reader.Where(i => i.Phone == phone && i.IsDelete == false).ToList());

        }

        private void BirthDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = BirthDateDp.SelectedDate;
            ReadersLv.ItemsSource = new List<Reader>(Connection.biblioteq.Reader.Where(i => i.Birthdate >= date && i.IsDelete == false).ToList());

        }

        private void EditReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            var reader = ReadersLv.SelectedItem as Reader;
            if(reader != null)
            {
                Windows.EditReaderBtn editReaderWindow = new Windows.EditReaderBtn(reader); //Случайно назвала EditReaderBtn, у вас скорее всего называется EditReaderWindow, не путайтесь
                editReaderWindow.Show();

            }
            else
            {
                MessageBox.Show("Для редактирования выберите читателя");
            }
        }

        private void DeleteReadreBtn_Click(object sender, RoutedEventArgs e)
        {
            var reader = ReadersLv.SelectedItem as Reader;
            if(reader != null)
            {
                MessageBoxResult message = MessageBox.Show($"Вы действительно хотите удалить читателя {reader.Lastname} {reader.Name} ?", "Удаление", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    reader.IsDelete = true;
                    Connection.biblioteq.SaveChanges();
                    ReadersLv.ItemsSource = new List<Reader>(DBConnection.Connection.biblioteq.Reader.Where(i => i.IsDelete == false).ToList());
                }
            }
            else
            {
                MessageBox.Show("Вы никого не выбрали.");
            }
        }

        private void ReadersLv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ReadersLv.ItemsSource = new List<Reader>(DBConnection.Connection.biblioteq.Reader.Where(i => i.IsDelete == false).ToList());
        }
    }
}
