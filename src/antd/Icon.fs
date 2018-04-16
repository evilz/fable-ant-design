namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props



[<RequireQualifiedAccess>]
module Icon =
    
    type ButtonProps =
        | Spin of bool
        | Type of string
        interface Fable.Helpers.React.Props.IProp


    let inline icon (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Icon" "antd" (keyValueList CaseRules.LowerFirst props) children

   