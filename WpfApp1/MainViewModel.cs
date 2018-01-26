using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;
using Teleta.Bari.XF.Repository;

namespace WpfApp1
{
    public class MainViewModel : ViewModelBase
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);
        Timer timer1;
        Timer timer2;

        public RelayCommand StartCommand { get; set; }
        public ObservableCollection<Article> Articles { get; set; }

        public MainViewModel()
        {
            this.StartCommand = new RelayCommand(StartCommandExecute);
            this.Articles = new ObservableCollection<Article>();
            load();
        }

        private void load()
        {
            int count = 100000;
            for (int i = 0; i < count; i++)
            {
                Article a = new Article();
                a.ID = rnd.Next(1, 1000);
                //a.Quantity = rnd.Next(87, 191);
                a.Name = string.Concat("Nome Art. ", a.ID);

                this.Articles.Add(a);
            }

            base.RaisePropertyChanged(nameof(Articles));
        }

        private void StartCommandExecute()
        {
            timer1 = new Timer(100);
            timer1.Elapsed += Timer_Elapsed1;

            timer2 = new Timer(1000);
            timer2.Elapsed += Timer_Elapsed2;

            timer1.Start();
            timer2.Start();
        }

        private void Timer_Elapsed2(object sender, ElapsedEventArgs e)
        {
            Article a = new Article();
            a.ID = rnd.Next(1, 1000);
            a.Name = string.Concat("Nome Art. ", a.ID);

            Application.Current.Dispatcher.Invoke(() => { this.Articles.Add(a); });
        }

        private void Timer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < this.Articles.Count; i++)
            {
                this.Articles[i].Quantity = rnd.Next(0, 4000);
            }
        }
    }
}