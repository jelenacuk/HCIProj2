﻿#pragma checksum "..\..\dodajTip.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1DC567046F68B3F2DD1C26131ED4E0CEC22587124F17BCC754328C988E0ACBB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCIProj2;
using HCIProj2.Shortcuts;
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


namespace HCIProj2 {
    
    
    /// <summary>
    /// dodajTip
    /// </summary>
    public partial class dodajTip : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\dodajTip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textB_id;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\dodajTip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textB_naziv;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\dodajTip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textB_opis;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\dodajTip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textB_ikonica;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\dodajTip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadIcon;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\dodajTip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dodajTipBtn;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\dodajTip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button odustaniBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/HCIProj2;component/dodajtip.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\dodajTip.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 19 "..\..\dodajTip.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.zatvoriProzor);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\dodajTip.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.dodajTipBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 21 "..\..\dodajTip.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Help_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textB_id = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\dodajTip.xaml"
            this.textB_id.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textB_id_TextChanged);
            
            #line default
            #line hidden
            
            #line 37 "..\..\dodajTip.xaml"
            this.textB_id.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.textB_id_Error));
            
            #line default
            #line hidden
            return;
            case 5:
            this.textB_naziv = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\dodajTip.xaml"
            this.textB_naziv.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.textB_naziv_Error));
            
            #line default
            #line hidden
            return;
            case 6:
            this.textB_opis = ((System.Windows.Controls.TextBox)(target));
            
            #line 90 "..\..\dodajTip.xaml"
            this.textB_opis.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.textB_opis_Error));
            
            #line default
            #line hidden
            return;
            case 7:
            this.textB_ikonica = ((System.Windows.Controls.TextBox)(target));
            
            #line 121 "..\..\dodajTip.xaml"
            this.textB_ikonica.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.textB_ikonica_Error));
            
            #line default
            #line hidden
            return;
            case 8:
            this.loadIcon = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\dodajTip.xaml"
            this.loadIcon.Click += new System.Windows.RoutedEventHandler(this.Button_Click_UcitajIkonicu);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dodajTipBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.odustaniBtn = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\dodajTip.xaml"
            this.odustaniBtn.Click += new System.Windows.RoutedEventHandler(this.odustaniBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

