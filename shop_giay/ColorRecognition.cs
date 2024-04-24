using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;

namespace shop_giay
{
    public class ColorRecognition
    {
       
        public static void Color()
        {
            // Load the image
            using (var image = new Image<Bgr, byte>("path/to/your/image.jpg"))
            {
                Bgr averageColor; // Choose a unique name
                MCvScalar sdv;


                 //image.AvgSdv(out calculatedAverageColor, out sdv);

                // With mask
                var mask = new Image<Gray, byte>("path/to/your/mask.png");
                image.AvgSdv(out averageColor, out sdv, mask);

                //Console.WriteLine($"Average color (BGR): {averageColor.Val0}, {averageColor.Val1}, {averageColor.Val2}");

                // Convert Bgr to Hsv for easier color identification
                //var hsvColor = averageColor.Convert<Hsv, byte>();
                var hsvColor = new MCvScalar();
                CvInvoke.CvtColor(averageColor, hsvColor, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv); 

                // Define color ranges (adjust these values based on your needs)
                var redRange = new ScalarArray(new MCvScalar(0, 100, 100)); // Lower bound (Hue, Saturation, Value) - Adjust for red
                var redRangeUpper = new ScalarArray(new MCvScalar ( 10, 255, 255 )); // Upper bound (Hue, Saturation, Value)

                // Check if the average color falls within the red range
                if (hsvColor.InRange(redRange, redRangeUpper))
                {
                    Console.WriteLine("The dominant color is red.");
                }

                // Add similar checks for other colors (example for green)
                var greenRange = new ScalarArray(new MCvScalar ( 40, 50, 50 )); // Lower bound (Hue, Saturation, Value) - Adjust for green
                var greenRangeUpper = new ScalarArray(new MCvScalar ( 80, 255, 255 )); // Upper bound (Hue, Saturation, Value)
                if (hsvColor.InRange(greenRange, greenRangeUpper))
                {
                    Console.WriteLine("The image contains a significant amount of green.");
                }

                // Alternatively, use predefined color detection methods (less accurate)
                //var isRed = image.InRegion(new Bgr(255, 0, 0), new Bgr(255, 100, 100)); // Check for red color range
                //if (isRed)
                //{
                //    Console.WriteLine("The image contains a significant amount of red.");
                //}
            }
        }

        private static IOutputArray Convert<T1, T2>(MCvScalar sdv)
        {
            throw new NotImplementedException();
        }
    }
}
