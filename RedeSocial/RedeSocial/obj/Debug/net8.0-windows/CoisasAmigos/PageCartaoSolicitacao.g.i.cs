﻿#pragma checksum "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C2FEE3D56C1739D3581385C9F4259036B08F7B17"
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
    /// PageCartaoSolicitacao
    /// </summary>
    public partial class PageCartaoSolicitacao : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle foto;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelNome;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botaoAceitar;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botaoRecusar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RedeSocial;component/coisasamigos/pagecartaosolicitacao.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.foto = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 21 "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml"
            this.foto.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.foto_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.labelNome = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.botaoAceitar = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml"
            this.botaoAceitar.Click += new System.Windows.RoutedEventHandler(this.botaoAceitar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.botaoRecusar = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\CoisasAmigos\PageCartaoSolicitacao.xaml"
            this.botaoRecusar.Click += new System.Windows.RoutedEventHandler(this.botaoRecusar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

