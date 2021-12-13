using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT_DoAnCuoiKi_Lalisa.Class_FS_Graph
{
    class FS_Graph
    {
        private int sodinh;
        private int nTPLT;
        public int DTerror;
        private int[,] a = new int[100, 100];
        private int[] LuuVet = new int[100];
        private int[] visited = new int[100];
        private int nT;
        
        struct Graph
        {
            public  int u;
            public  int v;
            public  int value;
        }
        private Graph CanhNhoNhat = new Graph();
        private Graph[] g = new Graph[100];

        public void readMatrix(string[] array, int sodinh)
        {
            int x = 0;
            this.sodinh = sodinh;
            int num = 0;
            for (int i = 0; i < this.sodinh; i++)
            {
                for (int j = 0; j < this.sodinh; j++)
                {
                    if (Int32.TryParse(array[x], out num))
                    {
                        this.a[i, j] = Convert.ToInt32(array[x++]);
                    }
                    else
                    {
                        this.DTerror = 1;
                        return;
                    }
                }
            }
        }
        public void readMatrixCH(string[] array, int sodinh)
        {
            int x = 0;
            this.sodinh = sodinh;
            int num = 0;
            for (int i = 0; i < this.sodinh; i++)
            {
                for (int j = 0; j < this.sodinh; j++)
                {
                    if (Int32.TryParse(array[x], out num))
                    {
                        num = Convert.ToInt32(array[x++]);
                        if (num > 0 ) { 
                            
                            this.a[i, j] = num;
                            this.a[j, i] = num;
                        }
                    }
                    else
                    {
                        this.DTerror = 1;
                        return;
                    }
                }
            }
        }
        public void readGRAPH(int[,] array, int sodinh)
        {
            
            this.sodinh = sodinh;
            for (int i = 0; i < this.sodinh; i++)
            {
                for (int j = 0; j < this.sodinh; j++)
                {
                    this.a[i, j] = array[i, j];
                }
            }
            
        }
        public void DFS(int s)
        {
            this.visited[s] = 1;
            for (int i = 0; i < this.sodinh; i++)
                if (this.visited[i] == 0 && this.a[s, i] != 0)
                {
                    this.LuuVet[i] = s; //Lưu trước đỉnh i là đỉnh s
                    this.DFS(i);//gọi đệ quy tiến hành xét tiếp
                }
        }


        public string duyetDFS(int s, int f)
        {
            string kq = "";
            //Khởi tạo giá trị ban đầu, tất cả các địh chư đuợc duyệt và chưa lưu vết
            for (int i = 0; i < this.sodinh; i++)
            {
                this.visited[i] = 0;
                this.LuuVet[i] = -1;
            }

            //Gọi hàm DFS
            this.DFS(s);

            if (this.visited[f] == 1)
            {
                //In ket qua
                int j = f;
                while (j != s)
                {
                    kq += Convert.ToString(j);
                    j = this.LuuVet[j];
                }
                kq += Convert.ToString(s);
            }
            else
            {
                kq = string.Empty;
            }
            return kq;
        }
        public void BFS(int s)
        {
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(s);
            while (Q.Count > 0)
            {
                s = Q.Dequeue();
                this.visited[s] = 1;
                for (int i = 0; i < this.sodinh; i++)
                    if (this.visited[i] == 0 && this.a[s, i] != 0)
                    {
                        Q.Enqueue(i); this.LuuVet[i] = s;
                    }
            }
        }
        public string duyetBFS(int s, int f)
        {
            string kq = "";
            //Khởi tạo giá trị ban đầu, tất cả các địh chư đuợc duyệt và chưa lưu vết
            for (int i = 0; i < this.sodinh; i++)
            {
                this.visited[i] = 0;
                this.LuuVet[i] = -1;
            }

            //Gọi hàm BFS
            BFS(s);

            if (this.visited[f] == 1)
            {
                //In ket qua
                int j = f;
                while (j != s)
                {
                    kq += Convert.ToString(j);
                    j = this.LuuVet[j];
                }
                kq += Convert.ToString(s);
            }
            else
                kq = string.Empty;
            return kq;
        }
        public void visitedLT(int s, int nLabel)
        {
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(s);
            this.visited[s] = nLabel;
            while (Q.Count > 0)
            {
                s = Q.Dequeue();
                for (int i = 0; i < this.sodinh; i++)
                    if (this.visited[i] == 0 && this.a[s, i] != 0)
                    {
                        Q.Enqueue(i); this.visited[i] = nLabel;
                    }
            }
        }
        public void xetLT()
        {
            for (int i = 0; i < this.sodinh; i++)
                this.visited[i] = 0;
            // đặt số miền liên thông ban đầu la 0
            this.nTPLT = 0;

            // dùng một vòng for i để tìm đỉnh chưa xét, gọi hàm duyệt cho đỉnh này
            for (int i = 0; i < this.sodinh; i++)
                if (this.visited[i] == 0)
                {
                    this.nTPLT++;
                    // nSoMienLienThong là nhãn sẽ gán cho các đỉnh trong lần duyệt này
                    this.visitedLT(i, this.nTPLT);
                }
        }
        public string[] thanhPhanLienThong()
        {
            xetLT();
            string[] TPLT = new string[this.nTPLT + 1];
            TPLT[0] = this.nTPLT.ToString();
            for (int i = 1; i <= TPLT.Length; i++)
            {
                // xét tất cả các đỉnh, nếu có nhãn trùng với nMienLienThong, in ra
                for (int j = 0; j < this.sodinh; j++)
                {
                    if (visited[j] == i)
                    {
                        TPLT[i] += j.ToString() + " ";
                    }
                }
            }
            return TPLT;
        }
        public string PrimMin()
        {
            string kq = string.Empty;
            this.xetLT();
            if( this.nTPLT > 1 )
            {
                return kq;
            }
             
            for (int i = 0; i < sodinh; i++)
            {
                this.visited[i] = 0;
            }
            this.visited[0] = 1;
            while(nT < sodinh - 1)
            {
                
                int GTNN = 100;
                for(int i = 0; i < sodinh; i++)
                {
                    if (visited[i] == 1)
                    {
                        for(int j = 0; j < sodinh; j++)
                        {
                            if (visited[j] == 0 && a[i, j] != 0 && GTNN > a[i, j])
                            {
                                CanhNhoNhat.u = i;
                                CanhNhoNhat.v = j;
                                CanhNhoNhat.value = a[i,j];
                                GTNN = this.a[i,j];
                            }
                        }
                    }
                   
                }
                g[nT] = CanhNhoNhat;
                nT++;
                visited[CanhNhoNhat.v] = 1;
            }
            /*int trongsotong = 0;*/
            for(int i = 0; i < nT; i++)
            {
                kq+= g[i].u.ToString()+g[i].v.ToString();
                /*trongsotong += g[i].value;*/
            }
            return kq;
        }
    }
}
