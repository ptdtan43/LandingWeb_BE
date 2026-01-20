using BE.BOs.Models;
using BE.DAOs;
using BE.REPOs.Interface;

namespace BE.REPOs.Implementation;

public class VoucherRepo : IVoucherRepo
{
    private readonly VoucherDAO _dao;

    public VoucherRepo(VoucherDAO dao)
    {
        _dao = dao;
    }

    public async Task<List<Voucher>> GetAllVouchersAsync() => await _dao.GetAllAsync();
    public async Task<Voucher?> GetVoucherByIdAsync(int id) => await _dao.GetByIdAsync(id);
    public async Task<Voucher?> GetVoucherByCodeAsync(string code) => await _dao.GetByCodeAsync(code);
    public async Task<Voucher> CreateVoucherAsync(Voucher voucher) => await _dao.CreateAsync(voucher);
    public async Task UpdateVoucherAsync(Voucher voucher) => await _dao.UpdateAsync(voucher);
    public async Task DeleteVoucherAsync(int id) => await _dao.DeleteAsync(id);
}
