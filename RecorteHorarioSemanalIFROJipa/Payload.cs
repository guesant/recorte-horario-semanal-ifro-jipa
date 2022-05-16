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

using System.Text.Json;

public class Payload
{
    public int Page { get; set; }

    public int DPI { get; set; }

    public PayloadHeader Header { get; set; }

    public PayloadClassTimeTable[] ClassesTimeTables { get; set; }

    public Payload(int page, int dpi, PayloadHeader header, PayloadClassTimeTable[] classesTimeTables)
    {
        this.Page = page;
        this.DPI = dpi;
        this.Header = header;
        this.ClassesTimeTables = classesTimeTables;
    }

    public static Payload FromString(string payloadJSONString)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        Payload payload = JsonSerializer.Deserialize<Payload>(payloadJSONString, options)!;
        return payload;
    }

    public static Payload FromFile(string payloadFileName)
    {
        string payloadJSONString = File.ReadAllText(payloadFileName);
        Console.WriteLine("[info] Payload carregado com sucesso.");
        return FromString(payloadJSONString);
    }
}
