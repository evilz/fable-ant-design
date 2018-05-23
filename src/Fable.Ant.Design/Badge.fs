namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Badge =

    [<StringEnum>]
    type BadgeStatus = Success | Processing | Default | Error | Warning

    type BadgeProps =
        | Count of int //U2<int, string> why string ???
        | ShowZero of bool
        | OverflowCount of int
        | Dot of bool
        // style?: React.CSSProperties;
        | PrefixCls of string
        | ScrollNumberPrefixCls of string
        // className?: string;
        | Status of BadgeStatus
        | Text of string
        | Offset of (U2<int,string> * U2<int,string>)
        | Title of string
        interface Fable.Helpers.React.Props.IProp

    let inline badge (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Badge" "antd" (keyValueList CaseRules.LowerFirst props) children
