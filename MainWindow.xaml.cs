using System.Windows;
using System.Windows.Media;

namespace RGBPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button_Click(0, new()); 
            RGBSliders_ValueChanged(0, new(0, 0)); 
        }

        private SolidColorBrush CreateSolidColorBrushFromSliders()
        {
            byte r = (byte)redSlider.Value;
            byte g = (byte)greenSlider.Value;
            byte b = (byte)blueSlider.Value;

            return new(Color.FromRgb(r, g, b));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double r = redSlider.Value;
            double g = greenSlider.Value;
            double b = blueSlider.Value;

            savedRGB.Content = $"{r}, {g}, {b}";
            savedRGB.Background = CreateSolidColorBrushFromSliders();
        }

        private void RGBSliders_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (redSlider == null || greenSlider == null || blueSlider == null)
                return;

            rgbRectangle.Fill = CreateSolidColorBrushFromSliders();
        }
    }
}