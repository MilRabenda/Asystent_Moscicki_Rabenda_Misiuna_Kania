#pragma checksum "..\..\PanelAnalityka.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0973D6CDDDD4EE911B901B5F1D1C43DD216B8DC8C039012A4DF36C72846D2EBE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Panel_Gościa;
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


namespace Panel_Gościa {
    
    
    /// <summary>
    /// PanelAnalityka
    /// </summary>
    public partial class PanelAnalityka : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\PanelAnalityka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_Witaj;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\PanelAnalityka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Raport;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\PanelAnalityka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Raport_Copy;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\PanelAnalityka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame anFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/Panel Gościa;component/panelanalityka.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PanelAnalityka.xaml"
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
            this.lbl_Witaj = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.btn_Raport = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\PanelAnalityka.xaml"
            this.btn_Raport.Click += new System.Windows.RoutedEventHandler(this.btn_ZapiszWizytę_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_Raport_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\PanelAnalityka.xaml"
            this.btn_Raport_Copy.Click += new System.Windows.RoutedEventHandler(this.btn_Raport_Copy_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.anFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

