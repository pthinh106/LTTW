using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTDT_DoAnCuoiKi_Lalisa
{
    public partial class FormMatrix : Form
    {
        private LTDT_DoAnCuoiKi_Lalisa.Class_FS_Graph.FS_Graph Dothi = new Class_FS_Graph.FS_Graph();
        private int num = 0;
        private string FS = string.Empty;
        private string FS1 = string.Empty;
        private string[] TPLT = new string[] { };
        private string[] arrListStr = new string[] { };
        private int i = 0;
        private int sodinh = -1;
        private int Dinhdau = -1;
        private int Dinhcuoi = -1;
        private bool xacnhan = false;
        public FormMatrix()
        {
            InitializeComponent();
        }
        private bool kiemTraInput()
        {
            if (Int32.TryParse(txbSoDinh.Text, out num) && Int32.TryParse(txbDinhBatDau.Text, out num) && Int32.TryParse(txbDinhKetThuc.Text, out num) && (cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS"))
            {
                sodinh = Convert.ToInt32(txbSoDinh.Text);
                string myString = txtMatran.Text;
                if(myString == string.Empty)
                {
                    MessageBox.Show("Lỗi nhập liệu vui lòng xem lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                Dinhdau = Convert.ToInt32(txbDinhBatDau.Text);
                Dinhcuoi = Convert.ToInt32(txbDinhKetThuc.Text);
                if(MatranGraph(myString, sodinh))
                {
                    Dothi.readMatrix(arrListStr, sodinh);
                    if (Dothi.DTerror == 1)
                    {
                        Dothi.DTerror = 0;
                        MessageBox.Show("Lỗi nhập liệu vui lòng xem lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    return true;
                }
                
            }
            if (Int32.TryParse(txbSoDinh.Text, out num) && cbxChucNang.Text == "Xét Liên Thông")
            {
                sodinh = Convert.ToInt32(txbSoDinh.Text);
                string myString = txtMatran.Text;
                if (myString == string.Empty)
                {
                    MessageBox.Show("Lỗi nhập liệu vui lòng xem lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (MatranGraph(myString, sodinh))
                {
                    if(cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
                    {
                        Dothi.readMatrix(arrListStr, sodinh);
                    }
                    if(cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                    {
                        Dothi.readMatrixCH(arrListStr, sodinh);
                    }
                    if (Dothi.DTerror == 1)
                    {
                        Dothi.DTerror = 0;
                        MessageBox.Show("Ma trận không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (sodinh * sodinh != arrListStr.Length)
                    {
                        MessageBox.Show("Số đỉnh không khớp với số đỉnh từ ma trận!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        private bool MatranGraph(string myString, int sodinh)
        { 
            if(myString == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập ma trận!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            myString = myString.Replace("\r", " ");
            myString = myString.Replace("\n", " ");
            myString = myString.TrimEnd();
            myString = myString.TrimStart();
            arrListStr = myString.Split(' ');
            arrListStr = arrListStr.Where(val => val != " ").ToArray();
            arrListStr = arrListStr.Where(val => val != string.Empty).ToArray();
            return true;
        }

        private void DuyetGraph()
        {   
            if (cbxChucNang.Text == "Duyệt BFS")
            {
                FS = Dothi.duyetBFS(Convert.ToInt32(txbDinhBatDau.Text), Convert.ToInt32(txbDinhKetThuc.Text));
            }
            if (cbxChucNang.Text == "Duyệt DFS")
            {
                FS = Dothi.duyetDFS(Convert.ToInt32(txbDinhBatDau.Text), Convert.ToInt32(txbDinhKetThuc.Text));
            }
            if (cbxChucNang.Text == "Xét Liên Thông")
            {
                TPLT = Dothi.thanhPhanLienThong();
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            
            if (txtMatran.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập ma trận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(txbSoDinh.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập số đỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            if (cbxCachDuyet.Text == string.Empty && (cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS"))
            {
                MessageBox.Show("Vui lòng chọn cách duyệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS") && (txbDinhBatDau.Text == string.Empty || txbDinhKetThuc.Text == String.Empty))
            {
                MessageBox.Show("Bạn chưa nhập đỉnh bắt đầu hoặc đỉnh kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!Int32.TryParse(txbSoDinh.Text, out num))
            {
                MessageBox.Show("Vui lòng kiểm tra lại số đỉnh mà bạn nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS") && (!Int32.TryParse(txbDinhBatDau.Text, out num) || !Int32.TryParse(txbDinhKetThuc.Text, out num)))
            {
                MessageBox.Show("Vui lòng kiểm tra lại đỉnh bắt đầu hoặc đỉnh kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxChucNang.Text == "Duyệt DFS" || cbxChucNang.Text == "Duyệt BFS")
            {
                if(Convert.ToInt32(txbDinhBatDau.Text) >= Convert.ToInt32(txbSoDinh.Text) || Convert.ToInt32(txbDinhKetThuc.Text) >= Convert.ToInt32(txbSoDinh.Text) || Convert.ToInt32(txbDinhBatDau.Text) < 0 || Convert.ToInt32(txbDinhKetThuc.Text) < 0)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại đỉnh bắt đầu hoặc đỉnh kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }
            FS = string.Empty;
            FS1 = string.Empty;
            if (kiemTraInput())
                DuyetGraph();
            i = FS.Length - 1;
            xacnhan = true;

        }
        private void cbxChucNang_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (!xacnhan)
            {
                MessageBox.Show("Bạn chưa xác nhận dữ liệu đầu vào", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxChucNang.Text == "Duyệt BFS" && cbxCachDuyet.Text == "Duyệt Toàn Bộ")
            {
                if (FS == string.Empty)
                {
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
                            trave += FS[i].ToString() + "-->";
                        }
                        else
                        {
                            trave += FS[i].ToString();
                        }
                    }
                    txtKetqua.Text = trave;
                }
                
            }
            else
            {
                if(cbxChucNang.Text == "Duyệt BFS" && cbxCachDuyet.Text == "Duyệt Từng Bước")
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
                    }
                }
            }
            if (cbxChucNang.Text == "Duyệt DFS" && cbxCachDuyet.Text == "Duyệt Toàn Bộ")
            {
                if (FS == string.Empty)
                {
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
                            trave += FS[i].ToString() + "-->";
                        }
                        else
                        {
                            trave += FS[i].ToString();
                        }
                    }
                    txtKetqua.Text = trave;
                }
            }
            else
            {
                if (cbxChucNang.Text == "Duyệt DFS" && cbxCachDuyet.Text == "Duyệt Từng Bước")
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
                    }
                }
            }
            if (cbxChucNang.Text == "Xét Liên Thông")
            {
                string showLT = string.Empty;
                for (int i = 0; i < TPLT.Length; i++)
                {
                    if (i == 0)
                    {
                        showLT += "Số Thành Phần Liên Thông: " + TPLT[0] + Environment.NewLine;
                    }
                    else
                    {
                        showLT += "Thành Phần Liên Thông Thứ " + i.ToString() + ": " + TPLT[i] + Environment.NewLine;
                    }
                }
                txtKetqua.Text = showLT;
            }
        }

        private void txtMatran_TextChanged(object sender, EventArgs e)
        {
            xacnhan = false;
        }

        private void txbSoDinh_TextChanged(object sender, EventArgs e)
        {
            xacnhan = false;
        }

        private void cbxLoaiDoThi_TextChanged(object sender, EventArgs e)
        {
            xacnhan = false;
        }

        private void txbDinhBatDau_TextChanged(object sender, EventArgs e)
        {
            xacnhan = false;
        }

        private void txbDinhKetThuc_TextChanged(object sender, EventArgs e)
        {
            xacnhan = false;
        }

        private void cbxCachDuyet_TextChanged(object sender, EventArgs e)
        {
            xacnhan = false;
        }

        private void cbxChucNang_TextChanged(object sender, EventArgs e)
        {
            if (cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS")
            {
                pnlFS.Visible = true;
                btnDuyet.Padding = new Padding(50, 0, 40, 0);
            }
            else
            {
                btnDuyet.Padding = new Padding(40, 0, 40, 0);
                pnlFS.Visible = false;
            }
            btnDuyet.Text = cbxChucNang.Text;
            xacnhan = false;
        }

    }
}
/*0 1 0 1 
0 0 0 0 
1 0 0 0 
0 0 0 0 
;*/