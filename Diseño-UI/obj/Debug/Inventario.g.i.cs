﻿#pragma checksum "..\..\Inventario.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E38BB3308AE604142A625CB3DD09BC96FDA19D20"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Diseño_UI;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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


namespace Diseño_UI {
    
    
    /// <summary>
    /// Inventario
    /// </summary>
    public partial class Inventario : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtcantidad;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbproducto;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtprecio;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbproveedor;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fecha_v;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fecha_f;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ginventario;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnactualizar;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gbbuscar;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btncloseebuscar;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gbproveedor;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\Inventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnclosee;
        
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
            System.Uri resourceLocater = new System.Uri("/Diseño-UI;component/inventario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Inventario.xaml"
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
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.txtcantidad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cmbproducto = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            
            #line 28 "..\..\Inventario.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtprecio = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cmbproveedor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.fecha_v = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.fecha_f = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            
            #line 54 "..\..\Inventario.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ginventario = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.btnactualizar = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.gbbuscar = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 13:
            this.btncloseebuscar = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\Inventario.xaml"
            this.btncloseebuscar.Click += new System.Windows.RoutedEventHandler(this.Btncloseebuscar_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.gbproveedor = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 15:
            this.btnclosee = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\Inventario.xaml"
            this.btnclosee.Click += new System.Windows.RoutedEventHandler(this.Btnclosee_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

