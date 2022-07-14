using System.Diagnostics;

namespace SearchImageDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Screen = ImageHelper.GetScreenCapture();
            Stopwatch stopwatch= Stopwatch.StartNew();
            var point = ImageSearchEngine.Find(Screen, new Bitmap(@"C:\Users\Administrator\Desktop\Œ¢–≈Õº∆¨_20220710140039.png"), 0.9);
            stopwatch.Stop();
            if (!point.IsEmpty)
            {
                MessageBox.Show($"≤È’“µΩÕº∆¨◊¯±Í:X: {point.X} Y:{point.Y} Width:{point.Width} Height:{point.Height} ∫ƒ ±:{stopwatch.ElapsedMilliseconds}∫¡√Î");
            }
            else
            {
                MessageBox.Show($"Œ¥≤È’“µΩÕº∆¨!");
            }
        }
    }
}