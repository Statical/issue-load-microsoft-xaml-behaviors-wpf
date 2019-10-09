# Microsoft.Xaml.Behaviors.Wpf Issue

Issue with Microsoft.Xaml.Behaviors.Wpf package when loading XAML resources.

```csharp
class App
{
    [STAThread]
    public static void Main(string[] args)
    {
        var app = new Application();
        // Loading XAML as a resource at run-time; we do this in our F# WPF application as well. Trying to port to .NET Core 3.0.
        var window = Application.LoadComponent(new Uri("/BehaviorIssueRepro.CSharp.Fail;component/Start.xaml", UriKind.Relative)) as Window;
        app.Run(window);
    }
}
```

```xaml
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:BehaviorIssueReproCSharpFail"
        xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
        mc:Ignorable="d"
        Title="BehaviorIssueRepro.CSharp.Fail" 
        WindowStartupLocation="CenterScreen"
        Height="300" Width="400">
        
    <!-- Boom! -->
    <i:Interaction.Triggers>
    </i:Interaction.Triggers>
    
</Window>
```
