# Microsoft.Xaml.Behaviors.Wpf Issue

Issue with Microsoft.Xaml.Behaviors.Wpf package when loading XAML resources.

## Annotated code

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
        <!-- ...even without any triggers in the collection -->
    </i:Interaction.Triggers>
    
</Window>
```

## Exception

XamlObjectWriterException: 'Cannot set unknown member '{http://schemas.microsoft.com/xaml/behaviors}Interaction.Triggers'.

```csharp
System.Windows.Markup.XamlParseException
  HResult=0x80131501
  Message='Cannot set unknown member '{http://schemas.microsoft.com/xaml/behaviors}Interaction.Triggers'.' Line number '11' and line position '6'.
  Source=PresentationFramework
  StackTrace:
   at System.Windows.Markup.XamlReader.RewrapException(Exception e, IXamlLineInfo lineInfo, Uri baseUri)
   at System.Windows.Markup.WpfXamlLoader.Load(XamlReader xamlReader, IXamlObjectWriterFactory writerFactory, Boolean skipJournaledProperties, Object rootObject, XamlObjectWriterSettings settings, Uri baseUri)
   at System.Windows.Markup.WpfXamlLoader.Load(XamlReader xamlReader, Boolean skipJournaledProperties, Uri baseUri)
   at System.Windows.Markup.XamlReader.Load(XamlReader xamlReader, ParserContext parserContext)
   at System.Windows.Markup.XamlReader.Load(XmlReader reader, ParserContext parserContext, XamlParseMode parseMode, Boolean useRestrictiveXamlReader)
   at System.Windows.Markup.XamlReader.Load(Stream stream, ParserContext parserContext, Boolean useRestrictiveXamlReader)
   at System.Windows.Markup.XamlReader.Load(Stream stream, ParserContext parserContext)
   at System.Windows.Application.LoadComponent(Uri resourceLocator, Boolean bSkipJournaledProperties)
   at System.Windows.Application.LoadComponent(Uri resourceLocator)
   at BehaviorIssueRepro.CSharp.Fail.App.Main(String[] args) in C:\Users\foo\issue-microsoft-xaml-behaviors-wpf\src\BehaviorIssueRepro.CSharp.Fail\App.cs:line 12

Inner Exception 1:
XamlObjectWriterException: 'Cannot set unknown member '{http://schemas.microsoft.com/xaml/behaviors}Interaction.Triggers'.' Line number '11' and line position '6'.
```
