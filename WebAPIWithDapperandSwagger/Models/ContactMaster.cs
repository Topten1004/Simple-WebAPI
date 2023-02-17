using System;

namespace WebAPIWithDapperandSwagger.Models
{
    public class ContactMaster
    {
        public Int32 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string PhoneNo { get; set; }
        public string ContactPhoto { get; set; }
    }
}
