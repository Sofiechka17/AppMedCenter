using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QRCoder;
using QRCoder.Xaml;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

namespace WpfQrCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Media.Color qrCodeColor = System.Windows.Media.Colors.Orange;    // Можно изменить на любой цвет QR-кода
        private System.Windows.Media.Color backgroundColor = System.Windows.Media.Colors.White;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = TextInput.Text;

            // Создание генератора QR-кода
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputText, QRCodeGenerator.ECCLevel.Q);

                // Преобразование списка BitArray в двумерный массив bool
                bool[,] qrMatrix = ConvertToBoolArray(qrCodeData.ModuleMatrix);

                // Генерация цветного QR-кода с использованием выбранных цветов
                QRCodeImage.Source = GenerateColorQRCode(qrMatrix, qrCodeColor, backgroundColor, 20);
            }
        }

        // Преобразование List<BitArray> в двумерный массив bool[,]
        private bool[,] ConvertToBoolArray(List<BitArray> moduleMatrix)
        {
            int size = moduleMatrix.Count;
            bool[,] qrMatrix = new bool[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    qrMatrix[y, x] = moduleMatrix[y][x];
                }
            }

            return qrMatrix;
        }

        // Генерация цветного QR-кода с помощью WriteableBitmap
        private WriteableBitmap GenerateColorQRCode(bool[,] qrMatrix, System.Windows.Media.Color qrColor, System.Windows.Media.Color backgroundColor, int pixelSize)
        {
            int size = qrMatrix.GetLength(0); // Размер QR-кода (квадратная матрица)
            int imageSize = size * pixelSize; // Размер изображения в пикселях

            WriteableBitmap bitmap = new WriteableBitmap(imageSize, imageSize, 96, 96, PixelFormats.Bgra32, null);
            bitmap.Lock();

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    // Выбор цвета в зависимости от значения QR-модуля
                    System.Windows.Media.Color color = qrMatrix[y, x] ? qrColor : backgroundColor;
                    DrawPixelBlock(bitmap, x * pixelSize, y * pixelSize, pixelSize, color);
                }
            }

            bitmap.Unlock();
            return bitmap;
        }

        // Рисование квадрата (pixelSize x pixelSize) в WriteableBitmap
        private void DrawPixelBlock(WriteableBitmap bitmap, int startX, int startY, int pixelSize, System.Windows.Media.Color color)
        {
            for (int y = 0; y < pixelSize; y++)
            {
                for (int x = 0; x < pixelSize; x++)
                {
                    SetPixel(bitmap, startX + x, startY + y, color);
                }
            }
        }

        // Установка пикселя в WriteableBitmap
        private void SetPixel(WriteableBitmap bitmap, int x, int y, System.Windows.Media.Color color)
        {
            bitmap.WritePixels(new Int32Rect(x, y, 1, 1), new byte[] { color.B, color.G, color.R, color.A }, 4, 0);
        }

    }
}
