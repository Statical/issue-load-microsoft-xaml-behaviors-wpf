namespace BehaviorIssueRepro.FSharp.Fail

[<AutoOpen>]
module App =
    open System
    open System.Windows

    [<STAThread()>]
    [<EntryPoint>]
    let main(args : string[]) =
        let app = new System.Windows.Application()
        // Relative lookup of item with BuildAction=Page (MSBuild:Compile) => MSBuild compile-time failure
        // C:\Program Files\dotnet\sdk\5.0.300\Sdks\Microsoft.NET.Sdk.WindowsDesktop\targets\Microsoft.WinFX.targets(240,9): error MC1000: Unknown build error, 'Object reference not set to an instance of an object.'  [...\issue-load-microsoft-xaml-behaviors-wpf\src\FSharp2\FSharp2.fsproj]
        let window = Application.LoadComponent (new Uri("Start.xaml", UriKind.Relative)) :?> Window
        app.Run(window)
