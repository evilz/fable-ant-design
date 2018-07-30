namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser

[<RequireQualifiedAccess>]
module Cascader =

    type CascaderOptionType = {
        value: string option ;
        label: React.ReactNode option;
        disabled: bool option;
        children: CascaderOptionType[] option;
        //[key: string]: any;
    }

    type FiledNamesType = {
        value: string option;
        label: string option;
        children: string option;
    }

    type FilledFiledNamesType = {
      value: string;
      label: string;
      children: string;
    }

    [<StringEnum>]
    type CascaderExpandTrigger = Click | Hover


    [<StringEnum>]
    type PopupPlacement = BottomLeft | BottomRight | TopLeft | TopRight

    type ShowSearchType = {
      filter: (inputValue: string, path: CascaderOptionType[], names: FilledFiledNamesType) => boolean;
      render?: (
        inputValue: string,
        path: CascaderOptionType[],
        prefixCls: string | undefined,
        names: FilledFiledNamesType,
      ) => React.ReactNode;
      sort?: (a: CascaderOptionType[], b: CascaderOptionType[], inputValue: string, names: FilledFiledNamesType) => number;
      matchInputWidth?: boolean;
    }

    type CascaderProps =
      | Options of CascaderOptionType[]
      | DefaultValue of string[]
      | Value of string[]
      | OnChange of (string[] * CascaderOptionType[] -> unit)
      | DisplayRender of (string[] * CascaderOptionType[] -> React.ReactNode)
      //style?: React.CSSProperties;
      //className?: string;
      | PopupClassName of string
      | PopupPlacement of PopupPlacement
      | Placeholder of string
      | Size of Common.Size
      | Disabled of bool
      | AllowClear of bool
      | ShowSearch of U2<bool,ShowSearchType>
      | NotFoundContent of React.ReactNode
      | LoadData of (CascaderOptionType[] -> unit)
      | ExpandTrigger of CascaderExpandTrigger
      | ChangeOnSelect of bool
      | OnPopupVisibleChange of (bool-> unit)
      | PrefixCls of string
      | InputPrefixCls of string
      | GetPopupContainer of (HTMLElement -> HTMLElement)
      | PopupVisible of bool
      | FiledNames of FiledNamesType

    let inline cascader  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Cascader" "antd" (keyValueList CaseRules.LowerFirst props) children
