module DataEntry.AutoComplete.AutoCompleteCustomized
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.AntD

let onSelect (value:AutoComplete.SelectValue) _ =
    console.log("onSelect",value)

let view datasource onSearch () = 
    AutoComplete.autoComplete [
        AutoComplete.DataSource datasource
        Style [ Width  200 ]
        AutoComplete.OnSelect onSelect
        AutoComplete.OnSearch onSearch
        Placeholder "input here"
    ] []