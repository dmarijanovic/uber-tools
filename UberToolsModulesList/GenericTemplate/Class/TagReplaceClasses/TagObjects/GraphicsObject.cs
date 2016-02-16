using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using  DamirM.Modules;
using DamirM.Class;
using DamirM.Controls;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Class;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Class.TagObjects
{
    class GraphicsObject
    {
        Tag2 tag;

        public GraphicsObject(Tag2 tag)
        {
            this.tag = tag;
        }

        public string ProcessTag()
        {
            string result = null;
            try
            {
                if (tag.Child.Name == "image")
                {
                    // {=graphics.image}
                    if (tag.Child.Child.Name == "analyzeanglepixels")
                    {
                        //{=graphics.image.analyzeanglepixels.[FilePath]}
                        result = AnalyzeAnglePixels(tag.Child.Child.Child.Name);
                    }
                    else if (tag.Child.Child.Name == "analyzeanglepixels_csvcolumns")
                    {
                        //{=graphics.image.analyzeanglepixels_getcsvcolumns}
                        result = "Path,FileName,Width,Height,Top,Bottom,Left,Right,BottomSize,RightSize";
                    }
                }

                // Error - not tag
                if(result == null)
                {
                    ModuleLog.Write(new string[] { TagsReplace.constError_CommandNotFound, tag.InputText }, this, "ProcessTag", ModuleLog.LogType.ERROR);
                    result = TagsReplace.constError_SyntaxError;
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { TagsReplace.constError_ExecutingBlock, tag.InputText }, this, "ProcessTag", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "ProcessTag", ModuleLog.LogType.ERROR);
                result = TagsReplace.constError_SyntaxError;
            }
            return result;
        }

        private string AnalyzeAnglePixels(string filePath)
        {
            string result = "";
            Image image;
            Bitmap bitmap;

            int topEndPixel;
            int bottomEndPixel;
            int leftEndPixel;
            int rightEndPixel;

            try
            {
                image = Image.FromFile(filePath);
                bitmap = new Bitmap(image);


                topEndPixel = AnalyzeTopImage(bitmap);
                bottomEndPixel = AnalyzeBottomImage(bitmap);
                leftEndPixel = AnalyzeLeftImage(bitmap);
                rightEndPixel = AnalyzeRightImage(bitmap);

                ModuleLog.Write(new string[] { "Top: " + topEndPixel, "Bottom: " + bottomEndPixel, "Left: " + leftEndPixel, "Right: " + rightEndPixel }, this, "AnalyzeAnglePixels", ModuleLog.LogType.DEBUG);

                result = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", filePath, Common.ExtractFileFromPath(filePath), bitmap.Width, bitmap.Height, topEndPixel, bottomEndPixel, leftEndPixel, rightEndPixel, bitmap.Height - bottomEndPixel, bitmap.Width - rightEndPixel);

                image.Dispose();
                bitmap.Dispose();
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "AnalyzeAnglePixels", ModuleLog.LogType.ERROR);
            }

            return result;
        }


        /// <summary>
        /// If deviation between two number is higher then deviation index then return false
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <param name="deviation">Max deviation</param>
        /// <returns></returns>
        private bool Deviation(byte numberOne, byte numberTwo, byte deviation)
        {
            // 4 10  - 5
            // 4 - 10 = -6 -> 6 > 5

            int sum = Math.Abs(numberOne - numberTwo);
            if (sum > deviation)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int AnalyzeTopImage(Bitmap bitmap)
        {
            Color color;

            int endPixel = 0;

            byte deviation = 10;
            byte r = 0;
            byte g = 0;
            byte b = 0;

            bool flag = false;

            // analyze top image
            for (int y = 0; y < bitmap.Height / 2; y++)
            {
                // increment j for 10% of image width
                for (int x = 0; x < bitmap.Width; x += ((bitmap.Width * 10) / 100))
                {
                    // get color object from x,y 
                    color = bitmap.GetPixel(x, y);

                    if (Deviation(r, color.R, deviation) && Deviation(g, color.G, deviation) && Deviation(b, color.B, deviation))
                    {
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        // new color is similar to new coler
                    }
                    else
                    {
                        if (y > 0)
                        {
                            endPixel = y;
                            flag = true;
                            ModuleLog.Write(new string[] { "Deviation: " + deviation, "Old RGB:" + r + ":" + g + ":" + b, "New RGB: " + color.R + ":" + color.G + ":" + color.B }, this, "AnalyzeTopImage", ModuleLog.LogType.DEBUG);
                            break;
                        }
                        else
                        {
                            // set default colors
                            r = color.R;
                            g = color.G;
                            b = color.B;
                        }
                    }
                }

                if (flag) { break; }
            }

            return endPixel;
        }
        private int AnalyzeBottomImage(Bitmap bitmap)
        {
            Color color;

            int endPixel = 0;

            byte deviation = 10;
            byte r = 0;
            byte g = 0;
            byte b = 0;

            bool flag = false;

            // analyze top image
            for (int y = bitmap.Height - 1; y > bitmap.Height / 2; y--)
            {
                // increment j for 10% of image width
                for (int x = 0; x < bitmap.Width; x += ((bitmap.Width * 10) / 100))
                {
                    // get color object from x,y 
                    color = bitmap.GetPixel(x, y);

                    if (Deviation(r, color.R, deviation) && Deviation(g, color.G, deviation) && Deviation(b, color.B, deviation))
                    {
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        // new color is similar to new coler
                    }
                    else
                    {
                        if (y < bitmap.Height - 1)
                        {
                            endPixel = y;
                            flag = true;
                            ModuleLog.Write(new string[] { "Deviation: " + deviation, "Old RGB:" + r + ":" + g + ":" + b, "New RGB: " + color.R + ":" + color.G + ":" + color.B }, this, "AnalyzeBottomImage", ModuleLog.LogType.DEBUG);
                            break;
                        }
                        else
                        {
                            // set default colors
                            r = color.R;
                            g = color.G;
                            b = color.B;
                        }
                    }
                }

                if (flag) { break; }
            }

            return endPixel;
        }
        private int AnalyzeLeftImage(Bitmap bitmap)
        {
            Color color;

            int endPixel = 0;

            byte deviation = 10;
            byte r = 0;
            byte g = 0;
            byte b = 0;

            bool flag = false;

            // analyze top image
            for (int x = 0; x < bitmap.Width / 2; x++)
            {
                // increment j for 10% of image width
                for (int y = 0; y < bitmap.Height; y += ((bitmap.Height * 10) / 100))
                {
                    // get color object from x,y 
                    color = bitmap.GetPixel(x, y);

                    if (Deviation(r, color.R, deviation) && Deviation(g, color.G, deviation) && Deviation(b, color.B, deviation))
                    {
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        // new color is similar to new coler
                    }
                    else
                    {
                        if (x > 0)
                        {
                            endPixel = x;
                            flag = true;
                            ModuleLog.Write(new string[] { "Deviation: " + deviation, "Old RGB:" + r + ":" + g + ":" + b, "New RGB: " + color.R + ":" + color.G + ":" + color.B }, this, "AnalyzeLeftImage", ModuleLog.LogType.DEBUG);
                            break;
                        }
                        else
                        {
                            // set default colors
                            r = color.R;
                            g = color.G;
                            b = color.B;
                        }
                    }
                }

                if (flag) { break; }
            }

            return endPixel;
        }
        private int AnalyzeRightImage(Bitmap bitmap)
        {
            Color color;

            int endPixel = 0;

            byte deviation = 10;
            byte r = 0;
            byte g = 0;
            byte b = 0;

            bool flag = false;

            // analyze top image
            for (int x = bitmap.Width - 1; x > bitmap.Width / 2; x--)
            {
                // increment j for 10% of image width
                for (int y = 0; y < bitmap.Height; y += ((bitmap.Height * 10) / 100))
                {
                    // get color object from x,y 
                    color = bitmap.GetPixel(x, y);

                    if (Deviation(r, color.R, deviation) && Deviation(g, color.G, deviation) && Deviation(b, color.B, deviation))
                    {
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        // new color is similar to new coler
                    }
                    else
                    {
                        if (x < bitmap.Width - 1)
                        {
                            endPixel = x;
                            flag = true;
                            ModuleLog.Write(new string[] { "Deviation: " + deviation, "Old RGB:" + r + ":" + g + ":" + b, "New RGB: " + color.R + ":" + color.G + ":" + color.B }, this, "AnalyzeRightImage", ModuleLog.LogType.DEBUG);
                            break;
                        }
                        else
                        {
                            // set default colors
                            r = color.R;
                            g = color.G;
                            b = color.B;
                        }
                    }
                }

                if (flag) { break; }
            }

            return endPixel;
        }

    }
}
