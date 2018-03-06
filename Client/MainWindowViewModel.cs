using Client.Controls;
using Client.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Client
{
    public class MainWindowViewModel : BindableBase
    {

        public MineGameModel MineGameModel { get; private set; }

        public DelegateCommand<object> RestartCommand { get; private set; }
        private void OnRestartRaised(object ob)
        {
            foreach (var mine in MineGameModel.MineControls)
            {
                mine.Shown = true;
            }
            MineGameModel.Score = 0;
            MineGameModel.IsEnabled = true;
            MineGameModel.Time = MineGameModel.timeValue;
            MineGameModel.dispatcherTimer.Start();
        }
        private bool CanRaiseRestart(object ob)
        {
            return true;
        }
        public MainWindowViewModel()
        {
            RestartCommand = new DelegateCommand<object>(OnRestartRaised, CanRaiseRestart);
            MineGameModel = new MineGameModel();
        }
    }
}
