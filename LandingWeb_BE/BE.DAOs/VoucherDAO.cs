using BE.BOs.Models;
using Microsoft.EntityFrameworkCore;

namespace BE.DAOs;

public class VoucherDAO
{
    private readonly AppDbContext _context;

    public VoucherDAO(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Voucher>> GetAllAsync() => await _context.Vouchers.ToListAsync();

    public async Task<Voucher?> GetByIdAsync(int id) => await _context.Vouchers.FindAsync(id);

    public async Task<Voucher?> GetByCodeAsync(string code) => 
        await _context.Vouchers.FirstOrDefaultAsync(v => v.Code == code);

    public async Task<Voucher> CreateAsync(Voucher voucher)
    {
        _context.Vouchers.Add(voucher);
        await _context.SaveChangesAsync();
        return voucher;
    }

    public async Task UpdateAsync(Voucher voucher)
    {
        _context.Vouchers.Update(voucher);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var voucher = await GetByIdAsync(id);
        if (voucher != null)
        {
            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
        }
    }
}
