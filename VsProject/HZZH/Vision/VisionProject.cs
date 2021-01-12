using HalconDotNet;
using HzVision.Device;
using ProVision.InteractiveROI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using Vision.Tool;
using Vision.Tool.Calibrate;
using Vision.Tool.Model;
using System.IO;

namespace HZZH.Vision
{
    public class VisionProject
    {
        #region 静态单例

        private static VisionProject _instance = new VisionProject();

        private VisionProject()
        {
            InitVisionProject();
        }

        public static VisionProject Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion 静态单例



        public VisionTool Tool { get; set; }  




        public void InitVisionProject()
        {
            HOperatorSet.SetSystem("width", 9999);
            HOperatorSet.SetSystem("height", 9999);
            HOperatorSet.SetSystem("border_shape_models", "false");
            HOperatorSet.SetSystem("pregenerate_shape_models", "true");
            Tool = new VisionTool();
        }



        #region  模板等工具的存储
        public void SaveTool(string fileName)
        {
            string path = Path.GetDirectoryName(fileName);

            Serialization.SaveToXml(Tool.Calibs[0], path + "\\calib0.xml", true);
            Serialization.SaveToXml(Tool.Calibs[1], path + "\\calib1.xml", true);

            Tool.Shapes[0].WriteHalconObj(path + "\\model\\model0");
            Tool.Shapes[1].WriteHalconObj(path + "\\model\\model1");
            Tool.Shapes[2].WriteHalconObj(path + "\\model\\model2");
            Tool.Shapes[3].WriteHalconObj(path + "\\model\\model3");
        }
        public void LoadTool(string fileName)
        {
            string path = Path.GetDirectoryName(fileName);
            var va0 = Serialization.LoadFromXml(Tool.Calibs[0].GetType(), path + "\\calib0.xml")   ;
            if (va0 != null)
            {
                this.Tool.Calibs[0] = (CalibPointToPoint)va0;
            }
            var va1 = Serialization.LoadFromXml(Tool.Calibs[1].GetType(), path + "\\calib1.xml");
            if (va1 != null)
            {
                this.Tool.Calibs[1] = (CalibPointToPoint)va1;
            }

            Tool.Shapes[0].ReadHalconObj(path + "\\model\\model0");
            Tool.Shapes[1].ReadHalconObj(path + "\\model\\model1");
            Tool.Shapes[2].ReadHalconObj(path + "\\model\\model2");
            Tool.Shapes[3].ReadHalconObj(path + "\\model\\model3");

        }
        #endregion


        #region 模板操作

        private void SetTempleteModel(ShapeModel shape, HImage img)
        {
            if (img != null)
            {
                if (shape.InputImg != null)
                {
                    shape.InputImg.Dispose();
                }
                shape.InputImg = img;
                shape.ShowSetting();
            }
        }

        private void SetTempleteModel(NCCModel nCC, HImage img)
        {
            if (img != null)
            {
                if (nCC.InputImg != null)
                {
                    nCC.InputImg.Dispose();
                }
                nCC.InputImg = img;
                nCC.ShowSetting();
            }
        }

        public void SetTempleteModel(int id, HImage img = null)
        {
            if (img == null) img = CameraMgr.Inst[id].GetCurrentImage();
            if (!Tool.Shapes.ContainsKey(id))
            {
                Tool.Shapes[id] = new ShapeModel();
            }
            SetTempleteModel(Tool.Shapes[id], img);
        }

        #endregion


        #region  为了显示
        private MainCamera[] mainCamera = new MainCamera[3];
        public void SetMainCamera(int index, MainCamera cam)
        {
            if (mainCamera[index] != null)
            {
                mainCamera[index].Draw -= VisionProject_Draw;
            }
            mainCamera[index] = cam;
            if (mainCamera[index] != null)
            {
                mainCamera[index].Draw += VisionProject_Draw;
            }
        }


        void VisionProject_Draw(object sender, DrawEventArgs e)
        {
            int index = Array.IndexOf(mainCamera, sender);
            if (index >= 0 && index <= 2)
            {
                if (this.Tool.Shapes[index].OutputResult.Count > 0)
                {
                    e.HWindow.SetColor("green");
                    e.HWindow.SetLineWidth(1);
                    for (int i = 0; i < Tool.Shapes[index].OutputResult.Count; i++)
                    {
                        e.HWindow.DispCross(this.Tool.Shapes[index].OutputResult.Row[i].D,
                            this.Tool.Shapes[index].OutputResult.Col[i].D,
                            80.0,
                            0.0);
                    }

                    HObject hObject = this.Tool.Shapes[index].GetMatchModelCont();
                    e.HWindow.DispObj(hObject);
                    hObject.Dispose();
                }
            }
        }
        #endregion

        readonly object locker = new object();

