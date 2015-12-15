module Tests

open Microsoft.Owin.Testing
open FsOwin
open System.Net
open System.Net.Http

let httpClient = TestServer.Create<Startup>().HttpClient

let exec f = 
  f
  |> Async.AwaitTask
  |> Async.RunSynchronously

[<Test>]
let hello() = httpClient.GetStringAsync "/hello/bob" |> exec == "Hello bob"

[<Test>]
let goodbye() = 
  let response = httpClient.PostAsync("/goodbye", new StringContent "bob") |> exec
  response.Content.ReadAsStringAsync() |> exec == "Goodbye bob"

[<Test>]
let notFound() = 
  let response = httpClient.GetAsync "/" |> exec
  response.StatusCode == HttpStatusCode.NotFound
