using LegendMotor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Abstractions.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoiceById (string invoiceId);
        List<Invoice> GetAllInvoice ();
        Invoice AddInvoice (Invoice invoice);

    }
}
