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

class VipsImageDisposer
{
    List<Image> imagesToDisposeManually = new List<Image>();

    public void Reset()
    {
        imagesToDisposeManually = new List<Image>();
    }

    public void Add(Image image)
    {
        imagesToDisposeManually.Add(image);
    }

    public void Run()
    {
        imagesToDisposeManually.Reverse();
        foreach (var image in imagesToDisposeManually)
        {
            image.Dispose();
        }
        Reset();
    }
}