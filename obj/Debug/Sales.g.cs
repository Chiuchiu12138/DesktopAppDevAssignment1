#pragma checksum "..\..\Sales.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F9CD1B51562AF1E3660C7F2233C8E3A7F8B84EE8AAFD754798E4E53C4A8497D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DesktopAppDevAssignment_1;
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


namespace DesktopAppDevAssignment_1 {
    
    
    /// <summary>
    /// Sales
    /// </summary>
    public partial class Sales : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button goBackToAdmin;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid cartGrid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button okToPay;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label cart;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totalSales1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox totalSales;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button viewCart;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button connectCart;
        
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
            System.Uri resourceLocater = new System.Uri("/DesktopAppDevAssignment_1;component/sales.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Sales.xaml"
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
            this.goBackToAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Sales.xaml"
            this.goBackToAdmin.Click += new System.Windows.RoutedEventHandler(this.goBackToAdmin_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cartGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.okToPay = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Sales.xaml"
            this.okToPay.Click += new System.Windows.RoutedEventHandler(this.OkToPay_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cart = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.totalSales1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.totalSales = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.viewCart = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Sales.xaml"
            this.viewCart.Click += new System.Windows.RoutedEventHandler(this.viewCart_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.connectCart = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Sales.xaml"
            this.connectCart.Click += new System.Windows.RoutedEventHandler(this.connectCart_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

