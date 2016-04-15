using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace NeuralNetwork
{

    public class Node
    {
        Point p;
        Ellipse el;
        List<Node> inputNodes = new List<Node>();
        List<Node> outputNodes = new List<Node>();
     
        
        public Point P
        {
            get
            {
                return p;
            }

            set
            {
                p = value;
            }
        }
        public Rect R
            {
            get { return new Rect(P,new Size(30,30)); }
            }

        public Ellipse El
        {
            get
            {
                return el;
            }

            set
            {
                el = value;
            }
        }

        public List<Node> InputNodes
        {
            get
            {
                return inputNodes;
            }

            set
            {
                inputNodes = value;
            }
        }

      

        public List<Node> OutputNodes
        {
            get
            {
                return outputNodes;
            }

            set
            {
                outputNodes = value;
            }
        }
    }
}
