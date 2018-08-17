using System;

namespace Airport.Db.Tools.Contracts
{
    public class CustomerContractsModel
    {
        public long Id { get; set; }
        public string FirestName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
