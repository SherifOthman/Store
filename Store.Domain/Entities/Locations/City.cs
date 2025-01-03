using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Addresses;

public class City
{
    public int Id { get; set; }
    public  string NameAr { get; set; } = string.Empty;
    public  string NameEn { get; set; } = string.Empty;
    public  int GovernorateId { get; set; }
    public Governorate? Governorate { get; set; }
}
