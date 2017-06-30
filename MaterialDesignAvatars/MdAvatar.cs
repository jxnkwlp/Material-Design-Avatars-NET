using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace MaterialDesignAvatars
{
    /// <summary>
    /// MdAvatar
    /// </summary>
    public class MdAvatar
    {
        ///// <summary>
        ///// </summary>
        //private string Letter { get; set; }

        ///// <summary>
        ///// </summary>
        //private int Size { get; set; }

        ///// <summary>
        ///// </summary> 
        //public MdAvatar(int avatarSize = 512)
        //{
        //    this.Size = avatarSize;
        //}

        ///// <summary>
        ///// </summary> 
        //public MdAvatar(string letter, int avatarSize = 512)
        //{
        //    if (string.IsNullOrEmpty(letter))
        //        throw new ArgumentNullException(letter);

        //    this.Letter = letter[0].ToString();
        //    this.Size = avatarSize;
        //}

        ///// <summary>
        /////   Build avatar image
        ///// </summary>
        ///// <returns>Avatar image content</returns>
        //public byte[] Build()
        //{
        //    if (string.IsNullOrEmpty(Letter))
        //        throw new ArgumentNullException(nameof(Letter));

        //    return Build(Letter);
        //}

        /// <summary>
        ///  Build avatar image
        /// </summary>
        /// <param name="letter">avatar letter</param>
        /// <returns>Avatar image content</returns>
        public byte[] Build(string letter, int avatarSize = 512)
        {
            if (string.IsNullOrEmpty(letter))
                throw new ArgumentNullException(nameof(letter));
            if (avatarSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(avatarSize));

            letter = letter[0].ToString();
            // this.Letter = letter;
            // this.Size = avatarSize;
            var size = avatarSize;

            PrivateFontCollection pfc = new PrivateFontCollection();

            bool isLetter = true;

            // cn char
            if (letter[0] > 127)
            {
                isLetter = false;
                var fontFile = AppDomain.CurrentDomain.BaseDirectory + "/fonts/SourceHanSansCN-Normal.ttf";
                if (!File.Exists(fontFile))
                    throw new FileNotFoundException(fontFile);

                pfc.AddFontFile(fontFile);
            }
            else
            {
                isLetter = true;

                var fontFile = AppDomain.CurrentDomain.BaseDirectory + "/fonts/SourceCodePro-Light.ttf";
                if (!File.Exists(fontFile))
                    throw new FileNotFoundException(fontFile);

                pfc.AddFontFile(fontFile);
            }

            int width = avatarSize;
            int height = avatarSize;

            using (var bitmap = new Bitmap(width, height))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    StringFormat sf = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center,
                    };


                    var rand = new Random(Guid.NewGuid().GetHashCode());
                    var backgroundColor = MaterialDesignColor[rand.Next(MaterialDesignColor.Count)];

                    // fill background color
                    g.FillEllipse(new SolidBrush(backgroundColor), new Rectangle(0, 0, width, height));

                    // default font 
                    var font = new Font(pfc.Families[0], size, GraphicsUnit.Pixel);

                    // the best fit font 
                    font = FindBestFitFont(g, letter, font, pfc.Families[0], new Size(size, size), sf);

                    float y = 0;
                    if (isLetter)
                        y = 12 * (size / 512F);
                    else
                        y = 92 * (size / 512F);

                    float x = 3 * (size / 512F);

                    // draw letter string 
                    g.DrawString(letter, font, new SolidBrush(Color.White), new RectangleF(x, y, width, height), sf);


                    // debug 
                    //g.DrawRectangle(Pens.Red, new Rectangle(Point.Empty, new Size(width, height)));
                    //g.DrawLine(Pens.Red, width / 2, 0, width / 2, height);
                    //g.DrawLine(Pens.Red, 0, height / 2, width, height / 2);

                    // out 
                    using (var ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                        return ms.ToArray();
                    }

                }
            }
        }

        Font FindBestFitFont(Graphics g, String text, Font font, FontFamily ff, Size proposedSize, StringFormat sf)
        {
            // Compute actual size, shrink if needed
            while (true)
            {
                SizeF size = g.MeasureString(text, font, proposedSize.Width, sf);

                // It fits, back out
                if (size.Height <= proposedSize.Height &&
                     size.Width <= proposedSize.Width) { return font; }

                // Try a smaller font (90% of old size)
                Font oldFont = font;
                font = new Font(ff, (float)(font.Size * .9), font.Style, GraphicsUnit.Pixel);
                oldFont.Dispose();
            }
        }

        #region MaterialDesignColor


        List<Color> MaterialDesignColor = new List<Color>() {
            Color.FromArgb(255, 235, 238),
            Color.FromArgb(255, 205, 210),
            Color.FromArgb(239, 154, 154),
            Color.FromArgb(229, 115, 115),
            Color.FromArgb(239, 83, 80),
            Color.FromArgb(244, 67, 54),
            Color.FromArgb(229, 57, 53),
            Color.FromArgb(211, 47, 47),
            Color.FromArgb(198, 40, 40),
            Color.FromArgb(183, 28, 28),
            Color.FromArgb(255, 138, 128),
            Color.FromArgb(255, 82, 82),
            Color.FromArgb(255, 23, 68),
            Color.FromArgb(213, 0, 0),
            Color.FromArgb(252, 228, 236),
            Color.FromArgb(248, 187, 208),
            Color.FromArgb(244, 143, 177),
            Color.FromArgb(240, 98, 146),
            Color.FromArgb(236, 64, 122),
            Color.FromArgb(233, 30, 99),
            Color.FromArgb(216, 27, 96),
            Color.FromArgb(194, 24, 91),
            Color.FromArgb(173, 20, 87),
            Color.FromArgb(136, 14, 79),
            Color.FromArgb(255, 128, 171),
            Color.FromArgb(255, 64, 129),
            Color.FromArgb(245, 0, 87),
            Color.FromArgb(197, 17, 98),
            Color.FromArgb(243, 229, 245),
            Color.FromArgb(225, 190, 231),
            Color.FromArgb(206, 147, 216),
            Color.FromArgb(186, 104, 200),
            Color.FromArgb(171, 71, 188),
            Color.FromArgb(156, 39, 176),
            Color.FromArgb(142, 36, 170),
            Color.FromArgb(123, 31, 162),
            Color.FromArgb(106, 27, 154),
            Color.FromArgb(74, 20, 140),
            Color.FromArgb(234, 128, 252),
            Color.FromArgb(224, 64, 251),
            Color.FromArgb(213, 0, 249),
            Color.FromArgb(170, 0, 255),
            Color.FromArgb(237, 231, 246),
            Color.FromArgb(209, 196, 233),
            Color.FromArgb(179, 157, 219),
            Color.FromArgb(149, 117, 205),
            Color.FromArgb(126, 87, 194),
            Color.FromArgb(103, 58, 183),
            Color.FromArgb(94, 53, 177),
            Color.FromArgb(81, 45, 168),
            Color.FromArgb(69, 39, 160),
            Color.FromArgb(49, 27, 146),
            Color.FromArgb(179, 136, 255),
            Color.FromArgb(124, 77, 255),
            Color.FromArgb(101, 31, 255),
            Color.FromArgb(98, 0, 234),
            Color.FromArgb(232, 234, 246),
            Color.FromArgb(197, 202, 233),
            Color.FromArgb(159, 168, 218),
            Color.FromArgb(121, 134, 203),
            Color.FromArgb(92, 107, 192),
            Color.FromArgb(63, 81, 181),
            Color.FromArgb(57, 73, 171),
            Color.FromArgb(48, 63, 159),
            Color.FromArgb(40, 53, 147),
            Color.FromArgb(26, 35, 126),
            Color.FromArgb(140, 158, 255),
            Color.FromArgb(83, 109, 254),
            Color.FromArgb(61, 90, 254),
            Color.FromArgb(48, 79, 254),
            Color.FromArgb(227, 242, 253),
            Color.FromArgb(187, 222, 251),
            Color.FromArgb(144, 202, 249),
            Color.FromArgb(100, 181, 246),
            Color.FromArgb(66, 165, 245),
            Color.FromArgb(33, 150, 243),
            Color.FromArgb(30, 136, 229),
            Color.FromArgb(25, 118, 210),
            Color.FromArgb(21, 101, 192),
            Color.FromArgb(13, 71, 161),
            Color.FromArgb(130, 177, 255),
            Color.FromArgb(68, 138, 255),
            Color.FromArgb(41, 121, 255),
            Color.FromArgb(41, 98, 255),
            Color.FromArgb(225, 245, 254),
            Color.FromArgb(179, 229, 252),
            Color.FromArgb(129, 212, 250),
            Color.FromArgb(79, 195, 247),
            Color.FromArgb(41, 182, 252),
            Color.FromArgb(3, 169, 244),
            Color.FromArgb(3, 155, 229),
            Color.FromArgb(2, 136, 209),
            Color.FromArgb(2, 119, 189),
            Color.FromArgb(1, 87, 155),
            Color.FromArgb(128, 216, 255),
            Color.FromArgb(64, 196, 255),
            Color.FromArgb(0, 176, 255),
            Color.FromArgb(0, 145, 234),
            Color.FromArgb(224, 247, 250),
            Color.FromArgb(178, 235, 242),
            Color.FromArgb(128, 222, 234),
            Color.FromArgb(77, 208, 225),
            Color.FromArgb(38, 198, 218),
            Color.FromArgb(0, 188, 212),
            Color.FromArgb(0, 172, 193),
            Color.FromArgb(0, 151, 167),
            Color.FromArgb(0, 131, 143),
            Color.FromArgb(0, 96, 100),
            Color.FromArgb(132, 255, 255),
            Color.FromArgb(24, 255, 255),
            Color.FromArgb(0, 229, 255),
            Color.FromArgb(0, 184, 212),
            Color.FromArgb(224, 242, 241),
            Color.FromArgb(178, 223, 219),
            Color.FromArgb(128, 203, 196),
            Color.FromArgb(77, 182, 172),
            Color.FromArgb(38, 166, 154),
            Color.FromArgb(0, 150, 136),
            Color.FromArgb(0, 137, 123),
            Color.FromArgb(0, 121, 107),
            Color.FromArgb(0, 105, 92),
            Color.FromArgb(0, 77, 64),
            Color.FromArgb(167, 255, 235),
            Color.FromArgb(100, 255, 218),
            Color.FromArgb(29, 233, 182),
            Color.FromArgb(0, 191, 165),
            Color.FromArgb(232, 245, 233),
            Color.FromArgb(200, 230, 201),
            Color.FromArgb(165, 214, 167),
            Color.FromArgb(129, 199, 132),
            Color.FromArgb(102, 187, 106),
            Color.FromArgb(76, 175, 80),
            Color.FromArgb(67, 160, 71),
            Color.FromArgb(56, 142, 60),
            Color.FromArgb(46, 125, 50),
            Color.FromArgb(27, 94, 32),
            Color.FromArgb(185, 246, 202),
            Color.FromArgb(105, 240, 174),
            Color.FromArgb(0, 230, 118),
            Color.FromArgb(0, 200, 83),
            Color.FromArgb(241, 248, 233),
            Color.FromArgb(220, 237, 200),
            Color.FromArgb(197, 225, 165),
            Color.FromArgb(174, 213, 129),
            Color.FromArgb(156, 204, 101),
            Color.FromArgb(139, 195, 74),
            Color.FromArgb(124, 179, 66),
            Color.FromArgb(104, 159, 56),
            Color.FromArgb(85, 139, 47),
            Color.FromArgb(51, 105, 30),
            Color.FromArgb(204, 255, 144),
            Color.FromArgb(178, 255, 89),
            Color.FromArgb(118, 255, 3),
            Color.FromArgb(100, 221, 23),
            Color.FromArgb(249, 251, 231),
            Color.FromArgb(240, 244, 195),
            Color.FromArgb(230, 238, 156),
            Color.FromArgb(220, 231, 117),
            Color.FromArgb(212, 225, 87),
            Color.FromArgb(205, 220, 57),
            Color.FromArgb(192, 202, 51),
            Color.FromArgb(164, 180, 43),
            Color.FromArgb(158, 157, 36),
            Color.FromArgb(130, 119, 23),
            Color.FromArgb(244, 255, 129),
            Color.FromArgb(238, 255, 65),
            Color.FromArgb(198, 255, 0),
            Color.FromArgb(174, 234, 0),
            Color.FromArgb(255, 253, 231),
            Color.FromArgb(255, 249, 196),
            Color.FromArgb(255, 245, 144),
            Color.FromArgb(255, 241, 118),
            Color.FromArgb(255, 238, 88),
            Color.FromArgb(255, 235, 59),
            Color.FromArgb(253, 216, 53),
            Color.FromArgb(251, 192, 45),
            Color.FromArgb(249, 168, 37),
            Color.FromArgb(245, 127, 23),
            Color.FromArgb(255, 255, 130),
            Color.FromArgb(255, 255, 0),
            Color.FromArgb(255, 234, 0),
            Color.FromArgb(255, 214, 0),
            Color.FromArgb(255, 248, 225),
            Color.FromArgb(255, 236, 179),
            Color.FromArgb(255, 224, 130),
            Color.FromArgb(255, 213, 79),
            Color.FromArgb(255, 202, 40),
            Color.FromArgb(255, 193, 7),
            Color.FromArgb(255, 179, 0),
            Color.FromArgb(255, 160, 0),
            Color.FromArgb(255, 143, 0),
            Color.FromArgb(255, 111, 0),
            Color.FromArgb(255, 229, 127),
            Color.FromArgb(255, 215, 64),
            Color.FromArgb(255, 196, 0),
            Color.FromArgb(255, 171, 0),
            Color.FromArgb(255, 243, 224),
            Color.FromArgb(255, 224, 178),
            Color.FromArgb(255, 204, 128),
            Color.FromArgb(255, 183, 77),
            Color.FromArgb(255, 167, 38),
            Color.FromArgb(255, 152, 0),
            Color.FromArgb(251, 140, 0),
            Color.FromArgb(245, 124, 0),
            Color.FromArgb(239, 108, 0),
            Color.FromArgb(230, 81, 0),
            Color.FromArgb(255, 209, 128),
            Color.FromArgb(255, 171, 64),
            Color.FromArgb(255, 145, 0),
            Color.FromArgb(255, 109, 0),
            Color.FromArgb(251, 233, 167),
            Color.FromArgb(255, 204, 188),
            Color.FromArgb(255, 171, 145),
            Color.FromArgb(255, 138, 101),
            Color.FromArgb(255, 112, 67),
            Color.FromArgb(255, 87, 34),
            Color.FromArgb(244, 81, 30),
            Color.FromArgb(230, 74, 25),
            Color.FromArgb(216, 67, 21),
            Color.FromArgb(191, 54, 12),
            Color.FromArgb(255, 158, 128),
            Color.FromArgb(255, 110, 64),
            Color.FromArgb(255, 61, 0),
            Color.FromArgb(221, 38, 0),
            Color.FromArgb(239, 235, 233),
            Color.FromArgb(215, 204, 200),
            Color.FromArgb(188, 170, 164),
            Color.FromArgb(161, 136, 127),
            Color.FromArgb(141, 110, 99),
            Color.FromArgb(121, 85, 72),
            Color.FromArgb(109, 76, 65),
            Color.FromArgb(93, 64, 55),
            Color.FromArgb(78, 52, 46),
            Color.FromArgb(62, 39, 35),
            Color.FromArgb(250, 250, 250),
            Color.FromArgb(245, 245, 245),
            Color.FromArgb(238, 238, 238),
            Color.FromArgb(224, 224, 224),
            Color.FromArgb(189, 189, 189),
            Color.FromArgb(158, 158, 158),
            Color.FromArgb(117, 117, 117),
            Color.FromArgb(97, 97, 97),
            Color.FromArgb(66, 66, 66),
            Color.FromArgb(33, 33, 33),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(236, 239, 241),
            Color.FromArgb(207, 216, 220),
            Color.FromArgb(176, 187, 197),
            Color.FromArgb(144, 164, 174),
            Color.FromArgb(120, 144, 156),
            Color.FromArgb(96, 125, 139),
            Color.FromArgb(84, 110, 122),
            Color.FromArgb(69, 90, 100),
            Color.FromArgb(55, 71, 79),
            Color.FromArgb(38, 50, 56)
            };

        #endregion
    }
}
