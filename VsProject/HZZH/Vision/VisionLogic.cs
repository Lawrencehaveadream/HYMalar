using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HZZH.Vision
{
    class VisionLogic
    {
        public int CameraID { get; set; }
        public int ModelID { get; set; }

        public bool Finish { get; private set; }

        public List<Point3> Result { get; set; } = new List<Point3>();

        public void Triger()
        {
            Finish = false;
            Result.Clear();
            ThreadPool.QueueUserWorkItem(CamLogic, this);
        }

        private void CamLogic(object obj)
        {
            VisionLogic  logic = (VisionLogic)obj;
            Result.AddRange(VisionProject.Instance.FindTempleteModel(CameraID, ModelID));
            logic.Finish = true;
        }
    }
}
