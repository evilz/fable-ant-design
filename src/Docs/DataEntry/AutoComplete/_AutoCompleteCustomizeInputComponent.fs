module DataEntry.AutoComplete.AutoCompleteCustomizeInputComponent

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.Import.React
open Fable.AntD

let onSelect (value:AutoComplete.SelectValue) _ =
    console.log("onSelect",value)

let handleKeyPress (ev:KeyboardEvent) =
    console.log("handleKeyPress", ev)

let view datasource onSearch () = 
    AutoComplete.autoComplete [
        AutoComplete.DataSource datasource
        Style [ Width  200 ]
        AutoComplete.OnSelect onSelect
        AutoComplete.OnSearch onSearch
    ] [
        Input.textarea [
          Placeholder "input here"
          ClassName "custom"
          Style [Height 50 ]
          OnKeyPress handleKeyPress] []
          
    ]