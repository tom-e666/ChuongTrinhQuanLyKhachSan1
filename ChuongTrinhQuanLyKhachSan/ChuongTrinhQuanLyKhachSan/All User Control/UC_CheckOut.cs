using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChuongTrinhQuanLyKhachSan.All_User_Control.CustomerInfo;

namespace ChuongTrinhQuanLyKhachSan.All_User_Control
{
    public partial class UC_CheckOut : UserControl
    {
        

        function fn = new function();
        String query;
        public UC_CheckOut()
        {
            InitializeComponent();
        }

        private void UC_CheckOut_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

            txtCheckOutDate.Format = DateTimePickerFormat.Custom;
            txtCheckOutDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            txtCheckOutDate.Value = DateTime.Now;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtName.Text + "%' and chekout = 'NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private CustomerInfo selectedCustomer;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                selectedCustomer = new CustomerInfo
                {
                    CustomerName = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    IDProof = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(),
                    Mobile = Convert.ToInt64(guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value),
                    Address = guna2DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(),
                    Nationality = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Gender = guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    RoomNumber = guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(),
                    RoomType = guna2DataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString(),
                    Price = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[12].Value),
                    CheckInDate = Convert.ToDateTime(guna2DataGridView1.Rows[e.RowIndex].Cells[8].Value),
                    CheckOutDate = DateTime.Now
                    
                };
                selectedCustomer.TimeToStay =  selectedCustomer.CheckOutDate - selectedCustomer.CheckInDate;
            }
        }

        
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cdate = txtCheckOutDate.Text;
                    query = "update customer set chekout = 'YES', checkout =  '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where cid = " + id + " update rooms set booked = 'NO' where roomNo = '" + txtRoom.Text + "'";
                    fn.setData(query, "Thanh Toán Thành Công");
                    UC_CheckOut_Load(this, null);
                    clearAll();
                    ThanhToan thanhToan = new ThanhToan();
                    thanhToan.SetDataFromUC_CheckOut(selectedCustomer);
                    this.Hide();
                    thanhToan.Show();
                }
            } 
            else
            {
                MessageBox.Show("Không Có Khách Hàng Để Lựa Chọn", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        public void clearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoom.Clear();
            txtCheckOutDate.ResetText();
        }
    }
}
