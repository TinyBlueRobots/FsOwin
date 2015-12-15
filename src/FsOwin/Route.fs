module Route

open System.Text.RegularExpressions

type HttpMethod = 
  | DELETE
  | GET
  | HEAD
  | METHOD
  | OPTIONS
  | POST
  | PUT
  | TRACE

let matchRoute method' (route : string) requestMethod requestPath = 
  match method' = requestMethod with
  | false -> false, dict []
  | true -> 
    let pattern = route.Replace("{", "(?<").Replace("}", ">.+)") |> sprintf "^%s$"
    let regex = new Regex(pattern, RegexOptions.IgnoreCase)
    let match' = regex.Match requestPath
    let groups = match'.Groups
    
    let parameters = 
      regex.GetGroupNames()
      |> Array.skip 1
      |> Array.map (fun x -> x, groups.[x].Value)
      |> Array.filter (fun (_, x) -> x.Length > 0)
      |> dict
    match'.Success, parameters

let (|Route|_|) (httpMethod : HttpMethod) route ctx = 
  let method' = sprintf "%A" httpMethod
  match matchRoute method' route ctx.Request.Method ctx.Request.Path.Value with
  | true, parameters -> Some parameters
  | _ -> None