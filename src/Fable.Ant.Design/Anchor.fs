namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Anchor =

    // Window ??? 
    type AnchorContainer =  HTMLElement | Window

    type AnchorProps  =
        | PrefixCls of string
        // className ofstring
        // style?: React.CSSProperties;
        // children?: React.ReactNode;
        | OffsetTop of int
        | Bounds of int
        | Affix of bool
        | ShowInkInFixed of bool
        | GetContainer of (unit -> AnchorContainer)
        interface Fable.Helpers.React.Props.IProp

    let inline anchor (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Anchor" "antd" (keyValueList CaseRules.LowerFirst props) children

    type AnchorLinkProps  =
        | PrefixCls of string
        | Href of string
        | Title of React.ReactElement // node
        //children?: any;
        interface Fable.Helpers.React.Props.IProp

    let inline link (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Anchor.Link" "antd" (keyValueList CaseRules.LowerFirst props) children
