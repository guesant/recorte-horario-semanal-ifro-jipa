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

public class PayloadHeader
{
    public int X { get; set; }
    public int Y { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }

    public int ClassTimeTableY { get; set; }
    public int ClassTimeTableWidth { get; set; }
    public int? ClassTimeTableHeight { get; set; }
}