namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Popover =
    
    type PopoverProps  =
        | Title of React.ReactElement
        | Content of React.ReactElement
        interface Fable.Helpers.React.Props.IProp

    let inline popover (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Popover" "antd" (keyValueList CaseRules.LowerFirst props) children