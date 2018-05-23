namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Avatar =

    [<StringEnum>]
    type AvatarShape = Circle | Square

    [<StringEnum>]
    type AvatarSize = Large | Small | Default

    type AvatarProps =
        | Shape of AvatarShape
        | Size of AvatarSize
        | Src of string
        | Icon of string
        // style?: React.CSSProperties;
        | PrefixCls of string
        //className?: string;
        //children?: any;
        interface Fable.Helpers.React.Props.IProp

    let inline avatar (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Avatar" "antd" (keyValueList CaseRules.LowerFirst props) children
