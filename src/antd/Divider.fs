namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props



[<RequireQualifiedAccess>]
module Divider =

    [<StringEnum>]
    type DividerType =
        | [<CompiledName("horizontal")>] Horizontal
        | [<CompiledName("vertical")>] Vertical
    
    [<StringEnum>]
    type DividerOrientation =
        | [<CompiledName("left")>] Left
        | [<CompiledName("center")>] Center
        | [<CompiledName("right")>] Right

    

    type DividerProps =
        | Dashed of bool
        | Type of DividerType
        | Orientation of DividerOrientation
        interface Fable.Helpers.React.Props.IProp

    let inline divider  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Divider" "antd" (keyValueList CaseRules.LowerFirst props) children
