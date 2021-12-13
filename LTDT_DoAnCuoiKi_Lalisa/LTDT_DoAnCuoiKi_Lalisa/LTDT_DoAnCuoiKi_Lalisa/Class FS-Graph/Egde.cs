using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT_DoAnCuoiKi_Lalisa.Class_FS_Graph
{
    class Egde
    {
        public int x;
        public int y;
        public int z;
        public int t;
        public int trongso = 1;
        /*public int trongso;*/
        public bool SoSanhEgdeVH(Egde b)
        {
            if ((this.x == b.x && this.y == b.y && this.z == b.z && this.t == b.t) || this.z == b.x && this.t == b.y && this.x == b.z && this.y == b.t)
            {
                this.z = b.x; this.t = b.y; this.x = b.z; this.y = b.t;
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SoSanhEgdeCH(Egde b)
        {
            if (this.x == b.x && this.y == b.y && this.z == b.z && this.t == b.t)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckHuong(Egde b)
        {
            if (this.z == b.x && this.t == b.y && this.x == b.z && this.y == b.t)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMatrixCH(NodeGraph a, NodeGraph b)
        {
            if (this.x == a.x && this.y == a.y && this.z == b.x && this.t == b.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMatrixVH(NodeGraph a, NodeGraph b)
        {
            if (this.x == a.x && this.y == a.y && this.z == b.x && this.t == b.y || this.x == b.x && this.y == b.y && this.z == a.x && this.t == a.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEgde()
        {
            return this.x != 0 && this.y != 0 && this.z != 0 && this.t != 0;
        }
    }
}
