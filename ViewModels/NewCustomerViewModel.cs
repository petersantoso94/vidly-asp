using System.Collections.Generic;
using vidly.Models;

namespace vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }


    }
}