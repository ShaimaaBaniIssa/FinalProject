
using FinalProject.Core.Utility;
using QuestPDF.Infrastructure;

namespace FinalProject.Core.Services
{
    public interface IPdfGenerator
    {
        public IDocument GetInvoice(Invoice invoice);
        
    }
}
