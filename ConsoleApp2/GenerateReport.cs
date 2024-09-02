using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using Color = QuestPDF.Infrastructure.Color; // For File handling

namespace GeneratePdf
{
    public class GenerateReport
    {
        public void GenerateFakeDataReport()
        {
            // Create lists to simulate your data categories
            List<List<string>> points = new();
            List<List<string>> lines = new();
            List<List<string>> polys = new();

            // Adding fake data for points
            points.Add(new List<string>() { "point a", "207898.13", "594880.19", "15.15",   "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153615_130.jpg"});
            points.Add(new List<string>() { "point 345", "207898.13", "594880.19", "15.15", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_29182353_3.jpg" });
            points.Add(new List<string>() { "point 3א5", "207898.1ד", "5943480.19", "15.15", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_29182353_3.jpg" });

            // Adding fake data for lines
            lines.Add(new List<string>() { "line1", "200.00m", "150.25m", "45°", "70%", "15m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153621_132.jpg" });
            lines.Add(new List<string>() { "moshe", "200.06m", "150.28m", "45°", "50%", "15.25m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153621_132.jpg" });

            // Adding fake data for polygons
            polys.Add(new List<string>() { "300m²", "80m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg" });


            // Generate the report PDF
            ReportToPdf(points, lines, polys, "דומגמה של שם אתר", "en");
        }

        public void ReportToPdf(List<List<string>> points, List<List<string>> lines, List<List<string>> polys, string siteName, string language)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .Column(column =>
                        {
                            
                            string logoPath = Path.Combine("C:\\Users\\User\\source\\repos\\ConsoleApp2\\NewFolder", "logoKav.png");
                            if (File.Exists(logoPath))
                            {
                                column.Item().Height(5).Background("4083c4");
                                column.Item().AlignCenter().Width(100).Image(logoPath);
                                column.Item().Height(5).Background("4083c4");
                            }
                            column.Spacing(10);
                            column.Item().Background("#00FF00");

                            column.Item().Text("Report Generated at: " + DateTime.Now.ToShortDateString() + "    " + siteName).AlignCenter().FontSize(10);
                            column.Item().Height(1).Background(Colors.Black);

                        });

                    page.Content()
                         .PaddingVertical(1, Unit.Centimetre)
                         .Column(col =>
                         {
                             foreach (var list in points)
                             {
                                 
                                 col.Item().Border(1).Table(table =>
                                 {
                                     table.ColumnsDefinition(columns =>
                                     {
                                         columns.RelativeColumn();
                                         columns.RelativeColumn();
                                         columns.RelativeColumn();
                                         columns.RelativeColumn();

                                     });

                                     table.Cell().Element(TableHeader).Text("Name");
                                     table.Cell().Element(TableHeader).Text("X");
                                     table.Cell().Element(TableHeader).Text("Y");
                                     table.Cell().Element(TableHeader).Text("Z");

                                     foreach (var item in list)
                                     {
                                         if (File.Exists(item))
                                         {

                                             col.Item().AlignCenter().Border(1).Height(200).Image(item);
                                             col.Item().AlignCenter().Height(1).Width(150).Background(Colors.Black);

                                             col.Spacing(20);
                                         }
                                         else
                                         {
                                             table.Cell().Element(Block).Text(item);
                                         }

                                         
                                     }

                                 });
                             }
                         });





                        //.Column(column =>
                        //{
                        //    column.Spacing(20);
                            
                        //    // Group data by type
                        //    var groupedData = GroupDataByType(values);

                        //    column.Item().Table(table =>
                        //    {
                        //        table.ColumnsDefinition(columns =>
                        //        {
                        //            columns.RelativeColumn();
                        //            columns.RelativeColumn();
                        //            columns.RelativeColumn();
                        //            columns.RelativeColumn();
                        //        });

                        //        foreach (var group in groupedData)
                        //        {
                        //            column.Item().Text(group.Key).Bold().FontSize(16);

                                    
                        //                table.Cell().Row(1).Column(1).Element(TableHeader).Text(group.Key);
                        //                table.Cell().Row(1).Column(2).Element(TableHeader).Text("B");
                        //                table.Cell().Row(1).Column(3).Element(TableHeader).Text("C");
                        //                table.Cell().Row(1).Column(4).Element(TableHeader).Text("D");

                                    
                                




                        //            foreach (var (name, data) in group.Value)
                        //            {
                        //                column.Item().Column(innerColumn =>
                        //                {
                        //                    innerColumn.Spacing(10);
                        //                    innerColumn.Item().Text($"Name: {name}").Bold();
                        //                    innerColumn.Item().Text($"Details:");
                        //                    foreach (var item in data.Take(data.Count - 1))
                        //                    {
                        //                        innerColumn.Item().Text(item);
                        //                    }

                        //                    // Display image
                        //                    var imagePath = data.Last();
                        //                    if (File.Exists(imagePath))
                        //                    {
                        //                        innerColumn.Item().Image(imagePath);
                        //                    }
                        //                });
                        //            }
                        //        }
                        //    });

                            
                        //});

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            })
            .ShowInPreviewer();
        }


        static IContainer Block(IContainer container)
        {
            return container
                .Border(1)
                .ShowOnce()
                .MinWidth(50)
                .MinHeight(10)
                .AlignCenter()
                .AlignMiddle();
        }

        static IContainer TableHeader(IContainer container)
        {
            return container
                .Border(1)
                .Background(Colors.Blue.Accent1)
                .ShowOnce()
                .MinWidth(50)
                .MinHeight(15)
                .AlignCenter()
                .AlignMiddle()
                ;
        }
    }
}
