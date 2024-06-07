using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataContext _ctx = new DataContext();

        public Supplier CreateSupplier(Supplier supplier)
        {
            _ctx.Supplier.Add(supplier);
            _ctx.SaveChanges();
            return supplier;
        }

        public List<Supplier> GetAllSupplier()
        {
            return _ctx.Supplier.ToList();
        }

        public Supplier GetSupplierBySupplierCode(string supplierCode)
        {
            return _ctx.Supplier.FirstOrDefault(supplier => supplier.SupplierCode.Equals(supplierCode));
        }

        public Supplier UpdateSupplier(Supplier supplier)
        {
            _ctx.Supplier.Update(supplier);
            _ctx.SaveChanges();
            return supplier;
        }
    }
}
