﻿#pragma checksum "..\..\..\..\..\View\Service\EditService.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F8D767293AED6D325D8BD32EFF00B49D992FC99B"
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
    /// EditService
    /// </summary>
    public partial class EditService : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\..\..\View\Service\EditService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbServiceType;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\View\Service\EditService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRequestDatae;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\View\Service\EditService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtServiceRequest;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\View\Service\EditService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ServiceSave;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\View\Service\EditService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ServiceCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/GardenGloryWpf;component/view/service/editservice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Service\EditService.xaml"
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
            this.CmbServiceType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.txtRequestDatae = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtServiceRequest = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ServiceSave = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\..\View\Service\EditService.xaml"
            this.ServiceSave.Click += new System.Windows.RoutedEventHandler(this.ServiceSave_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ServiceCancel = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\..\..\View\Service\EditService.xaml"
            this.ServiceCancel.Click += new System.Windows.RoutedEventHandler(this.ServiceCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

