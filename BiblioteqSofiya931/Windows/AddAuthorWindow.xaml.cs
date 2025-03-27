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
    /// Логика взаимодействия для AddAuthorWindow.xaml
    /// </summary>
    public partial class AddAuthorWindow : Window
    {
        public AddAuthorWindow()
        {
            InitializeComponent();
        }

        private void SaveAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            Author author = new Author();
            if(LastNameTb.Text != null && NameTb.Text!= null && PatronymicTb.Text != null)
            {
                author.LastName = LastNameTb.Text;
                author.Name = NameTb.Text;
                author.Patronymic = PatronymicTb.Text;
                Connection.biblioteq.Author.Add(author);
                Connection.biblioteq.SaveChanges();
                MessageBox.Show("Автор успешно сохранен");
                Close();
            }
        }
    }
}
