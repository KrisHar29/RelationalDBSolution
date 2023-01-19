using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class FullContactModel
    {
        public BasicContactModel BasicInfo { get; set; }
        public List<EmailAdressModel> EmailAddresses { get; set; } = new List<EmailAdressModel>();
        public List<PhoneNumberModel> PhoneNumber { get; set; } = new List<PhoneNumberModel>();
    }
}
