module Handlers

open System.IO
open System.Collections.Generic

let hello ctx name = sprintf "Hello %s" name |> ctx.Response.WriteAsync

let goodbye ctx = 
  use sr = new StreamReader(ctx.Request.Body)
  let body = sr.ReadToEnd()
  sprintf "Goodbye %s" body |> ctx.Response.WriteAsync

let greet ctx greeting name = sprintf "%s %s" greeting name |> ctx.Response.WriteAsync

let (?) (d : IDictionary<_, _>) n = d.[n]
