using System.Drawing;
using Size = ThumbnailGenerator.Size;

var d = new DirectoryInfo(@"C:\img");

var files = d.GetFiles();
var counter = 0;
foreach (var file in files)
{
    counter++;
    Console.WriteLine($"{counter}/{files.Length} Thumbnail for {file.Name}");
    var sizes = new List<Size>
    {
        new Size {W = 60, H = 60}, new Size {W = 120, H = 120},
        new Size {W = 200, H = 200}, new Size {W = 250, H = 250},
        new Size {W = 300, H = 300}, new Size {W = 400, H = 400},
        new Size {W = 500, H = 500}, new Size {W = 600, H = 600}
    };


#pragma warning disable CA1416
    var image = Image.FromFile(file.FullName);
#pragma warning restore CA1416
    foreach (var s in sizes)
#pragma warning disable CA1416
    {
        var thumb = image.GetThumbnailImage(s.W, s.H, () => false, IntPtr.Zero);
#pragma warning restore CA1416
        var newName = Path.ChangeExtension(file.Name, $"Thumb_{s.W}x{s.H}px{file.Extension}");
#pragma warning disable CA1416
        if (file.Directory?.FullName != null) thumb.Save(Path.Combine(file.Directory?.FullName, newName));
#pragma warning restore CA1416
    }
}

Console.WriteLine("Done");
Console.ReadLine();