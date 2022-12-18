using BookAccounting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для BookView.xaml
    /// </summary>
    public partial class BookView : Window
    {
        public Book Book { get; private set; }
        public BookView(Book book, ObservableCollection<Author> listOfAuthors, ObservableCollection<Publish> listOfPublishes)
        {
            InitializeComponent();
            Book = book;

            AuthorTextBox.ItemsSource = listOfAuthors;
            AuthorTextBox.SelectedItem = Book.Author;

            PublishTextBox.ItemsSource = listOfPublishes;
            PublishTextBox.SelectedItem = Book.Publish;

            DataContext = Book;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AuthorTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book.Author = (Author)AuthorTextBox.SelectedItem;
            Book.AuthorID = ((Author)AuthorTextBox.SelectedItem).AuthorID;
        }

        private void PublishTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book.Publish = (Publish)PublishTextBox.SelectedItem;
            Book.PublishID = ((Publish)PublishTextBox.SelectedItem).PublishID;
        }
    }
}
