using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;

namespace CarRentalsSystem
{
    
    public class VehicleLine
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PlateNo { get; set; }
        public decimal DailyRate { get; set; }
    }

    public class GeneratePDFContract
    {
        
        public class pdf_Contract
        {
            public void GenerateContract(
                string filePath,
                //long contractId,
                string customerName,
                string customerIdText,
                string address,
                string phone,
                string policyName,
                DateTime bookingDate,
                DateTime expectedReturnDate,
                int daysRented,
                decimal totalRentalAmount,
                decimal securityDeposit,
                string paymentMethod,
                decimal totalDue,
                string employeeName,
                string employeeId,
                IList<VehicleLine> vehicles
            )
            {
                QuestPDF.Settings.License = LicenseType.Community;

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(11));

                       
                        page.Header()
                            .Column(col =>
                            {
                                col.Item().Text("CAR RENTAL CONTRACT AGREEMENT")
                                    .SemiBold()
                                    .FontSize(20)
                                    .FontColor(Colors.Blue.Medium)
                                    .AlignCenter();

                                //col.Item().Text($"Contract ID: {contractId}")
                                //    .FontSize(11)
                                //    .AlignCenter();
                            });

                        
                        page.Content()
                            .PaddingVertical(10)
                            .Column(col =>
                            {
                                col.Spacing(10);

                                
                                col.Item().Text($"Date Created: {DateTime.Now:MMMM dd, yyyy}");

                                
                                col.Item()
                                   .Border(0.5f)
                                   .BorderColor(Colors.Grey.Lighten2)
                                   .Padding(8)
                                   .Column(block =>
                                   {
                                       block.Spacing(4);

                                       block.Item().Text("Customer Information")
                                           .SemiBold()
                                           .FontSize(13);

                                       block.Item().Text($"Name: {customerName}");
                                       block.Item().Text($"Customer ID: {customerIdText}");
                                       block.Item().Text($"Address: {address}");
                                       if (!string.IsNullOrWhiteSpace(phone))
                                           block.Item().Text($"Contact No: {phone}");

                                       block.Item().Text("");
                                       block.Item().Text("Contract Details")
                                           .SemiBold()
                                           .FontSize(13);

                                       block.Item().Text($"Policy: {policyName}");
                                       block.Item().Text($"Booking Date: {bookingDate:MMMM dd, yyyy}");
                                       block.Item().Text($"Expected Return Date: {expectedReturnDate:MMMM dd, yyyy}");
                                       block.Item().Text($"Total Rental Days: {daysRented} day(s)");
                                   });
 // --- Vehicles table
                                col.Item().Text("Vehicle(s)")
                                    .SemiBold()
                                    .FontSize(13);

                                col.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(3);  
                                        columns.RelativeColumn(2); 
                                        columns.RelativeColumn(2);  
                                    });

                                   
                                    table.Header(header =>
                                    {
                                        header.Cell().Element(Th).Text("Vehicle");
                                        header.Cell().Element(Th).Text("Plate No");
                                        header.Cell().Element(Th).Text("Daily Rate");
                                    });

                                    
                                    if (vehicles != null)
                                    {
                                        foreach (var v in vehicles)
                                        {
                                            table.Cell().Element(Td).Text($"{v.Brand} {v.Model}");
                                            table.Cell().Element(Td).Text(v.PlateNo);
                                            table.Cell().Element(Td).Text($"₱ {v.DailyRate:0.00}");
                                        }
                                    }
 // local helper for header cells
                                    IContainer Th(IContainer c) =>
                                        c.DefaultTextStyle(x => x.SemiBold())
                                         .PaddingVertical(4)
                                         .PaddingHorizontal(2)
                                         .Background(Colors.Grey.Lighten3)
                                         .Border(0.5f)
                                         .BorderColor(Colors.Grey.Lighten1);

                                    
                                    IContainer Td(IContainer c) =>
                                        c.PaddingVertical(2)
                                         .PaddingHorizontal(2)
                                         .Border(0.5f)
                                         .BorderColor(Colors.Grey.Lighten3);
                                });

                                
                                col.Item().Text("Payment Summary")
                                    .SemiBold()
                                    .FontSize(13);

                                col.Item()
                                   .Border(0.5f)
                                   .BorderColor(Colors.Grey.Lighten2)
                                   .Padding(8)
                                   .Column(block =>
                                   {
                                       block.Spacing(3);
                                       block.Item().Text($"Total Rental Amount: ₱ {totalRentalAmount:0.00}");
                                       block.Item().Text($"Security Deposit: ₱ {securityDeposit:0.00}");
                                       block.Item().Text($"Payment Method: {paymentMethod}");
                                       block.Item().Text($"Total Amount Due: ₱ {totalDue:0.00}")
                                            .SemiBold();
                                   });

                               
                                col.Item().Text(text =>
                                {
                                    text.Span(
                                        "By signing this Agreement, the Customer acknowledges receipt of the vehicle(s) in good condition and agrees to return them on or before the agreed return date. " +
                                        "The Customer is responsible for any damage, additional mileage charges, late return penalties, traffic violations, or other fees incurred during the rental period. " +
                                        "The security deposit may be used to cover such charges, and any remaining balance will be refunded to the Customer after the final inspection.\n\n"
                                    );
                                    text.Span(
                                        "The Customer agrees to comply with all applicable traffic laws and not to use the vehicle(s) for illegal or reckless activities. " +
                                        "This agreement becomes effective upon signing by both the Customer and the authorized Employee of the rental company.\n\n"
                                    );
                                });

                                
                                col.Item().Row(row =>
                                {
                                    row.RelativeItem().Column(c =>
                                    {
                                        c.Item().Text("______________________________");
                                        c.Item().Text("Customer Signature");
                                        c.Item().Text(customerName);
                                    });


                                  row.RelativeItem().Column(c =>
                                    {
                                        c.Item().Text("______________________________");
                                        c.Item().Text("Authorized Employee Signature");
                                        c.Item().Text(employeeName);
                                    });
                                });

                                
                                col.Item().Text("");
                            });

                       
                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Page ");
                                x.CurrentPageNumber();
                            });
                    });
                })
                .GeneratePdf(filePath);
            }
        }
    }
}
