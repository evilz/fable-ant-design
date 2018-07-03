namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Alert =

    type AlertType = Success | Info | Warning | Error

    type AffixProps =
        | Type of AlertType
        | Closable of bool
        | CloseText of React.ReactNode
        | Message of React.ReactNode
        | Description of React.ReactNode
        | OnClose of React.MouseEventHandler
        | AfterClose of (unit -> unit)
        | ShowIcon of bool
        | IconType of string
        //| style?: React.CSSProperties;
        | PrefixCls of string
        //className?: string;
        | Banner of bool
        interface Fable.Helpers.React.Props.IProp

    let inline alert (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Alert" "antd" (keyValueList CaseRules.LowerFirst props) children
