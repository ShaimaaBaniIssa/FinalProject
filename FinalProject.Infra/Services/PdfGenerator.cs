using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Core.Services;
using FinalProject.Core.Utility;
namespace FinalProject.Infra.Services

{
    public class PdfGenerator : IPdfGenerator
    {
           
  

        public IDocument GetInvoice(Invoice invoice)
            {

            
            QuestPDF.Settings.License = LicenseType.Community;
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(16));

                        page.Header()
                            .AlignCenter()
                            .Text("Train Ticket")
                            .FontSize(24)
                            .Bold();

                        page.Content()
                            .Column(column =>
                            {
                                column.Spacing(20);

                                column.Item().Row(row =>
                                {
                                    row.RelativeItem().Column(col =>
                                    {
                                        col.Item().Text($"Customer: {invoice.Fname}");
                                        col.Item().Text($"From: {invoice.Stationname}");
                                        col.Item().Text($"To: {invoice.Destadress}");
                                    });

                                    row.RelativeItem().Column(col =>
                                    {
                                        col.Item().Text($"Seat Number: {invoice.Seatnumber}");
                                        col.Item().Text($"Price: {invoice.Totalprice:C}");
                                    });
                                });

                                column.Item().Row(row =>
                                {
                                    row.RelativeItem().Text($"Reservation Date: {invoice.Reservationdate?.ToString("yyyy-MM-dd")}");
                                    row.RelativeItem().Text($"Trip Date: {invoice.RDate?.ToString("yyyy-MM-dd")}");
                                });
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text("Thank you for your reservation!");
                    });
                });
            }



        } 
    
}
