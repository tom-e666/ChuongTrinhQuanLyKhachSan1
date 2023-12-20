using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuongTrinhQuanLyKhachSan.All_User_Control
{

    public class CustomerInfo
    {
        public string CustomerName { get; set; }
        public string IDProof { get; set; }
        public long Mobile { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public long Price { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public TimeSpan TimeToStay { get; set; }
    }

}
