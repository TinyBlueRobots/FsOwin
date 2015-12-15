module FsOwin

open Owin
open System.Threading.Tasks
open Handlers
open Route

let route ctx = 
  match ctx with
  | Route GET "/hello/{name}" parameters -> hello ctx parameters?name
  | Route POST "/goodbye" _ -> goodbye ctx
  | Route GET "/greet/{greeting}/{name}" parameters -> greet ctx parameters?greeting parameters?name
  | _ -> 
    ctx.Response.StatusCode <- 404
    Task.Delay 0

type Startup() = 
  member __.Configuration(app : IAppBuilder) = app.Run(fun ctx -> createContext ctx |> route)
