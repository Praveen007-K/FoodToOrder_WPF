﻿#pragma checksum "..\..\..\EditDishWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ADA5FC639F4B2D329943451C63B3B277EF1C035C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FoodToOrderAppWPF;
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


namespace FoodToOrderAppWPF {
    
    
    /// <summary>
    /// EditDishWindow
    /// </summary>
    public partial class EditDishWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\EditDishWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EditDishIdTextbox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\EditDishWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EditDishNameTextbox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\EditDishWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EditpriceTextbox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\EditDishWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EditRidTextbox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\EditDishWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkboxdish;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FoodToOrderAppWPF;component/editdishwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditDishWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.EditDishIdTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\EditDishWindow.xaml"
            this.EditDishIdTextbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextBoxTextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EditDishNameTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\EditDishWindow.xaml"
            this.EditDishNameTextbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextBoxTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditpriceTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\..\EditDishWindow.xaml"
            this.EditpriceTextbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextBoxTextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditRidTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 77 "..\..\..\EditDishWindow.xaml"
            this.EditRidTextbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextBoxTextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.checkboxdish = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            
            #line 92 "..\..\..\EditDishWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditDish);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 99 "..\..\..\EditDishWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AdminOptions);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

