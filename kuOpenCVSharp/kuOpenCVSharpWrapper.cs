using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuOpenCVCpp;

namespace kuOpenCVSharp
{
    public sealed class kuOpenCVSharpWrapper
    {
        kuOpenCVCppWrapper CppWrapper = new kuOpenCVCppWrapper();

        public double kuTestFunctionSharp(int a, int b)
        {
            return CppWrapper.kuTestFunctionCpp(a, b);
        }

        public bool kuCalHomographySharp(IList<double> SrcPts, IList<double> DstPts)
        {
            return CppWrapper.kuCalHomographyCpp(SrcPts, DstPts);
        }

        public IList<double> kuPerspectiveTransformSharp(IList<double> SrcPts)
        {
            return CppWrapper.kuPerspectiveTransformCpp(SrcPts);
        }

        public double kuTestFunctionSharp2(int a, int b)
        {
            return CppWrapper.kuTestFunctionCpp2(a, b);
        }
    }
}
