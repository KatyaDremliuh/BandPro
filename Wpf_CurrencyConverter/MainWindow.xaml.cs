using System.Windows;

namespace Wpf_CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected RateViewModel ViewModel;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = ViewModel = new RateViewModel();
        }

        private async void OnLoad(object sender, RoutedEventArgs e)
        {
            await ViewModel.OnLoad(sender, e);
        }

        #region Система перемещения окна

        bool _move = false;
        Point _constPosition;

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Зафиксируем неизменяемую позицию
            _constPosition = e.GetPosition(this);

            // Разрешаем движение.
            _move = true;

            // Чтобы мышь не теряла окно, даже если окно скрывается под тормост окнами
            this.CaptureMouse();
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_move)
            {
                // Вычисляем разницу между бывшим и текущим положением курсора от края окна.
                double deltaX = e.GetPosition(this).X - _constPosition.X;
                double deltaY = e.GetPosition(this).Y - _constPosition.Y;


                // Положение окна тут же корректируем на вычисленную величину(разницу).
                this.Left += deltaX;
                this.Top += deltaY;
            }
        }

        private void Window_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Запрещаем движение и отпускаем мышь.
            _move = false;
            this.ReleaseMouseCapture();
        }

        #endregion

        #region Закрытие окна

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}