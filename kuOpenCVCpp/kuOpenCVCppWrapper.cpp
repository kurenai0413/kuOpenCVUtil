#include "pch.h"
#include "kuOpenCVCppWrapper.h"

using namespace kuOpenCVCpp;
using namespace Platform;
using namespace concurrency;
using namespace Platform::Collections;
using namespace Windows::Foundation::Collections;
using namespace Windows::Foundation;
using namespace Windows::UI::Core;

kuOpenCVCppWrapper::kuOpenCVCppWrapper()
{
}

double kuOpenCVCpp::kuOpenCVCppWrapper::kuTestFunctionCpp(int a, int b)
{
	return (double)(a + b);
}

double kuOpenCVCpp::kuOpenCVCppWrapper::kuTestFunctionCpp2(int a, int b)
{
	return (double)(a * b);
}

bool kuOpenCVCpp::kuOpenCVCppWrapper::kuCalHomographyCpp(IVector<double>^ SrcPts, IVector<double>^ DstPts)
{
	if ((SrcPts->Size == DstPts->Size) &&
		(SrcPts->Size % 2 == 0) && (DstPts->Size % 2 == 0))
	{
		int PtsNum = SrcPts->Size / 2;
		double sum = 0;

		vector<Point2f> SrcCVPts;
		vector<Point2f>	DstCVPts;

		for (int i = 0; i < PtsNum; i++)
		{
			SrcCVPts.push_back(Point2f(SrcPts->GetAt(2 * i), SrcPts->GetAt(2 * i + 1)));
			DstCVPts.push_back(Point2f(DstPts->GetAt(2 * i), DstPts->GetAt(2 * i + 1)));
		}

		hMat = findHomography(SrcCVPts, DstCVPts);

		/*vector<Point2f>	PatternBorderPts;
		vector<Point2f> RealBorderPts;

		PatternBorderPts.push_back(Point2f(40, 290));
		PatternBorderPts.push_back(Point2f(40, 40));
		PatternBorderPts.push_back(Point2f(290, 40));
		PatternBorderPts.push_back(Point2f(290, 290));
		RealBorderPts.resize(4);

		perspectiveTransform(PatternBorderPts, RealBorderPts, hMat);


		for (int i = 0; i < 4; i++)
		{
		sum += RealBorderPts[i].x;
		sum += RealBorderPts[i].y;
		}*/

		return true;
	}
	else
	{
		return false;
	}
}

IVector<double>^ kuOpenCVCpp::kuOpenCVCppWrapper::kuPerspectiveTransformCpp(IVector<double>^ SrcPts)
{
	//throw ref new Platform::NotImplementedException();
	// TODO: 於此處插入傳回陳述式
	if ((SrcPts->Size % 2) == 0)
	{
		vector<Point2f>	QueryPts;
		vector<Point2f>	ResultPts;

		int PtsNum = SrcPts->Size / 2;

		for (int i = 0; i < PtsNum; i++)
		{
			QueryPts.push_back(Point2f(SrcPts->GetAt(2 * i), SrcPts->GetAt(2 * i + 1)));
		}
		ResultPts.resize(PtsNum);

		perspectiveTransform(QueryPts, ResultPts, hMat);

		auto Res = ref new Vector<double>();

		for (int i = 0; i < PtsNum; i++)
		{
			Res->Append(ResultPts[i].x);
			Res->Append(ResultPts[i].y);
		}

		return Res;
	}
}
