using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BookAccounting.Models;
using BookAccounting.View;
using Microsoft.EntityFrameworkCore;

namespace BookAccounting.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        ApplicationContext db = new ApplicationContext();

        public ViewModel()
        {
            db.Database.EnsureCreated();

            db.Books.Load();
            Books = db.Books.Local.ToObservableCollection();

            db.Authors.Load();
            Authors = db.Authors.Local.ToObservableCollection();

            db.Publishes.Load();
            Publishes = db.Publishes.Local.ToObservableCollection();
        }

        //Книги
        RelayCommand addBook;
        RelayCommand editBook;
        RelayCommand deleteBook;
        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        public ObservableCollection<Book> Books { get; set; }

        public RelayCommand AddBook
        {
            get
            {
                return addBook ??
                (addBook = new RelayCommand((o) =>
                {
                    BookView BookWindow = new BookView(new Book(), Authors, Publishes);
                    if (BookWindow.ShowDialog() == true)
                    {
                        Book Book = BookWindow.Book;
                        db.Books.Add(Book);
                        db.SaveChanges();
                    }
                }));
            }
        }

        public RelayCommand EditBook
        {
            get
            {
                return editBook ??
                (editBook = new RelayCommand((selectedItem) =>
                {
    
                        Book book = selectedItem as Book;
                    if (book is null) return;

                    BookView BookWindow = new BookView(new Book
                    {
                        BookID = book.BookID,
                        Publish = book.Publish,
                        AuthorID = book.AuthorID,
                        Author = book.Author,
                        BookAbstract = book.BookAbstract,
                        Code = book.Code,
                        CountPage = book.CountPage,
                        HandCover = book.HandCover,
                        Price = book.Price,
                        PublishID = book.PublishID,
                        Status = book.Status,
                        Title = book.Title,
                        YearPublish = book.YearPublish
                    }, Authors, Publishes);

                    if (BookWindow.ShowDialog() == true)
                    {
                        book = db.Books.Find(BookWindow.Book.BookID);
                        if (book != null)
                        {
                            book.BookID = BookWindow.Book.BookID;
                            book.Publish = BookWindow.Book.Publish;
                            book.AuthorID = BookWindow.Book.AuthorID;
                            book.Author = BookWindow.Book.Author;
                            book.BookAbstract = BookWindow.Book.BookAbstract;
                            book.Code = BookWindow.Book.Code;
                            book.CountPage = BookWindow.Book.CountPage;
                            book.HandCover = BookWindow.Book.HandCover;
                            book.Price = BookWindow.Book.Price;
                            book.PublishID = BookWindow.Book.PublishID;
                            book.Status = BookWindow.Book.Status;
                            book.Title = BookWindow.Book.Title;
                            book.YearPublish = BookWindow.Book.YearPublish;
                            db.SaveChanges();
                        }
                    }
                }));
            }
        }

        public RelayCommand DeleteBook
        {
            get
            {
                return deleteBook ??
                (deleteBook = new RelayCommand((selectedItem) =>
                {
                    Book book = selectedItem as Book;
                    if (book is null) return;
                    db.Books.Remove(book);
                    db.SaveChanges();
                }));
            }
        }

        //Авторы
        RelayCommand addAuthor;
        RelayCommand editAuthor;
        RelayCommand deleteAuthor;
        private Author selectedAuthor;

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                selectedAuthor = value;
                OnPropertyChanged("SelectedAuthor");
            }
        }

        public ObservableCollection<Author> Authors { get; set; }

        public RelayCommand AddAuthor
        {
            get
            {
                return addAuthor ??
                (addAuthor = new RelayCommand((o) =>
                {
                    AuthorView AuthorWindow = new AuthorView(new Author());
                    if (AuthorWindow.ShowDialog() == true)
                    {
                        Author Author = AuthorWindow.Author;
                        db.Authors.Add(Author);
                        db.SaveChanges();
                    }
                }));
            }
        }

        public RelayCommand EditAuthor
        {
            get
            {
                return editAuthor ??
                (editAuthor = new RelayCommand((selectedItem) =>
                {

                    Author author = selectedItem as Author;
                    if (author is null) return;

                    AuthorView AuthorWindow = new AuthorView(new Author
                    {
                        AuthorID = author.AuthorID,
                        FirstName = author.FirstName,
                        LastName = author.LastName
                    });

                    if (AuthorWindow.ShowDialog() == true)
                    {
                        author = db.Authors.Find(AuthorWindow.Author.AuthorID);
                        if (author != null)
                        {
                            author.AuthorID = AuthorWindow.Author.AuthorID;
                            author.FirstName = AuthorWindow.Author.FirstName;
                            author.LastName = AuthorWindow.Author.LastName;
                            db.SaveChanges();
                        }
                    }
                }));
            }
        }

        public RelayCommand DeleteAuthor
        {
            get
            {
                return deleteAuthor ??
                (deleteAuthor = new RelayCommand((selectedItem) =>
                {
                    Author book = selectedItem as Author;
                    if (book is null) return;
                    db.Authors.Remove(book);
                    db.SaveChanges();
                }));
            }
        }

        //Издательства
        RelayCommand addPublish;
        RelayCommand editPublish;
        RelayCommand deletePublish;
        private Publish selectedPublish;

        public Publish SelectedPublish
        {
            get { return selectedPublish; }
            set
            {
                selectedPublish = value;
                OnPropertyChanged("SelectedPublish");
            }
        }

        public ObservableCollection<Publish> Publishes { get; set; }


        public RelayCommand AddPublish
        {
            get
            {
                return addPublish ??
                (addPublish = new RelayCommand((o) =>
                {
                    PublishView PublishWindow = new PublishView(new Publish());
                    if (PublishWindow.ShowDialog() == true)
                    {
                        Publish Publish = PublishWindow.Publish;
                        db.Publishes.Add(Publish);
                        db.SaveChanges();
                    }
                }));
            }
        }

        public RelayCommand EditPublish
        {
            get
            {
                return editPublish ??
                (editPublish = new RelayCommand((selectedItem) =>
                {

                    Publish publish = selectedItem as Publish;
                    if (publish is null) return;

                    PublishView PublishWindow = new PublishView(new Publish
                    {
                        PublishID = publish.PublishID,
                        NamePublisher = publish.NamePublisher,
                        Adress = publish.Adress,
                        Site = publish.Site
                    });

                    if (PublishWindow.ShowDialog() == true)
                    {
                        publish = db.Publishes.Find(PublishWindow.Publish.PublishID);
                        if (publish != null)
                        {
                            publish.PublishID = PublishWindow.Publish.PublishID;
                            publish.NamePublisher = PublishWindow.Publish.NamePublisher;
                            publish.Adress = PublishWindow.Publish.Adress;
                            publish.Site = PublishWindow.Publish.Site;
                            db.SaveChanges();
                        }
                    }
                }));
            }
        }

        public RelayCommand DeletePublish
        {
            get
            {
                return deletePublish ??
                (deletePublish = new RelayCommand((selectedItem) =>
                {
                    Publish book = selectedItem as Publish;
                    if (book is null) return;
                    db.Publishes.Remove(book);
                    db.SaveChanges();
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}