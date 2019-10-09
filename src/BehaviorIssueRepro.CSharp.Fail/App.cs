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
            var window = Application.LoadComponent(new Uri("/BehaviorIssueRepro.CSharp.Fail;component/Start.xaml", UriKind.Relative)) as Window;
            app.Run(window);
        }
    }
}
