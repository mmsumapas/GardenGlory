﻿#pragma checksum "..\..\..\..\..\View\Property\AddPropertyDescriptionView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51698C4E5D12896EA8B2803213350C54348E3C50"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GardenGloryWpf.View.Property;
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


namespace GardenGloryWpf.View.Property {
    
    
    /// <summary>
    /// AddPropertyDescriptionView
    /// </summary>
    public partial class AddPropertyDescriptionView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\..\View\Property\AddPropertyDescriptionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\View\Property\AddPropertyDescriptionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPropertyDescriptionSave;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\View\Property\AddPropertyDescriptionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditPropertyDescriptionCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/GardenGloryWpf;component/view/property/addpropertydescriptionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Property\AddPropertyDescriptionView.xaml"
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
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AddPropertyDescriptionSave = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\View\Property\AddPropertyDescriptionView.xaml"
            this.AddPropertyDescriptionSave.Click += new System.Windows.RoutedEventHandler(this.AddPropertyDescriptionSave_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditPropertyDescriptionCancel = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\..\View\Property\AddPropertyDescriptionView.xaml"
            this.EditPropertyDescriptionCancel.Click += new System.Windows.RoutedEventHandler(this.EditPropertyDescriptionCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

