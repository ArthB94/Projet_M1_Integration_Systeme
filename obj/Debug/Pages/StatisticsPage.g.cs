﻿#pragma checksum "..\..\..\Pages\StatisticsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "076FB6B6697F8B26DA7F1E27167E4B633ECC36178503AFFCF371DF6304724AA3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Projet_M1_Integration_Systeme.Pages;
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
    /// StatisticsPage
    /// </summary>
    public partial class StatisticsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Pages\StatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgClerks;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\StatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgDeliveryMan;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Pages\StatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LblAvgCommande;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Pages\StatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LblAvgCAcount;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Pages\StatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameShow;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Pages\StatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnShowCustomers;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Pages\StatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnShowCommands;
        
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
            System.Uri resourceLocater = new System.Uri("/Projet_M1_Integration_Systeme;component/pages/statisticspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\StatisticsPage.xaml"
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
            this.DgClerks = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.DgDeliveryMan = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.LblAvgCommande = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.LblAvgCAcount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.FrameShow = ((System.Windows.Controls.Frame)(target));
            return;
            case 6:
            this.BtnShowCustomers = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\Pages\StatisticsPage.xaml"
            this.BtnShowCustomers.Click += new System.Windows.RoutedEventHandler(this.BtnShowCustomers_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnShowCommands = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\Pages\StatisticsPage.xaml"
            this.BtnShowCommands.Click += new System.Windows.RoutedEventHandler(this.BtnShowCommands_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
