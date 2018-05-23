module DataEntry.AutoComplete.AutoCompleteLookupPatternsCertainCategory
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.AntD

let onSelect (value:AutoComplete.SelectValue) _ =
    console.log("onSelect",value)

let view () = 
    AutoComplete.autoComplete [
        AutoComplete.DataSource [||]
        Style [ Width  200 ]
        AutoComplete.OnSelect onSelect
        Placeholder "input here"
    ] []