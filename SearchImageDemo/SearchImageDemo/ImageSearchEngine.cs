using OpenCvSharp;
using System.Drawing;
using Point = OpenCvSharp.Point;

namespace SearchImageDemo
{
    internal class ImageSearchEngine
    {
public static Rectangle Find(Image sourceImage, Image matchImage, double threshold = 0.8)
{
    var refMat = Mat.FromImageData(ImageHelper.ImageToBytes(sourceImage), ImreadModes.AnyColor);//大图
    var tplMat = Mat.FromImageData(ImageHelper.ImageToBytes(matchImage), ImreadModes.AnyColor);//小图
    using (Mat res = new Mat(refMat.Rows - tplMat.Rows + 1, refMat.Cols - tplMat.Cols + 1, MatType.CV_32FC1))
    {
        Mat gref = refMat.CvtColor(ColorConversionCodes.BGR2GRAY);
        Mat gtpl = tplMat.CvtColor(ColorConversionCodes.BGR2GRAY);

        Cv2.MatchTemplate(gref, gtpl, res, TemplateMatchModes.CCoeffNormed);
        Cv2.Threshold(res, res, 0.8, 1.0, ThresholdTypes.Tozero);

        double minval, maxval;
        Point minloc, maxloc;

        Cv2.MinMaxLoc(res, out minval, out maxval, out minloc, out maxloc);

        if (maxval >= threshold)
        {
            return new Rectangle(maxloc.X, maxloc.Y, tplMat.Width, tplMat.Height);
        }
        return Rectangle.Empty;
    }
}

    }
}
