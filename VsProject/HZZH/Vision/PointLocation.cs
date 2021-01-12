using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalconDotNet;
using System.Diagnostics;

namespace HZZH.Vision
{
    /// <summary>
    /// 单mark点变换
    /// </summary>
    [Serializable]
    public class SinglePointLocation : IPointLocation
    {
        PointLocationImpl pointLocationImpl = new PointLocationImpl();

        public void SetBenchmark1(double x, double y, double r)
        {
            pointLocationImpl.benchmark1_X = x;
            pointLocationImpl.benchmark1_Y = y;
            pointLocationImpl.benchmark1_R = r;
        }

        public void SetBenchmark2(double x, double y, double r)
        {
            pointLocationImpl.benchmark2_X = x;
            pointLocationImpl.benchmark2_Y = y;
            pointLocationImpl.benchmark2_R = r;
        }


        public void Calculation()
        {
            pointLocationImpl.VectorAngleToRigid();
        }

        public void AffineTransPoint2d(HTuple x, HTuple y, out HTuple tx, out HTuple ty)
        {
            pointLocationImpl.AffineTransPoint2d(x, y, out tx, out ty);
        }

        public void ReverseTransPoint2d(HTuple x, HTuple y, out HTuple tx, out HTuple ty)
        {
            pointLocationImpl.ReverseTransPoint2d(x, y, out tx, out ty);
        }
    }

    /// <summary>
    /// 双mark点变换
    /// </summary>
    [Serializable]
    public class DoublePointLocation : IPointLocation
    {
        PointLocationImpl pointLocationImpl = new PointLocationImpl();

        /// <summary>
        /// 设定标准位置
        /// </summary>
        /// <param name="index"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetBenchmark1(int index, double x, double y)
        {
            pointLocationImpl.benchmark1_X[index] = x;
            pointLocationImpl.benchmark1_Y[index] = y;
        }

        /// <summary>
        /// 设定变换后的位置
        /// </summary>
        /// <param name="index"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetBenchmark2(int index, double x, double y)
        {
            pointLocationImpl.benchmark2_X[index] = x;
            pointLocationImpl.benchmark2_Y[index] = y;
        }

        public void Calculation()
        {
            pointLocationImpl.VectorToRigid();
        }

        public void AffineTransPoint2d(HTuple x, HTuple y, out HTuple tx, out HTuple ty)
        {
            pointLocationImpl.AffineTransPoint2d(x, y, out tx, out ty);
        }

        public void ReverseTransPoint2d(HTuple x, HTuple y, out HTuple tx, out HTuple ty)
        {
            pointLocationImpl.ReverseTransPoint2d(x, y, out tx, out ty);
        }

        public double Error
        {
            get
            {
                int min = new HTuple(pointLocationImpl.benchmark1_X.Length,
                          pointLocationImpl.benchmark1_Y.Length,
                          pointLocationImpl.benchmark2_X.Length,
                          pointLocationImpl.benchmark2_Y.Length).TupleMin();

                if (min != 2)
                {
                    return 0;
                }

                HTuple tuple1 = HMisc.DistancePp(pointLocationImpl.benchmark1_X[0].D, pointLocationImpl.benchmark1_Y[0], pointLocationImpl.benchmark1_X[1], pointLocationImpl.benchmark1_Y[1]);
                HTuple tuple2 = HMisc.DistancePp(pointLocationImpl.benchmark2_X[0].D, pointLocationImpl.benchmark2_Y[0], pointLocationImpl.benchmark2_X[1], pointLocationImpl.benchmark2_Y[1]);

                return Math.Abs(tuple1 - tuple2);
            }
        }

        public double[] MarkError
        {
            get
            {
                double[] error = new double[2];
                HTuple tuple1 = HMisc.DistancePp(pointLocationImpl.benchmark1_X[0].D, pointLocationImpl.benchmark1_Y[0], pointLocationImpl.benchmark2_X[0].D, pointLocationImpl.benchmark2_Y[0]);
                HTuple tuple2 = HMisc.DistancePp(pointLocationImpl.benchmark1_X[1].D, pointLocationImpl.benchmark1_Y[1], pointLocationImpl.benchmark2_X[1].D, pointLocationImpl.benchmark2_Y[1]);
                error[0] = tuple1[0].D;
                error[1] = tuple2[0].D;
                return error;
            }
        }

