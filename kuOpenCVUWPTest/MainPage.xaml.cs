using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using kuOpenCVSharp;

//空白頁項目範本收錄在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace kuOpenCVUWPTest
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        kuOpenCVSharpWrapper SharpWrapper;
        double c;

        public MainPage()
        {
            this.InitializeComponent();
            SharpWrapper = new kuOpenCVSharpWrapper();
        }

        private void RunMethodBtn_Click(object sender, RoutedEventArgs e)
        {
            int a, b;

            //c = wrapper.kuTestFunction(1, 2);
            if (int.TryParse(TextBoxA.Text, out a) &&
                int.TryParse(TextBoxB.Text, out b))
            {
                c = SharpWrapper.kuTestFunctionSharp(a, b);
                DisplayText.Text = "C: " + c.ToString();

                List<double> aaVec = new List<double>();
                List<double> bbVec = new List<double>();
                List<double> ccVec = new List<double>();

                aaVec.Add(75.0);    aaVec.Add(255.0);
                aaVec.Add(75.0);    aaVec.Add(75.0);
                aaVec.Add(255.0);   aaVec.Add(75.0);
                aaVec.Add(225.0);   aaVec.Add(225.0);

                bbVec.Add(159.0);   bbVec.Add(243.5);
                bbVec.Add(162.0);   bbVec.Add(133.0);
                bbVec.Add(261.0);   bbVec.Add(129.0);
                bbVec.Add(243.5);   bbVec.Add(222.5);

                bool cc = SharpWrapper.kuCalHomographySharp(aaVec, bbVec);

                ccVec.Add(40.0);  ccVec.Add(290.0);
                ccVec.Add(40.0);  ccVec.Add(40.0);
                ccVec.Add(290.0); ccVec.Add(40.0);
                ccVec.Add(290.0); ccVec.Add(290.0);

                var dd = SharpWrapper.kuPerspectiveTransformSharp(ccVec);

                DisplayText.Text += ", kuCalHomographySharp result: " + cc.ToString()
                                 + ", dd: " + dd.Count.ToString() + "\n";

                foreach (var item in dd)
                {
                    DisplayText.Text += " " + item.ToString();
                }
            }
            else
            {
                DisplayText.Text = "input not integer.";
            }
        }
    }
}
