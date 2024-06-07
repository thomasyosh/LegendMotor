using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface ISupplierRepository
    {
        public List<Supplier> GetAllSupplier();

        public Supplier CreateSupplier(Supplier supplier);

        public Supplier GetSupplierBySupplierCode(string supplierCode);

        public Supplier UpdateSupplier(Supplier supplier);
    }
}
