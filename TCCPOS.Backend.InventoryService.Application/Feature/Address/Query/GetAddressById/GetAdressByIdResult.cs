﻿namespace TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById
{
    public class GetAddressByIdResult
    {
        public string? addressId { get; set; }
        public string? shopTitle { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public string? address3 { get; set; }
        public string? zipcode { get; set; }
        public string? phoneNumber { get; set; }
    }
}
