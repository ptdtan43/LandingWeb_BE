using BE.BOs.Models;

namespace BE.REPOs.Interface;

public interface IVoucherRepo
{
    Task<List<Voucher>> GetAllVouchersAsync();
    Task<Voucher?> GetVoucherByIdAsync(int id);
    Task<Voucher?> GetVoucherByCodeAsync(string code);
    Task<Voucher> CreateVoucherAsync(Voucher voucher);
    Task UpdateVoucherAsync(Voucher voucher);
    Task DeleteVoucherAsync(int id);
}
