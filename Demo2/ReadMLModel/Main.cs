using System;
using System.IO;
using System.Windows.Ink;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Text;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Linq;
using static System.Math;
using System.Globalization;

namespace NumberSage
{
    public partial class Main : Form
    {
        private InkCanvas inkCanvas;

        public Main()
        {
            this.InitializeComponent();
            this.InitializeCanvas();
        }

        private void Predict(float[] digit)
        {
            var newDigit = new float[digit.Length];

            for (int i = 0; i < digit.Length; i++)
            {
                newDigit[i] = ((digit[i] / 255) - 0.1307f) / 0.3081f;
            }

            var denseTensor = new DenseTensor<float>(newDigit, new int[] { 1, newDigit.Length });

            var input = NamedOnnxValue.CreateFromTensor<float>("picture", denseTensor);

            var output = _session.Run(new[] { input }, new[] { "resultMatrix" })
                .First()
                .AsTensor<float>()
                .ToArray();

            var pred = Array.IndexOf(output, output.Max());
            this.ShowResult(pred, output, 0, Exp);
        }

        private InferenceSession _session;

        /// <summary>
        /// Load model *.onnx
        /// </summary>
        /// <param name="file">Path of the file.onnx</param>
        private void LoadModel(string file)
        {
            _session = new InferenceSession(file);
            textUrl.Text = "MODEL LOADED!";
            buttonLoad.Enabled = false;
        }


        /// <summary>
        /// Convert the 28x28 matrix into a list with 758 lines 
        /// </summary>
        /// <returns>Float array with 758 lines</returns>
        private float[] GetWrittenDigit()
        {
            int size = 28;

            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)inkCanvas.ActualWidth, (int)inkCanvas.ActualHeight,
                96d, 96d, PixelFormats.Default);

            renderTargetBitmap.Render(inkCanvas);

            var bitmap = new WriteableBitmap(renderTargetBitmap)
                            .Resize(size, size, WriteableBitmapExtensions.Interpolation.NearestNeighbor);

            float[] data = new float[size * size];
            for (int x = 0; x < bitmap.PixelWidth; x++)
            {
                for (int y = 0; y < bitmap.PixelHeight; y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    data[y * bitmap.PixelWidth + x] = 255 - ((color.R + color.G + color.B) / 3);
                }
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] <= 100)
                {
                    data[i] = 0;
                }
            }

            Console.WriteLine(Stringify(data));
            return data;
        }

        private string Stringify(float[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 0 || i % 28 == 0) sb.Append("{\r\n\t");  // Removing noise

                sb.Append($"{data[i],3:##0}, ");
            }

            sb.Append("\r\n}\r\n");

            return sb.ToString();
        }

        private void ShowResult(int prediction, float[] scores, double time, Func<double, double> conversion = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Scores:");

            for (int i = 0; i < scores.Length; i++)
            {
                double v = conversion == null ? scores[i] : conversion(scores[i]);
                sb.AppendLine($"\t{i}: {v.ToString("P", CultureInfo.InvariantCulture)}");
            }

            sb.AppendLine($"Prediction: {prediction}");
            sb.AppendLine($"Time: {time}");
            labelPrediction.Text = prediction.ToString();

            textResponse.Text = "";
            textResponse.Text = sb.ToString();
        }

        private void Clear()
        {
            inkCanvas.Strokes.Clear();
            textResponse.Clear();
            labelPrediction.Text = "";
        }

        private void InitializeCanvas()
        {
            textUrl.HideSelection = true;
            inkCanvas = new InkCanvas
            {
                DefaultDrawingAttributes = new DrawingAttributes()
                {
                    FitToCurve = true,
                    Height = 25,
                    Width = 25
                }
            };
            hostCanvas.Child = inkCanvas;
            labelPrediction.Text = "";
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            this.Predict(this.GetWrittenDigit());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK && File.Exists(openFile.FileName))
            {
                this.LoadModel(openFile.FileName);
            }                
        }
    }
}
