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

namespace Client.Controls
{
    /// <summary>
    /// Interaction logic for BallControl.xaml
    /// </summary>
    public partial class MineControl : UserControl
    {
        public int Number { get; set; }

        public event EventHandler ClickedEvent;

        public bool HasBomb
        {
            get { return (bool)this.GetValue(IsEmptyProperty); }
            set { SetValue(IsEmptyProperty, value); }
        }
        public static readonly DependencyProperty IsEmptyProperty = DependencyProperty.Register(
          "HasBomb", typeof(bool), typeof(MineControl), new PropertyMetadata(default(bool)));

        public bool Shown
        {
            get { return (bool)this.GetValue(ShownProperty); }
            set { SetValue(ShownProperty, value); }
        }
        public static readonly DependencyProperty ShownProperty = DependencyProperty.Register(
          "Shown", typeof(bool), typeof(MineControl), new PropertyMetadata(default(bool)));


        public Brush Color
        {
            get { return (Brush)this.GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
          "Color", typeof(Brush), typeof(MineControl), new PropertyMetadata(default(MineControl)));

        private void Grid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Shown = false;
            OnClicked(e);
        }

        public MineControl()
        {
            InitializeComponent();
            Color = Brushes.Red;
        }

        protected void OnClicked(EventArgs e)
        {
            if (ClickedEvent != null)
                ClickedEvent(this, e);
        }
    }
}
