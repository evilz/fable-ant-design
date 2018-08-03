[<RequireQualifiedAccess>]
module Fable.AntD.Common

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.React

[<StringEnum>]
type Size = Large | Default | Small


[<Emit("$2[$0] = $1")>]
let setProp (propName: string) (propValue: obj) (any: obj) : unit = jsNative

[<Emit("$0[$1]")>]
let getAs<'a> (x: obj) (key: string) : 'a = jsNative

[<Emit("typeof ($0) === 'string'")>]
let typeofString (x: obj) : bool = jsNative

[<Emit("typeof ($0) === 'object'")>]
let typeofObject (x: obj) : bool = jsNative