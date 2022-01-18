namespace BehaviorIssueRepro.FSharp.Fail

[<AutoOpen>]
module App =
    open System
    open System.Windows

    [<STAThread()>]
    [<EntryPoint>]
    let main(args : string[]) =
        let app = new System.Windows.Application()
        // Relative lookup of item with BuildAction=Resource => runtime failure
        // System.Windows.Markup.XamlParseException: ''Cannot set unknown member '{http://schemas.microsoft.com/xaml/behaviors}Interaction.Triggers'.' Line number '12' and line position '6'.'
        // XamlObjectWriterException: 'Cannot set unknown member '{http://schemas.microsoft.com/xaml/behaviors}Interaction.Triggers'.' Line number '12' and line position '6'.
        let window = Application.LoadComponent (new Uri("Start.xaml", UriKind.Relative)) :?> Window
        app.Run(window)
