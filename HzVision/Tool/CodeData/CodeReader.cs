using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HalconDotNet;
using Vision;

namespace Vision.Tool.CodeData
{
    [Serializable]
    public class CodeReader 
    {
        [NonSerialized]
        HRegion _serachRegion = new HRegion();
        bool _DateCodeTimeOut = true;
        int _DateCodeTimeOutValue = 2000;
        int _DateCodeRate = 1;
        [NonSerialized]
        HDataCode2D _CodeReaderHand;

        


        public HDataCode2D CodeReaderHand { get { return _CodeReaderHand; } set { _CodeReaderHand = value; } }
        public HRegion SearchRegion { get { return _serachRegion; }
        set {
                _serachRegion.Dispose();
                _serachRegion = value;
            }
        }

        public bool DateCodeTimeOut
        {
            get
            {
                return _DateCodeTimeOut;
            }
            set
            {
                _DateCodeTimeOut = value;
                HTuple val = _DateCodeTimeOut ? (HTuple)DateCodeTimeOutValue : (HTuple)"false";
                CodeReaderHand.SetDataCode2dParam((HTuple)"timeout", val);
            }
        }
        public int DateCodeTimeOutValue
        {
            get { return _DateCodeTimeOutValue; }
            set
            {
                _DateCodeTimeOutValue = value;
                HTuple val = _DateCodeTimeOut ? (HTuple)DateCodeTimeOutValue : (HTuple)"false";
                CodeReaderHand.SetDataCode2dParam((HTuple)"timeout", val);
            }
        }
        public float DateCodeZoomImg { get; set; }

        public int DateCodeRate
        {
            get { return _DateCodeRate; }
            set
            {
                if (_DateCodeRate == value)
                {
                    return;
                }

                switch (value)
                {
                    case 1:
                        CodeReaderHand.SetDataCode2dParam("default_parameters", "standard_recognition");
                        break;
                    case 2:
                        CodeReaderHand.SetDataCode2dParam("default_parameters", "enhanced_recognition");
                        break;
                    case 3:
                        CodeReaderHand.SetDataCode2dParam("default_parameters", "maximum_recognition");
                        break;
                    default:

                        return;
                }
                _DateCodeRate = value;
            }
        }

        public bool UseBrighten { get; set; }
        public float UseBrightenValue { get; set; }

        public CodeReader()
        {
            _CodeReaderHand = new HDataCode2D("Data Matrix ECC 200", new HTuple(), new HTuple());
            //_CodeReaderHand = new HDataCode2D("QR Code", new HTuple(), new HTuple());

            _CodeReaderHand.SetDataCode2dParam("default_parameters", "standard_recognition");
            DateCodeZoomImg = 1f;

            DateCodeTimeOut = true;
            UseBrightenValue = 1.5f;
        }

        [NonSerialized]
        public string DataCodeString = string.Empty;
        [NonSerialized]
        public HXLDCont DataCodeContour = new HXLDCont();

