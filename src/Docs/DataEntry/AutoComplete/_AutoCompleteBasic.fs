module DataEntry.AutoComplete.AutoCompleteBasic

open Fable.AntD
open Fable.Helpers.React.Props
open Elmish

type State = {
    TextInput: string
    Suggested: string list  
    Selected : string option
}

type Msg = 
    | UpdateInput of string
    | Selected of string 

let init() = 
    { TextInput = ""
      Suggested = [ ]
      Selected = None }, Cmd.none

let update msg state = 
    match msg with 
    | UpdateInput input -> 
        let concat = String.concat ""
        let suggested = 
          match input with
          | "" -> [ ]
          | _  -> [ input; 
                    concat [input; input]
                    concat [input; input; input] ] 
        
        { state with 
            TextInput = input;
            Suggested = suggested  }, Cmd.none

    | Selected value -> 
        { state with Selected = Some value }, Cmd.none

let view state (dispatch: Msg -> unit) = 
    AutoComplete.autoComplete [
        AutoComplete.DataSource state.Suggested
        Style [ Width  200 ]
        DefaultValue state.TextInput
        AutoComplete.OnSelect (Selected >> dispatch)
        AutoComplete.OnSearch (UpdateInput >> dispatch)
        Placeholder "input here"
    ] []