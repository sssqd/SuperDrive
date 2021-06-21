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
        int numberCar;
        int coinCounter = 10;
        int powerModeCounter = 200;
        double score;
        double i;
        bool Left, Right, GameOver, PowerMode;
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
            score += .05;
            coinCounter -= 1;
            Timer.Content = "Таймер: " + score.ToString("#.#") + "сек ";
            UserHitBox = new Rect(Canvas.GetLeft(User), Canvas.GetTop(User), User.Width, User.Height);
            if (Left == true && Canvas.GetLeft(User) > 0)
            {
                Canvas.SetLeft(User, Canvas.GetLeft(User) - userSpeed);
            }
            if (Right == true && Canvas.GetLeft(User) + 90 < Application.Current.MainWindow.Width) 
            {
                Canvas.SetLeft(User, Canvas.GetLeft(User) + userSpeed);
            }
            if (coinCounter < 1)
            {
                MakeStart();
                coinCounter = random.Next(600, 900);
            }
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "Markup")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + speed);
                    if (Canvas.GetTop(x) > 500)
                    {
                        Canvas.SetTop(x, -152);
                    }
                }
                if ((string)x.Tag == "Car")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + speed);

                    if (Canvas.GetTop(x) > 500)
                    {
                        ChangeCars(x);
                    }
                    Rect carHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (UserHitBox.IntersectsWith(carHitBox) && PowerMode == false)
                    {
                        GameTimer.Stop();
                        Timer.Content += "Нажмите Enter чтобы начать заново";
                        GameOver = true;
                    }
                }
                if ((string)x.Tag == "Coin")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + 5);
                    Rect coinHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if(UserHitBox.IntersectsWith(coinHitBox))
                    {
                        ItemRemove.Add(x);
                        PowerMode = true;
                        powerModeCounter = 200;
                    }
                    if (Canvas.GetTop(x)>400)
                    {
                        ItemRemove.Add(x);
                    }
                }

            }
            if (PowerMode == true)
            {
                powerModeCounter -= 1;
                PowerUp();
                if (powerModeCounter < 1)
                {
                    PowerMode = false;
                }
            }
            else
            {
                UserPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Cyan.png"));
                MyCanvas.Background = Brushes.Gray;
            }
            foreach (Rectangle y in ItemRemove)
            {
                MyCanvas.Children.Remove(y);
            }
            if (score >= 10 && score <20)
            {
                speed = 12;
            }
            if (score >= 20 && score < 30)
            {
                speed = 14;
            }
            if (score >= 30 && score < 40)
            {
                speed = 16;
            }
            if (score >= 40 && score < 50)
            {
                speed = 18;
            }
            if (score >= 50 && score < 80)
            {
                speed = 22;
            }
        }

        private void MyKeyDown(object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.Left)
            {
                Left = true;
            }
            if (e.Key == Key.Right)
            {
                Right = true;
            }
        }

        private void MyKeyUp(object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.Left)
            {
                Left = false;
            }
            if (e.Key == Key.Right)
            {
                Right = false;
            }
            if (e.Key== Key.Enter && GameOver==true)
            {
                StartGame();
            }
        }

        private void StartGame() 
        {
            speed = 8;
            GameTimer.Start();

            Left = false;
            Right = false;
            GameOver = false;
            PowerMode = false;

            score = 0;
            Timer.Content = "Таймер: 0 cек ";
            UserPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Cyan.png"));
            CoinPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Coin.png"));
            User.Fill = UserPicture;
            MyCanvas.Background = Brushes.Gray;
            foreach(var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if((string)x.Tag == "Car")
                {
                    Canvas.SetTop(x, (random.Next(100, 400) * -1));
                    Canvas.SetLeft(x, random.Next(0, 430));
                    ChangeCars(x);
               
                }
                if ((string)x.Tag == "Coin")
                {
                    ItemRemove.Add(x);
                }
            }
            ItemRemove.Clear();
        }

        private void ChangeCars(Rectangle car)
        {
            numberCar = random.Next(1, 6);
            ImageBrush carPicture = new ImageBrush();
            switch (numberCar)
            {
                case 1:
                    carPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Purple.png"));
                    break;
                case 2:
                    carPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Rad.png"));
                    break;
                case 3:
                    carPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Yellow.png"));
                    break;
                case 4:
                    carPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Green.png"));
                    break;
                case 5:
                    carPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Seroburomaline.png"));
                    break;
                case 6:
                    carPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Wheat.png"));
                    break;
            }
            car.Fill = carPicture;
            Canvas.SetTop(car, (random.Next(100, 400)* -1));
            Canvas.SetLeft(car, random.Next(0, 430));
        }

        private void PowerUp() 
        {
            i += .5;
            if (i < 4)
            {
                i = 1;
            }
            switch (i)
            {
                case 1:
                    UserPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Purple.png"));
                    break;
                case 2:
                    UserPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Rad.png"));
                    break;
                case 3:
                    UserPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Yellow.png"));
                    break;
                case 4:
                    UserPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Green.png"));
                    break;
                case 5:
                    UserPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Seroburomaline.png"));
                    break;
                case 6:
                    UserPicture.ImageSource = new BitmapImage(new Uri("C:/Users/borge/source/repos/SuperDrive/SuperDrive/Picture/Wheat.png"));
                    break;
            }
            MyCanvas.Background = Brushes.Lime;
        }

        private void MakeStart()
        {
            Rectangle newCoin = new Rectangle
            {
                Width = 50,
                Height = 50,
                Tag = "Coin",
                Fill = CoinPicture
            };
            Canvas.SetLeft(newCoin, random.Next(0, 430));
            Canvas.SetTop(newCoin, (random.Next(100, 400) * -1));
            MyCanvas.Children.Add(newCoin);
        }
    }
}
