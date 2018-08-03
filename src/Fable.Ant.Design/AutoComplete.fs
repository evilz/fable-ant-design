namespace Fable.AntD

open System
open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.Import.React

type IDataSourceItem = interface end

type AutoComplete() =   
    /// Show clear button, effective in multiple mode only. Default is `false`
    static member AllowClear(enable: bool) = unbox<IProp> ("allowClear", enable)
    /// get focus when component mounted. Default is `false` 
    static member AllowFocus(enable: bool) = unbox<IProp> ("allowFocus", enable)
    /// backfill selected item the input when using keyboard. Default is `false`
    static member Backfill(enable: bool) = unbox<IProp> ("backfill", enable)
    /// Defines a data source item by value 
    static member DataSourceItem(value: string) = unbox<IDataSourceItem> (value)
    /// Defines a data source item by value and display text
    static member DataSourceItem(value: string, text: string) = 
        let dataSourceItem = obj()
        Common.setProp "value" value dataSourceItem
        Common.setProp "text" text dataSourceItem
        unbox<IDataSourceItem> dataSourceItem 
    /// Specifies the data source for the auto-complete 
    static member DataSource([<ParamArray>] values: string array) = 
        unbox<IProp> ("dataSource", values) 
    /// Specifies the data source for the auto-complete 
    static member DataSource(values: string list) = 
        let valuesAsArray = Array.ofList values
        unbox<IProp> ("dataSource", valuesAsArray) 
    /// Data source for the auto complete as a list of elements
    static member DataSource(elements: ReactElement list) = 
        unbox<IProp>("dataSource", Array.ofList elements)
    
    /// Specifies the data source for the auto-complete 
    static member DataSource(values: IDataSourceItem list) = 
        let valuesAsArray = Seq.toArray values
        unbox<IProp> ("dataSource", valuesAsArray) 
    
    /// Defines whether the autocomplete input is disabled or not.
    static member Disabled(enable: bool) = unbox<IProp> ("disabled", enable)
    
    /// Event fires when a value is selected from the suggestions
    static member OnSelect(f: string -> unit) : IProp = 
        let innerF (input: obj) = 
            if Common.typeofString input  
            then f (unbox<string> input) 
            elif Common.typeofObject input 
            then f (Common.getAs<string> input "value")
            else ()

        unbox<IProp> ("onSelect", innerF)

    /// Whether active first option by default.
    static member DefaultActiveFirstOption(enable: bool) = 
        unbox<IProp>("defaultActiveFirstOption", enable)

[<RequireQualifiedAccess>]
module AutoComplete =

    [<StringEnum>]
    type AutoCompleteSize = Default | Large | Small

    type AutoComplete with 
      static member Size(size: AutoCompleteSize) = unbox<IProp> ("size", size)

    let inline autoComplete (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "AutoComplete" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline option  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "AutoComplete.Option " "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline optGroup  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "AutoComplete.OptGroup " "antd" (keyValueList CaseRules.LowerFirst props) children
