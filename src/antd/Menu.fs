module Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Props

module Menu =

    [<StringEnum>]
    type ButtonType =
        | [<CompiledName("primary")>] Primary
        | [<CompiledName("dashed")>] Dashed
        | [<CompiledName("ghost")>] Ghost
        | [<CompiledName("danger")>] Danger

    [<StringEnum>]
    type MenuMode = 
        | [<CompiledName("vertical")>] Vertical 
        | [<CompiledName("vertical-right ")>] VerticalRight 
        | [<CompiledName("horizontal")>] Horizontal 
        | [<CompiledName("inline")>] Inline

    [<StringEnum>]
    type MenuTheme = 
        | [<CompiledName("light")>] Light 
        | [<CompiledName("dark")>] Dark

    type MenuClickArgs = { item:React.ReactElement; key:string; keyPath:string }
    type MenuProps =
        | DefaultOpenKeys of string[]
        | DefaultSelectedKeys of string[]
        | ForceSubMenuRender of bool
        | InlineCollapsed of bool
        | InlineIndent of int
        | Mode of MenuMode 
        | Multiple of bool
        | OpenKeys of string[]
        | Selectable of bool
        | SelectedKeys of string[]
        //| style style of the root node object	
        | SubMenuCloseDelay of float
        | SubMenuOpenDelay of float
        | Theme of MenuTheme
        | OnClick of (MenuClickArgs -> unit)
        //| OnDeselect callback executed when a menu item is deselected, only supported for multiple mode	function({ item, key, selectedKeys })	-
        //onOpenChange called when open/close sub menu function(openKeys: string[])	noop
        //onSelect callback executed when a menu item is selected function({ item, key, selectedKeys })	none
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
   
    let inline subMenu (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Menu.SubMenu" "antd" (keyValueList CaseRules.LowerFirst props) children
   

