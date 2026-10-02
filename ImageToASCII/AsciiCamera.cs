using System.Drawing;
using System.Text;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImageToASCII;

public class AsciiCamera
{
    // camera 
    private FilterInfoCollection _videoDevices = null;
    private VideoCaptureDevice _videoSource = null;
    
    // ascii converter
    private Converter _asciiConverter = null;

    // output
    private int _width = 200;

    public AsciiCamera()
    {
        _asciiConverter = new Converter();
        
        InitVideoSource();
    }

    public AsciiCamera(double fontCorrectionFactor, int width)
    {
        Console.WriteLine("Ascii Camera initialize");
        
        _asciiConverter = new Converter(fontCorrectionFactor: fontCorrectionFactor);
        
        _width = width;
        
        InitVideoSource();
    }

    public void StopVideo()
    {
        _videoSource?.Stop();
    }

    private void InitVideoSource()
    {
        Console.WriteLine("InitVideoSource initialize");
        _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);

        Console.WriteLine("_videoSource.NewFrame signed");
        _videoSource.NewFrame += new NewFrameEventHandler(NewFrame_ToAscii);
        
        Console.WriteLine("camera started");
        _videoSource.Start();
    }

    private void NewFrame_ToAscii(object sender, NewFrameEventArgs eventArgs)
    {
        Console.Clear();

        var asciiStr = new StringBuilder();

        {
            using var frame = (Bitmap)eventArgs.Frame.Clone();
            asciiStr = new StringBuilder(_asciiConverter.ConvertImage(frame, _width));
        }
        
        Console.WriteLine(asciiStr.ToString());
    }
}