using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Media_Sorter
{
    public class CImageBuffer
    {
        int frame;
        List<Bitmap> buffer;

        public CImageBuffer()
        {
            buffer = new List<Bitmap>();
        }

        ~CImageBuffer()
        {
            buffer.Clear();
            buffer = null;
        }

        public void AddFrame(Image frame, int width = -1, int height= -1)
        {
            if (width < 0 && height < 0)
                buffer.Add(new Bitmap(frame));
            else
                buffer.Add(new Bitmap(frame, new Size(width, height)));
        }

        public Bitmap GetFrame()
        {
            if (frame == buffer.Count)
                frame = 0;

            return new Bitmap(buffer[frame++]);
        }

        public void Clear()
        {
            frame = 0;
            if (buffer != null)
                buffer.Clear();
        }
    }
}
