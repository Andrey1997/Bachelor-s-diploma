﻿#pragma checksum "..\..\StudyOfPeriodicityTimeSeries.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DC0538C0D41A6D0B7B3266152E776098421F695F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SoftwareForAnalysisTimeSeries;
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


namespace SoftwareForAnalysisTimeSeries {
    
    
    /// <summary>
    /// StudyOfPeriodicityTimeSeries
    /// </summary>
    public partial class StudyOfPeriodicityTimeSeries : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\StudyOfPeriodicityTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox NormalizeOn_Avg;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\StudyOfPeriodicityTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox NormalizeOn_σ;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\StudyOfPeriodicityTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox NewTimeSeriesChecked;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\StudyOfPeriodicityTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\StudyOfPeriodicityTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxColor;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\StudyOfPeriodicityTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAutocorrelation;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\StudyOfPeriodicityTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonFFT;
        
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
            System.Uri resourceLocater = new System.Uri("/SoftwareForAnalysisTimeSeries;component/studyofperiodicitytimeseries.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StudyOfPeriodicityTimeSeries.xaml"
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
            this.NormalizeOn_Avg = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 2:
            this.NormalizeOn_σ = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.NewTimeSeriesChecked = ((System.Windows.Controls.CheckBox)(target));
            
            #line 15 "..\..\StudyOfPeriodicityTimeSeries.xaml"
            this.NewTimeSeriesChecked.Checked += new System.Windows.RoutedEventHandler(this.PermissionInputTextBox);
            
            #line default
            #line hidden
            
            #line 15 "..\..\StudyOfPeriodicityTimeSeries.xaml"
            this.NewTimeSeriesChecked.Unchecked += new System.Windows.RoutedEventHandler(this.NotPermissionInputTextBox);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextBoxColor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 20 "..\..\StudyOfPeriodicityTimeSeries.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Normalize);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonAutocorrelation = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\StudyOfPeriodicityTimeSeries.xaml"
            this.ButtonAutocorrelation.Click += new System.Windows.RoutedEventHandler(this.ButtonAutocorrelation_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonFFT = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\StudyOfPeriodicityTimeSeries.xaml"
            this.ButtonFFT.Click += new System.Windows.RoutedEventHandler(this.ButtonFFT_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

