using Library.Service.Book;
using Library.shared.BookDTO;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBookService _bookService;

        public MainWindow(IBookService bookService)
        {
            _bookService = bookService;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        public MainWindow()
        {
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadBooks();

        }

        private async Task LoadBooks()
        {
            foreach (var item in await _bookService.FindAll())
            {
                TxtBooks.Text += item.ToString();
            }
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            _bookService.Add(new BookDTO(TxtNombre.Name, TxtAutor.Text, TxtDescripción.Text, TxtCategoria.Text));
            Console.WriteLine("Book saved");
        }
    }
}