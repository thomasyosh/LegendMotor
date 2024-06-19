using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public List<Invoice> GetAllInvoice()
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.Invoice.ToList();
            }
        }

        public Invoice GetInvoiceById(string invoiceId)
        {
            using (DataContext _ctx = new DataContext())
            {
                return _ctx.Invoice.FirstOrDefault(invoice=>invoice.InvoiceId.Equals(invoiceId));
            }
        }

        public Invoice AddInvoice(Invoice invoice)
        {
            using (DataContext _ctx = new DataContext())
            {
                _ctx.Invoice.Add(invoice);
                _ctx.SaveChanges();
                return invoice;
            }
        }
    }
}
