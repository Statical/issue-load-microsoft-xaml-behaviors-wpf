using System;
using System.Windows;

namespace BehaviorIssueRepro.CSharp.Fail
{
    class App
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new Application();
            // Relative lookup of item with BuildAction=Resource => runtime failure
            var window = Application.LoadComponent(new Uri("Start.xaml", UriKind.Relative)) as Window;
            // Also fails with 
            //var window = Application.LoadComponent(new Uri("CSharp1;component/Start.xaml", UriKind.Relative)) as Window;
            app.Run(window);
        }
    }
}