        public Point3[] FindTempleteModel(int caneraId, int modelId)
        {
            CameraMgr.Inst[caneraId].CameraSoft();

            if( CameraMgr.Inst[caneraId].WaiteGetImage(1000)==false)
            {
                Tool.Shapes[caneraId].OutputResult.Count = 0;
                return new Point3[0];
            }


            lock (locker)
            {
                HImage image = CameraMgr.Inst[caneraId].GetCurrentImage();
                List<Point3> list = new List<Point3>();
                try
                {
                    if (Tool.Shapes[modelId].InputImg != null)
                    {
                        Tool.Shapes[modelId].InputImg.Dispose();
                    }
                    Tool.Shapes[modelId].InputImg = image;
                    Tool.Shapes[modelId].FindModel();
                    ShapeMatchResult match = Tool.Shapes[modelId].OutputResult;

                    if (mainCamera[modelId] != null)
                    {
                        mainCamera[modelId].ReDraw();
                    }

                    if (match.Count > 0)
                    {
                        float row = CameraMgr.Inst[modelId].ImageSize.Height / 2f;
                        float col = CameraMgr.Inst[modelId].ImageSize.Width / 2f;

                        for (int i = 0; i < match.Count; i++)
                        {
                            CalibPointToPoint calib = Tool.Calibs[caneraId];
                            PointF pf;
                            calib.PixelPointToWorldPoint(new PointF(match.Col[i].F, match.Row[i].F),
                                out pf,
                                new PointF(col, row),
                                new PointF());
                            Point3 point = new Point3()
                            {
                                X = pf.X,
                                Y = pf.Y,
                                R = match.Angle.TupleDeg()[i].F
                            };
                            list.Add(point);
                        }
                    }
                }
                finally
                {

                }
                return list.ToArray();
            }
        }


        public CalibPPSetting[] calibPPSetting = new CalibPPSetting[3];

        public void ShowCalibSet(int index, IPlatformMove platformMove)
        {
            if (calibPPSetting[index] == null)
            {
                calibPPSetting[index] = new CalibPPSetting(Tool.Calibs[index]);
            }
            calibPPSetting[index].CalibratePP = Tool.Calibs[index];
            calibPPSetting[index].GetImage = CameraMgr.Inst[index];
            calibPPSetting[index].PlatformMove = platformMove;
            calibPPSetting[index].ShowSetting(null);
        }

        public PointF GetImageCenter(int index)
        {
            float row = CameraMgr.Inst[index].ImageSize.Height / 2f;
            float col = CameraMgr.Inst[index].ImageSize.Width / 2f;
            double x, y;
            Tool.Calibs[index].MatrixTransToWorld(row, col, out x, out y);
            return new PointF((float)x, (float)y);
        }


        public void DisplayShapeModel(int id, HWindowControl hWindow)
        {
            hWindow.HalconWindow.ClearWindow();
            if (VisionProject.Instance.Tool.Shapes[id].shapeModel != null &&
                VisionProject.Instance.Tool.Shapes[id].shapeModel.IsInitialized())
            {
                int row1, col1, row2, col2;
                Tool.Shapes[id].ModelRegion.SmallestRectangle1(out row1, out col1, out row2, out col2);
                Rectangle rectangle = Rectangle.FromLTRB(row1, col1, row2, col2);

                int width, height;
                Tool.Shapes[id].ModelImg.GetImageSize(out width, out height);
                KeepRadioRectangle(ref rectangle, width, height);

                hWindow.HalconWindow.SetPart(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
                hWindow.HalconWindow.DispObj(VisionProject.Instance.Tool.Shapes[id].ModelImg);
            }
        }


        private void KeepRadioRectangle(ref Rectangle rectangle, float width, float height)
        {
            double w = rectangle.Width * 1.0 / width;
            double h = rectangle.Height * 1.0 / height;
            double ww = width / height;
            if (w < h)
            {
                int X1 = rectangle.Location.X - (int)(h * width / ww - rectangle.Width) / 2;
                int Y1 = rectangle.Location.Y - (int)(h * height - rectangle.Height) / 2;
                rectangle.Location = new Point(X1, Y1);
                rectangle.Width = (int)(h * width / ww);
                rectangle.Height = (int)(h * height);
            }
            else if (w > h)
            {
                int X1 = rectangle.Location.X - (int)(w * width * ww - rectangle.Width) / 2;
                int Y1 = rectangle.Location.Y - (int)(w * height - rectangle.Height) / 2;
                rectangle.Location = new Point(X1, Y1);
                rectangle.Width = (int)(w * width * ww);
                rectangle.Height = (int)(w * height);
            }
        }
    }




    public class Point3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
    }


    [Serializable]
    public class VisionTool
    {
        public Dictionary<int, ShapeModel> Shapes { get; set; } 

        public Dictionary<int, CalibPointToPoint> Calibs { get; set; } 

        public DoublePointLocation PointLocation { get; set; }

        public VisionTool()
        {
            PointLocation = new DoublePointLocation();
            Shapes = new Dictionary<int, ShapeModel>();
            Calibs = new Dictionary<int, CalibPointToPoint>();
            Shapes.Add(0, new ShapeModel());
            Shapes.Add(1, new ShapeModel());
            Shapes.Add(2, new ShapeModel());
            Shapes.Add(3, new ShapeModel());

            Calibs.Add(0, new CalibPointToPoint());
            Calibs.Add(1, new CalibPointToPoint());
        }

    }


}
