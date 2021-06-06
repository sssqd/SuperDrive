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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SuperDrive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer GameTimer = new DispatcherTimer();
        List<Rectangle> ItemRemove = new List<Rectangle>();
        Random random = new Random();
        ImageBrush UserPicture = new ImageBrush();
        ImageBrush CoinPicture = new ImageBrush();
        Rect UserHitBox;

        int speed = 15;
        int userSpeed = 10;
        string nomberCar;
        int startCounter = 10;
        int powerModeCounter = 200;
        double score;
        double i;
        bool Left, Right, Up, Down;
        public MainWindow()
        {
            InitializeComponent();
            MyCanvas.Focus();
            GameTimer.Tick += GameLoop;
            GameTimer.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            
        }

        private void MyKeyDown(object sender, KeyEventArgs e) //перенести в отдельный класс
        {

        }

        private void MyKeyUp(object sender, KeyEventArgs e) //перенести в отдельный класс
        {

        }

        private void StartGame() //перенести в отдельный класс
        {
            speed = 8;
            GameTimer.Start();

            Left = false;
            Right = false;
            Up = false;
            Down = false;

            score = 0;
            Timer.Content = "Таймер: 0 cек";

        }

        private void ChangeCars(Rectangle C) //перенести в отдельный класс
        {

        }

        private void PowerUp() //перенести в отдельный класс
        {

        }

        private void MakeStart() //перенести в отдельный класс
        {

        }
    }
}
