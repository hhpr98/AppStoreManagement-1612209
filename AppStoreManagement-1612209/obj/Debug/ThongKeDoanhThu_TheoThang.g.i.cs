﻿#pragma checksum "..\..\ThongKeDoanhThu_TheoThang.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8E14CDE28962C2A7AA1D5AA99AADE64B9BBB55D4ED0D82832A26B045A70DA64C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AppStoreManagement_1612209;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AppStoreManagement_1612209 {
    
    
    /// <summary>
    /// ThongKeDoanhThu_TheoThang
    /// </summary>
    public partial class ThongKeDoanhThu_TheoThang : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ThongKeDoanhThu_TheoThang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ThongKeDoanhThu_TheoThang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMonth;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ThongKeDoanhThu_TheoThang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtYear;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ThongKeDoanhThu_TheoThang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStatis;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ThongKeDoanhThu_TheoThang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.ColumnSeries chart;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ThongKeDoanhThu_TheoThang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl1;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ThongKeDoanhThu_TheoThang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl2;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\ThongKeDoanhThu_TheoThang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl3;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AppStoreManagement-1612209;component/thongkedoanhthu_theothang.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ThongKeDoanhThu_TheoThang.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.txtMonth = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtYear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnStatis = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\ThongKeDoanhThu_TheoThang.xaml"
            this.btnStatis.Click += new System.Windows.RoutedEventHandler(this.BtnStatis_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.chart = ((System.Windows.Controls.DataVisualization.Charting.ColumnSeries)(target));
            return;
            case 6:
            this.lbl1 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lbl2 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lbl3 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

