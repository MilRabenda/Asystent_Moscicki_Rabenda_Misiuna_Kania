// Updated by XamlIntelliSenseFileGenerator 08.06.2022 18:26:43
#pragma checksum "..\..\..\StronyRecepcja\StronaKonta.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17505DEE5E6D8708488698198F2A8093F48D88DA77402AA622CCBF6ABC057F9B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Panel_Gościa.StronyRecepcja;
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


namespace Panel_Gościa.StronyPielegniarka
{


    /// <summary>
    /// StronaKonta
    /// </summary>
    public partial class StronaKonta : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Panel Gościa;component/stronyrecepcja/stronakonta.xaml", System.UriKind.Relative);

#line 1 "..\..\..\StronyRecepcja\StronaKonta.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.btnEditKonta = ((System.Windows.Controls.Button)(target));

#line 12 "..\..\..\StronyRecepcja\StronaKonta.xaml"
                    this.btnEditKonta.Click += new System.Windows.RoutedEventHandler(this.btnChangePassword_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.btnDeactivate = ((System.Windows.Controls.Button)(target));

#line 13 "..\..\..\StronyRecepcja\StronaKonta.xaml"
                    this.btnDeactivate.Click += new System.Windows.RoutedEventHandler(this.btnDeactivate_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

