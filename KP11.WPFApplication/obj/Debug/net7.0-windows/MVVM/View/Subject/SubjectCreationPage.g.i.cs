﻿#pragma checksum "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DFDFF3247B07BA51FF620922E8341BE1AB0EBE6B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KP11.WPFApplication.MVVM.View;
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


namespace KP11.WPFApplication.MVVM.View {
    
    
    /// <summary>
    /// SubjectCreationPage
    /// </summary>
    public partial class SubjectCreationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxSubjectName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelFieldEmptyWarning;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonClose;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCreate;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KP11.WPFApplication;component/mvvm/view/subject/subjectcreationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBoxSubjectName = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml"
            this.TextBoxSubjectName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxSubjectName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LabelFieldEmptyWarning = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ButtonClose = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml"
            this.ButtonClose.Click += new System.Windows.RoutedEventHandler(this.ButtonClose_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonCreate = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\..\..\MVVM\View\Subject\SubjectCreationPage.xaml"
            this.ButtonCreate.Click += new System.Windows.RoutedEventHandler(this.ButtonCreate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

