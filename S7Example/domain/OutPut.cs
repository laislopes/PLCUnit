using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7Example.domain
{
    public class OutPut
    {
        public OutPut(int numberIdentifier, string tag)
        {
            NumberIdentifier = numberIdentifier;
            Tag = tag;
        }

        public int NumberIdentifier { get; private set; }
        public string Tag { get; private set; }
    }
}
