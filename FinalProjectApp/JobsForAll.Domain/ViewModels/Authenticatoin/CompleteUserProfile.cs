using JobsForAll.Domain.Models;

namespace JobsForAll.Domain.ViewModels.Authenticatoin
{
    public class CompleteUserProfile
    {
        public string UserName{get; set;}
        public string PhoneNumber{get; set;}
        public string Address{get; set;}
        public string PostCode{get; set;}
        public string MainProfession{get; set;}
        public string SecundaryProfession{get; set;}

        public string Hobby{get; set;}
        public string FunFact{get; set;}
        public Role Role { get; set; }
    }
}
