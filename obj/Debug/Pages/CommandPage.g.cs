﻿#pragma checksum "..\..\..\Pages\CommandPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "106A0392FD83B2095615F23E43D8ECA8A1BFC432112DED0CB91568D5B8107911"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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


namespace Projet_M1_Integration_Systeme.Pages {
    
    
    /// <summary>
    /// CommandPage
    /// </summary>
    public partial class CommandPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 29 "..\..\..\Pages\CommandPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgPizzas;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Pages\CommandPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgDrinks;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Pages\CommandPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTotalPrice;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\Pages\CommandPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTotalPriceValue;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\Pages\CommandPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Pages\CommandPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Projet_M1_Integration_Systeme;component/pages/commandpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CommandPage.xaml"
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
            
            #line 75 "..\..\..\Pages\CommandPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAddPizza_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DgDrinks = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 125 "..\..\..\Pages\CommandPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAddDrink_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LblTotalPrice = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.LblTotalPriceValue = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 137 "..\..\..\Pages\CommandPage.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnPrevious_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnBuy = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\..\Pages\CommandPage.xaml"
            this.BtnBuy.Click += new System.Windows.RoutedEventHandler(this.BtnBuy_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 140 "..\..\..\Pages\CommandPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnLoad_Click);
            
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
            
            #line 69 "..\..\..\Pages\CommandPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnRemovePizza_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 119 "..\..\..\Pages\CommandPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnRemoveDrink_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

