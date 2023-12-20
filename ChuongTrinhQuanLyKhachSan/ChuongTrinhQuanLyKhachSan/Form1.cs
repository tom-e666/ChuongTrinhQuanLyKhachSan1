using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ChuongTrinhQuanLyKhachSan
{
    public partial class Form1 : Form
    {

        private SoundPlayer successSoundPlayer;
        private int loginAttempts = 0;
        string query;
        function fn = new function();
        public Form1()
        {
            InitializeComponent();
            // successSoundPlayer = new SoundPlayer("C:\\Users\\TRUNG DUC\\Downloads\\Từ-Thích-Thích-Thành-Thương-Thương-AMee-Hoàng-Dũng.wav");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = $"SELECT * FROM employee WHERE username='{txtUsername.Text}' AND pass='{txtPassword.Text}' ";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count > 0) 
            {    
               //  successSoundPlayer.Play();
                loginAttempts = 0;

                labelError.Visible = false;
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();
            }
            else
            {
                // Tăng số lần nhập sai
                loginAttempts++;
                labelError.Visible = true;
                txtPassword.Clear();
                txtUsername.Clear();
                if (loginAttempts >= 3)
                {
                    // Nếu nhập sai quá 3 lần, đóng ứng dụng
                    MessageBox.Show("Bạn đã nhập sai mật khẩu quá 3 lần. Ứng dụng sẽ thoát.");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tên người dùng và mật khẩu.");
                }
            }
        }


    }
}
