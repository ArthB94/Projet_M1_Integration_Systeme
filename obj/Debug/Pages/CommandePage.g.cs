﻿#pragma checksum "..\..\..\Pages\CommandePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51441B9AD43D5217ECD786FCDD7800500B84E3AE24887C42AAE23FC279C2FBA5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projet_M1_Integration_Systeme;
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


namespace Projet_M1_Integration_Systeme {
    
    
    /// <summary>
    /// CommandePage
    /// </summary>
    public partial class CommandePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\Pages\CommandePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgPizzas;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\CommandePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTotalPrice;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\CommandePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTotalPriceValue;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Pages\CommandePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Pages\CommandePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBuy;
        
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
            System.Uri resourceLocater = new System.Uri("/Projet_M1_Integration_Systeme;component/pages/commandepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CommandePage.xaml"
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
            this.DgPizzas = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.LblTotalPrice = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.LblTotalPriceValue = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Pages\CommandePage.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnBuy = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\Pages\CommandePage.xaml"
            this.BtnBuy.Click += new System.Windows.RoutedEventHandler(this.BtnBuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 60 "..\..\..\Pages\CommandePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnRemove_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

