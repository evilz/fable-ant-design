namespace DataEntry.AutoComplete

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Types =

    [<StringEnum>]
    type Demos = Basic | Customized | CustomizeInputComponent | NonCaseSensitive | LookupPatternsCertainCategory | LookupPatternsUncertainCategory


    type BasicModel = {
      TextInput : string
      Suggested : string list 
      Selected : string option  
    }

    type Model = {
        tabs:Map<Demos,DemoCard.Types.Tab>
        Basic: BasicModel
        customizedDataSource: string list
        customizeInputComponentDataSource: string list
        NonCaseSensitiveDataSource: string list
    } 

    type Msg =
      | ChangeTabMsg of Demos * DemoCard.Types.Tab
      | SearchBasicMsg of string
      | SearchCustomizedMsg of string
      | SearchCustomizeInputComponentMsg of string

open Types

module State =
    
    let updateBasicDataSource (value:string) = 
      let concat = String.concat ""
      match value with 
      |  "" -> [ ] 
      | _ -> 
        [value; 
         concat [value; value]
         concat [value; value; value]]

    let updateCustomizedDataSource value = 
      match value with 
      | null | "" -> [ ]
      | s when (s.Contains "@") -> [ ]
      | _ -> 
        ["gmail.com"; "yahoo.com"; "live.com"]   
        |> List.map (fun domain -> value + "@"+ domain )
      

    let initBasic() = {
      TextInput = "";
      Suggested = [ ] 
      Selected = None 
    }
    let init () : Model * Cmd<Msg> =
      
      let tabs = [ Basic; Customized; CustomizeInputComponent; NonCaseSensitive; LookupPatternsCertainCategory]  
                    |> List.map (fun x->x,DemoCard.Types.Demo) 
                    |>  Map.ofList
      { tabs = tabs; Basic = initBasic(); customizedDataSource =  [ ]; customizeInputComponentDataSource = [ ]; NonCaseSensitiveDataSource = [ ] }, Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) ->{model with tabs = model.tabs.Add(demo, tab)}, []
       | SearchBasicMsg value ->
          let suggested = updateBasicDataSource value
          let nextBasicModel = 
            { model.Basic with 
                TextInput = value
                Suggested = suggested }
          { model with Basic = nextBasicModel }, Cmd.none

       | SearchCustomizedMsg value ->{model with customizedDataSource = (updateCustomizedDataSource value) }, []
       | SearchCustomizeInputComponentMsg value ->{model with customizeInputComponentDataSource = (updateBasicDataSource value) }, []


module View =

  open Fable.Helpers.React
  open DemoCard.Types

  let root (model:Model) (dispatch:Msg->unit) =

    let demos =
      [| Basic, { 
          title = "Basic"; 
          demo = fun () ->
            AutoComplete.autoComplete 
              [ AutoComplete.DataSource (model.Basic.Suggested)
                Style [ Width  200 ]
                DefaultValue model.Basic.TextInput
                AutoComplete.OnSearch (SearchBasicMsg >> dispatch)
                Placeholder "input here"] []
          source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_AutoCompleteBasic.fs"; 
          activeTab = DemoCard.Types.Demo 
          }
         //Customized, { 
         // title = "Customized" ; 
         // demo = DataEntry.AutoComplete.AutoCompleteCustomized.view (SearchCustomizedMsg >> dispatch); 
         // source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_AutoCompleteCustomized.fs"; 
         // activeTab = DemoCard.Types.Demo 
         // }
         //CustomizeInputComponent, { 
         // title = "Customize input component" ; 
         // demo = DataEntry.AutoComplete.AutoCompleteCustomizeInputComponent.view (SearchCustomizeInputComponentMsg >> dispatch); 
         // source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_AutoCompleteCustomizeInputComponent.fs"; 
         // activeTab = DemoCard.Types.Demo
         // }
         //NonCaseSensitive, { 
         // title = "Non-case-sensitive AutoComplete" ; 
         // demo = DataEntry.AutoComplete.AutoCompleteNonCaseSensitive.view;
         // source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_AutoCompleteNonCaseSensitive.fs"; 
         // activeTab = DemoCard.Types.Demo
         // }
         //LookupPatternsCertainCategory, { 
         // title = "Lookup-Patterns - Certain Category" ; 
         // demo = DataEntry.AutoComplete.AutoCompleteLookupPatternsCertainCategory.view;
         // source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_AutoCompleteLookupPatternsCertainCategory.fs"; 
         // activeTab = DemoCard.Types.Demo
         // }
        
      |] |> Map.ofArray
  
    let renderDemo demo = 
      DemoCard.View.root {demos.[demo] with activeTab = model.tabs.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 

    div [ ] [
      yield h1 [] [str "AutoComplete"] 
      for demo in [ Basic ] ->  
        renderDemo demo
    ]
