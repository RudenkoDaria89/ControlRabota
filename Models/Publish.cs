using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
 
namespace BookAccounting.Models
{
    public class Publish : INotifyPropertyChanged
    {
        private int publishID;
        private string namePublisher;
        private string adress;
        private string site;

        [Key]
        public int PublishID
        {
            get { return publishID; }
            set
            {
                publishID = value;
                OnPropertyChanged("PublishID");
            }
        }

        public string NamePublisher
        {
            get { return namePublisher; }
            set
            {
                namePublisher = value;
                OnPropertyChanged("NamePublisher");
            }
        }

        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                OnPropertyChanged("Adress");
            }
        }

        public string Site
        {
            get { return site; }
            set
            {
                site = value;
                OnPropertyChanged("Site");
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