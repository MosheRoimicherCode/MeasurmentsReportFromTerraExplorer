using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Data.Common;
using System.Globalization;
using System.Resources;
using Color = QuestPDF.Infrastructure.Color; // For File handling

namespace GeneratePdf;

public class GenerateReport
{
    ResourceManager _rm = new ResourceManager("GeneratePdf.Languages.Resources", typeof(Program).Assembly);
    private float spacing = 18;
    DocumentMetadata metaData = new();
    public void GenerateFakeDataReport()
    {


        // Create lists to simulate your data categories
        List<List<string>> points = new();
        List<List<string>> lines = new();
        List<List<string>> polys = new();

        // Adding fake data for points
        points.Add(new List<string>() { "point a", "207898.13", "594880.19", "15.15",   "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153615_130.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153615_130.jpg" });
        points.Add(new List<string>() { "point a", "207898.13", "594880.19", "15.15", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153615_130.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153615_130.jpg" });
        points.Add(new List<string>() { "point a", "207898.13", "594880.19", "15.15", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153615_130.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153615_130.jpg" });

        // Adding fake data for lines
        lines.Add(new List<string>() { "line1", "200.00m", "150.25m", "45°", "70%", "15m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153621_132.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153621_132.jpg" });
        lines.Add(new List<string>() { "moshe", "200.06m", "150.28m", "45°", "50%", "15.25m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153621_132.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1153621_132.jpg" });

        // Adding fake data for polygons
        polys.Add(new List<string>() { "moshe","300m²", "80m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg" });
        polys.Add(new List<string>() { "moshe", "300m²", "80m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg" });
        polys.Add(new List<string>() { "moshe", "300m²", "80m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg" });
        polys.Add(new List<string>() { "moshe", "300m²", "80m", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg", "C:\\Users\\User\\AppData\\Local\\Temp\\TESS_1154537_155.jpg" });



        // Generate the report PDF
        //ReportToPdf(points, lines, polys, "דומגמה של שם אתר", "he", "projectName");
    }

    public void ReportToPdf(List<List<string>> points, List<List<string>> lines, List<List<string>> polys, string siteName, string language, string projectName, string pdfPath)
    {
        metaData.CreationDate = DateTimeOffset.Now.Date;
        metaData.Creator = "Automatic Report From Terra Explorer";
        metaData.Producer = "Kav Medida - Israel";
        metaData.Title = projectName;

        DefineCulture(language);
        QuestPDF.Settings.License = LicenseType.Community;

        // Get the base directory of the project
        string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logoKav.png");

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
                        if (File.Exists(logoPath))
                        {
                            column.Item().Height(5).Background("4083c4");
                            column.Item().AlignCenter().Width(100).Image(logoPath);
                            column.Item().Height(5).Background("4083c4");
                        }
                        column.Spacing(10);
                        column.Item().Background("#00FF00");

                        column.Item().Text(projectName + "          " + _rm.GetString("GroupName") + " " + siteName).AlignCenter().FontSize(8);
                        column.Item().Text(_rm.GetString("dateGenerated") + " " + DateTime.Now.ToShortDateString()).AlignCenter().FontSize(8);

                        column.Item().Height(1).Background(Colors.Black);

                    });

                page.Content()
                     .PaddingVertical(1, Unit.Centimetre)
                     .Column(col =>
                     {
                         var numberOfElements = 0;
                         //Point
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

                                 table.Cell().Element(TableHeader).Text(_rm.GetString("Name")).FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text("X").FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text("Y").FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text("Z").FontFamily(Fonts.Trebuchet);

                                 foreach (var item in list)
                                 {
                                     if (!File.Exists(item))
                                         table.Cell().Element(Block).Text(item);
                                 }


                                 col.Item().Table(t =>
                                 {
                                     t.ColumnsDefinition(c =>
                                     {
                                         c.RelativeColumn();
                                         c.ConstantColumn(10);
                                         c.RelativeColumn();
                                     });



                                     foreach (var item in list)
                                     {
                                         if (File.Exists(item))
                                         {
                                             t.Cell().Border(1).Image(item);
                                             t.Cell().Width(10);

                                         }

                                     }
                                 });

                                 col.Item().AlignCenter().Height(1).Width(150).Background(Colors.Black);
                                 col.Spacing(spacing);
                             });

                             numberOfElements++;
                             if (numberOfElements != 0 && numberOfElements % 2 == 0)
                                 col.Item().PageBreak();
                         }

                         //Polyline
                         foreach (var list in lines)
                         {

                             col.Item().Border(1).Table(table =>
                             {
                                 table.ColumnsDefinition(columns =>
                                 {
                                     columns.RelativeColumn();
                                     columns.RelativeColumn();
                                     columns.RelativeColumn();
                                     columns.RelativeColumn();
                                     columns.RelativeColumn();
                                     columns.RelativeColumn();
                                 });

                                 table.Cell().Element(TableHeader).Text(_rm.GetString("Name")).FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text(_rm.GetString("ElevationDifference")).FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text(_rm.GetString("HorizontalDistance")).FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text(_rm.GetString("AerialDistance")).FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text(_rm.GetString("SlopeDegrees")).FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text(_rm.GetString("SlopePercentage")).FontFamily(Fonts.Trebuchet);


                                 foreach (var item in list)
                                 {

                                     if (!File.Exists(item))
                                         table.Cell().Element(Block).Text(item);
                                 }


                                 col.Item().Table(t =>
                                 {
                                     t.ColumnsDefinition(c =>
                                     {
                                         c.RelativeColumn();
                                         c.ConstantColumn(10);
                                         c.RelativeColumn();
                                     });



                                     foreach (var item in list)
                                     {
                                         if (File.Exists(item))
                                         {
                                             t.Cell().Border(1).Image(item);
                                             t.Cell().Width(10);

                                         }

                                     }
                                 });
                                 col.Item().AlignCenter().Height(1).Width(150).Background(Colors.Black);
                                 col.Spacing(spacing);
                             });

                             numberOfElements++;
                             if (numberOfElements != 0 && numberOfElements % 2 == 0)
                                 col.Item().PageBreak();
                         }

                         //Polygon
                         foreach (var list in polys)
                         {

                             col.Item().Border(1).Table(table =>
                             {
                                 table.ColumnsDefinition(columns =>
                                 {
                                     columns.RelativeColumn();
                                     columns.RelativeColumn();
                                     columns.RelativeColumn();

                                 });

                                 table.Cell().Element(TableHeader).Text(_rm.GetString("Name")).FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text(_rm.GetString("Area")).FontFamily(Fonts.Trebuchet);
                                 table.Cell().Element(TableHeader).Text(_rm.GetString("Length")).FontFamily(Fonts.Trebuchet);

                                 foreach (var item in list)
                                 {

                                     if (!File.Exists(item))
                                         table.Cell().Element(Block).Text(item);
                                 }


                                 col.Item().Table(t =>
                                 {
                                     t.ColumnsDefinition(c =>
                                     {
                                         c.RelativeColumn();
                                         c.ConstantColumn(10);
                                         c.RelativeColumn();
                                     });



                                     foreach (var item in list)
                                     {
                                         if (File.Exists(item))
                                         {
                                             t.Cell().Border(1).Image(item);
                                             t.Cell().Width(10);

                                         }

                                     }
                                 });
                                 col.Item().AlignCenter().Height(1).Width(150).Background(Colors.Black);
                                 col.Spacing(spacing);
                             });

                             numberOfElements++;
                             if (numberOfElements != 0 && numberOfElements % 2 == 0)
                                 col.Item().PageBreak();
                         }
                     });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span(_rm.GetString("Page"));
                        x.CurrentPageNumber();
                    });
            });
        })
        .WithMetadata(metaData).GeneratePdf(pdfPath);
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
            .Background("659ed2")
            .ShowOnce()
            .MinWidth(50)
            .MinHeight(15)
            .AlignCenter()
            .AlignMiddle()
            ;
    }


    private void DefineCulture(string lng = "he-HE")
    {
        string cultureName = lng.Length > 0 ? lng : "en-US"; // Default to English if no argument
        CultureInfo culture = new CultureInfo(cultureName);
        // Set current UI culture
        CultureInfo.CurrentUICulture = culture;

        // Access resource string
        string greeting = _rm.GetString("Area");

        // Display greeting
        Console.WriteLine(greeting);
    }
}
