using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Wpf_CurrencyConverter
{
    public class RateViewModel : PropertyChangedBase
    {
        protected RateModel CurrentRate;
        protected DispatcherTimer Timer;
        protected Visibility isProgressVisible;

        public RateViewModel()
        {
            // Создаем курс валюты
            CurrentRate = new RateModel();

            // Создаем таймер, которые каждые 10 секунд получает новый курс доллара
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 10);
            Timer.Start();

            isProgressVisible = Visibility.Hidden;

            // Пробрасываем изменившиеся свойства Модели во View
            CurrentRate.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(e.PropertyName);
            };
        }

        public Visibility IsProgressVisible
        {
            get
            {
                return isProgressVisible;
            }
            set
            {
                isProgressVisible = value;
                OnPropertyChanged(nameof(IsProgressVisible));
            }
        }

        // Обработчик, который вызывается каждые 10 сек для получения курса доллара
        private async void timer_Tick(object sender, EventArgs e)
        {
            await GetRate();
        }

        // Событие случается при загрузке окна программы
        public async Task OnLoad(object sender, RoutedEventArgs e)
        {
            await GetRate();
        }

        public async Task GetRate()
        {
            IsProgressVisible = Visibility.Visible;

            await CurrentRate.GetRate();

            IsProgressVisible = Visibility.Hidden;
        }

        // public double Value => curRate.Value;

        public double Value
        {
            get { return CurrentRate.Value; }
        }
    }
}