module DataEntry.AutoComplete.AutoCompleteCustomized
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.AntD
open Fable.AntD
open Fable.AntD

let onSelect (value:AutoComplete.SelectValue) _ =
    console.log("onSelect",value)

let dataSource = [
    AutoComplete.DataSourceItem("Burns Bay Road")
    AutoComplete.DataSourceItem("Downing Street") 
    AutoComplete.DataSourceItem("Wall Street")
]

let view onSearch () = 
    AutoComplete.autoComplete [
        AutoComplete.DataSource dataSource
        Style [ Width  200 ]
        AutoComplete.OnSelect onSelect
        AutoComplete.OnSearch onSearch
        Placeholder "input here"
    ] []