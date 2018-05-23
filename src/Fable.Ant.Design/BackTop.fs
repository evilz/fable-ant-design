namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module BackTop =

    type BackTopTarget =  HTMLElement | Window

    type BackTopProps =
        | VisibilityHeight of int
        | OnClick of React.MouseEventHandler
        | Target of (unit -> BackTopTarget)
        | PrefixCls of string
        // className?: string;
        // style?: React.CSSProperties;
        interface Fable.Helpers.React.Props.IProp

    let inline backTop (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "BackTop" "antd" (keyValueList CaseRules.LowerFirst props) children
