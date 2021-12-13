using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT_DoAnCuoiKi_Lalisa.Class_FS_Graph
{
    class NodeGraph
    {
        public int x;
        public int y;

        public bool SoSanhNodeVH(Egde b)
        {
            if((this.x == b.x && this.y == b.y   || this.x == b.z && this.y == b.t))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool SoSanhNode(NodeGraph b)
        {
            if (this.x == b.x && this.y == b.y)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    
}
