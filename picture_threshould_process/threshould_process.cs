using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using System.IO;

namespace picture_threshould_process
{
    public partial class threshould_process : Form
    {
        ZBar.ImageScanner Image_Barcode_Scanner;
        static int[,] grayArray;
        static String filename = "";
        static String filepath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\";
        
        Bitmap Original_bitmap;
        Bitmap Gray_Barcode_Bitmap;
        int[] histogramd;
        int[] histogram;
        Stopwatch sw = new Stopwatch();
        long time = 0;

        public threshould_process()
        {
            InitializeComponent();
        }
        /*
         * Button2 is ImageLoading and For barcode detection
         */
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Image_Barcode_Scanner = new ZBar.ImageScanner();
                if (Original_bitmap == null) return;
                picBarcode.Image = Original_bitmap;

                List<ZBar.Symbol> Result = Image_Barcode_Scanner.Scan(Original_bitmap);
                foreach (var item in Result)
                {
                    textBox1.Text += item.Data;
                    textBox1.Text += ", ";
                }

                lblmsg.Text = "find barcode count:" + Result.Count;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please check the path to the image file again!");
            }
        }
        /*
         * Button3 is picture grey process and Threshould
         */
        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox2.Text = "";
            textBox3.Text = "";
            if (Original_bitmap == null)
            {
                Original_bitmap = new Bitmap(picBarcode.Image);
                filename = "fast-45cm-rota.png";
            }
            
            String histo_Barcode_Bitmap_Savepath = filepath + @"histo\";
            String histo_Barcode_Bitmap_SaveFilename = "histo_process_" + filename;

            sw.Start(); //kesu

            //82millise
            Gray_Barcode_Bitmap = Gray_process(Original_bitmap);
            Bitmap histo_Bitmap = histogram_process(grayArray, Original_bitmap.Width, Original_bitmap.Height);
            //82millise
            
            DirectoryInfo di = new DirectoryInfo(histo_Barcode_Bitmap_Savepath);
            if (di.Exists == false)
            {
                di.Create();
                histo_Bitmap.Save(histo_Barcode_Bitmap_Savepath + histo_Barcode_Bitmap_SaveFilename);
            }
            else
            {
                histo_Bitmap.Save(histo_Barcode_Bitmap_Savepath + histo_Barcode_Bitmap_SaveFilename);
            }
            graph_picture.Image = histo_Bitmap;
            
            threshould_Barcode_check(histo_Bitmap);
            
        }
        
        /*
         * threshould処理した写真のバーコードテスト
         */
        public void threshould_Barcode_check(Bitmap bmp)
        {
            String threshold_Barcode_Bitmap_Savepath = filepath + @"threshold\";
            String threshold_Barcode_Bitmap_SaveFilename = "threshold_" + filename;
            Mat threshold_Barcode_Bitmap = new Mat();
            
            //int thres_1 = ThresholdByIsoData(histogramd);
            int thres = ColorAverage(Gray_Barcode_Bitmap);
            //int thres = (thres_1 + thres_2) / 2;
            
            Mat gBitmap_mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(Gray_Barcode_Bitmap);
            int second = 255;

                Cv2.MorphologyDefaultBorderValue();
                ThresholdTypes thresholdTypes = ThresholdTypes.Binary;
                Cv2.Threshold(gBitmap_mat, threshold_Barcode_Bitmap, thres, second, thresholdTypes);

                DirectoryInfo di = new DirectoryInfo(threshold_Barcode_Bitmap_Savepath);
                if (di.Exists == false)
                {
                    di.Create();
                    threshold_Barcode_Bitmap.SaveImage(threshold_Barcode_Bitmap_Savepath + threshold_Barcode_Bitmap_SaveFilename);
                }
                else
                {
                    threshold_Barcode_Bitmap.SaveImage(threshold_Barcode_Bitmap_Savepath + threshold_Barcode_Bitmap_SaveFilename);
                }
                Bitmap threshold_Barcode_test_Bitmap = new Bitmap(threshold_Barcode_Bitmap_Savepath + threshold_Barcode_Bitmap_SaveFilename);
                Threshould_image.Image = threshold_Barcode_test_Bitmap;
                ZBar.ImageScanner ise = new ZBar.ImageScanner();

                List<ZBar.Symbol> lsst2 = ise.Scan(Gray_Barcode_Bitmap);
                List<ZBar.Symbol> lsst3 = ise.Scan(threshold_Barcode_test_Bitmap);
            
            foreach (var item in lsst2)
                {
                    textBox2.Text = item.Data;
                }
                foreach (var item in lsst3)
                {
                    textBox3.Text = item.Data;
                }
                
                    lblmsg.Text = "find by histogram: lsst2.count=" + lsst2.Count + ", lsst3.count=" + lsst3.Count;


           
            //GodGodhistohisto(Gray_Barcode_Bitmap);
        }

        //class mydata : IComparable<mydata>
        //{
        //    public int histo;
        //    public int index;
        //    public int CompareTo(mydata that)
        //    {
        //        if (that == null) return 1;
        //        if (this.histo < that.histo) return 1;
        //        if (this.histo > that.histo) return -1;
        //        return 0;
        //    }
        //}

        //public void GodGodhistohisto(Bitmap bmp)
        //{
        //    List<mydata> lst = new List<mydata>();
        //    for (int i = 0; i < histogram.Length; i++)
        //    {
        //        mydata d1 = new mydata();
        //        d1.histo = histogram[i];
        //        d1.index = i;
        //        lst.Add(d1);
        //    }
        //    lst.Sort(delegate (mydata p1, mydata p2) { return p1.CompareTo(p2); });
        //    int[] grade = histogram;

        //    int[] histo_index = new int[5];
        //    Array.Sort(grade);
        //    Array.Reverse(grade);
        //    foreach (var item in lst)
        //    {
        //        Debug.WriteLine(item.index.ToString());

        //    }
        //    for(int i = 0; i < histo_index.Length; i++)
        //    {

        //        histo_index[i] = Array.BinarySearch(histogram, grade[i]);
        //        Debug.WriteLine("histo_index[" + i + "] : " + histo_index[i]);
        //    }
            


        //}
        /*
         * 写真をGray色に設定するために必要
         */
        public Bitmap Gray_process(Bitmap bmp)
        {
            String Gray_Barcode_Bitmap_Savepath = filepath + @"GrayBarcodeBit\";
            String Gray_Barcode_Bitmap_SaveFilename = "gray_process_" + filename;
            int x, y, brightness;
            Color color;
            grayArray = new int[Original_bitmap.Height, Original_bitmap.Width];
            //Graphics gr = CreateGraphics();
            Bitmap gBitmap = new Bitmap(Original_bitmap);
            for (x = 0; x < Original_bitmap.Width; x++)
            {
                for (y = 0; y < Original_bitmap.Height; y++)
                {
                    color = gBitmap.GetPixel(x, y);
                    brightness = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    grayArray[y, x] = brightness;
                }
            }
            for (x = 0; x < Original_bitmap.Width; x++)
            {
                for (y = 0; y < Original_bitmap.Height; y++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    gBitmap.SetPixel(x, y, color);
                }
            }
            // gr.DrawImage(gBitmap, 10, Original_bitmap.Height + 60, gBitmap.Width, gBitmap.Height);
            //gr.Dispose();
            picThres.Image = gBitmap;

            DirectoryInfo di = new DirectoryInfo(Gray_Barcode_Bitmap_Savepath);
            if(di.Exists == false)
            {
                di.Create();
                gBitmap.Save(Gray_Barcode_Bitmap_Savepath + Gray_Barcode_Bitmap_SaveFilename);
            }
            else
            {
                gBitmap.Save(Gray_Barcode_Bitmap_Savepath + Gray_Barcode_Bitmap_SaveFilename);
            }
           

            return gBitmap;
        }
        /**
        * @param : int[,] histoArray - graphの実際できな情報が保存されます。
        *        , int Width - graphが描きされるBackgroundのWidth 
        *        , int Height - graphが描きされるBackgroundのHeight
        * @return : Bitmap 後の処理を行うかもしれないので一段returnします。
        * @TODO : もし後でreturnする必要ないならreturnは消していいです。
        * @deprecated : histogramを描きます。
        */
        public Bitmap histogram_process(int[,] histoArray, int Width, int Height)
        {
            const int HISTO_WIDTH = 256;
            const int HISTO_HEIGHT = 240;
            int x, y;
            Color color;
            Bitmap histo_Barcode_bitmap;
            histo_Barcode_bitmap = new Bitmap(HISTO_WIDTH, HISTO_HEIGHT);
            histogram = new int[256]; // histogram array Declaration
            histogram.Initialize();         // histogram array 0 reset
            int max_cnt = 0;      // The most pixels
            histogramd = histogram;
            // histogram
            for (y = 0; y < Height; y++)
                for (x = 0; x < Width; x++)
                    histogram[histoArray[y, x]]++;
            // The most number of pixels
            for (x = 0; x < HISTO_WIDTH; x++)
                if (histogram[x] > max_cnt)
                    max_cnt = histogram[x];
            // histogram background
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                for (y = 0; y < HISTO_HEIGHT; y++)
                {
                    color = Color.FromArgb(125, 125, 125);
                    histo_Barcode_bitmap.SetPixel(x, y, color);
                }
            }
            // histogram rod
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                double dHeight = (double)histogram[x] * (HISTO_HEIGHT - 1) / (double)max_cnt;
                for (y = 0; y < (int)dHeight; y++)
                {
                    color = Color.FromArgb(0, 0, 0);
                    histo_Barcode_bitmap.SetPixel(x, (HISTO_HEIGHT - 1) - y, color);
                }
            }
            int sum = 0;
            int amax = histogram.Max();
            for(int i = 0; i < histogram.Length; i++)
            {
                //Debug.WriteLine("histogram[" + i + "] : " + histogram[i]);
                sum = sum + histogram[i];
            }
            //Debug.WriteLine("histogram sum : " + sum);
            
            return histo_Barcode_bitmap;
        }
        /**
       * @param : int[,] histogram
       * @deprecated : 正しいThresholdValueを計算
       */
        public static int ThresholdByIsoData(int[] histogram)
        {
            int bef = histogram.Length / 2;
            while (true)
            {
                int sumL = 0;
                int countL = 0;
                int sumR = 0;
                int countR = 0;
                for (int i = 0; i < bef; i++)
                {
                    sumL += histogram[i] * i;
                    countL += histogram[i];
                }
                for (int i = bef; i < histogram.Length; i++)
                {
                    sumR += histogram[i] * i;
                    countR += histogram[i];
                }

                if (countR == 0)
                {
                    countR++;
                }
                if (countL == 0)
                {
                    countL++;
                }

                int cur = (sumL / countL + sumR / countR) / 2;
                if (cur == bef)
                {
                    break;
                }
                else
                {
                    bef = cur;
                }
            }
            return bef;
        }
        /**
         *  @param : Bitmap src
         *           int amp
         *  @deprecated : ampによってfilterのlevelが決められるのでいろいろ試してくれ
         *                今は使ってないです。
         *                後で使う可能性あるので残っております。
         */
        public Bitmap highfilter(Bitmap src, int amp)
        {
            int high_filter_Level = 3;
            String hfilename = "high_" + filename;
            String hfilepath = filepath + @"highfiltertest\result\level" + high_filter_Level + "_";
            int i, j, iColorValue;
            int[] iFilter = new int[] { -1, -1, -1, -1, 8, -1, -1, -1, -1 };
            int[,] iArrayValue = new int[src.Width, src.Height];
            Color[] cArrayColor = new Color[9];
            Color color;
            for (i = 1; i < src.Width - 1; i++)

                for (j = 1; j < src.Height - 1; j++)
                {
                    cArrayColor[0] = src.GetPixel(i - 1, j - 1);
                    cArrayColor[1] = src.GetPixel(i - 1, j);
                    cArrayColor[2] = src.GetPixel(i - 1, j + 1);
                    cArrayColor[3] = src.GetPixel(i, j - 1);
                    cArrayColor[4] = src.GetPixel(i, j);
                    cArrayColor[5] = src.GetPixel(i, j + 1);
                    cArrayColor[6] = src.GetPixel(i + 1, j - 1);
                    cArrayColor[7] = src.GetPixel(i + 1, j);
                    cArrayColor[8] = src.GetPixel(i + 1, j + 1);

                    //filter
                    iColorValue = iFilter[0] * cArrayColor[0].R + iFilter[1] * cArrayColor[1].R +

                    iFilter[2] * cArrayColor[2].R + iFilter[3] *

                    cArrayColor[3].R + iFilter[4] * cArrayColor[4].R +

                    iFilter[5] * cArrayColor[5].R + iFilter[6] *

                    cArrayColor[6].R + iFilter[7] * cArrayColor[7].R +

                    iFilter[8] * cArrayColor[8].R;

                    //出力結果はLevelによって違う
                    iColorValue = amp * iColorValue;   // Level 設定
                    if (iColorValue < 0)
                        iColorValue = -iColorValue;
                    if (iColorValue > 255)
                        iColorValue = 255;
                    iArrayValue[i, j] = iColorValue;
                }
            for (i = 1; i < src.Width - 1; i++)
                for (j = 1; j < src.Height - 1; j++)
                {
                    color = Color.FromArgb(iArrayValue[i, j], iArrayValue[i, j],
                               iArrayValue[i, j]); //色設定
                    src.SetPixel(i, j, color);
                }
            return src;
        }
        /**
        * @param : Bitmap bmp ,
        *          String filepath ,
        *          String filename ,
        *          String filetype ,
        * @deprecated : オリジナルとの類似度をチェックするためです今は使ってないけど
        *               後で使う可能性高いので残ります。
        */
        public Bitmap ResemblanceCheck(Bitmap bmp, String filepath, String filename, String filetype)
        {
            Mat Screen = null, find = null, res = null;
            String filepathres = filepath + filename + filetype;
            try
            {
                Screen = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);
                find = OpenCvSharp.Extensions.BitmapConverter.ToMat(new Bitmap(filepathres));

                res = Screen.MatchTemplate(find, TemplateMatchModes.CCoeffNormed);

                double min, max = 0;
                Cv2.MinMaxLoc(res, out min, out max);

                //Debug.WriteLine("search : " + max);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString() + "ERROROROROROROROROROROROROORORORORORORORORORORORORORO");
            }
            finally
            {
                Screen.Dispose();
                find.Dispose();
                res.Dispose();
            }

            return bmp;
        }
        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "jpg";
            openFile.Filter = "All files(*.*)|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length > 0)
            {
                Original_bitmap = new Bitmap(openFile.FileName);
                filename = Path.GetFileName(openFile.FileName);
            }
        }
        public int ColorAverage(Bitmap bmp)
        {
            int sum = 0;
            int nanu = 0;
            for(int i = 0; i < histogram.Length; i++)
            {
                if(histogram[i] != 0)
                {
                    sum = sum + i;
                    nanu++;
                }
            }

            return sum/nanu;
            //int Width = bmp.Width;
            //int Height = bmp.Height;
            //long sum = 0;
            //for(int i = 0; i < Width; i++)
            //{
            //    for (int j = 0; j < Height; j++)
            //    {
            //        Color color = bmp.GetPixel(i, j);
            //        sum = sum + (color.R + color.G + color.B);
            //    }
                
            //}
            //int avg = (int)(sum / (Width * Height));
            //Debug.WriteLine("avg/3 : " + avg/3);
            
            //return avg/3;
        }
    }
}

