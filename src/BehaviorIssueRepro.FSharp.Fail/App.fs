namespace BehaviorIssueRepro.FSharp.Fail

[<AutoOpen>]
module App =
    open System
    open System.Windows

    [<STAThread()>]
    [<EntryPoint>]
    let main(args : string[]) =

        let app = new System.Windows.Application()

        let window = Application.LoadComponent (new Uri("/BehaviorIssueRepro.FSharp.Fail;component/Start.xaml", UriKind.Relative)) :?> Window

        app.Run(window)
