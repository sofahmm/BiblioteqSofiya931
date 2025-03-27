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
    /// Логика взаимодействия для BookksPage.xaml
    /// </summary>
    public partial class BookksPage : Page
    {
        public static List<Book> books { get; set; }
        public BookksPage()
        {
            InitializeComponent();
            books = new List<Book>(Connection.biblioteq.Book.Where(i => i.IsDelete == false).ToList());
            this.DataContext = this;
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddBookWindow addBookWindow = new Windows.AddBookWindow();
            addBookWindow.Show();
        }
    }
}
