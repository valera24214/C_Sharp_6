using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int task = 0;
        bool shift = false;
        bool created = false;
        

        UIElement[] controls;
        System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void grid_Clear()
        {
            for (int i = grid.Children.Count - 1; i >= 0; i--)
            {
                if (grid.Children[i].GetType() != typeof(Menu))
                    grid.Children.Remove(grid.Children[i]);
            }
        }

        private void Task1_Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.None;
            this.Height = 768;
            this.Width = 1349;
            this.WindowState = WindowState.Maximized;
            this.ResizeMode = ResizeMode.NoResize;

            Task1 task1 = new Task1();

            grid_Clear();

            List<Shape> shapes = task1.Task();
            foreach (var shape in shapes)
                grid.Children.Add(shape);
        }

        private void Task2_Button_Click(object sender, RoutedEventArgs e)
        {

            this.WindowStyle = WindowStyle.None;
            this.Height = 768;
            this.Width = 1349;
            this.WindowState = WindowState.Maximized;
            this.ResizeMode = ResizeMode.NoResize;

            task = 2;      
            grid_Clear();
            Label label = new Label()
            {
                Content = "Астроух В. Д., ИСТ-41, Вариант 1",
                Margin = new Thickness(50, 50, 0, 0),
            };
            grid.Children.Add(label);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (task == 2 && created)
            {
                if (e.Key == Key.Q)
                {
                    created = false;

                    grid_Clear();
                }

                if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                    shift = true;

                if (shift == true)
                {
                    switch (e.Key)
                    {
                        case Key.W:
                            {
                                if (rectangle.Margin.Bottom < 600)
                                {
                                    rectangle.Margin = new Thickness(rectangle.Margin.Left, rectangle.Margin.Top, rectangle.Margin.Right, rectangle.Margin.Bottom + 50);
                                }


                                break;
                            }
                        case Key.A:
                            {
                                if (rectangle.Margin.Left > -1300)
                                {
                                    rectangle.Margin = new Thickness(rectangle.Margin.Left - 50, rectangle.Margin.Top, rectangle.Margin.Right, rectangle.Margin.Bottom);
                                }
                                break;
                            }
                        case Key.D:
                            {
                                if (rectangle.Margin.Left < 1300)
                                {
                                    rectangle.Margin = new Thickness(rectangle.Margin.Left + 50, rectangle.Margin.Top, rectangle.Margin.Right, rectangle.Margin.Bottom);
                                }

                                break;
                            }
                        case Key.S:
                            {
                                if (rectangle.Margin.Bottom > -700)
                                {
                                    rectangle.Margin = new Thickness(rectangle.Margin.Left, rectangle.Margin.Top, rectangle.Margin.Right, rectangle.Margin.Bottom - 50);
                                }

                                break;
                            }
                    }
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (task == 2)
                if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                    shift = false;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (task == 2 && created == false)
            {
                rectangle.Width = 50;
                rectangle.Height = 50;
                rectangle.Fill = System.Windows.Media.Brushes.Green;
                rectangle.Focusable = true;
                grid.Children.Add(rectangle);
                created = true;
            }
        }

        private void Task3_Button_Click(object sender, RoutedEventArgs e)
        {
            grid_Clear();
            this.ResizeMode = ResizeMode.CanResize;
            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.SingleBorderWindow;

            Button nutton = new Button()
            {
                Margin = new Thickness(500, 0, 0, 550),
                Width = 80,
                Height = 20,
                Content = "Вычислить",
            };

            nutton.Click += Nutton_Click;

            controls = new UIElement[]
            {
                    new Border()
                    {
                        BorderBrush = System.Windows.Media.Brushes.White,
                        BorderThickness = new Thickness(1, 1, 1, 1),
                        Margin = new Thickness(0,130,0,0),
                        Uid = "border",
                        
                    },

                    new Label()
                    {
                        Content = "a = ",
                        Margin = new Thickness(65, 85, 0, 0),
                        FontSize = 25,
                        Uid = "label1",
                    },

                     new TextBox()
                    {
                        Margin = new Thickness(0,0,1050, 510),
                        Width = 50,
                        Height = 20,
                        Uid = "a_textBox",
                        Text = "1",
                    },

                    new Label()
                    {
                        Content = "x_Min = ",
                        Margin = new Thickness(220, 85, 0, 0),
                        FontSize = 25,
                    },

                    new TextBox()
                    {
                        Margin = new Thickness(0, 0, 670, 510),
                        Width = 50,
                        Height = 20,
                        Uid = "x_min_textBox",
                        Text = "1",
                    },

                    new Label()
                    {
                        Content = "x_Max = ",
                        Margin = new Thickness(420, 85, 0, 0),
                        FontSize = 25,
                       
                    },

                    new TextBox()
                    {
                        Margin = new Thickness(0,0,270,510),
                        Width = 50,
                        Height = 20,
                        Uid = "x_max_textBox",
                        Text = "10"
                    },

                    nutton,
            };

            controls.ToList().ForEach(c => grid.Children.Add(c));
        }

        public double f(double x, double a)
        {
            double rez = Math.Exp(-a * x) + Math.Cos(a * Math.Pow(x, 8.0 / 7.0)) + ((1.0 / 101.0) * Math.Log10(Math.Abs(a * x))) + a * Math.Pow(x, 4) + a;

            return rez;
        }

        private void Nutton_Click(object sender, RoutedEventArgs e)
        {
            
            if (!TryParse(out var data))
            {
                return;
            }

            var points = new List<PointF>();
            for (var x = data.x_min; x <= data.x_max; x += 10e-3)
            {
                points.Add(new PointF((float)x, (float)f(x, data.a)));
            }

            var border = controls.First(o => o.Uid == "border") as Border;
            border.Height = grid.DesiredSize.Height;
            border.Width = grid.DesiredSize.Width;
            DrawAxes(border.Width, border.Height, data.x_max);
            points = points.Normalize(border.Width, border.Height);
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (IsConstraintsValid(points[i], points[i + 1]))
                {
                    continue;
                }

                var line = new Line();
                line.X1 = points[i].X;
                line.X2 = points[i + 1].X;
                line.Y1 = points[i].Y;
                line.Y2 = points[i + 1].Y;
                line.Stroke = System.Windows.Media.Brushes.Red;
                line.StrokeThickness = 2;

                grid.Children.Add(line);

            }

        }

        private bool IsConstraintsValid(PointF point1, PointF point2) => point1.Y < 130 || point2.Y < 130;

        private void DrawAxes(double Width, double Height, double x_max)
        {

            var points = new List<PointF>();
            Line line1 = new Line()
            {
                X1 = 0,
                X2 = Width,
                Y1 = Height / 2 + 130,
                Y2 = Height / 2 + 130,
                Stroke = System.Windows.Media.Brushes.Black,
                StrokeThickness = 2,
            };

            Line line2 = new Line()
            {
                X1 = Width / 2,
                X2 = Width / 2,
                Y1 = 130,
                Y2 = Height + 130,
                Stroke = System.Windows.Media.Brushes.Black,
                StrokeThickness = 2,

            };

            grid.Children.Add(line1);
            grid.Children.Add(line2);

            var step = Width / (x_max * 2);
            var lines = new List<Line>();
            for (double i = step; i < Width; i += step)
            {
                Line line = new Line()
                {
                    X1 = i,
                    X2 = i,
                    Y1 = Height / 2 + 130 + 10,
                    Y2 = Height / 2 + 130 - 10,
                    Stroke = System.Windows.Media.Brushes.Black,
                    StrokeThickness = 2,
                };
                
                grid.Children.Add(line);
            }

            step = Height / 10;

            for (double i = step + 130; i < Height + 130; i += step)
            {
                Line line_1 = new Line()
                {
                    X1 = Width / 2 - 10,
                    X2 = Width / 2 + 10,
                    Y1 = i,
                    Y2 = i,
                    Stroke = System.Windows.Media.Brushes.Black,
                    StrokeThickness = 2,
                };
                grid.Children.Add(line_1);
            }
        }

        private bool TryParse(out (double x_min, double x_max, double a) data)
        {
            data = default;
            string str = (controls.First(c => c.Uid == "a_textBox") as TextBox).Text.Trim();
            if (!double.TryParse(str, out double a))
            {
                return false;
            }

            str = (controls.First(c => c.Uid == "x_min_textBox") as TextBox).Text;
            if (!double.TryParse(str, out double x_min))
            {
                return false;
            }

            str = (controls.First(c => c.Uid == "x_max_textBox") as TextBox).Text;
            if (!double.TryParse(str, out double x_max))
            {
                return false;
            }

            data = (x_min, x_max, a);
            return true;
        }

        private void MainWindow_SizeChanged(object sender, RoutedEventArgs e)
        {
            if (controls is null)
            {
                return;
            }
            grid.Height = grid.RenderSize.Height;
            grid.Width = grid.RenderSize.Width;
            
            for (int i = grid.Children.Count - 1; i >= 0; i--)
            {
                if (grid.Children[i].GetType() == typeof(Line))
                    grid.Children.Remove(grid.Children[i]);
            }

            var border = controls.First(o => o.Uid == "border") as Border;
            border.Height = grid.DesiredSize.Height;
            border.Width = grid.DesiredSize.Width;

            Nutton_Click(sender, e);
            
           
        }
    }





}


