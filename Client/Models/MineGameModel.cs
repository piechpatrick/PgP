using Client.Controls;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace Client.Models
{
    public class MineGameModel : BindableBase
    {
        public static readonly int timeValue = 10;

        private ObservableCollection<MineControl> _mineControls = new ObservableCollection<MineControl>();
        public ObservableCollection<MineControl> MineControls
        {
            get { return _mineControls; }
            set { SetProperty(ref _mineControls, value); }
        }

        private int _score = 0;
        public int Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }

        private int _bestScore = 0;
        public int BestScore
        {
            get { return _bestScore; }
            set { SetProperty(ref _bestScore, value); }
        }

        private int _time = timeValue;
        public int Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        private Brush _ballColor = Brushes.Red;
        public Brush BallColor
        {
            get { return _ballColor; }
            set { SetProperty(ref _ballColor, value); }
        }

        Random random = new Random();
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MineGameModel()
        {
            for (int i = 0; i < 1056; i++)
            {
                var mine = new MineControl()
                {
                    Color = Brushes.Red,
                    Number = i,
                    HasBomb = (random.Next(100) < 50),//define how lucky you are
                    Shown = true
                };
                mine.ClickedEvent += Mine_ClickedEvent; ;
                MineControls.Add(mine);
            }
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Time > 0)
                Time--;
            else
            {
                dispatcherTimer.Stop();
                IsEnabled = false;
            }
        }

        private void Mine_ClickedEvent(object sender, EventArgs e)
        {
            if (!(sender as MineControl).HasBomb)
                Score++;
            else
                Score = 0;
            if (Score > BestScore)
                BestScore = Score;
        }
    }
}
