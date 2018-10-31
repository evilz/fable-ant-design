namespace DataEntry.Cascader

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open DemoCard.Types
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Types = 
    [<StringEnum>]
    type Demo = Basic | DefaultValue | Hover 
    
    type BasicDemo = {
        SelectedOption: Option<string list> 
    }

    type State = {
        Tabs: Map<Demo, DemoCard.Types.Tab>
        BasicState : BasicDemo 
    }

    type Msg =
    | ChangeTabMsg of Demo * DemoCard.Types.Tab
    | BasicOnSelected of string list     
  
open Types 

module State = 

    let init() : State * Cmd<Msg> = 
      { Tabs = Map.ofList [ Basic, DemoCard.Types.Demo ]
        BasicState = { SelectedOption = None } }, Cmd.none

    let update msg state = 
        match msg with 
        | ChangeTabMsg (demo, tab) ->
            let nextState = { state with Tabs = state.Tabs.Add(demo, tab) }
            nextState, Cmd.none 

        | BasicOnSelected values -> 
            let nextState = { state with BasicState = { SelectedOption = Some values } }
            nextState, Cmd.none 

    
module View =

    let render state dispatch = 

        let options : Cascader.CascaderValue list = 
          [ { Value = "fruit"
              Label = "Fruit"
              Children = 
               [ { Value = "apples"
                   Label = "Apples"
                   Children = [] }
                 { Value = "bananas"
                   Label = "Bananas"
                   Children = [] } ] } ]

        let basicCascader = 
            div [ Style [ Padding 20 ] ] [ 
                
                yield Cascader.cascader 
                    [ Cascader.Options options
                      Cascader.Size Cascader.Large
                      Cascader.OnSelected (BasicOnSelected >> dispatch)
                      Cascader.DefaultValues (defaultArg state.BasicState.SelectedOption [ ])
                      Style [ Width 300 ] ] 
                    [ ]

                yield br [ ] 

                match state.BasicState.SelectedOption with 
                | None -> yield h4 [ Style [ MarginTop 20 ] ] [ str "Nothing selected yet" ] 
                | Some values -> yield h4 [ Style [ MarginTop 20 ] ] [ str ("Selected: " + toJson values) ] 
            ]

        let demos = 
          [ Basic, { 
              title = "Basic"; 
              demo = fun () -> basicCascader
              source = importAll "!!highlight-loader?raw=true&lang=fsharp!./Basic.fs" 
              activeTab = DemoCard.Types.Demo  } ] 
          |> Map.ofList 

        let renderDemo demo = 
            DemoCard.View.root 
                { demos.[demo] with activeTab = state.Tabs.[demo] }  
                (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 

        div [ ] [
            yield h1 [ ] [ str "Cascader" ] 
            for demo in [ Basic ] -> renderDemo demo 
        ]