using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Shapes;

namespace NeuralNetwork
{
    public class Edge
    {
        private Node fromNode;
        private Node toNode;
        private double weight;
        private Line l;

        public Edge (Node fromNode, Node toNode)
        {
            this.fromNode = fromNode;
            this.toNode = toNode;
        }

        public Node FromNode
        {
            get
            {
                return fromNode;
            }

            set
            {
                fromNode = value;
            }
        }

        public Node ToNode
        {
            get
            {
                return toNode;
            }

            set
            {
                toNode = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }


        public Line L
        {
            get
            {
                return l;
            }

            set
            {
                l = value;
            }
        }
    }
}
