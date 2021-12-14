using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace LTDT_DoAnCuoiKi_Lalisa
{
    public partial class Form1 : Form
    {
        //
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        //constructor

        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 69);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private struct RGBcolors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 115);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //iconTittle
                iconcurrentChildform.IconChar = currentBtn.IconChar;
                iconcurrentChildform.IconColor = currentBtn.IconColor;
                lblTittleChildForm.Text = currentBtn.Text;


            }
        }
        private void openChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
                currentChildForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pnlDesktop.Controls.Add(childForm);
                pnlDesktop.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                leftBorderBtn.Visible = false;
                iconcurrentChildform.IconChar = IconChar.Home;
                lblTittleChildForm.Text = "Home";
                iconcurrentChildform.IconColor = Color.MediumPurple;
            }
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new FormGraph());
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlTittle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void logoHCMUE_Click(object sender, EventArgs e)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            DisableButton();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                btnZoom.IconChar = IconChar.WindowRestore;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                btnZoom.IconChar = IconChar.WindowMaximize;
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            openChildForm(new ThongTinSanPham());
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
        }

    }
}
