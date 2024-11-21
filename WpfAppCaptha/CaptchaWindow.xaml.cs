using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfAppCaptha
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        public CaptchaWindow()
        {
            InitializeComponent();
            GenerateCaptcha();
        }
        // Генерация капчи
        private void GenerateCaptcha()
        {
            captchaText = GenerateRandomText();
            Bitmap captchaImage = CreateCaptchaImage(captchaText);

            // Конвертируем изображение в BitmapImage для отображения
            using (MemoryStream memory = new MemoryStream())
            {
                captchaImage.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                CaptchaImage.Source = bitmapImage;
            }
        }

        // Метод для создания изображения капчи
        private Bitmap CreateCaptchaImage(string captchaText)
        {
            Bitmap bitmap = new Bitmap(150, 50);
            Random random = new Random();

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(System.Drawing.Color.LightGray);

                // Добавляем шум и линии
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, System.Drawing.Color.DarkGray);
                }

                for (int i = 0; i < 5; i++)
                {
                    int x1 = random.Next(bitmap.Width);
                    int y1 = random.Next(bitmap.Height);
                    int x2 = random.Next(bitmap.Width);
                    int y2 = random.Next(bitmap.Height);
                    graphics.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Gray), x1, y1, x2, y2);
                }

                // Отрисовка текста капчи с случайным углом и цветом
                for (int i = 0; i < captchaText.Length; i++)
                {
                    Font font = new Font("Arial", random.Next(16, 20), FontStyle.Bold);
                    System.Drawing.Color color = System.Drawing.Color.FromArgb(random.Next(100, 255), random.Next(100, 255), random.Next(100, 255));
                    Brush brush = new SolidBrush(color);

                    int x = 20 + i * 20;
                    int y = random.Next(10, 25);
                    graphics.TranslateTransform(x, y);
                    graphics.RotateTransform(random.Next(-10, 10));
                    graphics.DrawString(captchaText[i].ToString(), font, brush, 0, 0);
                    graphics.ResetTransform();
                }
            }
            return bitmap;
        }

        // Метод для генерации случайного текста капчи
        private string GenerateRandomText()
        {
            Random random = new Random();
            int length = random.Next(4, 7);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }

        // Обработчик кнопки для проверки введенной капчи
        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaInput.Text.Trim() == captchaText)
            {
                DialogResult = true; // Если введенная капча совпадает
            }
            else
            {
                MessageBox.Show("Капча введена неверно. Попробуйте еще раз.");
                GenerateCaptcha(); // Перегенерируем капчу при ошибке
            }
        }
    }
}