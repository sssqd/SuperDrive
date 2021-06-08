using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SuperDrive
{
    public class Game
    {
        private readonly Canvas mainCanvas;

        DispatcherTimer GameTimer = new DispatcherTimer();
        List<Rectangle> ItemRemove = new List<Rectangle>();
        Random random = new Random();
        ImageBrush UserPicture = new ImageBrush();
        ImageBrush CoinPicture = new ImageBrush();
        Rect UserHitBox;

        int speed = 15; //спиды
        int userSpeed = 10;
        int numberCar;
        int coinCounter = 10;
        int powerModeCounter = 200;
        double score;
        double i;
        bool Left, Right, GameOver, PowerMode;
    }
}
