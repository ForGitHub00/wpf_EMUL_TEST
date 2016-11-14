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

namespace wpf_EMUL_TEST {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }


        #region CnvEMUL_Draw
        
        Point currentPoint = new Point();
        
        private void CnvEmul_MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition((Canvas)sender).X;
                line.Y2 = e.GetPosition((Canvas)sender).Y;

                currentPoint = e.GetPosition((Canvas)sender);


                DateTime d = DateTime.Now;
                if (d.Millisecond % 1 == 0){
                    CnvEmul.Children.Add(line);
                }
                
            }
        }
        private void CnvEmul_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition((Canvas)sender);
        }

        private void CnvEmul_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            CnvEmul.Children.Clear();
        }

        /*
        Line newLine;
        Point start;
        Point end;

        private void CnvEmul_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed){
                start = e.GetPosition((Canvas) sender);
            }
        }
        private void CnvEmul_MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                end = e.GetPosition((Canvas)sender);
            }
        }
       

        private void CnvEmul_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            newLine = new Line();
            newLine.Stroke = SystemColors.WindowFrameBrush;
            newLine.X1 = start.X;
            newLine.Y1 = start.Y;
            newLine.X2 = end.X;
            newLine.Y2 = end.Y;

            CnvEmul.Children.Add(newLine);
        }
        */
        #endregion
        private void bt_cnv_draw_Click(object sender, RoutedEventArgs e){
            Cnv.Children.Clear();
            foreach (Line item in CnvEmul.Children){
                Rectangle rec = new Rectangle(){
                    Height = 2,
                    Width = 2,
                    Fill = Brushes.Red
                };

                Canvas.SetTop(rec, item.Y1);
                Canvas.SetLeft(rec, item.X1);
                /*
                Canvas.SetTop(rec, Canvas.GetTop(item));
                Canvas.SetLeft(rec, Canvas.GetLeft(item));*/
                //MessageBox.Show($"{Canvas.GetTop(item)}");
                Cnv.Children.Add(rec);
            }
        }
        
    }
}
