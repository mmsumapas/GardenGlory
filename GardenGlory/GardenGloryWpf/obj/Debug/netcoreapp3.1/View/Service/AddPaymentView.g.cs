﻿#pragma checksum "..\..\..\..\..\View\Service\AddPaymentView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "338655AAF3D28B4C251D3AB3DF64DBEC2062BC3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GardenGloryWpf.View.Service;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace GardenGloryWpf.View.Service {
    
    
    /// <summary>
    /// AddPaymentView
    /// </summary>
    public partial class AddPaymentView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbPaymentMethod;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAmount;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPaymentSave;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPaymentCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GardenGloryWpf;component/view/service/addpaymentview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CmbPaymentMethod = ((System.Windows.Controls.ComboBox)(target));
            
            #line 47 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
            this.CmbPaymentMethod.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.CmbPaymentMethod_OnPreviewKeyUp);
            
            #line default
            #line hidden
            
            #line 48 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
            this.CmbPaymentMethod.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CmbPaymentMethod_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtAmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AddPaymentSave = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
            this.AddPaymentSave.Click += new System.Windows.RoutedEventHandler(this.AddPaymentSave_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddPaymentCancel = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\..\..\View\Service\AddPaymentView.xaml"
            this.AddPaymentCancel.Click += new System.Windows.RoutedEventHandler(this.AddPaymentCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

