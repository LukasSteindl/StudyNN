using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NeuralNetwork
{
    public class Network
    {
        private List<Node> nodes;
        private List<Edge> edges;
        public List<Node> Nodes
        {
            get
            {
                return nodes;
            }

            set
            {
                nodes = value;
            }
        }

        public List<Edge> Edges
        {
            get
            {
                return edges;
            }

            set
            {
                edges = value;
            }
        }

        public Network()
        {
            this.nodes = new List<Node>();
            this.edges = new List<Edge>();
        }
    }
}
