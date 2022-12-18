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
    /// Логика взаимодействия для PublishView.xaml
    /// </summary>
    public partial class PublishView : Window
    {
        public Publish Publish { get; private set; }
        public PublishView(Publish publish)
        {
            InitializeComponent();
            Publish = publish;
            DataContext = Publish;
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
