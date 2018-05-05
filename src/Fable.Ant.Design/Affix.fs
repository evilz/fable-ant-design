namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Affix =

    type AffixProps =
        | OffsetBottom of int /// Pixels to offset from bottom when calculating position of scroll
        | OffsetTop of int /// Pixels to offset from top when calculating position of scroll
        | Target of (unit -> Browser.HTMLElement) /// specifies the scrollable area dom node
        | OnChange of (bool -> unit) /// Callback for when affix state is changed
        interface Fable.Helpers.React.Props.IProp

    let inline affix (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Affix" "antd" (keyValueList CaseRules.LowerFirst props) children
