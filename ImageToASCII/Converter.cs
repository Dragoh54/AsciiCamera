using System;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;

#pragma warning disable CA1416

namespace ImageToASCII;

public class Converter
{
    // font correction factor 
    public double FontCorrectionFactor { get; private set; } = 0.55d;
    
    //ASCII symbols
    public string AsciiChars { get; private set; } = " .,:;+*?%S#@";

    // public string AsciiChars { get; private set; } =
    //     "`.'^\",:;Il!i><~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$\\";

    // constructors
    public Converter()
    {
    }

    public Converter(double fontCorrectionFactor)
    {
        FontCorrectionFactor = fontCorrectionFactor;
    }
    
    // methods
    public string ConvertImage(Bitmap image, int width)
    {
        var asciiStr = new StringBuilder();
        
        var height = (int)(image.Height * ((double)width / image.Width) * FontCorrectionFactor);
        
        var resizedImage = new Bitmap(image, new Size(width, height));

        for (var y = 0; y < resizedImage.Height; y++)
        {
            for (var x = 0; x < resizedImage.Width; x++)
            {
                var pixel = resizedImage.GetPixel(x, y);

                var gray = (pixel.R + pixel.G + pixel.B) / 3;

                var i = gray * (AsciiChars.Length - 1) / 255;

                asciiStr.Append(AsciiChars[i]);
            }

            asciiStr.AppendLine();
        }
        
        return asciiStr.ToString();
    }
}

#pragma warning restore CA1416