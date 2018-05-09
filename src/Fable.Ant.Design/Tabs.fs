namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tabs =

    [<StringEnum>]
    type TabsType = 
        | Line 
        | Card 
        | [<CompiledName("editable-card")>] EditableCard

    [<StringEnum>]
    type TabsPosition = Top | Right | Bottom | Left

    [<StringEnum>]
    type TabsSize = Large | Default | Small


    type TabsAnimation = { inkBar: bool; tabPane: bool; }
   
    type TabsProps  =
        | ActiveKey of string
        | DefaultActiveKey of string
        | HideAdd of bool
        | OnChange of (string -> unit)
        | OnTabClick of (unit -> unit) //  of React.MouseEventHandler ?
        | OnPrevClick of React.MouseEventHandler
        | OnNextClick of React.MouseEventHandler
        | TabBarExtraContent of React.ReactNode
        | TabBarStyle of React.CSSProperties
        | Type of TabsType
        | TabPosition of TabsPosition
        | OnEdit of ((U2<string,React.MouseEvent> * obj) -> unit)
        | Size of TabsSize
        //| Style?: React.CSSProperties;
        | PrefixCls of string
        // className?: string;
        | Animated of  U2<bool,TabsAnimation>
        | TabBarGutter of int
        interface Fable.Helpers.React.Props.IProp

    type TabPaneProps =
        | Tab of U2<React.ReactNode, string>
        //style?: React.CSSProperties;
        | Closable of bool
        //className?: string;
        //disabled?: boolean;
        | ForceRender of bool
        interface Fable.Helpers.React.Props.IProp

    let inline tabs (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Tabs" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline tabPane (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Tabs.TabPane" "antd" (keyValueList CaseRules.LowerFirst props) children