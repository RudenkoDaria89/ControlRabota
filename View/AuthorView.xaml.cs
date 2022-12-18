using BookAccounting.Models;
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

namespace BookAccounting.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorView.xaml
    /// </summary>
    public partial class AuthorView : Window
    {
        public Author Author { get; private set; }
        public AuthorView(Author author)
        {
            InitializeComponent();
            Author = author;
            DataContext = Author;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
