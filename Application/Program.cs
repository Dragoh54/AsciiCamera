using System.Drawing;
using ImageToASCII;

// var imagePath = "C:\\Users\\Nikita\\Pictures\\6.jpg";
// var textFilePath = "C:\\Users\\Nikita\\Desktop\\Test\\test.txt";
//
// var converter = new Converter(fontCorrectionFactor: 0.5d);
//
// {
//     using var bmp = new Bitmap(imagePath);
//     using var sw = new StreamWriter(textFilePath, append: false);
//
//     var str = converter.ConvertImage(bmp, 100);
//     
//     Console.WriteLine(str);
//     
//     sw.Write(str);
// }

var asciiCamera = new AsciiCamera(fontCorrectionFactor: 0.5d, width: 400);


