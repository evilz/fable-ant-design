namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Props
open Fable.AST.Fable

module Layout =

    type LayoutProps =
        | HasSider of bool
        interface Fable.Helpers.React.Props.IProp

    [<StringEnum>]
    type SiderBreakpoint =
        | [<CompiledName("xs")>] XS
        | [<CompiledName("sm")>] SM
        | [<CompiledName("md")>] MD
        | [<CompiledName("lg")>] LG
        | [<CompiledName("xl")>] XL
        | [<CompiledName("xxl")>] XXL

    [<StringEnum>]
    type CollapseType = 
        | [<CompiledName("clickTrigger")>] ClickTrigger
        | [<CompiledName("responsive")>] Responsive
        
    // [<Pojo>]
    // type SiderCollapseArgs = { collapsed:bool; ``type``:CollapseType }

    type SiderProps =
        | Breakpoint of SiderBreakpoint
        | Trigger of string //ReactNode
        | Collapsible of bool
        | Collapsed of bool
        | CollapsedWidth of int
        | DefaultCollapsed of bool
        | ReverseArrow of bool
        | Width of int
        | OnCollapse of (bool -> CollapseType -> unit)
        interface Fable.Helpers.React.Props.IProp
    
    let inline layout (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Layout" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline header (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Layout.Header" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline content (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Layout.Content" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline footer  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Layout.Footer" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline sider (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Layout.Sider" "antd" (keyValueList CaseRules.LowerFirst props) children

