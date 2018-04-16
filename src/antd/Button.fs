namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props



[<RequireQualifiedAccess>]
module Button =

    [<StringEnum>]
    type ButtonType =
        | Primary
        | Dashed
        | Ghost
        | Danger

    [<StringEnum>]
    type ButtonSize =
        | Small
        | Default
        | Large

    [<StringEnum>]
    type ButtonShape =
        | Circle
        | [<CompiledName("circle-outline")>] CircleOutline
    
    type ButtonProps =
        | Ghost of bool
        | Href of string
        | Target of string
        | Type of ButtonType
        | HtmlType of string
        | Icon of string
        | Shape of ButtonShape
        | Size of ButtonSize
        | Loading of bool
        interface Fable.Helpers.React.Props.IProp


    let primary = Type Primary
    let dashed = Type Dashed
    let ghost = Type ButtonType.Ghost
    let danger = Type Danger

    let inline button (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Button" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline group (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Button.Group" "antd" (keyValueList CaseRules.LowerFirst props) children

   