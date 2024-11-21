using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace ImageTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        internal class PostgresModel
        {
            public static DataTable Select(string selectSQL)
            {
                DataTable dataTable = new DataTable("STUDY_PALACE");
                string connectionString = "Host=localhost;Database=STUDY_PALACE;Username=postgres;Password=yourpassword;";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(selectSQL, connection))
                    {
                        using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    }
                }
                return dataTable;
            }
        }

        public class ByteImage
        {
            private static readonly ImageConverter _imageConverter = new ImageConverter();

            public static byte[] CopyImageToByteArray(Image theImage)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    theImage.Save(memoryStream, ImageFormat.Png);
                    return memoryStream.ToArray();
                }
            }

            public static Bitmap GetImageFromByteArray(byte[] byteArray)
            {
                Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

                if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                                   bm.VerticalResolution != (int)bm.VerticalResolution))
                {
                    bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                     (int)(bm.VerticalResolution + 0.5f));
                }

                return bm;
            }

            public static BitmapImage Convert(Bitmap src)
            {
                MemoryStream ms = new MemoryStream();
                ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

            string connectionString = "Host=localhost;Database=STUDY_PALACE;Username=postgres;Password=yourpassword;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO image (image_data) VALUES (@Image)", connection))
                {
                    command.Parameters.AddWithValue("@Image", NpgsqlTypes.NpgsqlDbType.Bytea, imageBytes);
                    command.ExecuteNonQuery();
                }
            }

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string savePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "SelectedImage.png");
                    File.WriteAllBytes(savePath, imageBytes);

                    MessageBox.Show($"Изображение сохранено по пути: {savePath}", "Сохранение успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            DataTable matcherQuery = PostgresModel.Select("SELECT * FROM image");
            if (matcherQuery.Rows.Count > 0)
            {
                byte[] imageBytes = (byte[])matcherQuery.Rows[matcherQuery.Rows.Count - 1]["image_data"];
                image.Source = ByteImage.Convert(ByteImage.GetImageFromByteArray(imageBytes));
            }
            else
            {
                MessageBox.Show("Нет изображений в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}