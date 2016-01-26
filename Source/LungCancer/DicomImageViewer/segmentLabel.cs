using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomImageViewer
{
    class segmentLabel
    {
        public int x;
        public int y;
        public int label;
        public segmentLabel(int x , int y,int label)
        {
            this.x=x;
            this.y=y;
            this.label=label; 

        }
    }
}
