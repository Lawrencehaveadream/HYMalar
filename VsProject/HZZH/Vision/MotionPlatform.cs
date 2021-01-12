
using HZZH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections;
using Device;
using HZZH.Logic.Commmon;
using HzVision.Device;

namespace HZZH.Vision.Logic
{
    /// <summary>
    /// 标定移动的平台
    /// </summary>
    class MotionPlatform : IPlatformMove
    {
        public AxisClass X { get; set; }
        public AxisClass Y { get; set; }
        public AxisClass Z { get; set; }


        public float[] AxisPosition
        {
            get
            {
                float[] XYROrigin = new float[3];
                XYROrigin[0] = X.currPos;
                XYROrigin[1] = Y.currPos;
                XYROrigin[2] = Z.currPos;
                return XYROrigin;
            }
        }

        public void AbsMoving(float x, float y, float z = 0)
        {
            X.MC_MoveAbs(x);
            Y.MC_MoveAbs(y);
            Z.MC_MoveAbs(z);
        }

        public bool WaitOnCompleteMoving(int outTime = -1)
        {
            DateTime time = DateTime.Now;
            float spendTime = outTime < 0 ? float.PositiveInfinity : outTime;
            while (Math.Abs((time - DateTime.Now).TotalMilliseconds) < spendTime)
            {
                if (X.status == Device.AxState.AXSTA_READY &&
                   Y.status == Device.AxState.AXSTA_READY &&
                   Z.status == Device.AxState.AXSTA_READY)
                {
                    return true;
                }
                Thread.Sleep(100);
            }

            return false;
        }

        private MotionPlatform() { }

        public static MotionPlatform MotionPlat = new MotionPlatform()
        {
            X = DeviceRsDef.Axis_X,
            Y = DeviceRsDef.Axis_Y,
            Z = DeviceRsDef.Axis_Z1
        };
    }







}