        public bool FindDataCode(HImage img, bool train = false)
        {
            if (!SearchRegion.IsInitialized())
            {
                SearchRegion = img.GetDomain();
            }

            if (!train)
            {
                Display(1);
            }
           

            HImage reduceImg = img.ReduceDomain(SearchRegion);
            HImage searchImg = reduceImg.CropDomain();
            reduceImg.Dispose();

            int width, height;
            searchImg.GetImageSize(out width, out height);
           
            HImage zoomImg = searchImg.ZoomImageFactor(DateCodeZoomImg, DateCodeZoomImg, "constant");
            DataCodeContour.Dispose();
            searchImg.Dispose();

            HTuple ResultHandles, DecodedDataStrings;
            if (train)
            {
                DataCodeContour = CodeReaderHand.FindDataCode2d(zoomImg, "train", "all", out ResultHandles, out DecodedDataStrings);
            }
            else
            {
                DataCodeContour = CodeReaderHand.FindDataCode2d(zoomImg, "stop_after_result_num", 1, out ResultHandles, out DecodedDataStrings);
            }


            if (DecodedDataStrings.Length > 0)
            {
                DataCodeString = DecodedDataStrings[0].S;

                HHomMat2D mat = new HHomMat2D();
                HHomMat2D scalMat= mat.HomMat2dScale(1 / DateCodeZoomImg, 1 / DateCodeZoomImg, 0.0, 0.0);
                double row, col;
                SearchRegion.AreaCenter(out row, out col);
                HHomMat2D tranMat = scalMat.HomMat2dTranslate(row - height / 2.0, col - width / 2.0);

                HXLDCont tranDataCodeContour= tranMat.AffineTransContourXld(DataCodeContour);
                DataCodeContour.Dispose();
                DataCodeContour = tranDataCodeContour;

                if (!train)
                {
                    Display(2);
                    Display(3);
                }
               
            }
            else
            {
                if (UseBrighten)
                {
                    HImage brightenImg = zoomImg.ScaleImage(UseBrightenValue, 0.0);
                    DataCodeContour = CodeReaderHand.FindDataCode2d(brightenImg, "stop_after_result_num", 1, out ResultHandles, out DecodedDataStrings);
                    if (DecodedDataStrings.Length > 0)
                    {
                        DataCodeString = DecodedDataStrings[0].S;

                        HHomMat2D mat = new HHomMat2D();
                        HHomMat2D scalMat = mat.HomMat2dScale(1 / DateCodeZoomImg, 1 / DateCodeZoomImg, 0.0, 0.0);
                        double row, col;
                        SearchRegion.AreaCenter(out row, out col);
                        HHomMat2D tranMat = scalMat.HomMat2dTranslate(row - height / 2.0, col - width / 2.0);

                        HXLDCont tranDataCodeContour = tranMat.AffineTransContourXld(DataCodeContour);
                        DataCodeContour.Dispose();
                        DataCodeContour = tranDataCodeContour;
                        if (!train)
                        {
                            Display(2);
                            Display(3);
                        }

                        return true;
                    }       
                }



                DataCodeString = string.Empty;
               
                if (!train)
                {
                    Display(4);
                }
                return false;
            }



            return true;
        }

        public bool FindDataCode(HImage img,HRegion region, bool train = false)
        {
            if (!region.IsInitialized())
            {
                region = img.GetDomain();
            }

            if (!train)
            {
                Display(0, region);
            }


            HImage reduceImg = img.ReduceDomain(region);
            HImage searchImg = reduceImg.CropDomain();
            reduceImg.Dispose();

            int width, height;
            searchImg.GetImageSize(out width, out height);

            HImage zoomImg = searchImg.ZoomImageFactor(DateCodeZoomImg, DateCodeZoomImg, "constant");
            DataCodeContour.Dispose();
            searchImg.Dispose();

            HTuple ResultHandles, DecodedDataStrings;
            if (train)
            {
                DataCodeContour = CodeReaderHand.FindDataCode2d(zoomImg, "train", "all", out ResultHandles, out DecodedDataStrings);
            }
            else
            {
                DataCodeContour = CodeReaderHand.FindDataCode2d(zoomImg, "stop_after_result_num", 1, out ResultHandles, out DecodedDataStrings);
            }


            if (DecodedDataStrings.Length > 0)
            {
                DataCodeString = DecodedDataStrings[0].S;

                HHomMat2D mat = new HHomMat2D();
                HHomMat2D scalMat = mat.HomMat2dScale(1 / DateCodeZoomImg, 1 / DateCodeZoomImg, 0.0, 0.0);
                double row, col;
                region.AreaCenter(out row, out col);
                HHomMat2D tranMat = scalMat.HomMat2dTranslate(row - height / 2.0, col - width / 2.0);

                HXLDCont tranDataCodeContour = tranMat.AffineTransContourXld(DataCodeContour);
                DataCodeContour.Dispose();
                DataCodeContour = tranDataCodeContour;

                if (!train)
                {
                    Display(2);
                    Display(3);
                }

            }
            else
            {
                if (UseBrighten)
                {
                    HImage brightenImg = zoomImg.ScaleImage(UseBrightenValue, 0.0);
                    DataCodeContour = CodeReaderHand.FindDataCode2d(brightenImg, "stop_after_result_num", 1, out ResultHandles, out DecodedDataStrings);
                    if (DecodedDataStrings.Length > 0)
                    {
                        DataCodeString = DecodedDataStrings[0].S;

                        HHomMat2D mat = new HHomMat2D();
                        HHomMat2D scalMat = mat.HomMat2dScale(1 / DateCodeZoomImg, 1 / DateCodeZoomImg, 0.0, 0.0);
                        double row, col;
                        region.AreaCenter(out row, out col);
                        HHomMat2D tranMat = scalMat.HomMat2dTranslate(row - height / 2.0, col - width / 2.0);

                        HXLDCont tranDataCodeContour = tranMat.AffineTransContourXld(DataCodeContour);
                        DataCodeContour.Dispose();
                        DataCodeContour = tranDataCodeContour;
                        if (!train)
                        {
                            Display(2);
                            Display(3);
                        }

                        return true;
                    }
                }



                DataCodeString = string.Empty;

                if (!train)
                {
                    Display(4);
                }
                return false;
            }



            return true;
        }

