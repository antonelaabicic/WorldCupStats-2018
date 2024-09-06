﻿#pragma checksum "..\..\..\..\UCs\TeamOverviewUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F32AAACE0F8559251AE88288FEF7044A05415674"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MatchView.UCs;
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


namespace MatchView.UCs {
    
    
    /// <summary>
    /// TeamOverviewUC
    /// </summary>
    public partial class TeamOverviewUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\UCs\TeamOverviewUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbFavTeam;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UCs\TeamOverviewUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbOpponentTeam;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\UCs\TeamOverviewUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbScore;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\UCs\TeamOverviewUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxFavTeam;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\UCs\TeamOverviewUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxOppTeam;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\UCs\TeamOverviewUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lsFavTeam;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\UCs\TeamOverviewUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lsOppTeam;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MatchView;component/ucs/teamoverviewuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UCs\TeamOverviewUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbFavTeam = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lbOpponentTeam = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lbScore = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            
            #line 45 "..\..\..\..\UCs\TeamOverviewUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowFavTeamInfo_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 55 "..\..\..\..\UCs\TeamOverviewUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowOppTeamInfo_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.comboBoxFavTeam = ((System.Windows.Controls.ComboBox)(target));
            
            #line 63 "..\..\..\..\UCs\TeamOverviewUC.xaml"
            this.comboBoxFavTeam.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxFavTeam_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.comboBoxOppTeam = ((System.Windows.Controls.ComboBox)(target));
            
            #line 69 "..\..\..\..\UCs\TeamOverviewUC.xaml"
            this.comboBoxOppTeam.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxOppTeam_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lsFavTeam = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            this.lsOppTeam = ((System.Windows.Controls.ListBox)(target));
            return;
            case 10:
            
            #line 92 "..\..\..\..\UCs\TeamOverviewUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnNextButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

