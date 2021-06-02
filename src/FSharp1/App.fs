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
        let window = Application.LoadComponent (new Uri("Start.xaml", UriKind.Relative)) :?> Window
        app.Run(window)
