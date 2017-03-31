#pragma once

using namespace cv;
using namespace std;
using namespace Windows::Foundation::Collections;

namespace kuOpenCVCpp
{
    public ref class kuOpenCVCppWrapper sealed
    {
    public:
		kuOpenCVCppWrapper();
		double kuTestFunctionCpp(int a, int b);
		double kuTestFunctionCpp2(int a, int b);

		bool kuCalHomographyCpp(IVector<double>^ SrcPts, IVector<double>^ DstPts);
		IVector<double>^ kuPerspectiveTransformCpp(IVector<double>^ SrcPts);

	private:
		Mat hMat;				// Homography matrix
    };
}
