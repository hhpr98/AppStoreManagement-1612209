﻿#pragma checksum "..\..\TimKiem.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17F933884771B7B775DD4B645B77D34CF585B33335B554A20D5FDEF0181C468A"
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
    /// TimKiem
    /// </summary>
    public partial class TimKiem : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl1;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbType;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblType;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtType;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox itemCombo;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\TimKiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/AppStoreManagement-1612209;component/timkiem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TimKiem.xaml"
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
            this.lbl1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cbName = ((System.Windows.Controls.CheckBox)(target));
            
            #line 17 "..\..\TimKiem.xaml"
            this.cbName.Checked += new System.Windows.RoutedEventHandler(this.cbName_Checked);
            
            #line default
            #line hidden
            
            #line 17 "..\..\TimKiem.xaml"
            this.cbName.Unchecked += new System.Windows.RoutedEventHandler(this.cbName_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\TimKiem.xaml"
            this.txtName.GotFocus += new System.Windows.RoutedEventHandler(this.TxtName_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbType = ((System.Windows.Controls.CheckBox)(target));
            
            #line 24 "..\..\TimKiem.xaml"
            this.cbType.Checked += new System.Windows.RoutedEventHandler(this.cbType_Checked);
            
            #line default
            #line hidden
            
            #line 24 "..\..\TimKiem.xaml"
            this.cbType.Unchecked += new System.Windows.RoutedEventHandler(this.cbType_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblType = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.txtType = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\TimKiem.xaml"
            this.txtType.GotFocus += new System.Windows.RoutedEventHandler(this.TxtType_GotFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.itemCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 31 "..\..\TimKiem.xaml"
            this.itemCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ItemCombo_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 31 "..\..\TimKiem.xaml"
            this.itemCombo.Loaded += new System.Windows.RoutedEventHandler(this.ItemCombo_Loaded);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\TimKiem.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\TimKiem.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

