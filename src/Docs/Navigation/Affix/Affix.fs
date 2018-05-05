namespace Navigation.Affix

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open DemoCard.Types

module Types =

    

    [<StringEnum>]
    type AffixDemos = Basic
    type Model = Map<AffixDemos,DemoCard.Types.Tab> 

    type Msg =
      | ChangeTabMsg of AffixDemos * DemoCard.Types.Tab

open Types

module State =

    let init () : Model * Cmd<Msg> =
      [Basic]
      |> List.map (fun x->x,DemoCard.Types.Demo) 
      |>  Map.ofList , Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> model.Add(demo, tab), []


module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    
    importAll "./Affix.less" 

    let demos =
        [|
          Basic, { title = "Basic" ; 
            demo = Navigation.Affix.BasicAffix.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BasicAffix.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
        |] |> Map.ofArray

    let renderDemo dispatch (demos:Map<AffixDemos,DemoCardModel>) (model:Model) demo  = 
      DemoCard.View.root {demos.[demo] with activeTab = model.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
          

    let root (model:Model) (dispatch:Msg->unit) =

      let renderDemo = renderDemo dispatch demos model
      div [ ClassName "affix-demo"  ] [
              yield h1 [] [str "Affix"] 
              yield! [ Basic]
                      |> List.map renderDemo
            ]
