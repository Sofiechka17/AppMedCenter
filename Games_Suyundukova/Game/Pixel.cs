﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public readonly struct Pixel
    {
        private const char PixelChar = '█';

        public Pixel(int x, int y, ConsoleColor color, int pixelSize = 3)
        {
            X = x;
            Y = y;
            Color = color;
            PixelSize = pixelSize;
        }

        public int X { get; }

        public int Y { get; }

        public ConsoleColor Color { get; }

        public int PixelSize { get; }

        public void Draw()
        {
            ConsoleColor ForegroundColor = Color;
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    SetCursorPosition(X * PixelSize + x, Y * PixelSize + y);
                    Write(PixelChar);
                }
            }
        }

        private void Write(char pixelChar)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    SetCursorPosition(X * PixelSize + x, Y * PixelSize + y);
                    Write(' ');
                }
            }
        }

        private void SetCursorPosition(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
