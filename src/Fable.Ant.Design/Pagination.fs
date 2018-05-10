namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Pagination =

    [<StringEnum>]
    type PaginationType = 
        | Page 
        | Prev 
        | Next 
        | [<CompiledName("jump-prev")>] JumpPrev 
        | [<CompiledName("jump-next")>] JumpNext
    
    [<StringEnum>]
    type PaginationSize = 
        | Small 
        | Default

    type PaginationProps =
        | Total of int
        | DefaultCurrent of int
        | Current of int
        | DefaultPageSize of int
        | PageSize of int
        | OnChange of (int -> int -> unit)
        | HideOnSinglePage of bool
        | ShowSizeChanger of bool
        | PageSizeOptions of string[]
        | OnShowSizeChange of (int -> int -> unit) /// current -> size -> unit
        | ShowQuickJumper of bool
        | ShowTotal of (int -> int * int -> React.ReactElement) /// (total, [from, to])
        | Size of PaginationSize
        | Simple of bool
        //| Style?: React.CSSProperties;
        | Locale of obj
        //| ClassName?: string;
        | PrefixCls of string
        | SelectPrefixCls of string
        | ItemRender of (int -> PaginationType -> React.ReactElement -> React.ReactElement)
        interface Fable.Helpers.React.Props.IProp

    let inline pagination  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Pagination" "antd" (keyValueList CaseRules.LowerFirst props) children