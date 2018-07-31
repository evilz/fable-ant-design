module DataEntry.Cascader

open Fable.AntD
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Elmish 

type State = { 
    SelectedOption: Option<string list>
}


type Msg = UserSelectedOption of string list

let init() = { SelectedOption = None }

let update msg state = 
    match msg with 
    | UserSelectedOption values -> 
        let nextState = { state with SelectedOption = Some values }
        nextState, Cmd.none

let render state dispatch = 
    // the cascader items 
    let items : Cascader.CascaderValue list = 
      [ { Value = "fruit"
          Label = "Fruit"
          Children = [ 
            { Value = "apples"
              Label = "Apples"
              Children = [] }
            { Value = "bananas"
              Label = "Bananas"
              Children = [] }
          ] } ]

    let cascaderInitialValue = defaultArg state.SelectedOption [ ] 
        
    Cascader.cascader 
        [ Cascader.Options items
          Cascader.Size Cascader.Large
          Cascader.OnSelected (UserSelectedOption >> dispatch)
          Cascader.DefaultValues cascaderInitialValue
          Style [ Width 300 ] ] 
        [ ]