        [OnDeserialized()]
        private void OnDeserializedMethod(StreamingContext context)
        {
            _CodeReaderHand = new HDataCode2D("Data Matrix ECC 200", new HTuple(), new HTuple());
            //_CodeReaderHand = new HDataCode2D("QR Code", new HTuple(), new HTuple());

            _CodeReaderHand.SetDataCode2dParam("default_parameters", "standard_recognition");
            _serachRegion = new HRegion();
            DataCodeString = string.Empty;
            DataCodeContour = new HXLDCont();
            DisplayControl = new List<HWindowControl>();
        }


        void Display(int state, HObject obj = null)
        {
            if (DisplayControl.Count == 0) return;

            switch (state)
            {
                case 0:
                    foreach (var v in DisplayControl)
                    {
                        v.HalconWindow.SetColor("blue");
                        v.HalconWindow.SetDraw("margin");
                        v.HalconWindow.DispObj(obj);
                    }

                    break;

                case 1:
                    foreach (var v in DisplayControl)
                    {
                        v.HalconWindow.SetColor("blue");
                        v.HalconWindow.SetDraw("margin");
                        v.HalconWindow.DispObj(SearchRegion);
                    }
                    break;
                case 2:
                    foreach (var v in DisplayControl)
                    {
                        v.HalconWindow.SetColor("green");
                        v.HalconWindow.SetDraw("margin");
                        v.HalconWindow.DispObj(DataCodeContour);
                    }
                    break;
                case 3:
                    foreach (var v in DisplayControl)
                    {
                        InternalMethod.disp_message(v.HalconWindow, DataCodeString, "image", 20, 20, "green", "false");
                    }
                    break;
                case 4:
                    foreach (var v in DisplayControl)
                    {
                        InternalMethod.disp_message(v.HalconWindow, "没有找到", "image", 20, 20, "red", "false");
                    }
                    break;
            }

        }



        [NonSerialized]
        CodeReaderControl form;
        public void ShowSetting(HImage img=null)
        {
            if (form == null || !form.Created)
            {
                form = new CodeReaderControl(this);
                form.TopLevel = true;
                form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

                if (img != null&& img.IsInitialized())
                {
                    form.InitImage(img);
                }

                form.Show();
            }
            else
            {
                form.BringToFront();
            }

            
        }


        public void WriteHalconObj(string fileName)
        {
            if (CodeReaderHand.Handle.ToInt32() > 0)
            {
                CodeReaderHand.WriteDataCode2dModel(fileName + ".dcm");
            }

            if (SearchRegion.IsInitialized())
            {
                SearchRegion.WriteRegion(fileName + ".hobj");
            }

        }

        public bool ReadHalconObj(string fileName)
        {
            bool state = true;
            if (System.IO.File.Exists(fileName + ".dcm"))
            {
                CodeReaderHand.ReadDataCode2dModel(fileName + ".dcm");
            }
            else
            {
                state = false;
            }

            if (System.IO.File.Exists(fileName + ".hobj"))
            {
                SearchRegion.ReadRegion(fileName + ".hobj");
            }
            else
            {
                state = false;
            }

            return state;
        }

        [NonSerialized]
        List<HWindowControl> DisplayControl = new List<HWindowControl>();
        public void AddDisplayControl(HWindowControl ctrl)
        {
            if (ctrl != null && !DisplayControl.Contains(ctrl)) DisplayControl.Add(ctrl);
        }

        public void RemoveDisplayControl(HWindowControl ctrl)
        {
            DisplayControl.Remove(ctrl);
        }
    }
}
