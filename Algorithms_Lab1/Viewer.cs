using System;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Algorithms_Lab1;

public static class Viewer
{
    public static void CreateWB(double[] times, int step)
    {
        File.Delete("Test1.xlsx");
        
        Workbook wb = new Workbook();

        Worksheet sheet  = wb.Worksheets[0];

        for (int i = 0; i < times.Length; i++)
        {
            Cell cell = sheet.Cells[i + 2, 1];
            cell.PutValue(times[i]);
            Cell cell1 = sheet.Cells[i + 2, 2];
            cell1.PutValue(i * step);
        }

        int chartIndex = sheet.Charts.Add(ChartType.Line, 5, 4, 35, 30);

        Chart chart = sheet.Charts[chartIndex];
        
        chart.NSeries.Add($"B2:B{times.Length + 1}", true);

        wb.Save("Result.xlsx", SaveFormat.Xlsx);
    }
}