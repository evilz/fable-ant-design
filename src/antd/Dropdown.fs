namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props



[<RequireQualifiedAccess>]
module Dropdown =

    [<StringEnum>]
    type DropDownTrigger = Click | Hover | ContextMenu

    [<StringEnum>]
    type DropDownPlacement = TopLeft | TopCenter | TopRight | BottomLeft | BottomCenter | BottomRight
    
    type DropDownProps  =
        | Trigger of DropDownTrigger[]
        | Overlay of React.ReactElement
        | OnVisibleChange of (bool -> unit)
        | Visible of bool
        | Disabled of bool
        | Align of obj
        | GetPopupContainer of (React.ReactElement -> React.ReactHTMLElement)
        | PrefixCls of string
        | ClassName of string
        | TransitionName of string
        | Placement of DropDownPlacement
        | ForceRender of bool
        interface Fable.Helpers.React.Props.IProp


    let inline dropdown  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Dropdown" "antd" (keyValueList CaseRules.LowerFirst props) children
