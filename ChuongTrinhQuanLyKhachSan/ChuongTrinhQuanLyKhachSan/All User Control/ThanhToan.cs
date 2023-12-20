using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace ChuongTrinhQuanLyKhachSan.All_User_Control
{
    public partial class ThanhToan : Form
    {
        function fn = new function();
        String query;
        public ThanhToan()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string ConvertTimeToHours(TimeSpan totalTime)
        {
            int totalHours = (int)totalTime.TotalHours;
            int totalMinutes = totalTime.Minutes;

            return $"{totalHours} giờ {totalMinutes} phút";
        }
        private decimal CalculateTotalAmount(TimeSpan totalTime, decimal roomPrice)
        {
            // Nếu số phút nhỏ hơn 15, loại bỏ số phút
            if (totalTime.Minutes < 15)
            {
                totalTime = new TimeSpan(totalTime.Hours, 0, 0);
            }
            // Ngược lại, làm tròn lên số giờ
            else
            {
                totalTime = new TimeSpan(totalTime.Hours + 1, 0, 0);
            }

            // Tính tổng tiền
            decimal totalAmount = (decimal)totalTime.TotalHours * roomPrice;
            return totalAmount;
        }
        public void SetDataFromUC_CheckOut(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {
                txtCName.Text = customerInfo.CustomerName;
                txtIDProof.Text = customerInfo.IDProof;
                txtContact.Text = customerInfo.Mobile.ToString();
                txtAddress.Text = customerInfo.Address;
                txtGender.Text = customerInfo.Gender;
                txtNationality.Text = customerInfo.Nationality; 
                txtRoom.Text = customerInfo.RoomNumber;
                txtRoomType.Text = customerInfo.RoomType;
                txtPrice.Text = customerInfo.Price.ToString();
                txtCheckin.Text = customerInfo.CheckInDate.ToString("yyyy-MM-dd HH:mm:ss");
                txtCheckOutDate.Text = customerInfo.CheckOutDate.ToString("yyyy-MM-dd HH:mm:ss");
                txtTimeToStay.Text = ConvertTimeToHours(customerInfo.TimeToStay);
                decimal totalAmount = CalculateTotalAmount(customerInfo.TimeToStay, customerInfo.Price);
                txtMoney.Text = totalAmount.ToString();
            }
        }
        int id;
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            fn.setData(query, "Thanh Toán Thành Công");
            clearAll();
            UC_CheckOut uC_CheckOut = new UC_CheckOut();
            this.Hide();
            uC_CheckOut.Show();
        }
        private void clearAll() 
        {
            txtCName.Clear();
            txtContact.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtIDProof.Clear();
            txtAddress.Clear();
            txtCheckin.ResetText();
            txtRoom.Clear();
            txtRoomType.Clear();
            txtPrice.Clear();
            txtCheckOutDate.ResetText();
            txtTimeToStay.Clear();
            txtMoney.Clear();
            txtCheckin.ResetText();
        }

        
    }
}
