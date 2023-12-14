using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarknessLevelApp
{
    public partial class Form1 : Form
    {
        private double totalDarkness = 0;
        private int totalImagesProcessed = 0;
        private List<string> imageProcessingErrors = new List<string>();


        public Form1()
        {
            InitializeComponent();

            // Configura el RichTextBox
            richTextBoxErrors.ReadOnly = true;
            richTextBoxErrors.ScrollBars = RichTextBoxScrollBars.Vertical;
        }

        private double CalculateImageDarkness(Bitmap image)
        {
            double totalDarkness = 0;

            using (Bitmap lockedImage = new Bitmap(image))
            {
                BitmapData bmpData = lockedImage.LockBits(new Rectangle(0, 0, lockedImage.Width, lockedImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                IntPtr ptr = bmpData.Scan0;
                int bytes = Math.Abs(bmpData.Stride) * lockedImage.Height;
                byte[] rgbValues = new byte[bytes];
                Marshal.Copy(ptr, rgbValues, 0, bytes);

                for (int i = 0; i < rgbValues.Length; i += 4)
                {
                    double pixelDarkness = 1.0 - ((0.299 * rgbValues[i + 2] + 0.587 * rgbValues[i + 1] + 0.114 * rgbValues[i]) / 255.0);
                    totalDarkness += pixelDarkness;
                }

                lockedImage.UnlockBits(bmpData);
            } // Aquí se liberarán automáticamente los recursos de lockedImage al finalizar el bloque using

            int totalPixels = image.Width * image.Height;
            double averageDarkness = totalDarkness / totalPixels;

            return averageDarkness;
        }



        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Selecciona una carpeta de imágenes";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFolderPath = folderBrowserDialog1.SelectedPath;

                // Resetea los valores antes de procesar la carpeta
                totalDarkness = 0;
                totalImagesProcessed = 0;

                // Muestra "Procesando..." en el Label
                lblAverageDarkness.Text = "Procesando...";

                // Procesa todas las imágenes en la carpeta en segundo plano
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (senderWorker, eWorker) =>
                {
                    ProcessImagesInFolder(selectedFolderPath);
                };
                worker.RunWorkerCompleted += (senderWorker, eWorker) =>
                {
                    // Calcula y muestra el promedio total
                    if (totalImagesProcessed > 0)
                    {
                        double averageDarkness = totalDarkness / totalImagesProcessed;
                        lblAverageDarkness.Text = $"Promedio total de oscuridad: {(int)Math.Round(averageDarkness * 100)}% \nde un total de {totalImagesProcessed} imagenes";
                    }
                    else
                    {
                        lblAverageDarkness.Text = "Ninguna imagen encontrada";
                    }
                    // Mostrar errores si los hay
                    if (imageProcessingErrors.Count > 0)
                    {
                        richTextBoxErrors.AppendText("Errores de procesamiento de imágenes:\n");
                        foreach (string error in imageProcessingErrors)
                        {
                            richTextBoxErrors.AppendText(error + "\n");
                        }
                    }
                    else
                    {
                        richTextBoxErrors.Text = "No se encontraron errores de procesamiento de imágenes.\n";
                    }
                };
                worker.RunWorkerAsync();
            }
        }


        private void ProcessImagesInFolder(string folderPath)
        {
            List<string> results = new List<string>();

            // Obtén la lista de archivos de imagen en la carpeta
            string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                .Where(file => file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".bmp"))
                .ToArray();

            foreach (string imagePath in imageFiles)
            {
                try
                {
                    using (Bitmap image = new Bitmap(imagePath))
                    {
                        double darkness = CalculateImageDarkness(image);
                        int darknessPercentage = (int)Math.Round(darkness * 100);

                        // Agrega el resultado a la lista
                        results.Add($"{Path.GetFileName(imagePath)}, Nivel de oscuridad: {darknessPercentage}%");

                        // Actualiza el total de oscuridad y el contador de imágenes procesadas
                        totalDarkness += darkness;
                        totalImagesProcessed++;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción aquí y agregar el error a la lista
                    string errorMessage = $"Error al procesar la imagen {imagePath}: {ex.Message}";
                    imageProcessingErrors.Add(errorMessage);
                    Console.WriteLine(errorMessage); // También puedes mostrar el error en la consola si lo deseas.
                }

            }

            // Guarda los resultados en un archivo CSV
            string csvFilePath = Path.Combine(folderPath, "results.csv");

            try
            {
                using (StreamWriter writer = new StreamWriter(csvFilePath))
                {
                    foreach (string result in results)
                    {
                        writer.WriteLine(result);
                    }
                }

                MessageBox.Show("Proceso completado. Los resultados se han guardado en results.csv.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCalculateSingleImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.png;*.bmp|Todos los archivos|*.*";
            openFileDialog1.Title = "Selecciona una imagen";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog1.FileName;

                // Muestra "Procesando..." en el Label
                lblBrightness.Text = "Procesando...";

                // Realiza el cálculo del nivel de oscuridad en segundo plano
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (senderWorker, eWorker) =>
                {
                    using (Bitmap image = new Bitmap(selectedImagePath))
                    {
                        double darkness = CalculateImageDarkness(image);
                        int darknessPercentage = (int)Math.Round(darkness * 100);

                        // Actualiza el Label con el resultado
                        this.Invoke((MethodInvoker)delegate
                        {
                            lblBrightness.Text = $"Nivel de Oscuridad: {darknessPercentage}%";
                        });
                    }
                };
                worker.RunWorkerAsync();
            }
        }
    }
}

