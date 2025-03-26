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
using System.Windows.Shapes;

namespace BiblioteqSofiya931.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddReaderWindow.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        public AddReaderWindow()
        {
            InitializeComponent();
        }

        private void SaveReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            Reader reader = new Reader();
            reader.Lastname = LastNameTb.Text.Trim();
            reader.Name = NameTb.Text.Trim();
            reader.Patronymic = PatromymicTb.Text.Trim();
            reader.Birthdate = BirthDateDp.SelectedDate;
            reader.Phone = PhoneTb.Text.Trim();
            reader.IsDelete = false;
            Connection.biblioteq.Reader.Add(reader);
            Connection.biblioteq.SaveChanges();
            MessageBox.Show("Читатель успешно добавлен.");
            Close();
        }
    }
}
