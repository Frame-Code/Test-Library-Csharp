using Library.Domain.Data;
using Library.Domain.Repository;
using Library.Service.Book;
using System.Configuration;
using System.Data;
using System.Windows;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dbContext = new LibraryContext();
            IBookRepository bookRepository = new BookRepository(dbContext);
            IBookService bookService = new BookService(bookRepository);
            MainWindow mainWindow = new MainWindow(bookService);
            mainWindow.Show();


        }
        
    }

}
