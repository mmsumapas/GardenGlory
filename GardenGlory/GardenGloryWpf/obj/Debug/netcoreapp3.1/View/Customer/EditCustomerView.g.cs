﻿#pragma checksum "..\..\..\..\..\View\Customer\EditCustomerView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "010A899B61B8DD9160FB1CF7E553F4451160FA5B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GardenGloryWpf.View.Customer;
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


namespace GardenGloryWpf.View.Customer {
    
    
    /// <summary>
    /// CustomerEditView
    /// </summary>
    public partial class CustomerEditView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerName;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerEmail;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtContactNumber;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbOwnerType;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CSave;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/GardenGloryWpf;component/view/customer/editcustomerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
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
            this.txtCustomerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtCustomerEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtContactNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CmbOwnerType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 84 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
            this.CmbOwnerType.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.CmbOwnerType_OnPreviewKeyUp);
            
            #line default
            #line hidden
            
            #line 85 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
            this.CmbOwnerType.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CmbOwnerType_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CSave = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
            this.CSave.Click += new System.Windows.RoutedEventHandler(this.CSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CCancel = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\..\..\View\Customer\EditCustomerView.xaml"
            this.CCancel.Click += new System.Windows.RoutedEventHandler(this.CCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

