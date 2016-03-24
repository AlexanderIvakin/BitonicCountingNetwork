using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitonicCountingNetwork
{
    public class Balancer
    {
        private readonly object _lock = new object();

        private bool _toggle = true;

        public int traverse()
        {
            lock (_lock)
            {
                try
                {
                    if (_toggle)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                finally
                {
                    _toggle = !_toggle;
                }
            }
        }
    }
}
