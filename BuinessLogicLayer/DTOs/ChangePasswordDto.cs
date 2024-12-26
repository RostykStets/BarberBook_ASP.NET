using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class ChangePasswordDto
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public _UserType UserType { get; set; }
        public string ErrorMsg { get; set; }
        public ChangePasswordDto()
        {
            ErrorMsg = "";
        }
    }
}
