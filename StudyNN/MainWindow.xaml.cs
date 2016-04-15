using NeuralNetwork;
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

namespace StudyNN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Network nw;
        Node currentNode;
        public MainWindow()
        {
            InitializeComponent();
            nw = new Network();
        }


        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(myPanel);
                currentNode = Node_at_position(p);
                if (currentNode == null)
                {
                    Node n = new_node(p);
                    add_UIEllipse(n);
                    sync_position(n);
                }
                else
                {
                    sync_position(currentNode);
                }
            }
        }

        private Node Node_at_position(Point p)
        {
            foreach (Node n in nw.Nodes)
            {
                if (n.R.Contains(p))
                    return n;
            }
            return null;
        }

        private Node new_node(Point p)
        {
            Node n = new Node();
            n.P = p;
            nw.Nodes.Add(n);
            return n;
        }

        private void add_UIEllipse(Node n)
        {
            Ellipse el = new Ellipse();
            el.Width = 30;
            el.Height = 30;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Colors.YellowGreen);
            SolidColorBrush BorderBrush = new SolidColorBrush(Colors.Black);
            el.Fill = mySolidColorBrush;
            el.Stroke = BorderBrush;
            el.StrokeThickness = 2;
            myPanel.Children.Add(el);
            n.El = el;
        }

        private void add_UILine(Edge e)
        {
            Line l = new Line();
            l.StrokeThickness = 2;
            l.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            e.L = l;
            myPanel.Children.Add(l);
          
        }

        private void sync_position(Node n)
        {
          //  foreach (Node n in nw.Nodes)
           // {
           if (n != null)
            { 
                Canvas.SetTop(n.El, n.P.Y);
                Canvas.SetLeft(n.El, n.P.X);
                foreach (Edge e in nw.Edges)
                {
                    e.L.X1 = e.FromNode.P.X+15;
                    e.L.Y1 = e.FromNode.P.Y+15;
                    e.L.X2 = e.ToNode.P.X+15;
                    e.L.Y2 = e.ToNode.P.Y+15;
                }

            }
            // }
        }





        private void myPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && currentNode != null)
            {
                currentNode.P = e.GetPosition(myPanel);
                sync_position(currentNode);
            }
        }
        
        private void myPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Released)
            //    currentNode = null;
        }

        private void myPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(myPanel);
                currentNode = Node_at_position(p);
            }
        }

        private void myPanel_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
           if (currentNode != null)
            {
                Point p = e.GetPosition(myPanel);
                Node toNode = Node_at_position(p);
                if (toNode != null)
                {
                    toNode.InputNodes.Add(currentNode);
                    currentNode.OutputNodes.Add(toNode);
                    Edge edg = new Edge(currentNode,toNode);
                    nw.Edges.Add(edg);
                    add_UILine(edg);
                    sync_position(toNode);
                }
            }

        }
    }
}
