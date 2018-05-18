namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Input =

    [<StringEnum>]
    type InputSize = Large | Default | Small

    type AbstractInputProps =
        | PrefixCls of string
        //className?: string
        | DefaultValue of obj
        | Value of obj
        | TabIndex of int
        //style?: React.CSSProperties;
        interface Fable.Helpers.React.Props.IProp

    type InputProps  =
        | Placeholder of string
        | Type of string
        | Id of U2<int, string>
        | Name of string
        | Size of InputSize
        | MaxLength of int //?: number | string
        | Disabled of bool
        | ReadOnly of bool
        | AddonBefore of React.ReactNode
        | AddonAfter of React.ReactNode
        | OnPressEnter of React.FormEventHandler
        | OnKeyDown of React.FormEventHandler
        | OnKeyUp of React.FormEventHandler
        | OnChange of React.FormEventHandler  //React.ChangeEventHandler
        | OnClick of React.FormEventHandler
        | OnFocus of React.FormEventHandler
        | OnBlur of React.FormEventHandler
        | AutoComplete of string
        | Prefix of React.ReactNode
        | Suffix of React.ReactNode
        | SpellCheck of bool
        | AutoFocus of bool
        interface Fable.Helpers.React.Props.IProp

    let inline input (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Input" "antd" (keyValueList CaseRules.LowerFirst props) children


    type GroupProps =
        //className?: string;
        | Size of InputSize
        //children?: any;
        //style?: React.CSSProperties;
        | PrefixCls of string
        | Compact of bool
        interface Fable.Helpers.React.Props.IProp
    
    let inline group (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Input.Group" "antd" (keyValueList CaseRules.LowerFirst props) children

    type SearchProps =
        | InputPrefixCls of string
        | OnSearch of (string -> unit)
        | EnterButton of U2<bool, React.ReactNode>
        interface Fable.Helpers.React.Props.IProp

    let inline search (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Input.Search" "antd" (keyValueList CaseRules.LowerFirst props) children

    
    type AutoSizeType = {minRows: int option; maxRows: int option}

    type TextAreaProps =
        | Autosize of U2<bool, AutoSizeType>
        | OnPressEnter of React.FormEventHandler
        interface Fable.Helpers.React.Props.IProp
        

    //type HTMLTextareaProps = React.TextareaHTMLAttributes<HTMLTextAreaElement>;

    let inline textarea (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Input.TextArea" "antd" (keyValueList CaseRules.LowerFirst props) children