module DataEntry.AutoComplete.AutoCompleteNonCaseSensitive
open Fable.Core
open Fable.Import.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.AntD
open Fable.AntD


let view () = 
    AutoComplete.autoComplete [
        AutoComplete.DataSource ["Burns Bay Road"; "Downing Street"; "Wall Street" ]
        Style [ Width  200 ]
        Placeholder "try to type `b`"
        AutoComplete.FilterOption  (U2.Case2(fun inputValue option -> sprintf "%A" option.children |> (fun s -> s.ToUpperInvariant() ) |> fun s -> s.Contains(inputValue.ToUpperInvariant()) )) //option :?> Component))
    ] []