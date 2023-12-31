﻿
using TCCPOS.Backend.SecurityService.Entities;

namespace TCCPOS.Backend.SecurityService.Application.Contract
{
    public interface ISecurityRepository
    {
        public Task<user> getUserById(string id);
        public Task<user> getUserByUsername(string username);
        public Task<user> createUserAsync(string username, string password, string line_sub_id);
        public Task<user> getUserByLineId(string lineId);
        public Task<merchant> createMerchantAsync(string shopId, string price_tier_id, string shop_group_id, string username);
        public Task<merchantaddress> createNewShopAddress(string shopId, string shopTitle, string address1, string address2, string address3, string zipcode, string phone_number, string userId);
        public Task<user> updateUserShopId(string id, string shopId);
        public Task<employeelogin> getUserEmployeeByUsername(string username);
        public Task<employeetenant> getEmployeeTenantByTenantId(string TenantID);
        public Task<supplier> getSupplierById(string supplierID);
    }
}
