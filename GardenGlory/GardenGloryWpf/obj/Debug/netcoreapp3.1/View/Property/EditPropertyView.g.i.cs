﻿#pragma checksum "..\..\..\..\..\View\Property\EditPropertyView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06A6AC4619FAEA5358ADCE554279C9CC2362ADC8"
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
    /// EditPropertyView
    /// </summary>
    public partial class EditPropertyView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPropertyName;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStreet;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCity;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtZip;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PropertyEditSave;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PropertyEditCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/GardenGloryWpf;component/view/property/editpropertyview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
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
            this.txtPropertyName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtStreet = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtZip = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PropertyEditSave = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
            this.PropertyEditSave.Click += new System.Windows.RoutedEventHandler(this.PropertyEditSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PropertyEditCancel = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\..\..\View\Property\EditPropertyView.xaml"
            this.PropertyEditCancel.Click += new System.Windows.RoutedEventHandler(this.PropertyEditCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

