namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser

[<RequireQualifiedAccess>]
module AutoComplete =

    // Should Be in SELECT !
    type LabeledValue = { key: string; label: React.ReactNode}
    type SelectValue = U6<string, string[], float, float[], LabeledValue, LabeledValue[]>
    
    type DataSourceItemObject = { value: string; text: string; }
    type DataSourceItemType = U2<string,DataSourceItemObject>

    [<StringEnum>]
    type AutoCompleteSize = Default | Large | Small

    type AutoCompleteInputProps = 
        | OnChange of React.FormEventHandler
        | Value of obj
        interface Fable.Helpers.React.Props.IProp


    type ValidInputElement = U3<HTMLInputElement, HTMLTextAreaElement, React.ReactElement>

    type OptionProps = {  
        disabled: bool option;
        value: U2<string,float> option;
        title: string option;
        children: React.ReactNode option;
    }

    type AutoCompleteProps =
        | Value of SelectValue
        | DefaultValue of SelectValue
        | DataSource of DataSourceItemType[]
        | OptionLabelProp of string
        | OnChange of (SelectValue -> unit)
        | OnSelect of (SelectValue -> obj -> unit) //=> any;
        //| Children?: ValidInputElement |
        // React.ReactElement<OptionProps> |
        // Array<React.ReactElement<OptionProps>>;
        // FROM AbstractSelectProps !!
        | PrefixCls of string
        | Size of AutoCompleteSize
        | NotFoundContent of React.ReactNode
        | TransitionName of string
        | ChoiceTransitionName of string
        | ShowSearch of bool
        | AllowClear of bool
        | Disabled of bool
        | DefaultActiveFirstOption of bool
        | DropdownClassName of string
        | DropdownStyle of React.CSSProperties
        | DropdownMenuStyle of React.CSSProperties
        | OnSearch of (string -> unit)
        | FilterOption of U2<bool, (string -> React.Component<OptionProps,obj> -> unit)>
        interface Fable.Helpers.React.Props.IProp

    let inline autoComplete (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "AutoComplete" "antd" (keyValueList CaseRules.LowerFirst props) children
