using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;

namespace shop_giay
{
    public static class ColorRecognition
    {

        public static void Color()
        {
            // Load the image
            using (var image = new Image<Bgr, byte>("Upload/Images/Users/anh_do.jpg"))
            {
                MCvScalar sdv;

                // With mask
                var mask = new Image<Gray, byte>("Upload/Images/Users/anh_do.jpg");
                var averageColor = image.GetAverage(mask);

                // Convert Bgr to Hsv for easier color identification
                var hsvImage = image.Convert<Hsv, byte>();

                // Define color ranges (adjust these values based on your needs)
                var redRangeLower = new Hsv(0, 100, 100); // Lower bound (Hue, Saturation, Value) - Adjust for red
                var redRangeUpper = new Hsv(10, 255, 255); // Upper bound (Hue, Saturation, Value)

                // Check if the average color falls within the red range
                var redMask = hsvImage.InRange(redRangeLower, redRangeUpper);
                if (CvInvoke.CountNonZero(redMask) > 0)
                {
                    Console.WriteLine("The dominant color is red.");
                }

                // Add similar checks for other colors (example for green)
                var greenRangeLower = new Hsv(40, 50, 50); // Lower bound (Hue, Saturation, Value) - Adjust for green
                var greenRangeUpper = new Hsv(80, 255, 255); // Upper bound (Hue, Saturation, Value)
                var greenMask = hsvImage.InRange(greenRangeLower, greenRangeUpper);
                if (CvInvoke.CountNonZero(greenMask) > 0)
                {
                    Console.WriteLine("The image contains a significant amount of green.");
                }
                Console.WriteLine("no clor.");
            }
        }
    }
}
