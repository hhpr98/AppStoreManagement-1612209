﻿#pragma checksum "..\..\ThongKeMaster_TheoNam.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52E0E0496F6A1AC66D97C2E158CDCB8356328DB0"
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
    /// ThongKeMaster_TheoNam
    /// </summary>
    public partial class ThongKeMaster_TheoNam : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ThongKeMaster_TheoNam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ThongKeMaster_TheoNam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtYear;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ThongKeMaster_TheoNam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStatis;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ThongKeMaster_TheoNam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.PieSeries chart;
        
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
            System.Uri resourceLocater = new System.Uri("/AppStoreManagement-1612209;component/thongkemaster_theonam.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ThongKeMaster_TheoNam.xaml"
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
            this.txtYear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnStatis = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\ThongKeMaster_TheoNam.xaml"
            this.btnStatis.Click += new System.Windows.RoutedEventHandler(this.BtnStatis_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.chart = ((System.Windows.Controls.DataVisualization.Charting.PieSeries)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

