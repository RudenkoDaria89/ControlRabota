using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BookAccounting.Models
{
    public class Book : INotifyPropertyChanged
    {
        private int bookID;
        private int authorID;
        private Author author;
        private int publishID;
        private Publish publish;
        private string title;
        private string code;
        private int yearPublish;
        private int countPage;
        private double price;
        private string handCover;
        private string bookAbstract;
        private string status;


        [Key]
        public int BookID
        {
            get { return bookID; }
            set
            {
                bookID = value;
                OnPropertyChanged("BookID");
            }
        }

        public int AuthorID
        {
            get { return authorID; }
            set
            {
                authorID = value;
                OnPropertyChanged("AuthorID");
            }
        }

        public Author Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        public int PublishID
        {
            get { return publishID; }
            set
            {
                publishID = value;
                OnPropertyChanged("PublishID");
            }
        }

        public Publish Publish
        {
            get { return publish; }
            set
            {
                publish = value;
                OnPropertyChanged("Publish");
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        public int YearPublish
        {
            get { return yearPublish; }
            set
            {
                yearPublish = value;
                OnPropertyChanged("YearPublish");
            }
        }

        public int CountPage
        {
            get { return countPage; }
            set
            {
                countPage = value;
                OnPropertyChanged("CountPage");
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string HandCover
        {
            get { return handCover; }
            set
            {
                handCover = value;
                OnPropertyChanged("HandCover");
            }
        }

        public string BookAbstract
        {
            get { return bookAbstract; }
            set
            {
                bookAbstract = value;
                OnPropertyChanged("BookAbstract");
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
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