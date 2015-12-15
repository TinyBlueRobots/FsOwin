module Program

open Microsoft.Owin.Hosting
open FsOwin

[<EntryPoint>]
let main _ =
  use webApp = WebApp.Start<Startup> "http://localhost:8080"
  stdin.ReadLine() |> ignore
  0
