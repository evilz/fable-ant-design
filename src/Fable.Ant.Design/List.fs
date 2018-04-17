namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Props

[<RequireQualifiedAccess>]
module List =

    [<StringEnum>]
    type ColumnCount =  
        | [<CompiledName("1")>] One
        | [<CompiledName("2")>] Two
        | [<CompiledName("3")>] Three
        | [<CompiledName("4")>] Four
        | [<CompiledName("6")>] Six
        | [<CompiledName("8")>] Eight
        | [<CompiledName("12")>] Twelve
        | [<CompiledName("24")>] TwentyFour


    [<StringEnum>]
    type ColumnType = 
        | Gutter 
        | Column
        | Xs 
        | Sm 
        | Md 
        | Lg 
        | Xl 
        | Xxl

    type ListGridType = {
      gutter: int option
      column: ColumnCount option
      xs: ColumnCount option
      sm: ColumnCount option
      md: ColumnCount option
      lg: ColumnCount option
      xl: ColumnCount option
      xxl: ColumnCount option
    }

    [<StringEnum>]
    type ListSize = Small | Default | Large


    type ListProps =
        | Bordered of bool
        | DataSource of obj[]
        | Extra of React.ReactElement
        | Grid of ListGridType
        | ItemLayout of string
        | Loading of bool //U2<bool,SpinProps>; TODO
        | LoadMore of React.ReactElement
        | Pagination of obj
        | PrefixCls of string
        | RowKey of obj
        | RenderItem of  (obj * int -> React.ReactElement)
        | Size of ListSize
        | Split of bool
        | Header of React.ReactElement
        | Footer of React.ReactElement
        | Locale of obj
        interface Fable.Helpers.React.Props.IProp

    
    let inline list (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "List" "antd" (keyValueList CaseRules.LowerFirst props) children


    type ListItemProps =
        | PrefixCls of string
        | Extra of React.ReactElement
        | Actions of React.ReactElement[]
        | Grid of ListGridType
        interface Fable.Helpers.React.Props.IProp

    type ListItemMetaProps = 
        | Avatar of React.ReactElement
        | Description of React.ReactElement
        | PrefixCls of string
        | Title of React.ReactElement
        interface Fable.Helpers.React.Props.IProp



    let inline item (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "List.Item" "antd" (keyValueList CaseRules.LowerFirst props) children
