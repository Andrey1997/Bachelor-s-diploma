﻿#pragma checksum "..\..\..\Page_Predict\PredictTimeSeries.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2F73DE43237E36AB5B4F66E106911C8EB8889932"
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
    /// PredictTimeSeries
    /// </summary>
    public partial class PredictTimeSeries : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonExponentialSmoothingMethod;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMovingAverageMethod;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SmoothingInterval;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMethodLeastSquares;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuantityPredict;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuantityPredictLeastSquares;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox TypeMethodLeastSquares;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SmoothingIntervalExp;
        
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
            System.Uri resourceLocater = new System.Uri("/SoftwareForAnalysisTimeSeries;component/page_predict/predicttimeseries.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
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
            this.ButtonExponentialSmoothingMethod = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
            this.ButtonExponentialSmoothingMethod.Click += new System.Windows.RoutedEventHandler(this.ButtonExponentialSmoothingMethod_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonMovingAverageMethod = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
            this.ButtonMovingAverageMethod.Click += new System.Windows.RoutedEventHandler(this.ButtonMovingAverageMethod_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SmoothingInterval = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ButtonMethodLeastSquares = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Page_Predict\PredictTimeSeries.xaml"
            this.ButtonMethodLeastSquares.Click += new System.Windows.RoutedEventHandler(this.ButtonMethodLeastSquares_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.QuantityPredict = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.QuantityPredictLeastSquares = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TypeMethodLeastSquares = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.SmoothingIntervalExp = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

