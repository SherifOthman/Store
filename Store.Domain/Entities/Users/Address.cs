using Store.Domain.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users;

public class Address
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int CityId { get; set; }
    public City? City { get; set; }
    public required string PostalCode { get; set; }
    public required string AddressDetails { get; set; }
}
