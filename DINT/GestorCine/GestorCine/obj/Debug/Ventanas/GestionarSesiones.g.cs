﻿#pragma checksum "..\..\..\Ventanas\GestionarSesiones.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0999D3183E59C15ED75F5A28588BBFDD47549D0893944B7E6205732B19DAAA58"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using GestorCine.Comandos;
using GestorCine.Ventanas;
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


namespace GestorCine.Ventanas {
    
    
    /// <summary>
    /// GestionarSesiones
    /// </summary>
    public partial class GestionarSesiones : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 112 "..\..\..\Ventanas\GestionarSesiones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button guardarCambiosButton;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Ventanas\GestionarSesiones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelarCambiosButton;
        
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
            System.Uri resourceLocater = new System.Uri("/GestorCine;component/ventanas/gestionarsesiones.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Ventanas\GestionarSesiones.xaml"
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
            
            #line 16 "..\..\..\Ventanas\GestionarSesiones.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed_Agregar);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\..\Ventanas\GestionarSesiones.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed_Modificar);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\Ventanas\GestionarSesiones.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CommandBinding_CanExecute_Modificar);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 25 "..\..\..\Ventanas\GestionarSesiones.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed_Eliminar);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\Ventanas\GestionarSesiones.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CommandBinding_CanExecute_Eliminar);
            
            #line default
            #line hidden
            return;
            case 4:
            this.guardarCambiosButton = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\Ventanas\GestionarSesiones.xaml"
            this.guardarCambiosButton.Click += new System.Windows.RoutedEventHandler(this.guardarCambiosButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cancelarCambiosButton = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\..\Ventanas\GestionarSesiones.xaml"
            this.cancelarCambiosButton.Click += new System.Windows.RoutedEventHandler(this.cancelarCambiosButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

