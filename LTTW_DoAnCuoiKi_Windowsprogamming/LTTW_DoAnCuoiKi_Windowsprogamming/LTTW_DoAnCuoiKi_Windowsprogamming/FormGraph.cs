using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace LTTW_DoAnCuoiKi_WindowsProgamming
{
    public partial class FormGraph : Form
    {
        private IconButton currentBtn;
        private Panel rightBorderBtn;
        private Button btncreate = new Button();
        private bool Checkiconbtn = false;
        private int dx = 0, dy = 0, dx1 = 0, dy1 = 0;
        private int d1 = -1, d2 = -1;
        private int Dinh1 = -1, Dinh2 = -1;
        private Backend.Egde Egdes = new Backend.Egde();
        private List<Backend.Egde> ListarrEgde = new List<Backend.Egde> { };
        private bool CheckHuong = false;
        private Backend.NodeGraph Nod = new Backend.NodeGraph();
        private List<Backend.NodeGraph> ListarrNod = new List<Backend.NodeGraph> { };
        private int PtuxoaNod = -1;
        private int sodinh = 0;
        private int sodinhcheck = 0;
        public int[,] Matrix = new int[100, 100];
        private Backend.FS_Graph Dothi = new Backend.FS_Graph();
        private string FS = string.Empty;
        private string FS1 = string.Empty;
        private string Prim = string.Empty;
        private string Kruskal = string.Empty;
        private string Dijkstra = string.Empty;
        private string[] TPLT = new string[] { };
        private int i = 0;
        private int dem = 0;
        private List<Backend.Egde> Egl = new List<Backend.Egde> { };
        private List<Backend.NodeGraph> LNodLT = new List<Backend.NodeGraph> { };
        private Backend.Egde Eg = new Backend.Egde();
        private Backend.NodeGraph NodLT = new Backend.NodeGraph();
        private bool Xacnhan = false;
        private int socanh = 0;
        private int num = 0;

        public FormGraph()
        {
            InitializeComponent();
            rightBorderBtn = new Panel();
            rightBorderBtn.Size = new Size(7, 42);
            panelClickSukien.Controls.Add(rightBorderBtn);
            btnThemCanh.Enabled = false;
        }
        private Color[] a = 
        {
            Color.FromArgb(51, 255, 153),
            Color.FromArgb(255, 255, 51),
            Color.FromArgb(102, 255, 255),
            Color.FromArgb(178, 102, 255),
            Color.FromArgb(255, 102, 178),
            Color.FromArgb(255, 153, 153),
        };
        //Event
        //1. Thay Đổi Trạng Thái Button Thêm Đỉnh
        private void btnThemDinh_Click(object sender, EventArgs e)
        {
            if (Checkiconbtn == false)
            {
                ActivateButton(sender);
                Checkiconbtn = true;
            }
            else
            {
                DisableButton(sender);
                Checkiconbtn = false;
            }

        }
        //2. Thay Đổi Text Button Duyệt Theo Chức Năng
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS" || cbxChucNang.Text == "Dijkstra")
            {
                pnlFS.Visible = true;
                pnlCachDuyet.Visible = true;
                btnDuyet.Padding = new Padding(50, 0, 40, 0);
            }
            else 
            {
                btnDuyet.Padding = new Padding(40, 0, 40, 0);
                pnlCachDuyet.Visible = false;
                pnlFS.Visible = false;
            }
            if(cbxChucNang.Text == "Prim" || cbxChucNang.Text == "Kruskal" || cbxChucNang.Text == "Dijkstra" && (cbxChucNang.Text != "Duyệt BFS" || cbxChucNang.Text != "Duyệt DFS"))
            {
                pnlCachDuyet.Visible = true;
                btnDuyet.Padding = new Padding(50, 0, 40, 0);
            }
            btnDuyet.Text = cbxChucNang.Text;
            Xacnhan = false;
        }
        //3. Tạo Đỉnh Đồ Thị
        private void pnlVeDoThi_MouseClick(object sender, MouseEventArgs e)
        {
            if (Checkiconbtn == true)
            {
                Button btn = new Button();
                btn.Width = 30;
                btn.Height = 30;
                btn.Location = new Point(e.X, e.Y);
                btn.Name = string.Format("{0},{1}", e.X, e.Y);
                btn.Text = string.Format("{0}", sodinh++);
                btn.Click += new EventHandler(getToaDo);
                pnlVeDoThi.Controls.Add(btn);
                Nod.x = e.X;
                Nod.y = e.Y;
                ListarrNod.Add(Nod);
                Nod = new Backend.NodeGraph();
            }
        }
        //4. Button Xóa Đỉnh
        private void btnXoaDinh_Click(object sender, EventArgs e)
        {

            if (ListarrNod.Count == 0)
            {
                MessageBox.Show("Không còn đỉnh để Xxa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Nod = new Backend.NodeGraph();
                Egdes = new Backend.Egde();
                btncreate = null;
                dx = dy = dx1 = dy1 = 0;
                d1 = d2 = -1;
                Dinh1 = Dinh2 = -1;
                return;
            }
            if (btncreate != null)
            {
                int n = 0;
                int tmp = ListarrNod.Count();
                Nod.x = btncreate.Location.X;
                Nod.y = btncreate.Location.Y;
                Backend.NodeGraph NodEgde = new Backend.NodeGraph();
                NodEgde.x = btncreate.Location.X + 12;
                NodEgde.y = btncreate.Location.Y + 12;
                pnlVeDoThi.Controls.Clear();
                pnlVeDoThi.Invalidate();
                pnlVeDoThi.Refresh();
                for (int i = 0; i < ListarrEgde.Count; i++)
                {
                    if (!NodEgde.SoSanhNodeVH(ListarrEgde[i]))
                    {
                        VeDoThi1(ListarrEgde[i]);
                    }
                    else
                    {
                        ListarrEgde.RemoveAt(i);
                        i = i - 1;
                    }
                }
                /*for (int i = 0; i < ListarrEgde.Count; i++)
                {
                    s += ListarrEgde[i].x.ToString() + " " + ListarrEgde[i].y.ToString() + " " + ListarrEgde[i].z.ToString() + " " + ListarrEgde[i].t.ToString() + Environment.NewLine;
                }*/
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    if (!Nod.SoSanhNode(ListarrNod[i]))
                    {
                        Button btn = new Button();
                        btn.Width = 30;
                        btn.Height = 30;
                        btn.Location = new Point(ListarrNod[i].x, ListarrNod[i].y);
                        btn.Text = string.Format("{0}", n++);
                        btn.Click += new EventHandler(getToaDo);
                        pnlVeDoThi.Controls.Add(btn);
                    }
                    else
                    {
                        PtuxoaNod = i;
                    }
                }
                if (PtuxoaNod != -1 && ListarrNod.Count > 0)
                {
                    ListarrNod.RemoveAt(PtuxoaNod);
                    Nod = new Backend.NodeGraph();
                    Egdes = new Backend.Egde();
                    btncreate = null;
                    dx = dy = dx1 = dy1 = 0;
                    d1 = d2 = -1;
                    Dinh1 = Dinh2 = -1;
                }
                if (tmp > ListarrNod.Count() && cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {
                    TaolaiMaTranCH();
                }
                if (tmp > ListarrNod.Count() && cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
                {
                    TaolaiMaTranVH();
                }
                /*m += Environment.NewLine + Nod.x.ToString() + " " + Nod.y.ToString() + " " + Environment.NewLine;*/
                /*for (int i = 0; i < ListarrNod.Count; i++)
                {
                    p += Environment.NewLine + (ListarrNod[i].x + 12).ToString() + " " + (ListarrNod[i].y + 12).ToString() + " " + Environment.NewLine;
                }*/
                /*txtKetqua.Text = s + p;*/
                sodinh = ListarrNod.Count;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn đỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Nod = new Backend.NodeGraph();
            Egdes = new Backend.Egde();
            btncreate = null;
            dx = dy = dx1 = dy1 = 0;
            d1 = d2 = -1;
            Dinh1 = Dinh2 = -1;
        }
        //5. Button Vẽ Cạnh 
        private void btnThemCanh_Click(object sender, EventArgs e)
        {
            if(txtTrongSo.Text == "0" && cbxChucNang.Text != "Dijkstra")
            {
                MessageBox.Show("Trọng số bằng 0 không thể vẽ cạnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Egdes = new Backend.Egde();
                Nod = new Backend.NodeGraph();
                btncreate = null;
                dx = dy = dx1 = dy1 = 0;
                d1 = d2 = -1;
                Dinh1 = Dinh2 = -1;
                labTrongSo.Text = "Trọng Số";
                txtTrongSo.Text = String.Empty;
                txtKetqua.Text = "Kết Quả";
                return;
            }
            VeDoThi(Egdes);
            Egdes = new Backend.Egde();
            Nod = new Backend.NodeGraph();
            btncreate = null;
            dx = dy = dx1 = dy1 = 0;
            d1 = d2 = -1;
            Dinh1 = Dinh2 = -1;
            labTrongSo.Text = "Trọng Số";
            txtKetqua.Text = "Kết Quả";
            txtTrongSo.Text =String.Empty;
        }
        //6. Button Xóa Cạnh 
        private void btnXoaCanh_Click(object sender, EventArgs e)
        {
            if (ListarrEgde.Count == 0)
            {
                MessageBox.Show("Không còn cạnh nào để xóa","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Nod = new Backend.NodeGraph();
                Egdes = new Backend.Egde();
                btncreate = null;
                dx = dy = dx1 = dy1 = 0;
                d1 = d2 = -1;
                Dinh1 = Dinh2 = -1;
                return;
            }
            if (btncreate == null)
            {
                MessageBox.Show("Bạn chưa chọn cạnh","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pnlVeDoThi.Invalidate();
            pnlVeDoThi.Refresh();
            int n = ListarrEgde.Count;
            for (int i = 0; i < ListarrEgde.Count; i++)
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
                {
                    if (!ListarrEgde[i].SoSanhEgdeVH(Egdes))
                    {
                        VeDoThi1(ListarrEgde[i]);
                    }
                    else
                    {
                        ListarrEgde.RemoveAt(i);
                        i = i - 1;
                        Matrix[d1, d2] = 0;
                        Matrix[d2, d1] = 0;
                    }
                }
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {
                    if (!ListarrEgde[i].SoSanhEgdeCH(Egdes))
                    {
                        VeDoThi1(ListarrEgde[i]);
                    }
                    else
                    {
                        ListarrEgde.RemoveAt(i);
                        i = i - 1;
                        Matrix[d1, d2] = 0;
                    }
                    if (!CheckHuong && ListarrEgde.Count >= 0)
                    {
                        CheckHuong = ListarrEgde[i].CheckHuong(Egdes);
                    }
                }
            }
            if (ListarrEgde.Count > 0)
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng" && (CheckHuong || n == ListarrEgde.Count))
                {
                    MessageBox.Show("Không tồn tại đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng" && n == ListarrEgde.Count)
                {
                    MessageBox.Show("Không tồn tại đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            Egdes = new Backend.Egde();
            Nod = new Backend.NodeGraph();
            btncreate = null;
            dx = dy = dx1 = dy1 = 0;
            d1 = d2 = -1;
            Dinh1 = Dinh2 = -1;
            CheckHuong = false;
        }
        //7. Button Xác Nhận Các Dữ Liệu
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cbxLoaiDoThi.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn loại đồ thị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxChucNang.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn chức năng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxCachDuyet.Text == string.Empty && (cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS" || cbxChucNang.Text == "Dijkstra"))
            {
                MessageBox.Show("Vui lòng chọn cách duyệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS" || cbxChucNang.Text == "Dijkstra") && (txtDinhBatDau.Text == string.Empty || txtDinhKetThuc.Text == String.Empty))
            {
                MessageBox.Show("Bạn chưa nhập đỉnh bắt đầu hoặc đỉnh kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS"||cbxChucNang.Text == "Dijkstra")
            {
                if(Int32.TryParse(txtDinhBatDau.Text, out num) && Int32.TryParse(txtDinhKetThuc.Text, out num))
                {

                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại đỉnh bắt đầu hoặc đỉnh kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (cbxChucNang.Text == "Duyệt DFS" || cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Dijkstra")
            {
                if (Convert.ToInt32(txtDinhBatDau.Text) >= ListarrNod.Count || Convert.ToInt32(txtDinhKetThuc.Text) >= ListarrNod.Count || Convert.ToInt32(txtDinhBatDau.Text) < 0 || Convert.ToInt32(txtDinhKetThuc.Text) < 0)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại đỉnh bắt đầu hoặc đỉnh kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {
                TaolaiMaTranVH();
                string Mtran = string.Empty;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                txtMatran.Text = Mtran;
                Egl = new List<Backend.Egde> { };
                ResetDT();
            }
            if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
            {
                TaolaiMaTranCH();
                string Mtran = string.Empty;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                txtMatran.Text = Mtran;
                Egl = new List<Backend.Egde> { };
                ResetDT();
            }
            if (cbxChucNang.Text == "Xét Liên Thông" && cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
            {
                TaolaiMaTranVH();
                string Mtran = string.Empty;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                Egl = new List<Backend.Egde> { };
                ResetDT();
            }
            /*string Mtran2 = string.Empty;
            for (int i = 0; i < ListarrNod.Count; i++)
            {
                for (int j = 0; j < ListarrNod.Count; j++)
                {
                    Mtran2 += Matrix[i, j] + " ";
                }
                Mtran2 += Environment.NewLine;
            }
            MessageBox.Show(Mtran2);*/
            socanh = ListarrEgde.Count;
            sodinhcheck = ListarrNod.Count;
            FS = string.Empty;
            FS1 = string.Empty;
            Prim = string.Empty;
            Kruskal = string.Empty;
            Dijkstra = string.Empty; 
            dem = 0;
            btncreate = null;
            Dothi.readGRAPH(Matrix, sodinh);
            DuyetGraph();
            Egl = new List<Backend.Egde> { };
            if (FS != string.Empty)
            {
                getDD(FS);
                i = FS.Length - 1;
            }
            if (Prim != string.Empty)
            {
                getcaykhung(Prim);
                i = 0;
            }
            if (Kruskal != string.Empty)
            {
                getcaykhung(Kruskal);
                i = 0;
            }
            if(Dijkstra != string.Empty)
            {
                getDD2(Dijkstra);
                i = 0;
            }
            dx = dy = dx1 = dy1 = 0;
            Dinh1 = Dinh2 = -1;
            d1 = d2 = -1;
            Nod = new Backend.NodeGraph();
            Egdes = new Backend.Egde();
            Xacnhan = true;
        }
        //8. Button Duyệt
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            dx = dy = dx1 = dy1 = 0;
            d1 = d2 = -1;
            Dinh1 = Dinh2 = -1;
            Nod = new Backend.NodeGraph();
            Egdes = new Backend.Egde();
            btncreate = null;
            if (!Xacnhan || socanh != ListarrEgde.Count || sodinhcheck != ListarrNod.Count)
            {
                MessageBox.Show("Bạn chưa xác nhận dữ liệu đầu vào", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ListarrNod.Count == 0 && Xacnhan)
            {
                /*txtKetqua.Text = "Bạn Chưa Vẽ Đồ Thị";*/
                MessageBox.Show("Bạn chưa vẽ đồ thị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Prim
            if (cbxChucNang.Text == "Prim" && cbxCachDuyet.Text == "Duyệt Toàn Bộ" )
            {
                if (Prim == string.Empty)
                {
                    /*txtKetqua.Text = "Không có đường đi";*/
                    MessageBox.Show("Không có cây khung", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string trave = "";
                    for (int i = 0; i < Prim.Length; i=i+2)
                    {
                        trave += "(" + Prim[i] + "," + Prim[i + 1] + ")" + ",";
                    }
                    txtKetqua.Text = trave;
                    DanhDauDuongDiTB();
                    return;
                }

            }
            else
            {
                if (cbxChucNang.Text == "Prim" && cbxCachDuyet.Text == "Duyệt Từng Bước")
                {
                    if (Prim == string.Empty)
                    {
                        MessageBox.Show("Không có cây khung", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        /*txtKetqua.Text = "Không có đường đi";*/
                        return;
                    }
                    else
                    {
                        if (i < Prim.Length)
                        {
                            FS1 += "(" + Prim[i] + "," + Prim[i + 1] + ")" + ",";
                            i = i + 2;
                            txtKetqua.Text = FS1;
                        }
                        if (dem != Egl.Count)
                        {
                            DanhDauDuongDiTB2();
                            dem = dem + 1;
                        }
                    }
                }
            }
            //Kruskal
            if (cbxChucNang.Text == "Kruskal" && cbxCachDuyet.Text == "Duyệt Toàn Bộ")
            {
                if (Kruskal == string.Empty)
                {
                    /*txtKetqua.Text = "Không có đường đi";*/
                    MessageBox.Show("Không có cây khung", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string trave = "";
                    for (int i = 0; i < Kruskal.Length; i = i + 2)
                    {
                        trave += "(" + Kruskal[i] + "," + Kruskal[i + 1] + ")" + ",";
                    }
                    txtKetqua.Text = trave;
                    DanhDauDuongDiTB();
                    return;
                }

            }
            else
            {
                if (cbxChucNang.Text == "Kruskal" && cbxCachDuyet.Text == "Duyệt Từng Bước")
                {
                    if (Kruskal == string.Empty)
                    {
                        MessageBox.Show("Không có cây khung", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        /*txtKetqua.Text = "Không có đường đi";*/
                        return;
                    }
                    else
                    {
                        if (i < Kruskal.Length)
                        {
                            FS1 += "(" + Kruskal[i] + "," + Kruskal[i + 1] + ")" + ",";
                            i = i + 2;
                            txtKetqua.Text = FS1;
                        }
                        if (dem != Egl.Count)
                        {
                            DanhDauDuongDiTB2();
                            dem = dem + 1;
                        }
                    }
                }
            }

            //FS_LT

            if (cbxChucNang.Text == "Dijkstra" && cbxCachDuyet.Text == "Duyệt Toàn Bộ" && txtDinhKetThuc.Text != string.Empty && txtDinhBatDau.Text != string.Empty)
            {
                if (Dijkstra == string.Empty)
                {
                    /*txtKetqua.Text = "Không có đường đi";*/
                    MessageBox.Show("Đồ thị không liên thông nên không tìm được đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string trave = "";
                    for (int i = 0; i <Dijkstra.Length; i++)
                    {
                        if (i != Dijkstra.Length - 1)
                        {
                            trave += Dijkstra[i].ToString() + " --> ";
                        }
                        else
                        {
                            trave += Dijkstra[i].ToString();
                        }
                    }
                    txtKetqua.Text = trave;
                    DanhDauDuongDiTB();
                    return;
                }

            }
            else
            {
                if (cbxChucNang.Text == "Dijkstra" && cbxCachDuyet.Text == "Duyệt Từng Bước" && txtDinhKetThuc.Text != string.Empty && txtDinhBatDau.Text != string.Empty)
                {
                    if (Dijkstra == string.Empty)
                    {
                        MessageBox.Show("Đồ thị không liên thông nên không tìm được đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        /*txtKetqua.Text = "Không có đường đi";*/
                        return;
                    }
                    else
                    {
                        if (i == 0)
                        {

                            FS1 += Dijkstra[i].ToString();
                            i++;
                        }
                        else
                        {
                            if (i < Dijkstra.Length)
                            {
                                FS1 += " --> " + Dijkstra[i].ToString();
                                i++;
                            }

                        }
                        txtKetqua.Text = FS1;
                        if (dem != Egl.Count && i > 1)
                        {
                            DanhDauDuongDiTB2();
                            dem = dem + 1;
                        }
                    }
                }
            }if (cbxChucNang.Text == "Duyệt BFS" && cbxCachDuyet.Text == "Duyệt Toàn Bộ" && txtDinhKetThuc.Text != string.Empty && txtDinhBatDau.Text != string.Empty)
            {
                if (FS == string.Empty)
                {
                    /*txtKetqua.Text = "Không có đường đi";*/
                    MessageBox.Show("Không có đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string trave = "";
                    for (int i = FS.Length - 1; i >= 0; i--)
                    {
                        if (i != 0)
                        {
                            trave += FS[i].ToString() + " --> ";
                        }
                        else
                        {
                            trave += FS[i].ToString();
                        }
                    }
                    txtKetqua.Text = trave;
                    DanhDauDuongDiTB();
                    return;
                }

            }
            else
            {
                if (cbxChucNang.Text == "Duyệt BFS" && cbxCachDuyet.Text == "Duyệt Từng Bước" && txtDinhKetThuc.Text != string.Empty && txtDinhBatDau.Text != string.Empty)
                {
                    if (FS == string.Empty)
                    {
                        MessageBox.Show("Không có đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        /*txtKetqua.Text = "Không có đường đi";*/
                        return;
                    }
                    else
                    {
                        if (i == FS.Length - 1)
                        {

                            FS1 += FS[i].ToString();
                            i--;
                        }
                        else
                        {
                            if (i > -1)
                            {
                                FS1 += " --> " + FS[i].ToString();
                                i--;
                            }

                        }
                        txtKetqua.Text = FS1;
                        if (dem != Egl.Count && i != FS.Length - 2)
                        {
                            DanhDauDuongDiTB2();
                            dem = dem + 1;
                        }
                    }
                }
            }

            if( cbxChucNang.Text == "Duyệt DFS" && cbxCachDuyet.Text == "Duyệt Toàn Bộ" && txtDinhKetThuc.Text != string.Empty && txtDinhBatDau.Text != string.Empty)
            {
                if (FS == string.Empty)
                {
                    /* txtKetqua.Text = "Không có đường đi";*/
                    MessageBox.Show("Không có đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string trave = "";
                    for (int i = FS.Length - 1; i >= 0; i--)
                    {
                        if (i != 0)
                        {
                            trave += FS[i].ToString() + " --> ";
                        }
                        else
                        {
                            trave += FS[i].ToString();
                        }
                    }
                    txtKetqua.Text = trave;
                    DanhDauDuongDiTB();
                    return;
                }
            }
            else
            {
                if (cbxChucNang.Text == "Duyệt DFS" && cbxCachDuyet.Text == "Duyệt Từng Bước" && txtDinhKetThuc.Text != string.Empty && txtDinhBatDau.Text != string.Empty )
                {
                    if (FS == string.Empty)
                    {
                        MessageBox.Show("Không có đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (i == FS.Length - 1)
                        {

                            FS1 += FS[i].ToString();
                            i--;
                        }
                        else
                        {
                            if (i > -1)
                            {
                                FS1 += "-->" + FS[i].ToString();
                                i--;
                            }
                        }
                        txtKetqua.Text = FS1;
                        if (dem != Egl.Count && i != FS.Length - 2)
                        {
                            DanhDauDuongDiTB2();
                            dem = dem + 1;
                        }
                        return;
                    }
                }
            }
            if (cbxChucNang.Text == "Xét Liên Thông" && Xacnhan )
            {
                string showLT = string.Empty;
                if (TPLT[0] != "0")
                {
                    /*if (Convert.ToInt32(TPLT[0]) == 1)
                    {
                        showLT += "Đồ Thị Liên Thông" + Environment.NewLine;
                    }
                    else
                    {
                        showLT += "Đồ Thị Không Liên Thông" + Environment.NewLine;
                    }*/
                }
                else
                {
                    MessageBox.Show("Bạn chưa vẽ đồ thị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(TPLT[0] == "1")
                {
                    for (int i = 1; i < TPLT.Length; i++)
                    {
                            showLT += "Thành Phần Liên Thông Duy Nhất: " + TPLT[i] + Environment.NewLine;
                    }
                    txtKetqua.Text = showLT;
                    return;
                }
                else
                {
                    for (int i = 0; i < TPLT.Length; i++)
                    {
                        if (i == 0)
                        {
                            showLT += "Số Thành Phần Liên Thông: " + TPLT[0] + Environment.NewLine;
                        }
                        else
                        {
                            showLT += "Thành Phần Liên Thông Thứ " + i.ToString() + ": " + TPLT[i] + Environment.NewLine;
                            string arrListStr = TPLT[i].Replace(" ","");
                            getDDLT(arrListStr);
                            Pen pen;
                            if(i > 5)
                            {
                                Random r = new Random();
                                pen = new Pen(Color.FromArgb((byte)r.Next(1, 255),(byte)r.Next(1, 255), (byte)r.Next(1, 233)), 2);
                            }
                            else
                            {
                                pen = new Pen(a[i - 1], 2);
                            }
                            ResetLT(pen);
                            pen = null;
                            LNodLT = new List<Backend.NodeGraph> { };
                    }
                }
                    if (Convert.ToInt32(TPLT[0]) == 1)
                    {
                        showLT += "Đồ Thị Liên Thông" + Environment.NewLine;
                    }
                    else
                    {
                        showLT += "Đồ Thị Không Liên Thông" + Environment.NewLine;
                    }

                    txtKetqua.Text = showLT;
                    return;
                }
            }

            
        }
        //9. Button Tạo Mới Và Xóa
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            pnlVeDoThi.Controls.Clear();
            pnlVeDoThi.Invalidate();
            pnlVeDoThi.Refresh();
            txtDinhBatDau.Text = string.Empty;
            txtDinhKetThuc.Text = string.Empty;
            txtTrongSo.Text = String.Empty;
            txtKetqua.Text = "Kết Quả";
            btncreate = new Button();
            Checkiconbtn = false;
            dx = 0; dy = 0; dx1 = 0; dy1 = 0;
            d1 = -1; d2 = -1;
            Dinh1 = -1; Dinh2 = -1;
            Backend.Egde Egdes = new Backend.Egde();
            ListarrEgde = new List<Backend.Egde> { };
            CheckHuong = false;
            Backend.NodeGraph Nod = new Backend.NodeGraph();
            ListarrNod = new List<Backend.NodeGraph> { };
            PtuxoaNod = -1;
            sodinh = 0;
            Matrix = new int[100, 100];
            Backend.FS_Graph Dothi = new Backend.FS_Graph();
            FS = string.Empty;
            FS1 = string.Empty;
            TPLT = new string[] { };
            i = 0;
            btnThemDinh.TextAlign = ContentAlignment.MiddleCenter;
            btnThemDinh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemDinh.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemDinh.IconChar = IconChar.PlusCircle;
            btnThemDinh.Text = "Thêm Đỉnh";
            rightBorderBtn.Visible = false;
            Xacnhan = false;
            txtMatran.Text = "Ma Trận";
        }

        //Event Reset Đồ Thị và textBox Kết Quả Theo Các Input
        private void cbxCachDuyet_TextChanged(object sender, EventArgs e)
        {
            txtKetqua.Text = "Kết Quả";
            ResetDT();
            Xacnhan = false;
        }
        private void txtDinhBatDau_TextChanged(object sender, EventArgs e)
        {
            txtKetqua.Text = "Kết Quả";
            Xacnhan = false;
        }
        private void txtDinhKetThuc_TextChanged(object sender, EventArgs e)
        {
            txtKetqua.Text = "Kết Quả";
            Xacnhan = false;
        }
        private void cbxChucNang_TextChanged(object sender, EventArgs e)
        {
            txtKetqua.Text = "Kết Quả";
            Xacnhan = false;
            ResetDT();
        }
        //Method Vẽ Đồ Thị

        //1. Lấy Tọa Độ Các Đỉnh
        public void getToaDo(object sender, EventArgs e)
        {
            btncreate = (Button)sender;
            if (dx != 0 && dx1 != 0)
            {
                dx = dy = dx1 = dy1 = 0;
                dx = btncreate.Location.X + 12;
                dy = btncreate.Location.Y + 12;
                Egdes.x = dx;
                Egdes.y = dy;
                Egdes.z = dx1;
                Egdes.t = dy1;
            }

            if (dx == 0 && dy == 0)
            {
                dx = btncreate.Location.X + 12;
                dy = btncreate.Location.Y + 12;
                Egdes.x = dx;
                Egdes.y = dy;
            }
            else
            {
                if (dx1 == 0 && dy1 == 0)
                {
                    dx1 = btncreate.Location.X + 12;
                    dy1 = btncreate.Location.Y + 12;
                    Egdes.z = dx1;
                    Egdes.t = dy1;
                }
            }
            if (dx1 == dx)
            {
                dx1 = dy1 = 0;
                Egdes.z = dx1;
                Egdes.t = dy1;
            }
            //
            if (d1 != -1 && d2 != -1)
            {
                d1 = d2 = -1;
                d1 = Convert.ToInt32(btncreate.Text);
                Dinh1 = d1;
                Dinh2 = d2;
            }
            if (d1 == -1 && d2 == -1)
            {
                d1 = Convert.ToInt32(btncreate.Text);
                Dinh1 = d1;

            }
            else
            {
                if (d2 == -1)
                {
                    d2 = Convert.ToInt32(btncreate.Text);
                    Dinh2 = d2;
                }
            }
            if (d1 == d2)
            {
                d2 = -1;
                Dinh2 = d2;
            }
            txtKetqua.Text = dx.ToString() + " " + dy.ToString() + " " + Dinh1.ToString() + " " + dx1.ToString() + " " + dy1.ToString() + " " + Dinh2.ToString();
            if(Dinh1 != -1 && Dinh2 == -1)
            {
                labTrongSo.Text = "Trọng số từ đỉnh " + Dinh1.ToString();
            }
            else if (Dinh2 != -1 && Dinh2 != -1)
            {
                labTrongSo.Text = "Trọng số từ đinh " + Dinh1.ToString() + " đến đỉnh " + Dinh2.ToString();
            }
                
        }
        //2. Vẽ Cạnh 
        private void VeDoThi(Backend.Egde NodeG)
        {
            if(ListarrEgde.Count > 0 && check(Dinh1, Dinh2))
            {
                if (Matrix[Dinh1, Dinh2] != 0 && cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng" && NodeG.CheckEgde())
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    if (txtTrongSo.Text != String.Empty)
                    {
                        NodeG.trongso = Convert.ToInt32(txtTrongSo.Text);
                    }
                    int x = (NodeG.x + NodeG.z) / 2;
                    int y = (NodeG.y + NodeG.t) / 2;

                    SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                    dc.FillEllipse(sb, x - 15, y - 15, 30, 30);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        Panel pnlDraw = new Panel();

                        dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                    }
                    ListarrEgde.Add(NodeG);
                    Matrix[Dinh1, Dinh2] = NodeG.trongso;
                    Matrix[Dinh2, Dinh1] = NodeG.trongso;
                }
                else if (Matrix[Dinh1, Dinh2] != 0 && cbxLoaiDoThi.Text == "Đồ Thị Có Hướng" && NodeG.CheckEgde())
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    if (txtTrongSo.Text != String.Empty)
                    {
                        NodeG.trongso = Convert.ToInt32(txtTrongSo.Text);
                    }
                    int x = (NodeG.x + NodeG.z) / 2;
                    int y = (NodeG.y + NodeG.t) / 2;

                    SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                    dc.FillEllipse(sb, x - 15, y - 15, 30, 30);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        Panel pnlDraw = new Panel();

                        dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                    }
                    ListarrEgde.Add(NodeG);
                    Matrix[Dinh1, Dinh2] = NodeG.trongso;
                }
            }
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng" && NodeG.CheckEgde() && check(Dinh1, Dinh2))
            {
                Graphics dc = pnlVeDoThi.CreateGraphics();
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen BlackPen = new Pen(Color.Black, 2);
                dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                dx = dy = dx1 = dy1 = 0;
                if(txtTrongSo.Text != String.Empty)
                {
                    NodeG.trongso = Convert.ToInt32(txtTrongSo.Text);
                }
                int x = (NodeG.x + NodeG.z) / 2;
                int y = (NodeG.y + NodeG.t) / 2;

                SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                dc.FillEllipse(sb, x - 15, y - 15, 30, 30);

                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    Panel pnlDraw = new Panel();

                   dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                }
                ListarrEgde.Add(NodeG);
                Matrix[Dinh1, Dinh2] = NodeG.trongso;
                Matrix[Dinh2, Dinh1] = NodeG.trongso;
                
            }
            else
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng" && NodeG.CheckEgde() && check(Dinh1, Dinh2))
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Pen BlackPen = new Pen(Color.Black, 2);
                    dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    DrawArrowhead(dc, BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    dx = dy = dx1 = dy1 = 0;
                    if (txtTrongSo.Text != String.Empty)
                    {
                        NodeG.trongso = Convert.ToInt32(txtTrongSo.Text);
                    }
                    int x = (NodeG.x + NodeG.z) / 2;
                    int y = (NodeG.y + NodeG.t) / 2;

                    SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                    dc.FillEllipse(sb, x - 15, y - 15, 30, 30);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        Panel pnlDraw = new Panel();

                        dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                    }
                    ListarrEgde.Add(NodeG);
                    Matrix[Dinh1, Dinh2] = NodeG.trongso;
                }
            }
        }
        //3. Vẽ Đồ Thị Lúc Xóa Cạnh
        private void VeDoThi1(Backend.Egde NodeG)
        {
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {

                Graphics dc = pnlVeDoThi.CreateGraphics();
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen BlackPen = new Pen(Color.Black, 2);
                dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                int x = (NodeG.x + NodeG.z) / 2;
                int y = (NodeG.y + NodeG.t) / 2;
                SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                dc.FillEllipse(sb, x - 15, y - 15, 30, 30);
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    Panel pnlDraw = new Panel();
                    dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                }

            }
            else
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Pen BlackPen = new Pen(Color.Black, 2);
                    dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    DrawArrowhead(dc, BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    int x = (NodeG.x + NodeG.z) / 2;
                    int y = (NodeG.y + NodeG.t) / 2;
                    SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                    dc.FillEllipse(sb, x - 15, y - 15, 30, 30);
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        Panel pnlDraw = new Panel();
                        dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                    }

                }

            }
        }
        //4. Vẽ Đường Đi Kết Quả
        private void VeDoThi2(Backend.Egde NodeG)
        {
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {
                Graphics dc = pnlVeDoThi.CreateGraphics();
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen BlackPen = new Pen(Color.Red, 2);
                dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                int x = (NodeG.x + NodeG.z) / 2;
                int y = (NodeG.y + NodeG.t) / 2;
                SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                dc.FillEllipse(sb, x - 15, y - 15, 30, 30);
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    Panel pnlDraw = new Panel();
                    dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                }

            }
            else
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Pen BlackPen = new Pen(Color.Red, 2);
                    dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    DrawArrowhead(dc, BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    int x = (NodeG.x + NodeG.z) / 2;
                    int y = (NodeG.y + NodeG.t) / 2;
                    SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                    dc.FillEllipse(sb, x - 15, y - 15, 30, 30);
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        Panel pnlDraw = new Panel();
                        dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                    }

                }
            }
        }
        //5. Trạng Thái Buttton Thêm Đỉnh
        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                //button
                currentBtn = (IconButton)senderBtn;
                currentBtn.IconChar = IconChar.StopCircle;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.Overlay;
                currentBtn.ImageAlign = ContentAlignment.TopLeft;
                currentBtn.Text = "Dừng";
                //left border button
                rightBorderBtn.BackColor = Color.FromArgb(172, 126, 241);
                rightBorderBtn.Location = new Point(currentBtn.Location.X, currentBtn.Location.Y);
                rightBorderBtn.Visible = true;
                rightBorderBtn.BringToFront();

            }
        }
        //6. Trạng Thái Button Dừng Thêm Đỉnh
        private void DisableButton(object sender)
        {
            if (currentBtn != null)
            {
                currentBtn = (IconButton)sender;
                currentBtn.IconChar = IconChar.PlusCircle;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.Text = "Thêm Đỉnh";
                rightBorderBtn.Visible = false;
            }
        }
        //7. Vẽ Hướng Đồ Thị
        private void DrawArrowhead(Graphics gr, Pen pen, int x, int y, int z, int t)
        {
            float dx = z - x;
            float dy = t - y;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);
            dx /= dist;
            dy /= dist;
            const float scale = 5;
            dx *= scale;
            dy *= scale;
            float p1x = -dy;
            float p1y = dx;
            float p2x = dy;
            float p2y = -dx;
            float cx = (x + z) / 2f;
            float cy = (y + t) / 2f;
            float cxy = (cx + z) / 2f;
            float cyx = (cy + t) / 2f;
            PointF[] points =
            {
        new PointF (cxy - dx + p1x, cyx - dy + p1y),
        new PointF (cxy, cyx),
        new PointF (cxy - dx + p2x, cyx - dy + p2y),
    };
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.DrawLines(pen, points);
        }
        //8. Ktra Cạnh Đã Vẽ
        private bool check(int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                return Matrix[x, y] != 1;
            }
            else
            {
                return false;
            }
        }
        //9. Tạo Ma Trận Có Hướng
        private void TaolaiMaTranCH()
        {
            Matrix = new int[100, 100];
            for (int i = 0; i < ListarrEgde.Count; i++)
            {
                Backend.Egde Eg = ListarrEgde[i];
                for (int j = 0; j < ListarrNod.Count; j++)
                {
                    for (int l = 0; l < ListarrNod.Count; l++)
                    {
                        Backend.NodeGraph Nod1 = new Backend.NodeGraph();
                        Nod1.x = ListarrNod[j].x + 12;
                        Nod1.y = ListarrNod[j].y + 12;
                        Backend.NodeGraph Nod2 = new Backend.NodeGraph();
                        Nod2.x = ListarrNod[l].x + 12;
                        Nod2.y = ListarrNod[l].y + 12;
                        if (Eg.CheckMatrixCH(Nod1, Nod2))
                        {
                            Matrix[j, l] = Eg.trongso;
                        }
                    }
                }
            }
        }
        //10. Tạo Ma Trận Vô Hướng
        private void TaolaiMaTranVH()
        {
            Matrix = new int[100, 100];
            for (int i = 0; i < ListarrEgde.Count; i++)
            {
                Backend.Egde Eg = ListarrEgde[i];
                for (int j = 0; j < ListarrNod.Count; j++)
                {
                    for (int l = j + 1; l < ListarrNod.Count; l++)
                    {
                        Backend.NodeGraph Nod1 = new Backend.NodeGraph();
                        Nod1.x = ListarrNod[j].x + 12;
                        Nod1.y = ListarrNod[j].y + 12;
                        Backend.NodeGraph Nod2 = new Backend.NodeGraph();
                        Nod2.x = ListarrNod[l].x + 12;
                        Nod2.y = ListarrNod[l].y + 12;
                        if (Eg.CheckMatrixVH(Nod1, Nod2))
                        {
                            Matrix[j, l] = Eg.trongso;
                            Matrix[l, j] = Eg.trongso;
                        }
                    }
                }
            }
        }
        //11. Xét Sụ Thay Đổi Đồ Thị Mà Vẽ Lại Ma Trận Và Đồ Thị
        private void cbxLoaiDoThi_TextChanged(object sender, EventArgs e)
        {
            if (cbxLoaiDoThi.Text == string.Empty)
            {
                btnThemCanh.Enabled = false;
            }
            else
            {
                btnThemCanh.Enabled = true;
            }
            txtKetqua.Text = "Kết Quả";
            ResetDT();
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {
                TaolaiMaTranVH();
                string Mtran = string.Empty;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                txtMatran.Text = Mtran;
                Egl = new List<Backend.Egde> { };
            }
            if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
            {
                TaolaiMaTranCH();
                string Mtran = string.Empty;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                txtMatran.Text = Mtran;
                Egl = new List<Backend.Egde> { };
            }
            Xacnhan = false;
        }
        //12. Vẽ Lại Đồ Thị
        private void ResetDT()
        {
            pnlVeDoThi.Invalidate();
            pnlVeDoThi.Refresh();
            for (int i = 0; i < ListarrEgde.Count; i++)
            {
                VeDoThi1(ListarrEgde[i]);
            }
        }
        //13. Vẽ Liên Thông
        private void VeDoThiLT(Backend.Egde NodeG, Pen pen)
        {
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {

                Graphics dc = pnlVeDoThi.CreateGraphics();
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                dc.DrawLine(pen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                int x = (NodeG.x + NodeG.z) / 2;
                int y = (NodeG.y + NodeG.t) / 2;
                SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                dc.FillEllipse(sb, x - 15, y - 15, 30, 30);
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    Panel pnlDraw = new Panel();
                    dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                }
            }
            else
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    dc.DrawLine(pen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    DrawArrowhead(dc, pen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    int x = (NodeG.x + NodeG.z) / 2;
                    int y = (NodeG.y + NodeG.t) / 2;
                    SolidBrush sb = new SolidBrush(Color.FromArgb(241, 175, 0));
                    dc.FillEllipse(sb, x - 15, y - 15, 30, 30);
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        Panel pnlDraw = new Panel();
                        dc.DrawString($"{NodeG.trongso}", pnlDraw.Font, new SolidBrush(Color.Black), x, y, sf);
                    }

                }
            }
        
         }
        //14. Vẽ Thành Phần Liên Thông
        private void ResetLT(Pen a)
        {
            for (int i = 0; i < ListarrEgde.Count; i++)
            {
                for(int j=0;j< LNodLT.Count; j++)
                {
                    if (LNodLT[j].SoSanhNodeVH(ListarrEgde[i]))
                    {
                        VeDoThiLT(ListarrEgde[i],a);
                    }
                }
            }
        }

        //method Duyệt Và Trả Kết Quả

        //1.Duyệt Theo Chức Năng
        private void DuyetGraph()
        {
            if (cbxChucNang.Text == "Duyệt BFS" && Int32.TryParse(txtDinhBatDau.Text, out PtuxoaNod) && Int32.TryParse(txtDinhKetThuc.Text, out PtuxoaNod))
            {
                FS = Dothi.duyetBFS(Convert.ToInt32(txtDinhBatDau.Text), Convert.ToInt32(txtDinhKetThuc.Text));
            }
            else
            {
                if (cbxChucNang.Text == "Duyệt DFS" && Int32.TryParse(txtDinhBatDau.Text, out PtuxoaNod) && Int32.TryParse(txtDinhKetThuc.Text, out PtuxoaNod))
                {
                    FS = Dothi.duyetDFS(Convert.ToInt32(txtDinhBatDau.Text), Convert.ToInt32(txtDinhKetThuc.Text));
                }
                else
                {
                    if (cbxChucNang.Text == "Xét Liên Thông")
                    {
                        TPLT = Dothi.thanhPhanLienThong();
                    }
                    else
                    {
                        if(cbxChucNang.Text == "Kruskal")
                        {
                            Kruskal = Dothi.Kruskal();
                        }
                        else
                        {
                            if (cbxChucNang.Text == "Prim")
                            {
                                Prim = Dothi.PrimMin();
                            }
                            else
                            {   
                                if(cbxChucNang.Text == "Dijkstra" && Int32.TryParse(txtDinhBatDau.Text, out PtuxoaNod) && Int32.TryParse(txtDinhKetThuc.Text, out PtuxoaNod))
                                {
                                    Dijkstra = Dothi.Xuat(Convert.ToInt32(txtDinhBatDau.Text), Convert.ToInt32(txtDinhKetThuc.Text));
                                }
                                else
                                {
                                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu đầu vào", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                
                            }
                        }
                    }
                    
                }
            }
            
            /*if (cbxChucNang.Text == "Duyệt DFS" && Int32.TryParse(txtDinhBatDau.Text, out PtuxoaNod) && Int32.TryParse(txtDinhKetThuc.Text, out PtuxoaNod))
            {
                FS = Dothi.duyetDFS(Convert.ToInt32(txtDinhBatDau.Text), Convert.ToInt32(txtDinhKetThuc.Text));
            }
            if (cbxChucNang.Text == "Xét Liên Thông")
            {
                TPLT = Dothi.thanhPhanLienThong();
            }*/


        }

        private void FormGraph_Load(object sender, EventArgs e)
        {

        }

        //cmt

        //2. Lấy Đường Đi BFS hoặc DFS
        private void getDD2(string a)
        {
            for (int i = 0; i <a.Length-1; i++)
            {
                Eg.x = ListarrNod[(int)a[i] - '0'].x + 12;
                Eg.y = ListarrNod[(int)a[i] - '0'].y + 12;
                Eg.z = ListarrNod[(int)a[i + 1] - '0'].x + 12;
                Eg.t = ListarrNod[(int)a[i + 1] - '0'].y + 12;
                Eg.trongso = Matrix[(int)a[i] - '0', (int)a[i + 1] - '0'];
                Egl.Add(Eg);
                Eg = new Backend.Egde();
            }
        }


        private void getDD(string a)
        {
            for (int i = a.Length - 1; i > 0; i--)
            {
                Eg.x = ListarrNod[(int)a[i] - '0'].x + 12;
                Eg.y = ListarrNod[(int)a[i] - '0'].y + 12;
                Eg.z = ListarrNod[(int)a[i - 1] - '0'].x + 12;
                Eg.t = ListarrNod[(int)a[i - 1] - '0'].y + 12;
                Eg.trongso = Matrix[(int)a[i] - '0', (int)a[i - 1] - '0'];
                Egl.Add(Eg);
                Eg = new Backend.Egde();
            }
        }
        private void getcaykhung(string a)
        {
            for (int i = 0; i < a.Length; i=i+2)
            {
                Eg.x = ListarrNod[(int)a[i] - '0'].x + 12;
                Eg.y = ListarrNod[(int)a[i] - '0'].y + 12;
                Eg.z = ListarrNod[(int)a[i + 1] - '0'].x + 12;
                Eg.t = ListarrNod[(int)a[i + 1] - '0'].y + 12;
                Eg.trongso = Matrix[(int)a[i]-'0',(int)a[i + 1]-'0'];
                Egl.Add(Eg);
                Eg = new Backend.Egde();
            }
        }
        //3.Lấy Các Đỉnh Liên Thông
        private void getDDLT(string a)
        {
            for (int i = 0; i < a.Length ; i++)
            {
                NodLT.x = ListarrNod[(int)(a[i] - '0')].x + 12;
                NodLT.y = ListarrNod[(int)a[i] - '0'].y + 12;
                LNodLT.Add(NodLT);
                NodLT = new Backend.NodeGraph();
            }
        }
        //4. Vẽ Đường Đi BFS hoặc DFS Toàn Bộ
        private void DanhDauDuongDiTB()
        {
            pnlVeDoThi.Invalidate();
            pnlVeDoThi.Refresh();
            for (int i = 0; i < ListarrEgde.Count; i++)
            {
                VeDoThi1(ListarrEgde[i]);
            }
            for (int j = 0; j < Egl.Count; j++)
            {
                VeDoThi2(Egl[j]);
            }
        }
        //5. Vẽ Đường Đi BFS hoặc DFS Từng Bước
        private void DanhDauDuongDiTB2()
        {
            pnlVeDoThi.Invalidate();
            pnlVeDoThi.Refresh();
            for (int i = 0; i < ListarrEgde.Count; i++)
            {
                VeDoThi1(ListarrEgde[i]);
            }
            for (int j = 0; j <= dem; j++)
            {
                VeDoThi2(Egl[j]);
            }
        }
    }
}