        public double Rotate
        {
            get
            {
                double sx, sy, phi, theta, tx, ty;
                sx = this.pointLocationImpl.matrix.HomMat2dToAffinePar(out sy, out phi, out theta, out tx, out ty);
                return phi;
            }
        }
    }

    /// <summary>
    /// 点位变换
    /// </summary>
    public interface IPointLocation
    {
        /// <summary>
        /// 计算变换矩阵
        /// </summary>
        void Calculation();
        /// <summary>
        /// 将标准平面上的点，转换到变换后平面上的坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        void AffineTransPoint2d(HTuple x, HTuple y, out HTuple tx, out HTuple ty);
        /// <summary>
        /// 将变换后的平面坐标的点，转换到标准平面上的坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        void ReverseTransPoint2d(HTuple x, HTuple y, out HTuple tx, out HTuple ty);
    }



    [Serializable]
    [DebuggerDisplay("Matrix = {matrix.RawData}")]
    class PointLocationImpl
    {
        public HHomMat2D matrix = new HHomMat2D();


        public HTuple benchmark1_X = new HTuple();
        public HTuple benchmark1_Y = new HTuple();
        public HTuple benchmark1_R = new HTuple();

        public HTuple benchmark2_X = new HTuple();
        public HTuple benchmark2_Y = new HTuple();
        public HTuple benchmark2_R = new HTuple();

        /// <summary>
        /// 从点和角度计算刚性仿射变换
        /// </summary>
        public void VectorAngleToRigid()
        {
            if (benchmark1_X.Length != 1 &&
                benchmark1_Y.Length != 1 &&
                benchmark1_R.Length != 1 &&
                benchmark2_X.Length != 1 &&
                benchmark2_Y.Length != 1 &&
                benchmark2_R.Length != 1)
            {
                matrix.VectorAngleToRigid(benchmark1_X, benchmark1_Y, benchmark1_R, benchmark2_X, benchmark2_Y, benchmark2_R);
            }
            else
            {
                Debug.Assert(false, "矩阵参数错误");
            }

        }

        /// <summary>
        /// 从点对应近似刚性仿射变换
        /// </summary>
        public void VectorToRigid()
        {
            HTuple length = new HTuple(benchmark1_X.Length, benchmark1_Y.Length, benchmark2_X.Length, benchmark2_Y.Length).TupleMin();
            if (benchmark1_X.Length == length &&
                benchmark1_Y.Length == length &&
                benchmark2_X.Length == length &&
                benchmark2_Y.Length == length)
            {
                string info = string.Format("mark({0},{1}),mark({2},{3})== >> FindMark({4},{5}),FindMark({6},{7})",
                        benchmark1_X[0].F, benchmark1_Y[0].F, benchmark1_X[1].F, benchmark1_Y[1].F,
                        benchmark2_X[0].F, benchmark2_Y[0].F, benchmark2_X[1].F, benchmark2_Y[1].F);
                Debug.WriteLine(info);
                matrix.VectorToRigid(benchmark1_X, benchmark1_Y, benchmark2_X, benchmark2_Y);
                Debug.WriteLine(string.Format("[{0},{1},{2},{3},{4},{5}]", matrix[0].D, matrix[1].D, matrix[2].D, matrix[3].D, matrix[4].D, matrix[5].D));

                Debug.WriteLine(string.Format("[{0},{1},{2},{3},{4},{5}]", matrix[0].D, matrix[1].D, matrix[2].D, matrix[3].D, matrix[4].D, matrix[5].D));
            }
            else
            {
                Debug.Assert(false, "矩阵参数错误");
            }
        }

        public void AffineTransPoint2d(HTuple x, HTuple y, out HTuple tx, out HTuple ty)
        {
            Debug.Assert((x != null) && (y != null));
            Debug.Assert(x.Length == y.Length, string.Format("输入参数长度错误：x={0},Y={1}", x.Length, y.Length));
            HOperatorSet.AffineTransPoint2d(matrix, x, y, out tx, out ty);
        }

        public void ReverseTransPoint2d(HTuple x, HTuple y, out HTuple tx, out HTuple ty)
        {
            HHomMat2D mat2D = matrix.HomMat2dInvert();
            Debug.Assert((x != null) && (y != null));
            Debug.Assert(x.Length == y.Length, string.Format("输入参数长度错误：x={0},Y={1}", x.Length, y.Length));
            HOperatorSet.AffineTransPoint2d(mat2D, x, y, out tx, out ty);
        }

    }

}
