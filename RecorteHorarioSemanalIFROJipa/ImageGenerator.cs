/* 
 * This file is part of the RecorteHorarioSemanalIFROJipa (https://github.com/guesant/recorte-horario-semanal-ifro-jipa).
 * Copyright (c) 2022 Gabriel R. Antunes.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using NetVips;

public class ImageGenerator
{
    static string FormatImageDimensions(Image image)
    {
        return $"{image.Width}x{image.Height}";
    }

    public static void Generate(Payload payload, string originalPDFFilename, string outputImageFilename)
    {
      System.Console.WriteLine("doido");
        var manualImageDisposer = new VipsImageDisposer();

        using var originalPage = Image.Pdfload(originalPDFFilename, payload.Page, 1, payload.DPI);

        Console.WriteLine($"[info] Grade geral carregada com sucesso ({FormatImageDimensions(originalPage)}).");
        
        var tableHeaderX = (int)(payload.Header.X * payload.DPI);
        var tableHeaderY = (int)(payload.Header.Y * payload.DPI);
        var tableHeaderWidth = (int)(payload.Header.Width * payload.DPI);
        var tableHeaderHeight = (int)(payload.Header.Height * payload.DPI);

        using var tableHeader = originalPage.Copy().Crop(tableHeaderX, tableHeaderY, tableHeaderWidth, tableHeaderHeight);

        var finalTable = tableHeader.Copy();

        manualImageDisposer.Add(finalTable);

        foreach (var grade in payload.ClassesTimeTables)
        {
            var gradeX = (int)(grade.X * payload.DPI);

            var gradeY = (int)((grade.Y != null ? grade.Y : payload.Header.ClassTimeTableY) * payload.DPI);

            var gradeWidth = (int)((grade.Width != null ? grade.Width : payload.Header.ClassTimeTableWidth) * payload.DPI);

            var gradeHeight = (int)((grade.Height != null ? 
              grade.Height : 
              (payload.Header.ClassTimeTableHeight != null ?
                payload.Header.ClassTimeTableHeight :
                payload.Header.Height
              )
            ) * payload.DPI);

            using var horarioTurma = originalPage.Copy().Crop(gradeX, gradeY, gradeWidth, gradeHeight);

            finalTable = finalTable.Join(horarioTurma, Enums.Direction.Horizontal);

            manualImageDisposer.Add(finalTable);
        }

        using var finalImage = finalTable;

        finalImage.WriteToFile(outputImageFilename);
        
        Console.WriteLine($"[info] Arquivo final gerado com sucesso ({FormatImageDimensions(finalImage)}).");
        
        manualImageDisposer.Run();
    }
}

