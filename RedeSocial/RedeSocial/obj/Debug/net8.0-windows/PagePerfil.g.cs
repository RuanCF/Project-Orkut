﻿#pragma checksum "..\..\..\PagePerfil.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E9E4F8322D464105DC6C0C71E3E95FDBAA96B751"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using RedeSocial;
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


namespace RedeSocial {
    
    
    /// <summary>
    /// PagePerfil
    /// </summary>
    public partial class PagePerfil : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\PagePerfil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle retanguloCapa;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\PagePerfil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse ellipseFotoUser;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\PagePerfil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelAlterarFoto;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\PagePerfil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelNomeUsuario;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\PagePerfil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelQuantAmigos;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\PagePerfil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridPosts;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\PagePerfil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frame6Amigos;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RedeSocial;component/pageperfil.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PagePerfil.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.retanguloCapa = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 2:
            this.ellipseFotoUser = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 55 "..\..\..\PagePerfil.xaml"
            this.ellipseFotoUser.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ellipseFotoUser_MouseEnter);
            
            #line default
            #line hidden
            
            #line 55 "..\..\..\PagePerfil.xaml"
            this.ellipseFotoUser.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ellipseFotoUser_MouseLeave);
            
            #line default
            #line hidden
            
            #line 55 "..\..\..\PagePerfil.xaml"
            this.ellipseFotoUser.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ellipseFotoUser_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.labelAlterarFoto = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.labelNomeUsuario = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.labelQuantAmigos = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            
            #line 61 "..\..\..\PagePerfil.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gridPosts = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.frame6Amigos = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

