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
            // Relative lookup of item with BuildAction=Page (MSBuild:Compile) => success
            var window = Application.LoadComponent(new Uri("Start.xaml", UriKind.Relative)) as Window;
            app.Run(window);
        }
    }
}
