module Startup

open FsOwin
open Microsoft.Owin

[<assembly:OwinStartup(typeof<Startup>)>]
do ()
