using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.ViewModels
{
    public class SchoolInfoVM
    {
        public int SchoolInfoId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolFirstColor { get; set; }
        public string SchoolSecondColor { get; set; }
        public string MastCot { get; set; }
        public string SchoolAddress { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string Zip { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public int ShippingState { get; set; }
        public string ShippingZip { get; set; }
        public string Telephone { get; set; }
        public string AlternateTelephone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ContactNumber { get; set; }
        public string ContactTitle { get; set; }
        public string ItemsRequiredFor { get; set; }
        public string ReceiveItemsForYear { get; set; }
        public string ItemsUsedFor { get; set; }
        public bool AnnounceSponcerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StateName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int IsActive { get; set; }
    }
}
