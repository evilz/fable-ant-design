namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Props

[<RequireQualifiedAccess>]
module Menu =

    [<StringEnum>]
    type ButtonType =
        | Primary
        | Dashed
        | Ghost
        | Danger

    [<StringEnum>]
    type MenuMode = 
        | Vertical 
        | [<CompiledName("vertical-left")>] VerticalLeft 
        | [<CompiledName("vertical-right")>] VerticalRight 
        | Horizontal 
        | Inline

    [<StringEnum>]
    type MenuTheme = 
        | Light 
        | Dark

    type SelectParam = {
        key: string
        keyPath: string[]
        item: React.ReactElement // any ?
        domEvent: Browser.DocumentEvent // any ?
        selectedKeys: string[]
    }

    type ClickParam  = { 
        key:string
        keyPath:string
        item:React.ReactElement // any ?
        domEvent: Browser.DocumentEvent // any ?
    }


    type MenuProps =
        | Id of string
        | Theme of MenuTheme
        | Mode of MenuMode 
        | Selectable of bool
        | SelectedKeys of string[]
        | DefaultSelectedKeys of string[]
        | OpenKeys of string[]
        | DefaultOpenKeys of string[]
        | OnOpenChange of (string[] -> unit)
        | OnSelect of (SelectParam -> unit)
        | OnDeselect of (SelectParam -> unit)
        | OnClick of (ClickParam -> unit)
        | Style of React.CSSProperties
        | OpenAnimation of U2<string,obj>
        | OpenTransitionName of U2<string,obj>
        | ClassName of string
        | PrefixCls of string
        | Multiple of bool
        | InlineIndent of int
        | InlineCollapsed of bool
        | SubMenuCloseDelay of float
        | SubMenuOpenDelay of float
        | GetPopupContainer of (Browser.Element -> Browser.HTMLElement)
        interface Fable.Helpers.React.Props.IProp

    type TitleClickArg = { key:string ; domEvent:Browser.DocumentEvent }

    type SubMenuProps =
        | Disabled of bool
        | Key of string
        | Title of React.ReactElement // string|ReactNode
        | OnTitleClick of TitleClickArg
        interface Fable.Helpers.React.Props.IProp

    let inline menu (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Menu" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline item (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Menu.Item" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline divider (props: IProp list): React.ReactElement =
       [] |> ofImport "Menu.Divider" "antd" (keyValueList CaseRules.LowerFirst props)
   
    let inline subMenu (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Menu.SubMenu" "antd" (keyValueList CaseRules.LowerFirst props) children
   
    let inline itemGroup (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Menu.ItemGroup" "antd" (keyValueList CaseRules.LowerFirst props) children

